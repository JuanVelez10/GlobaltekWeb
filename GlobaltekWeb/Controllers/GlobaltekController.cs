using Application.Interfaces;
using Domain.References;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Web.Controllers
{
    public class GlobaltekController : Controller
    {
        private readonly ILogger<GlobaltekController> _logger;
        private readonly IBillServices billServices;

        public GlobaltekController(ILogger<GlobaltekController> logger, IBillServices billServices)
        {
            _logger = logger;
            this.billServices = billServices;
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
                token = billServices.VefirySession(login);
                if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Globaltek", routeValues: new { loginError = "Wrong email or password" });
                ControllerContext.HttpContext.Response.Cookies.Append("token", token);
            }

            var listProduct = billServices.GetAllBill(token);

            return View(listProduct);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}