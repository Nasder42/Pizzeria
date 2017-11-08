using Microsoft.EntityFrameworkCore;
using StoreWebApp.Data;
using StoreWebApp.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Services
{
    public class DishesService
    {
        private readonly ApplicationDbContext _context;

        public DishesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesWithCategories()
        {
            var applicationDbContext = _context.Dishes.Include(d => d.Category);
            return await applicationDbContext.ToListAsync();
        }

        public async Task<Dish> GetSingleDish(int? id)
        {
            var dish = await _context.Dishes
                .Include(d => d.Category)
                .SingleOrDefaultAsync(m => m.DishId == id);

            return dish;
        }

        public async void CreateDish(Dish dish)
        {
            _context.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async void EditDish(Dish dish)
        {
            _context.Update(dish);
            await _context.SaveChangesAsync();
        }

        public async void DeleteDish(int? id)
        {
            var dish = await _context.Dishes.SingleOrDefaultAsync(m => m.DishId == id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }
    }
}
