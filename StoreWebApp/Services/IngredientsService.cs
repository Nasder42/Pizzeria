using Microsoft.EntityFrameworkCore;
using StoreWebApp.Data;
using StoreWebApp.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Services
{
    public class IngredientsService
    {
        private readonly ApplicationDbContext _context;

        public IngredientsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetSingleIngredient(int? id)
        {
            var ingredient = await _context.Ingredients
                .SingleOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return null;
            }

            return ingredient;
        }

        public async void CreateIngredient(Ingredient ingredient)
        {
            _context.Add(ingredient);
            await _context.SaveChangesAsync();
        }

        public async void EditIngredient(int id, Ingredient ingredient)
        {
            _context.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        public async void DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(m => m.IngredientId == id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }

        public bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
