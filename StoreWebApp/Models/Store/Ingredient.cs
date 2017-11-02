using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models.Store
{
    public class Ingredient
    {
        [Key]
        public int IngredientId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<DishIngredient> DishIngredients
        {
            get;
            set;
        }

        public byte[] Image { get; set; }
    }
}
