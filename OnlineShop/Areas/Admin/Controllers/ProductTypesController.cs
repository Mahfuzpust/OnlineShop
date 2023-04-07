using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.ProductTypes.ToList();
            return View(data);
        }

        //Get Method Product Types Create
        public IActionResult Create()
        {
            return View();
        }
        //Post Method Product Types
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(model);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Product save successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        //Get Method Product Types Edit
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var ProductType = _db.ProductTypes.FirstOrDefault(e=> e.Id == id); 
            if (ProductType==null)
            {
                return NotFound();
            }
            return View(ProductType);
        }
        //Post Method Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Update(model);
                await _db.SaveChangesAsync();
                TempData["update"] = "product updated";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        //Get Method Product Types Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ProductType = _db.ProductTypes.FirstOrDefault(e => e.Id == id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }
        //Post Method Details 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(ProductTypes model)
        {
            return RedirectToAction(nameof(Index));
        }


        //Delete Product Types
        public IActionResult Delete(int? id, ProductTypes model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id != model.Id)
            {

            }
            var ProductType = _db.ProductTypes.FirstOrDefault(e => e.Id == id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Post Method Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductTypes model)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Remove(model);
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
