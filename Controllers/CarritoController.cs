using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;

namespace MvcHouseofg.Controllers
{
    public class CarritoController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /Carrito/

        public ActionResult AgregarCarrito(int id)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.PRODUCTOS.Single(x => x.PROD_ID == id), 1));
                Session["carrito"] = compras;
            }
            else
            { 
                List<CarritoItem> compras = (List<CarritoItem>) Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.PRODUCTOS.Single(x => x.PROD_ID == id), 1));
                }
                else
                {
                    compras[IndexExistente].cantidad++;
                }

                Session["carrito"] = compras;
            }
            return View();
        }

        public int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].producto.PROD_ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            int IndexExistente = getIndex(id);
            if (IndexExistente != -1)
            {
                compras[IndexExistente].cantidad--;
                if( compras[IndexExistente].cantidad == 0){
                    compras.RemoveAt(getIndex(id));
                }
            }
            Session["carrito"] = compras;
            return View("AgregarCarrito");
        }

        public ActionResult VerCarrito()
        {
            if (Session["carrito"] == null)
            {
                ViewBag.mensaje = "Vacio";
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                Session["carrito"] = compras;
            }
            return View("AgregarCarrito");
        }

        public ActionResult Comprar()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for(int i = 0; i < compras.Count; i++)
            {
                PEDIDOS pedido = new PEDIDOS();
                pedido.USU_ID = (String)Session["username"];
                pedido.PED_FECHA = DateTime.Now;
                db.PEDIDOS.AddObject(pedido);
                DETALLES detalle = new DETALLES();
                detalle.PROD_ID = compras[i].producto.PROD_ID;
                detalle.PED_ID = pedido.PED_ID;
                detalle.DET_CANTIDAD = compras[i].cantidad;
                db.DETALLES.AddObject(detalle);
                db.SaveChanges();
                
            }
            compras = null;
            Session["carrito"] = null;
            return View("AgregarCarrito");
        }
    }
}
