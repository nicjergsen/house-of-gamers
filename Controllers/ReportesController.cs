using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;

namespace MvcHouseofg.Controllers
{
    public class ReportesController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /Reportes/

        public ActionResult MasVendido()
        {

            var query = from detalles in db.DETALLES
                        group detalles by detalles.PROD_ID into d
                        select d;

//         Select Top 1 PROD_ID, COUNT(PROD_ID)+COUNT(DET_CANTIDAD) AS VECESVENDIDO 
//from [houseofg].[dbo].[DETALLES]
//Group by PROD_ID
//Order by count(2) desc

            return View("Home");
        }

        public ActionResult HistorialCompras()
        {
            var query = from detalles in db.DETALLES
                        join pedidos in db.PEDIDOS
                        on detalles.PED_ID equals pedidos.PED_ID
                        join productos in db.PRODUCTOS
                        on detalles.PROD_ID equals productos.PROD_ID
                        select detalles;


//    Select DETALLES.PROD_ID, PRODUCTOS.PROD_NOMBRE, PED_FECHA, DET_CANTIDAD, USU_ID
//from [houseofg].[dbo].[DETALLES]
//inner join [houseofg].[dbo].[PEDIDOS]
//on DETALLES.PED_ID = PEDIDOS.PED_ID
//inner join [houseofg].[dbo].[PRODUCTOS]
//on DETALLES.PROD_ID = PRODUCTOS.PROD_ID

            

            return View();
        }

    }
}
