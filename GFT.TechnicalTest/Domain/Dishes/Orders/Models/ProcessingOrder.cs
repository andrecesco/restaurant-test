using System.Text;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Models
{
    public sealed class ProcessingOrder
    {
        #region Properties
        public string Name { get; set; }

        public int Count { get; set; }

        public bool AllowMultiple { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            var result = new StringBuilder(this.Name);

            if (this.Count > 1 && this.AllowMultiple)
            {
                result.Append($"(x{this.Count})");
            }

            return result.ToString().ToLowerInvariant();
        }
        #endregion
    }
}
