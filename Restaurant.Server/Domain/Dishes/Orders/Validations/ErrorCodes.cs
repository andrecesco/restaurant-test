namespace Restaurant.Domain.Dishes.Orders.Validations
{
    internal static class ErrorCodes
    {
        #region Basic Info
        /// <summary>
        /// Error code for <see cref="Orders.Models.CreateOrder.Period"/> validations
        /// </summary>
        public const string Period = "Order-001";

        /// <summary>
        /// Error code for <see cref="Orders.Models.CreateOrder.Dishes"/> validations
        /// </summary>
        public const string Dishes = "Order-002";
        #endregion
    }
}
