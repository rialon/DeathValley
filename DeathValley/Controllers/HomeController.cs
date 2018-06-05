using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeathValley.Models;
using DeathValley.Models.Abstract;

namespace DeathValley.Controllers {

    public class HomeController : Controller {
        private IChartProcessor _ChartProcessor;

        public HomeController(IChartProcessor processor) {
            this._ChartProcessor = processor;
        }

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Chart(Chart chart) {
            if (chart.LowerLimit >= chart.HigherLimit) {
                ModelState.AddModelError("", "Lower limit is greater than the higher one");
            }
            if (ModelState.IsValid) {
                this._ChartProcessor.SetChartPoints(chart);
                return Json(new { isValid = true, data = chart.Points });
            } else {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { isValid = false, data = errors });
            }
        }
    }
}