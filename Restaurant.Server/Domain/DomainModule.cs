
using Autofac;
using Restaurant.Domain.Dishes.Orders;

namespace Restaurant.Domain
{
    public sealed class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<OrdersModule>();
        }
    }
}
