using FluentValidation;
using GFT.TechnicalTest.Data.Context;
using GFT.TechnicalTest.Data.Models.Dishes;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;
using GFT.TechnicalTest.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Services
{
    public sealed class MorningOrderService : IOrderService
    {
        #region Constants
        private const string Separator = ", ";
        #endregion

        #region Properties
        private IDataContext Context { get; }
        #endregion

        #region Constructors
        public MorningOrderService(IDataContext context)
        {
            this.Context = context;
        }
        #endregion

        public SelectOrder MakeOrder(CreateOrder createModel)
        {
            if (createModel is null)
            {
                throw new ArgumentNullException(nameof(createModel));
            }

            if (!Period.Morning.Equals(createModel.Period))
            {
                throw new InvalidOperationException(createModel.Period.ToString());
            }

            if (!createModel.Dishes.Any())
            {
                throw new ArgumentException(MessageManager.GetException("MorningOrderService-001"));
            }

            var orders = this.SelectOrders(createModel);

            var data = createModel.Dishes
                                  .OrderBy(id => id)
                                  .GroupBy(key => key, item => item)
                                  .Select(group => BuildOrder(orders, group))
                                  .Select(b => b.ToString())
                                  .ToList();

            var content = string.Join(Separator, data);
            return new SelectOrder { Data = content };
        }

        private IEnumerable<Order> SelectOrders(CreateOrder createModel)
        {
            // Reduces duplicates when checking data on DB
            var filteredIds = createModel.Dishes.ToHashSet();

            return this.Context.Orders
                       .Where(o => o.Period.Equals(Period.Morning))
                       .Where(o => filteredIds.Contains(o.Id))
                       .ToList();
        }

        private static ProcessingOrder BuildOrder(IEnumerable<Order> orders, IGrouping<int, int> idGroup)
        {
            var validGroup = CheckGroup(orders, idGroup);

            return validGroup is null
                ? new ProcessingOrder { Name = "error" }
                : new ProcessingOrder { Name = validGroup.Name, Count = idGroup.Count() };
        }

        private static Order CheckGroup(IEnumerable<Order> orders, IGrouping<int, int> idGroup)
        {
            var groupKey = idGroup.Key;
            var correspondingOrder = orders.FirstOrDefault(o => o.Id.Equals(groupKey));

            if (correspondingOrder is null)
            {
                return null;
            }
            else if (idGroup.Count() > 1 && !correspondingOrder.Multiple.Equals(true))
            {
                return null;
            }
            else
            {
                return correspondingOrder;
            }
        }
    }
}
