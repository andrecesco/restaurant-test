using System.Text;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Models
{
    public sealed class ProcessingOrder
    {
        #region Properties
        public string Name { get; set; }

        public int Count { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            var result = new StringBuilder(this.Name);

            if (this.Count > 1)
            {
                result.Append($"(x{this.Count})");
            }

            return result.ToString().ToLowerInvariant();
        }
        #endregion
    }
}
