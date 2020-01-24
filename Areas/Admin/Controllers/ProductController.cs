using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EO.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    //private ApplicationDbContext _db;
    [Area("Admin")]


    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
  
        public ProductController(ApplicationDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_db.Products.Include(p=>p.ProductTypes).Include(c => c.ProductTypes).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create (Products products)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);


        }


    }
}