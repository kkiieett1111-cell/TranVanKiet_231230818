using Microsoft.AspNetCore.Mvc;
using TranVanKiet_231230818.Models;

namespace TranVanKiet_231230818.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _context;

        public HomeController(QLNhaSachContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var dsSach = _context.Saches
                .Where(s => s.Gia != null && s.Gia >= 100)
                .ToList();

            ViewBag.TieuDe = "TRẦN VĂN KIỆT";
            return View(dsSach);
        }

   
        [HttpGet]
        public IActionResult LocSachTheoTheLoai(int maTL)
        {
            List<Sach> dsSach;

            if (maTL == 0)
            {
               
                dsSach = _context.Saches
                    .Where(s => s.Gia != null && s.Gia >= 100)
                    .ToList();
                ViewBag.TieuDe = "TRẦN VĂN KIỆT";
            }
            else
            {
              
                var theLoai = _context.TheLoais.Find(maTL);
                dsSach = _context.Saches
                    .Where(s => s.MaTl == maTL)
                    .ToList();
                ViewBag.TieuDe = theLoai != null ? theLoai.TenTl.ToUpper() : "DANH SÁCH SÁCH";
            }

            return PartialView("_SachListPartial", dsSach);
        }
    }
}