﻿using Application.Interfaces;
using Domain.Dtos;
using Domain.References;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static Domain.Enums.Enums;

namespace Web.Controllers
{
    public class GlobaltekController : Controller
    {
        private readonly ILogger<GlobaltekController> _logger;
        private readonly IBillServices billServices;
        private readonly IPersonServices personServices;
        private readonly IDiscountServices discountServices;
        private readonly ITaxServices taxServices;
        private readonly IProductServices productServices;

        public GlobaltekController(ILogger<GlobaltekController> logger, IBillServices billServices, IPersonServices personServices,
            IDiscountServices discountServices, ITaxServices taxServices, IProductServices productServices)
        {
            _logger = logger;
            this.billServices = billServices;
            this.personServices = personServices;
            this.discountServices = discountServices;
            this.taxServices = taxServices;
            this.productServices = productServices;
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
            var session = Session();

            if (string.IsNullOrEmpty(session))
            {
                var person = personServices.VefirySession(login);
                if (person == null) return ReturnLogin("Wrong email or password");
                if (person.Data == null) return ReturnLogin(person.Message);
                session = person.Data.Token;
                if (string.IsNullOrEmpty(session)) return ReturnLogin("Wrong email or password");
                ControllerContext.HttpContext.Response.Cookies.Append("token", session);
            }

            var listProduct = billServices.GetAllBill(session);

            return View(listProduct);
        }

        public IActionResult ReturnLogin(string message)
        {
            return RedirectToAction("Login", "Globaltek", routeValues: new { loginError = message });
        }

        public IActionResult Details(Guid? id)
        {
            var session = Session();
            if (string.IsNullOrEmpty(session)) return ReturnLogin("You are not logged in");
            var billInfo = billServices.GetBillInfo(session, id);
            return View(billInfo);
        }

        [HttpPost]
        public IActionResult SaveInfo([FromBody] BillInfo BillInfo)
        {

            return View();
        }

        public IActionResult Save(Guid? id,bool update)
        {
            var session = Session();
            if (string.IsNullOrEmpty(session)) return ReturnLogin("You are not logged in");

            var billInfo = new BillInfo();
            billInfo.Date = DateTime.Now;

            if (update)
            {
                ViewBag.save = "Edit Invoice";
                ViewBag.hide = "";
                billInfo = billServices.GetBillInfo(session, id);
            }
            else
            {
                ViewBag.save = "Create Invoice";
                ViewBag.hide = "Hide";
            }

            ViewBag.listPaymentType = ListPaymentType();
            ViewBag.listPerson = new SelectList(personServices.GetAll(session),"Id", "Name");
            ViewBag.listTaxes = new SelectList(taxServices.GetAll(session), "Id", "Name");
            ViewBag.listDiscounts = new SelectList(discountServices.GetAll(session), "Id", "Name");
            ViewBag.listproducts = new SelectList(productServices.GetAll(session), "Id", "Name");
            ViewBag.listAmounts = ListAmount();

            return View(billInfo);
        }

        public IActionResult Delete(Guid? id)
        {
            var session = Session();
            if (string.IsNullOrEmpty(session)) return ReturnLogin("You are not logged in");
            var billInfo = billServices.GetBillInfo(session, id);
            return View(billInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string Session()
        {
           return ControllerContext.HttpContext.Request.Cookies.Where(x => x.Key == "token").FirstOrDefault().Value;
        }

        private List<SelectListItem> ListAmount()
        {
            List<SelectListItem> listAmounts = new List<SelectListItem>();
            for (int i=1; i <= 10;i++)
            {
                listAmounts.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            return listAmounts;
        }

        private List<SelectListItem> ListPaymentType()
        {
            List<SelectListItem> listPaymentType = new List<SelectListItem>();
            foreach (int item in Enum.GetValues(typeof(PaymentType)))
            {
                listPaymentType.Add(new SelectListItem { Value = ((int)item).ToString(), Text = Enum.ToObject(typeof(PaymentType), (int)item).ToString() });
            }
            return listPaymentType;
        }


    }
}