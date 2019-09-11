using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using qwerty1.Models;

namespace qwerty1.Controllers
{
    public class AirlineController : Controller
    {
        private CrudOpContext orm = null;
        public AirlineController(CrudOpContext _orm)
        {
            orm = _orm;
        }
        [HttpGet]
        public IActionResult AddNewAirline()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewAirline(Airline A)
        {
            try
            {
                orm.Airline.Add(A);
                orm.SaveChanges();
                ViewBag.Message = A.Name + "Airline Saved Successfully!";
                ViewBag.Messagetype = "S";

            }
            catch
            {
                ViewBag.Message = A.Name + "Error in Saving Airline!";
                ViewBag.Messagetype = "E";
            }
            return View();
        }
       public IActionResult AllAirline()
        {
            return View(orm.Airline.ToList());
        }
       

    }
}