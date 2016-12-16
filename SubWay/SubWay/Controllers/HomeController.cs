using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubWay.DAL;

namespace SubWay.Controllers
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
            try
            {
                demosubwaydbEntities dbContext = new demosubwaydbEntities();
                Customer newCustomer = new Customer();
                newCustomer.Nombres = "Andrea Reyes";
                newCustomer.Telefono = "3112110445";
                newCustomer.Email = "yurypecas@hotmail.com";
                newCustomer.TwilioCode = "XZZXCERT";
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
            
                ViewBag.Message = "Salvado Ok ...";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            
            

            return View();
        }
    }
}