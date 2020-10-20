using System;
using System.Collections.Generic;

namespace InventoryAPI.Models.FoodModels
{
    public partial class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Price { get; set; }
    }
}
