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
    public class AccountController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET /Account/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(CUENTAS cue)
        {
           
            if (ModelState.IsValid)
            {
                cue.USU_ID = (String)Session["cue_id"];
                cue.TIC_ID = 1;
                db.CUENTAS.AddObject(cue);
                db.SaveChanges();
                return RedirectToAction("../User/Index");
            }
            return View(cue);
        }

        //
        // GET: /Account/Login

        public ActionResult Login(String username, String pass)
        {
             CUENTAS name = db.CUENTAS.FirstOrDefault(x => x.USU_ID == username);
             if (name != null)
             {
                 CUENTAS pwd = db.CUENTAS.FirstOrDefault(x => x.CUE_PASSWORD == pass);
                     if (pwd != null)
                     {
                         return View(pwd);

                     }
                     else
                     {
                         ViewBag.mensaje = "password incorrecta";
                     }
             }
             else {
                ViewBag.mensaje = "usuario no encontrado";
             }
        
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(CUENTAS cuenta)
        {
            Session["autentificado"] = false;
            Session["adm"] = false;
            CUENTAS aux = db.CUENTAS.Single(x=> x.TIC_ID == 0);
            if (ModelState.IsValid)
            {
                Session["autentificado"] = true;
                Session["username"] = cuenta.USU_ID;
                if (aux.TIC_ID == 0)
                {
                    Session["adm"] = true;
                }
                else
                {
                    Session["adm"] = false;
                }

            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("../Home");
        }

        //
        // GET: /Account/Logout

        public ActionResult Logout()
        {
            Session["autentificado"] = null;

            return RedirectToAction("../Home");
        }

        //
        // GET /Account/CambiarPass
        public ActionResult CambiarPass(String username)
        {
            CUENTAS cuenta = db.CUENTAS.Single(x => x.USU_ID == username );
            
            return View(cuenta);
        }
        //
        // POST: /Account/CambiarPass

        [HttpPost]
        public ActionResult CambiarPass(CUENTAS cue)
        {

            if (ModelState.IsValid)
            {
                db.CUENTAS.Attach(cue);
                db.ObjectStateManager.ChangeObjectState(cue, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("../User/Index");
            }
            return View(cue);
        }

    }
}
