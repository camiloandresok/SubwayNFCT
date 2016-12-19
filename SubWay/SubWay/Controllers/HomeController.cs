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

        public ActionResult AsyncProcess()
        {
            int x = 0;
            int y = x;
             
            return Content("prueba de comunicacion Ajax Camilo");
        }


        public ActionResult AsyncProcessP(List<Usuario> items)
        {
            int x = 0;
            int y = x;

            Customer kk = new Customer();

            return Content("<div><marquee><h1> info en header" + System.DateTime.Now.ToString() + "</h1></marquee></div>");
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
                newCustomer.Nombres = "Pepito Perez";
                newCustomer.Telefono = "325206613";
                newCustomer.Email = "pepitogay@hotmail.com";
                newCustomer.TwilioCode = "XZWSCERT";
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
            
                ViewBag.Message = "Customer Salvado Ok gracias karen...";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            
            

            return View();
        }
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}