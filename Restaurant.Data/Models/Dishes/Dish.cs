﻿namespace Restaurant.Data.Models.Dishes
{
    public sealed class Dish
    {
        #region Properties
        public int Id { get; set; }

        public DishType DishType { get; set; }

        public Period Period { get; set; }

        public bool? Multiple { get; set; }

        public string Name { get; set; }
        #endregion
    }
}
