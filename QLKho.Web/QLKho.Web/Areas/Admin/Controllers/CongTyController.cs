using Microsoft.AspNetCore.Mvc;

namespace QLKho.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CongTyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
