
using Autofac;
using AutoMapper;
using GFT.TechnicalTest.Domain.Dishes.Orders;
using System;

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
        }
    }
}
