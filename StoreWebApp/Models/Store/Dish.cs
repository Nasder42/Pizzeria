using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreWebApp.Models.Store
{
    public class Dish
    {
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public List<DishIngredient> DishIngredients { get; set; }
        public List<CartDish> CartDishes { get; set; }
        public byte[] Image { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
