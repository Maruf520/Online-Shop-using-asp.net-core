using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _db;
        private ProductTypes productTypes;

        public ProductTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList());
        }

        // Create get Action Method
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                _db.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(productTypes);
        }


    }
}
