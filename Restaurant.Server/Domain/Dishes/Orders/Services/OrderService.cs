using FluentValidation;
using Restaurant.Data.Context;
using Restaurant.Data.Models.Dishes;
using Restaurant.Domain.Dishes.Orders.Models;
using Restaurant.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Domain.Dishes.Orders.Services
{
    /// <summary>
    /// Handles all operations over <see cref="Dish"/> orders
    /// </summary>
    public sealed class OrderService : IOrderService
    {
        #region Constants
        /// <summary>
        /// Separator used at inputs to separate items
        /// </summary>
        private const string Separator = ", ";

        /// <summary>
        /// String used to display errors during processing
        /// </summary>
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

        /// <summary>
        /// Makes an order based on the input
        /// </summary>
        /// <param name="createModel">Order input</param>
        /// <returns>Processed order</returns>
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

            var orders = this.ProcessOrderGroup(createModel);
            var data = ProcessGroups(orders);

            var content = string.Join(Separator, data);
            return new SelectOrder { Data = content };
        }

        private IEnumerable<Dish> SelectOrders(CreateOrder createModel)
        {
            // Reduces duplicates when checking data on DB
            var filteredIds = createModel.Dishes.ToHashSet();

            return this.Context.Dishes
                       .Where(o => o.Period.Equals(createModel.Period))
                       .Where(o => filteredIds.Contains(o.Id))
                       .ToList();
        }

        private IEnumerable<IEnumerable<ProcessingOrder>> ProcessOrderGroup(CreateOrder createModel)
        {
            var orders = this.SelectOrders(createModel);

            var dataGroups = createModel.Dishes
                                        .OrderBy(id => id)
                                        .GroupBy(key => key, item => item);

            var result = new List<IEnumerable<ProcessingOrder>>(dataGroups.Count());

            foreach (var idGroup in dataGroups)
            {
                var groupKey = idGroup.Key;
                var correspondingOrder = orders.FirstOrDefault(o => o.Id.Equals(groupKey));

                var item = new OrderGroup(correspondingOrder, idGroup);

                if (!(item is null))
                {
                    var processed = item.Process();
                    result.Add(processed);
                }
            }

            return result;
        }

        private static IEnumerable<string> ProcessGroups(IEnumerable<IEnumerable<ProcessingOrder>> orderGroups)
        {
            var result = new List<ProcessingOrder>(orderGroups.Count());

            foreach (var group in orderGroups)
            {
                result.AddRange(group);

                if (group.Any(p => ErrorName.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    break;
                }
            }

            return result.Select(b => b.ToString())
                         .ToList();
        }
    }
}
