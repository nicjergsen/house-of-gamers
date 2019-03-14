using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;

namespace MvcHouseofg.Controllers
{
    public class HomeController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Catalogo()
        {
            return View(db.PRODUCTOS.ToList());
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Product(int id)
        {
            Session["prod_id"] = id;
            FichaProducto p = new FichaProducto();
            p.producto = db.PRODUCTOS.FirstOrDefault(x => x.PROD_ID == id);
            List<VALORACIONES> valoraciones = db.VALORACIONES.Where(x => x.PROD_ID == id).ToList();
            p.valoracion = valoraciones;
            try
            {
                p.prom_val = db.VALORACIONES.Where(x => x.PROD_ID == id).Average(x => x.VAL_PUNTAJE);
                
                //p.valoracion = db.VALORACIONES.FirstOrDefault(y => y.PROD_ID == id);
                //PRODUCTOS p = db.PRODUCTOS.FirstOrDefault(x => x.PROD_ID == id);
            }
            catch (Exception ex)
            {

            }
            if (p != null)
            {
                ViewData.Model = p;
            }
            else
            {
                ViewBag.mensaje = "Producto no encontrado";
            }
            return View();
        }
    }
}
