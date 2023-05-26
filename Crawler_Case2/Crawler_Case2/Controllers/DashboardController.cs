using Microsoft.AspNetCore.Mvc;

namespace Crawler_Case2.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
