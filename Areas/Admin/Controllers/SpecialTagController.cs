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
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _db;
        private SpecialTags specialtags;
        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult TagList()
        {
            return View(_db.Specialtags.ToList());
        }
    }
}