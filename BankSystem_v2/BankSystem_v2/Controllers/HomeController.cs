using BankSystem_v2.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BankSystem_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CurrencyConverter(FormCollection form)
        {
            var FromList = new List<string> { "BGN", "USD", "EUR", "GBP" };
            var ToList = new List<string> { "BGN", "USD", "EUR", "GBP" };

            ViewBag.From = new SelectList(FromList);
            ViewBag.To = new SelectList(ToList);

            string from = form["From"];
            string to = form["To"];
            string sum = form["SumFrom"];

            CurrencyConverter currencyConverter = new CurrencyConverter();
            string sumReturn = null;

            foreach (var item in currencyConverter.Coefficients)
            {
                if (item.Item1 == from && item.Item2 == to)
                {
                    sumReturn = (double.Parse(sum) * item.Item3).ToString();
                }
                ViewBag.From = from;
                ViewBag.To = to;
                ViewBag.SumReturn = sumReturn;
                ViewBag.Sum = sum;
            }

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Strategy()
        {
            return View();
        }
    }
}