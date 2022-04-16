using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Web.Manager;
using Web.Models;

namespace Web.Controllers
{
    public class GlobaltekController : Controller
    {
        private readonly ILogger<GlobaltekController> _logger;
        private BillManager billManager;

        public GlobaltekController(ILogger<GlobaltekController> logger)
        {
            _logger = logger;
            billManager = new BillManager();
        }

        public IActionResult Login(string loginError)
        {
            ControllerContext.HttpContext.Response.Cookies.Delete("token");
            if (!string.IsNullOrEmpty(loginError)) ViewBag.LoginError = loginError;
            return View();
        }

        [HttpPost]
        public IActionResult Home(LoginRequest login = null, int idCategory = 0)
        {
            var session = ControllerContext.HttpContext.Request.Cookies.Where(x => x.Key == "token").FirstOrDefault().Value;

            var token = string.Empty;
            if (string.IsNullOrEmpty(session))
            {
                token = billManager.VefirySession(login);
                if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Globaltek", routeValues: new { loginError = "Wrong email or password" });
                ControllerContext.HttpContext.Response.Cookies.Append("token", token);
            }

            var listProduct = billManager.GetAllBill(token);

            return View(listProduct);
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}