using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHouseofg.Models;
using System.Data;
using System.Data.Entity;

namespace MvcHouseofg.Controllers
{
    public class ProductoController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            return View(db.PRODUCTOS.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ViewResult Details(int id)
        {
            PRODUCTOS producto = db.PRODUCTOS.Single(p => p.PROD_ID == id);
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(PRODUCTOS producto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Imagenes/") + System.IO.Path.GetFileName(file.FileName));
                    producto.PROD_IMAGEN = System.IO.Path.GetFileName(file.FileName);
                }
                db.PRODUCTOS.AddObject(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id)
        {
            PRODUCTOS producto = db.PRODUCTOS.Single(p => p.PROD_ID == id);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODUCTOS producto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Imagenes/") + System.IO.Path.GetFileName(file.FileName));
                    producto.PROD_IMAGEN = System.IO.Path.GetFileName(file.FileName);
                }
                db.PRODUCTOS.Attach(producto);
                db.ObjectStateManager.ChangeObjectState(producto, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id)
        {
            PRODUCTOS producto = db.PRODUCTOS.Single(p => p.PROD_ID == id);
            return View(producto);
        }
        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS producto = db.PRODUCTOS.Single(p => p.PROD_ID == id);
            db.PRODUCTOS.DeleteObject(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
