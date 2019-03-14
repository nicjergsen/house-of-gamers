using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;

namespace MvcHouseofg.Controllers
{
    public class RedSocialController : Controller
    {

        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /RedSocial/

        public ActionResult Index()
        { 
             String userid = (String)Session["username"];

            if (userid != null)
            {

                var query = from a in db.AMIGOS select a;
                var lista = query.Where(x => x.USU_ID == userid);

                return View(lista);
            }

            else {

                return View();
            
            }
           
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(String ami_id)
        {
            AMIGOS ami = new AMIGOS();
            String userid = (String)Session["username"];

            if (ModelState.IsValid)
            {
                ami.AMI_ID = ami_id;
                ami.USU_ID = userid;
                db.AMIGOS.AddObject(ami);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult Notificaciones(String amigo)
        {

            var ami = db.AMIGOS.FirstOrDefault(a => a.AMI_ID == amigo);

            DateTime fechasession = Convert.ToDateTime(Session["fechasession"]);

            String username = (String)Session["username"];

            if (username != null && ami != null)
            {

                var query = from detalles in db.DETALLES
                            join pedidos in db.PEDIDOS
                            on detalles.PED_ID equals pedidos.PED_ID
                            join productos in db.PRODUCTOS
                            on detalles.PROD_ID equals productos.PROD_ID
                            select detalles;

                //var test = from detalles in db.DETALLES
                //           select detalles;

                //var test2 = test.Where(x=>x.PROD_ID==0);
                var lista = query.Where(x => x.PEDIDOS.USU_ID == amigo);

                return View(lista);
            }

            else
            {

                return RedirectToAction("../Home/Perfil");
            }

        }

        public ActionResult HistorialVenta()
        {
            String usuario = (String)Session["username"];
            if (usuario != "")
            {
                var query = from detalles in db.DETALLES
                            join pedidos in db.PEDIDOS
                            on detalles.PED_ID equals pedidos.PED_ID
                            join productos in db.PRODUCTOS
                            on detalles.PROD_ID equals productos.PROD_ID
                            select detalles;

                var lista = query.Where(x => x.PEDIDOS.USU_ID == usuario);
                return View(lista);
            }
            return View("Home/Index");
        }

    }
}
