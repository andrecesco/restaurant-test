namespace Restaurant.Domain.Dishes.Orders.Models
{
    /// <summary>
    /// Result of a <see cref="CreateOrder"/>
    /// </summary>
    public sealed class SelectOrder
    {
        #region Properties
        /// <summary>
        /// Result of the request.
        /// </summary>
        /// <example>Eggs, toast, coffee(x3)</example>
        public string Data { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.Data.ToLowerInvariant();
        }
        #endregion
    }
}
