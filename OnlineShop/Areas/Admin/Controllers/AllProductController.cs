using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AllProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment environment;
        public AllProductController(ApplicationDbContext db,IHostingEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var data = db.AllProducts.Include(e => e.ProductTypes).Include(e => e.SpecialTag).ToList();
            return View(data);
        }
        //Get Method create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(db.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["SpecialTagId"] = new SelectList(db.SpecialTages.ToList(), "Id", "SpeciaTag");
            return View();
        }
        //Post Method Create
        [HttpPost]
        public async Task<IActionResult> Create(AllProduct AllProduct, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    var name = Path.Combine(environment.WebRootPath+"/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    AllProduct.Image = "Images/" + image.FileName;
                }
                db.AllProducts.Add(AllProduct);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(AllProduct);
            }
        }
    }
}
