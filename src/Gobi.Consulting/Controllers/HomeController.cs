using Microsoft.AspNetCore.Mvc;

namespace Gobi.Consulting.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index() => View();
	}
}
