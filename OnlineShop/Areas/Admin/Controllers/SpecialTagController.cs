using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SpecialTagController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            var data = _db.SpecialTages.ToList();
            return View(data);
        }
        // Create in Get
        public IActionResult Create()
        {
            return View();
        }
        //Create in Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag model)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTages.Add(model);
                await _db.SaveChangesAsync();   
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        //Post Edit
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var specialtag = _db.SpecialTages.FirstOrDefault(e=>e.Id == id);
            if (specialtag == null)
            {
                return NotFound();
            }
            return View(specialtag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTag model)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTages.Update(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
        //Get Method Special tag Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialtag = _db.SpecialTages.FirstOrDefault(e => e.Id == id);
            if (specialtag == null)
            {
                return NotFound();
            }
            return View(specialtag);
        }
        //Post Method Details 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTag model)
        {
            return RedirectToAction(nameof(Index));
        }


        //Delete Product Types
        public IActionResult Delete(int? id, SpecialTag model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != model.Id)
            {

            }
            var specialtag = _db.SpecialTages.FirstOrDefault(e => e.Id == id);
            if (specialtag == null)
            {
                return NotFound();
            }
            return View(specialtag);
        }

        //Post Method Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SpecialTag model)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTages.Remove(model);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product deleted";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}
