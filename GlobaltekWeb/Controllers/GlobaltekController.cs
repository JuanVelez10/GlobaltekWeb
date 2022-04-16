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
        private readonly IPersonServices personServices;

        public GlobaltekController(ILogger<GlobaltekController> logger, IBillServices billServices, IPersonServices personServices)
        {
            _logger = logger;
            this.billServices = billServices;
            this.personServices = personServices;
        }

        public IActionResult Login(string loginError)
        {
            ControllerContext.HttpContext.Response.Cookies.Delete("token");
            if (!string.IsNullOrEmpty(loginError)) ViewBag.LoginError = loginError;
            return View();
        }

        [HttpPost]
        public IActionResult Home(LoginRequest login = null)
        {
            var session = ControllerContext.HttpContext.Request.Cookies.Where(x => x.Key == "token").FirstOrDefault().Value;

            if (string.IsNullOrEmpty(session))
            {
                session = personServices.VefirySession(login);
                if (string.IsNullOrEmpty(session)) return RedirectToAction("Login", "Globaltek", routeValues: new { loginError = "Wrong email or password" });
                ControllerContext.HttpContext.Response.Cookies.Append("token", session);
            }

            var listProduct = billServices.GetAllBill(session);

            return View(listProduct);
        }


        public IActionResult Details(Guid? id)
        {
            var session = ControllerContext.HttpContext.Request.Cookies.Where(x => x.Key == "token").FirstOrDefault().Value;
            if (string.IsNullOrEmpty(session)) return RedirectToAction("Login", "Globaltek", routeValues: new { loginError = "You are not logged in" });
            var billInfo = billServices.GetBillInfo(session, id);
            return View(billInfo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}