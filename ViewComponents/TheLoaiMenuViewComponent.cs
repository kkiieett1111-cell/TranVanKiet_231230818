using Microsoft.AspNetCore.Mvc;
using TranVanKiet_231230818.Models;

namespace TranVanKiet_231230818.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _context;

        public TheLoaiMenuViewComponent(QLNhaSachContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var theLoais = _context.TheLoais.ToList();
            return View(theLoais);
        }
    }
}