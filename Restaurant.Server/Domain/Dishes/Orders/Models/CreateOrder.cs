using Restaurant.Data.Models.Dishes;
using System.Collections.Generic;

namespace Restaurant.Domain.Dishes.Orders.Models
{
    /// <summary>
    /// Creates an Order
    /// </summary>
    /// <example>morning, 1, 2, 3, 3, 3</example>
    public sealed class CreateOrder
    {
        #region Properties
        /// <summary>
        /// <see cref="Period"/> for the dish
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        /// Dishes, as <see cref="int"/>s. Some may be repeated.
        /// </summary>
        public IEnumerable<int> Dishes { get; set; }
        #endregion

        #region Constructors
        public CreateOrder()
        {
            this.Dishes = new List<int>();
        }
        #endregion
    }
}
