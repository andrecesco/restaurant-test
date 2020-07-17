
using Autofac;
using GFT.TechnicalTest.Domain.Dishes.Orders;

namespace GFT.TechnicalTest.Domain
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
