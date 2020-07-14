namespace GFT.TechnicalTest.Data.Models.Dishes
{
    public sealed class Order
    {
        #region Properties
        public string Id { get; set; }

        public DishType DishType { get; set; }

        public Period Period { get; set; }

        public bool? Multiple { get; set; }

        public string Name { get; set; }
        #endregion
    }
}
