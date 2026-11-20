using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranVanKiet_231230818.Models;

namespace TranVanKiet_231230818.Controllers
{
    public class SachController : Controller
    {
        private readonly QLNhaSachContext _context;

        public SachController(QLNhaSachContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais.ToList(), "MaTl", "TenTl");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaTl,TenSach,Gia,Anh")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
             
                return RedirectToAction("Index", "Home");
            }

            ViewBag.MaTl = new SelectList(_context.TheLoais.ToList(), "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}