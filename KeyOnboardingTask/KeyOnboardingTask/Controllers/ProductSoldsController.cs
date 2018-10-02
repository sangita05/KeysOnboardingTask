using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeyOnboardingTask;
using KeyOnboardingTask.Models;

namespace KeyOnboardingTask.Controllers
{
    public class ProductSoldsController : Controller
    {
        private KeyDBEntities db = new KeyDBEntities();

        // GET: ProductSolds
        public ActionResult Index()
        {

            var productSolds = db.ProductSolds.Include(p => p.Customer).Include(p => p.Product).Include(p => p.Store);

            return View(productSolds.ToList());
        }
        public JsonResult List()
        {
            //return Json(db.ProductSolds.ToList(), JsonRequestBehavior.AllowGet);
            using (db)
            {
                var psold = new ProductSold();
                ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", psold.CustomerId);
                ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", psold.ProductId);
                ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", psold.StoreId);
                var product = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(s => s.Store).Select(x => new {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    Customer = x.Customer.Name,
                    ProductId = x.ProductId,
                    Product = x.Product.Name,
                    StoreId = x.StoreId,
                    Store = x.Store.Name,
                    DateSold = x.DateSold
                }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: ProductSolds/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductSold productSold = db.ProductSolds.Find(id);
        //    if (productSold == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productSold);
        //}

        // GET: ProductSolds/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
        //    ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
        //  //  ViewBag.Id = new SelectList(db.ProductSolds, "Id", "Id");
        //    //ViewBag.Id = new SelectList(db.ProductSolds, "Id", "Id");
        //    ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
        //    return View();
        //}

      
        //[HttpPost]
        public JsonResult Create(ProductSold prod)
        {
            using (db)
            {
                db.ProductSolds.Add(prod);
                db.SaveChanges();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }

        
        public JsonResult Edit(int id, ProductSold prod)
        {
            using (db)
            {
                var prod1 = db.ProductSolds.Find(id);
                if (prod1 != null)
                {
                    db.Entry(prod1).State = EntityState.Detached;
                }
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: ProductSolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ProductId,CustomerId,StoreId,DateSold")] ProductSold productSold)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productSold).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", productSold.CustomerId);
        //    ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productSold.ProductId);
        //    //ViewBag.Id = new SelectList(db.ProductSolds, "Id", "Id", productSold.Id);
        //    //ViewBag.Id = new SelectList(db.ProductSolds, "Id", "Id", productSold.Id);
        //    ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productSold.StoreId);
        //    return View(productSold);
        //}

        //    public ActionResult Edit(ProductSold productSold)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productSold).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return Json(productSold.Id);
        //    }
        //    return View(productSold);
        //}

      

        public JsonResult Delete(int id)
        {
            using (db)
            {
                ProductSold prod = db.ProductSolds.Find(id);
                db.ProductSolds.Remove(prod);
                db.SaveChanges();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
