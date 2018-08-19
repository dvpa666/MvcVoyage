using MvcVoyage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcVoyage.Controllers
{
    public class ListController : Controller
    {

        VoyageEntities storeDB = new VoyageEntities();
        // GET: List
        public ActionResult Index()
        {
            
            var countries = storeDB.Countries.ToList();
            /*new List<Country>
            {
                new Country {Name ="Europa" }
                , new Country {Name ="Azja" }
                , new Country {Name ="Ameryka Południowa" }
            };*/
            return View(countries);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var city = storeDB.Cities.Find(id);
            return View(city);
        }

        // GET: Browse
        public ActionResult Browse(string country)
        {
            var counrtyModel = storeDB.Countries.Include("Cities").Single(g => g.Name == country);
            return View(counrtyModel);
        }
    }
}