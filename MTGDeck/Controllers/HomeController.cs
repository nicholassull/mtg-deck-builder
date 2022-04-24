using Microsoft.AspNetCore.Mvc;

namespace SweetandSavory.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}