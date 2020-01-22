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

        public bool False { get; private set; }

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
            Console.WriteLine("Print hoise get request");
            return View();

        }
        //Create Post Action Method
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProductTypes productTypes)
        {
            Console.WriteLine("MARUF");

         
                Console.WriteLine(" post request printed");

                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));

            
            return View(productTypes);
        }

        // Edit get Action Method
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType==null)
            {
                return NotFound();
            }
            Console.WriteLine("Print hoise get request");
            return View(productType);

        }
        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ?id,ProductTypes productTypes)
        {
            Console.WriteLine("MARUF");

            if (ModelState.IsValid)
            {
                Console.WriteLine(productTypes);
                Console.WriteLine(" post request printed");
                Console.WriteLine("MARUFfsfsd");
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        // Edit get Action Method
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            Console.WriteLine("Print hoise get request");
            
            return View(productType);

        }
        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(ProductTypes productTypes)
        {
                 Console.WriteLine("MARUF");
            TempData["save"] = "Item created successfully";
            return RedirectToAction(nameof(Index));
  
        }
        // Create get Action Method
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Console.WriteLine("Print hoise get request");
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            Console.WriteLine("Print hoise get request");
            return View(productType);

        }
        //Create Post Action Method
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            Console.WriteLine("MARUF");

            if (id == null)
            {
               return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();
            }


                Console.WriteLine(" Delete hoise");
                
                var productType = _db.ProductTypes.Find(id);
                _db.ProductTypes.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            
            
        }



    }
}
