using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreWebApp.Data;
using StoreWebApp.Models.Store;
using Microsoft.AspNetCore.Authorization;
using StoreWebApp.Services;
using System.Net;

namespace StoreWebApp.Controllers
{
    public class DishesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly DishesService _dishesService;
        private readonly CategoriesService _categoriesService;

        public DishesController(DishesService dishesService, CategoriesService categoriesService)
        {
            //_context = context;
            _dishesService = dishesService;
            _categoriesService = categoriesService;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _dishesService.GetAllDishesWithCategories();
            return View(await applicationDbContext);
        }

        //Klart

        // GET: Dishes/Details/5
        public async  Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _dishesService.GetSingleDish(id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: Dishes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoriesService.GetAllCategories(), "CategoryId", "Name");
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([Bind("DishId,Name,Price,ImageURL,CategoryId")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _dishesService.CreateDish(dish);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoriesService.GetAllCategories(), "CategoryId", "Name", dish.CategoryId);
            return View(dish);
        }

        // GET: Dishes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _dishesService.GetSingleDish(id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoriesService.GetAllCategories(), "CategoryId", "Name", dish.CategoryId);
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [Bind("DishId,Name,Price,ImageURL,CategoryId")] Dish dish)
        {
            if (id != dish.DishId)
            {
                return NotFound();
            }

            //Validate image input and add it to dish.
            if (dish.ImageURL != null)
            {
                var webClient = new WebClient();
                var imageBytes = webClient.DownloadData(dish.ImageURL);
                dish.Image = imageBytes;
                
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dishesService.EditDish(dish);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dishesService.DishExists(dish.DishId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoriesService.GetAllCategories(), "CategoryId", "Name", dish.CategoryId);
            return View(dish);
        }

        // GET: Dishes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = _dishesService.GetSingleDish(id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _dishesService.DeleteDish(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
