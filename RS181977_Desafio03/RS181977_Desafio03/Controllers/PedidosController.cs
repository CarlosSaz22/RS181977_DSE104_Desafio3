using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using RS181977_Desafio03.Models;

namespace RS181977_Desafio03.Controllers
{
    public class PedidosController : Controller
    {
        private Farmacia db = new Farmacia();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Clientes).Include(p => p.Productos);
            return View(pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.Clientes_id = new SelectList(db.Clientes, "id", "Nombres");
            ViewBag.Productos_id = new SelectList(db.Productos, "id", "NombreProducto");
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cantidad,Clientes_id,Productos_id")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                Productos productos = db.Productos.Find(pedidos.Productos_id);
                if (productos.Stock >= pedidos.Cantidad)
                {
                    productos.Stock = productos.Stock - pedidos.Cantidad;

                    db.Entry(productos).State = EntityState.Modified;
                    db.Pedidos.Add(pedidos);
                    db.SaveChanges();
                }
                else
                {

                  

                }
          
                return RedirectToAction("Index");
            }

            ViewBag.Clientes_id = new SelectList(db.Clientes, "id", "Nombres", pedidos.Clientes_id);
            ViewBag.Productos_id = new SelectList(db.Productos, "id", "NombreProducto", pedidos.Productos_id);
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Clientes_id = new SelectList(db.Clientes, "id", "Nombres", pedidos.Clientes_id);
            ViewBag.Productos_id = new SelectList(db.Productos, "id", "NombreProducto", pedidos.Productos_id);
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cantidad,Clientes_id,Productos_id")] Pedidos pedidos)
        {
            Productos productos = db.Productos.Find(pedidos.Productos_id);

     
     
         
            if (ModelState.IsValid)
            {
            

         
                if (productos.Stock >= pedidos.Cantidad)
                {

                    productos.Stock = productos.Stock - pedidos.Cantidad;

                    db.Entry(productos).State = EntityState.Modified;
                   
                    // db.Entry(pedidos).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {

                }
            
                return RedirectToAction("Index");
            }
            ViewBag.Clientes_id = new SelectList(db.Clientes, "id", "Nombres", pedidos.Clientes_id);
            ViewBag.Productos_id = new SelectList(db.Productos, "id", "NombreProducto", pedidos.Productos_id);
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            Productos productos = db.Productos.Find(pedidos.Productos_id);
            productos.Stock = productos.Stock + pedidos.Cantidad;
            db.Pedidos.Remove(pedidos);
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
 1 - id duplicado
 2 - Cantidad negativa
 3 - Sin Clientes_id
 4 - Sin Producto_id
 5 - Sin cantidad
 */

        [HttpPost]
        public Int32 Agregar(Pedidos pedidos)
        {
          
            try
            {
                var lista = Pedidos.Listar();
                if (pedidos.Cantidad < 0)
                    return 2;
                if (pedidos.Clientes_id==0)
                    return 3;
                if (pedidos.Productos_id == 0)
                    return 4;
                if (pedidos.Cantidad == 0)
                    return 5;
                if (lista.Where(x => x.id == pedidos.id).Any())
                    return 1;
                lista.Add(pedidos);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
