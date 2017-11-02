using StoreWebApp.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.ViewModels
{
    public class StoreViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Category> Categories { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
