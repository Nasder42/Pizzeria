using Microsoft.EntityFrameworkCore;
using StoreWebApp.Data;
using StoreWebApp.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Services
{
    public class CategoriesService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetSingleCategoryAsync(int? id)
        {
            var category = await _context.Categories
                .SingleOrDefaultAsync(m => m.CategoryId == id);

            return category;
        }

        public async void CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async void EditCategory(int id, Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }

        public async void DeleteCategory(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoryId == id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
