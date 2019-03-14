using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;

namespace MvcHouseofg.Controllers
{
    public class ValoracionController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
       
        public ActionResult Valorar(FichaProducto val)
        {
            if (ModelState.IsValid)
            {
                VALORACIONES valoracion = new VALORACIONES();
                valoracion.USU_ID = (String )Session["username"];
                valoracion.PROD_ID = (int)Session["prod_id"];
                //valoracion.VAL_COMENTARIO = comentario;
                //valoracion.VAL_PUNTAJE = puntaje;
                db.VALORACIONES.AddObject(valoracion);
                db.SaveChanges();
            }
            return View("../Home/Product" + Session["prod_id"]);
        }

    }
}
