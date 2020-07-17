using Autofac;
using FluentValidation;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using GFT.TechnicalTest.Domain.Dishes.Orders.Services;
using GFT.TechnicalTest.Domain.Dishes.Orders.Validations;

namespace GFT.TechnicalTest.Domain.Dishes.Orders
{
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
