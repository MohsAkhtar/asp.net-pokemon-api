using System.Net;
using System.Web.Mvc;

namespace Pokemon_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create request to API
            WebRequest request = WebRequest.Create("http://pokeapi.co/api/v2/pokemon/10");
            // Send that request off
            WebResponse response = request.GetResponse();
            return View();
        }

    }
}