using Autofac;
using FluentValidation;
using Restaurant.Domain.Dishes.Orders.Models;
using Restaurant.Domain.Dishes.Orders.Services;
using Restaurant.Domain.Dishes.Orders.Validations;

namespace Restaurant.Domain.Dishes.Orders
{
    /// <summary>
    /// Registers all components necessary to have the Order Module working
    /// <see cref="Module"/>
    /// </summary>
    public sealed class OrdersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterType<OrderService>()
                .As<IOrderService>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CreateOrderValidator>()
                .As<IValidator<CreateOrder>>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }
    }
}
