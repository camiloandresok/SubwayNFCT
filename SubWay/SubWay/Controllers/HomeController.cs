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
            return Content("prueba de comunicacion Ajax Dicisoft");
        }


        public ActionResult AsyncProcessP(Usuario usuario)
        {
            string response = string.Empty;
            try
            {
                demosubwaydbEntities dbContext = new demosubwaydbEntities();
                Customer customer = new Customer();
                customer.Nombres = usuario.Nombre;
                customer.Telefono = usuario.Telefono;
                customer.Email = usuario.Email;
                customer.TwilioCode = Guid.NewGuid().ToString();
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                response = @"<div class=""alert alert-success"" role=""alert""><p>Reclame su sandwich con el siguiente codigo : <strong>"+ customer.TwilioCode + " <strong></p></div>";
            }
            catch (Exception ex)
            {
                response = @"<div class=""alert alert-danger"" role=""alert""><p>Se presento un error intenta mas tarde : <strong> " + ex.Message + "<strong></p></div>";
            }

            return Content(response);
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
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}