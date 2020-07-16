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
    public sealed class OrderService : IOrderService
    {
        #region Constants
        private const string Separator = ", ";
        private const string ErrorName = "error";
        #endregion

        #region Properties
        private IDataContext Context { get; }
        #endregion

        #region Constructors
        public OrderService(IDataContext context)
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

            if (!createModel.Dishes.Any())
            {
                throw new ArgumentException(MessageManager.GetException("OrderService-001"));
            }

            var orders = this.SelectOrders(createModel);

            var dataGroups = createModel.Dishes
                                        .OrderBy(id => id)
                                        .GroupBy(key => key, item => item)
                                        .Select(g => BuildGroup(orders, g));

            var data = ProcessGroups(dataGroups).Select(b => b.ToString())
                                                .ToList();

            var content = string.Join(Separator, data);
            return new SelectOrder { Data = content };
        }

        private IEnumerable<Order> SelectOrders(CreateOrder createModel)
        {
            // Reduces duplicates when checking data on DB
            var filteredIds = createModel.Dishes.ToHashSet();

            return this.Context.Orders
                       .Where(o => o.Period.Equals(createModel.Period))
                       .Where(o => filteredIds.Contains(o.Id))
                       .ToList();
        }

        private static OrderGroup BuildGroup(IEnumerable<Order> orders, IGrouping<int, int> idGroup)
        {
            var groupKey = idGroup.Key;
            var correspondingOrder = orders.FirstOrDefault(o => o.Id.Equals(groupKey));

            return new OrderGroup(correspondingOrder, idGroup);
        }

        private static IEnumerable<ProcessingOrder> ProcessGroups(IEnumerable<OrderGroup> orderGroups)
        {
            var result = new List<ProcessingOrder>(orderGroups.Count());

            foreach (var orderGroup in orderGroups)
            {
                var processed = orderGroup.Process();

                if (processed is null)
                {
                    break;
                }

                result.AddRange(processed);

                if (processed.Any(p => p.Name.Equals(ErrorName)))
                {
                    break;
                }
            }

            return result;
        }
    }
}
