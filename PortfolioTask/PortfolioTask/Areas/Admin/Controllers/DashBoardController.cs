using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        // GET: DashBoardController
        public ActionResult Index()
        {
            return View();
        }
    }
}
