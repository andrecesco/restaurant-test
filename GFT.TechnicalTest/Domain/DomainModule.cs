
using Autofac;
using AutoMapper;
using GFT.TechnicalTest.Domain.Dishes.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GFT.TechnicalTest.Domain
{
    public sealed class DomainModule : Autofac.Module
    {
        #region Constants
        private static readonly Type[] OpenTypes = new[] {
            typeof(IValueResolver<,,>),
            typeof(IMemberValueResolver<,,,>),
            typeof(ITypeConverter<,>),
            typeof(IValueConverter<,>),
            typeof(IMappingAction<,>)
        };
        #endregion

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<OrdersModule>();

            RegisterMappers(builder);
        }

        #region Mappers
        private static void RegisterMappers(ContainerBuilder builder)
        {
            var assembliesToScan = new Assembly[] {
                Assembly.GetExecutingAssembly()
            };

            var allTypes = assembliesToScan
                          .Where(a => !a.IsDynamic)
                          .Where(a => a.GetName().Name != nameof(AutoMapper))
                          .SelectMany(a => a.DefinedTypes)
                          .Where(t => t.IsClass)
                          .Where(t => !t.IsAbstract)
                          .Distinct()
                          .Select(t => t.AsType())
                          .ToArray();

            var types = OpenTypes.SelectMany(openType => allTypes.Where(t => ImplementsGenericInterface(t, openType)));

            foreach (var type in types)
            {
                builder.RegisterType(type)
                       .InstancePerLifetimeScope();
            }

            builder.Register<AutoMapper.IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(assembliesToScan))).SingleInstance();

            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<AutoMapper.IConfigurationProvider>(), ctx.Resolve)).InstancePerLifetimeScope();
        }

        private static bool ImplementsGenericInterface(Type type, Type interfaceType)
        {
            return IsGenericType(type, interfaceType)
                || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => IsGenericType(@interface, interfaceType));
        }

        private static bool IsGenericType(Type type, Type genericType)
        {
            return type.GetTypeInfo().IsGenericType
                && type.GetGenericTypeDefinition().Equals(genericType);
        }
        #endregion
    }
}
