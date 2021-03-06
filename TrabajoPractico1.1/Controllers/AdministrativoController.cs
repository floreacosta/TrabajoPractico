﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPractico.Models;
using TrabajoPractico1._1;
using System.Data.Entity;
using System.Net;

namespace TrabajoPractico1._1.Controllers
{
    public class administrativoController : Controller
    {
        ContextoPractico ctx = new ContextoPractico();
        //
        // GET: /Administrativo/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerificarUsuario([Bind(Include="IdUsuario,NombreUsuario,Password" )]Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                var admin = (from p in ctx.Usuarios
                             where (p.NombreUsuario == usuario.NombreUsuario) && (p.Password == usuario.Password)
                             select p).FirstOrDefault();
                if (admin == null)
                    return View("Error");
                else
                    return View("GestionAdmin");
            }

            else return View("Login");

        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}