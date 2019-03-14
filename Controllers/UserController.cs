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
    public class UserController : Controller
    {
        private houseofgEntities db = new houseofgEntities();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET /User/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(USUARIOS user)
        {
            if (ModelState.IsValid)
            {
                Session["cue_id"] = user.USU_ID;
                db.USUARIOS.AddObject(user);
                db.SaveChanges();
                
                return RedirectToAction("../Account/Create");
            }
            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(String id)
        {
            USUARIOS user = db.USUARIOS.Single(p => p.USU_ID == id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIOS usuario)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Attach(usuario);
                db.ObjectStateManager.ChangeObjectState(usuario, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

    }
}
