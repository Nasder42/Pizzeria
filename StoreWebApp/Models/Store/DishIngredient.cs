using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models.Store
{
    public class DishIngredient
    {
        [Key, ForeignKey("Dish")]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        [Key, ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
