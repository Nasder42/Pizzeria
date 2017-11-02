using Microsoft.AspNetCore.Identity;
using StoreWebApp.Models;
using StoreWebApp.Models.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoreWebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var adminRole = new IdentityRole { Name = "Admin" };
            var customerRole = new IdentityRole { Name = "Customer" };

            var roleResult = roleManager.CreateAsync(adminRole).Result;
            roleResult = roleManager.CreateAsync(customerRole).Result;


            var customerUser = new ApplicationUser();
            customerUser.UserName = "customer@test.com";
            customerUser.Email = "customer@test.com";
            var customerUserResult = userManager.CreateAsync(customerUser, "Pa$$w0rd").Result;


            var adminUser = new ApplicationUser();
            adminUser.UserName = "admin@test.com";
            adminUser.Email = "admin@test.com";
            var adminUserResult = userManager.CreateAsync(adminUser, "Pa$$w0rd").Result;

            userManager.AddToRoleAsync(customerUser, "Customer");
            userManager.AddToRoleAsync(adminUser, "Admin");


            if (context.Dishes.ToList().Count == 0)
            {
                // Add Categories
                var category = new Category { Name = "Pizza" };
                context.Categories.Add(category);
                //context.Categories.Add(new Category { Name = "Pizza" });
                context.Categories.Add(new Category { Name = "Assian" });
                context.Categories.Add(new Category { Name = "Greek" });
                context.Categories.Add(new Category { Name = "Italian" });
                context.Categories.Add(new Category { Name = "Thai" });
                context.Categories.Add(new Category { Name = "Sushi" });


                //Add Ingredients
                var cheese = new Ingredient { Name = "cheese" };
                var tomatoes = new Ingredient { Name = "tomatoes" };
                var ham = new Ingredient { Name = "ham" };
                var anchovies = new Ingredient { Name = "anchovies" };
                var mozzarella = new Ingredient { Name = "mozzarella" };
                var garlic = new Ingredient { Name = "garlic" };
                var oregano = new Ingredient { Name = "oregano" };
                var olives = new Ingredient { Name = "olives" };
                var boiledEgg = new Ingredient { Name = "half of a boiled egg" };
                var mushrooms = new Ingredient { Name = "mushrooms" };
                var prosciutto = new Ingredient { Name = "prosciutto" };
                var peas = new Ingredient { Name = "peas" };
                var shellfish = new Ingredient { Name = "shellfish" };
                var parmiianoReggiano = new Ingredient { Name = "parmiiano-reggiano" };
                var ricotta = new Ingredient { Name = "ricotta" };
                var gorgonzola = new Ingredient { Name = "gorgonzola" };
                var sausages = new Ingredient { Name = "sausages" };
                var shrimp = new Ingredient { Name = "shrimp" };
                var cherryTomatoes = new Ingredient { Name = "cherry tomatoes" };
                var spinach = new Ingredient { Name = "spinach" };
                var onnion = new Ingredient { Name = "onnion" };



                //Add Pizzas
                string directoryPath = Environment.CurrentDirectory + "/Images/Dishes/";
                //string directoryPath = Directory.GetCurrentDirectory();
                //string directoryPath = "/Users/Sander/Projects/2018/Asp2/Projects/Functional/PizzeriaOnline-AlexanderBranch/Data/Images/Food/Dishes/";
                string imagePath;

                var pizza = new Dish { Name = "Margherita", Price = 75 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = tomatoes });
                imagePath = string.Concat(directoryPath, "Margherita.png");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Alla Napoletana (Napoli)", Price = 79 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = anchovies });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = tomatoes });
                imagePath = string.Concat(directoryPath, "AllaNapoletana.jpg");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Marinara", Price = 79 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = garlic });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = anchovies });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = oregano });
                imagePath = string.Concat(directoryPath, "Marinara.jpg");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Pugliese", Price = 85 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = olives });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = tomatoes });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = onnion });
                imagePath = string.Concat(directoryPath, "Pugliese.jpg");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Capricciosa", Price = 90 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = olives });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = boiledEgg });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = prosciutto });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mushrooms });
                imagePath = string.Concat(directoryPath, "Capricciosa.jpg");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Veronese", Price = 85 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = prosciutto });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mushrooms });
                imagePath = string.Concat(directoryPath, "Veronese.jpg");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Quattro stagioni", Price = 105 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = tomatoes });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = boiledEgg });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mushrooms });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = olives });
                imagePath = string.Concat(directoryPath, "Margherita.png");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Ai Quattro Formagi", Price = 95 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = parmiianoReggiano });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = ricotta });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = gorgonzola });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                imagePath = string.Concat(directoryPath, "QuattroStagioni.png");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                pizza = new Dish { Name = "Ai Funghi e Salsicce", Price = 95 };
                pizza.DishIngredients = new List<DishIngredient>();
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = sausages });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mozzarella });
                pizza.DishIngredients.Add(new DishIngredient { Dish = pizza, Ingredient = mushrooms });
                imagePath = string.Concat(directoryPath, "AiFunghiSalsicce.png");
                pizza.Image = ImageToBinary(imagePath);
                pizza.Category = category;
                context.Dishes.Add(pizza);

                context.SaveChanges();
            }
        }


        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fS = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
            return b;
        }
    }
}
