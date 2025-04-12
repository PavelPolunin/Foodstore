using Foodstore.Data;
using Foodstore.Models;
using FoodStoreApp1_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApp1_2025.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManufacturersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Manufacturers> ManufacturersList = _db.Manufacturers;
            // Возвращаем загруженный список в представление
            return View(ManufacturersList);
        }

        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturers cat)
        {
            if (ModelState.IsValid)
            {
                _db.Manufacturers.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);

        }


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturers.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturers cat)
        {
            if (ModelState.IsValid)
            {
                _db.Manufacturers.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturers.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.Manufacturers.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Manufacturers.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
