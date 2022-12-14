using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Directs to index
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
