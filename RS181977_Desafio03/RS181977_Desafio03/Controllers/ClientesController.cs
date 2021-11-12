using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RS181977_Desafio03.Models;

namespace RS181977_Desafio03.Controllers
{
    public class ClientesController : Controller
    {
        private Farmacia db = new Farmacia();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombres,primerApellido,segundoApellido,Telefono,Dui,email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombres,primerApellido,segundoApellido,Telefono,Dui,email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
 Código de error:
 
 0 - Acción exitosa
 1 - DUI duplicado
 2 - Sin nombre
 3 - Sin primer apellido
 4 - Sin segundo apellido
 5 - Sin teléfono
 6 - Sin email
 */

        [HttpPost]
        public Int32 Agregar(Clientes clientes)
        {
            try
            {
                var lista = Clientes.Listar();
                if (String.IsNullOrEmpty(clientes.Nombres))
                    return 2;
                if (String.IsNullOrEmpty(clientes.primerApellido))
                    return 3;
                if (String.IsNullOrEmpty(clientes.segundoApellido))
                    return 4;
                if (String.IsNullOrEmpty(clientes.Telefono))
                    return 5;
                if (String.IsNullOrEmpty(clientes.email))
                    return 6;
                if (String.IsNullOrEmpty(clientes.Dui))
                    return 7;
                if (lista.Where(x => x.Dui == clientes.Dui).Any())
                    return 1;
               

                lista.Add(clientes);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

   
      



    }
}
