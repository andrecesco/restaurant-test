using Restaurant.Data.Models.Dishes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Restaurant.Domain.Dishes.Orders.Models
{
    /// <summary>
    /// Groups <see cref="CreateOrder.Dishes"/> and processes the group into <see cref="ProcessingOrder"/>
    /// </summary>
    public sealed class OrderGroup : IGrouping<int, int>, IEquatable<OrderGroup>
    {
        #region Constants
        /// <summary>
        /// String used to display errors during processing
        /// </summary>
        private const string ErrorName = "error";
        #endregion

        #region Properties
        private List<int> Elements { get; set; }

        public int Key { get; private set; }

        public Dish Order { get; }

        public bool AllowMultiple => !(this.Order is null)
                && this.Order.Multiple.Equals(true);
        #endregion

        #region Constructors
        public OrderGroup(Dish order, IGrouping<int, int> grouping)
        {
            if (grouping is null)
            {
                throw new ArgumentNullException(nameof(grouping));
            }

            this.Key = grouping.Key;
            this.Elements = grouping.ToList();

            this.Order = order;
        }
        #endregion

        #region Interface
        public IEnumerator<int> GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Equals([AllowNull] OrderGroup other)
        {
            return !(other is null)
                && this.Key.Equals(other.Key)
                && this.AllowMultiple.Equals(other.AllowMultiple)
                && this.GetEnumerator().Equals(other.GetEnumerator());
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            return !(obj is null)
                && this.GetType().Equals(obj.GetType())
                && this.Equals(obj as OrderGroup);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Elements, this.Key, this.AllowMultiple);
        }
        #endregion

        #region Processing
        /// <summary>
        /// Processes all dishes into order items
        /// Checks for item multiplicity and count
        /// </summary>
        /// <returns><see cref="ProcessingOrder"/> items processed</returns>
        public IEnumerable<ProcessingOrder> Process()
        {
            var result = new List<ProcessingOrder>();

            if (this.Order is null)
            {
                result.Add(new ProcessingOrder { Name = ErrorName });
            }
            else
            {
                result.Add(new ProcessingOrder
                {
                    Name = this.Order.Name,
                    Count = this.Count(),
                    AllowMultiple = this.AllowMultiple
                });

                if (this.Count() > 1 && !this.AllowMultiple)
                {
                    result.Add(new ProcessingOrder { Name = ErrorName });
                }
            }

            return result;
        }
        #endregion
    }
}
