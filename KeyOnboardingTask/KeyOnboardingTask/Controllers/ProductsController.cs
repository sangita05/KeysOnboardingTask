﻿using System;
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
    public class ProductsController : Controller
    {
        private KeyDBEntities db = new KeyDBEntities();

        // GET: Products
        public ActionResult Index()
        {
            var query = db.Products.ToList();
            return View(query);
        }

        public JsonResult List()
        {
            using (db)
            {
                var prod = db.Products.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Price
                }).ToList();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }



        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] Product product)
        {
            Product newProduct = new Product();
            if (ModelState.IsValid)
            {
               // try
               // {
                    //db.Products.Add(product);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                    newProduct.Id = product.Id;
                    newProduct.Name = product.Name;
                    newProduct.Price = product.Price;
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    return RedirectToAction("Index");
             //   }catch(Exception ex)
              //  {
               //     Console.WriteLine(ex.InnerException);
               // }
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] Product product)
        {
            //try {
            //    if (ModelState.IsValid)
            //    {
            //        //try
            //        // {
            //        db.Entry(product).State = EntityState.Modified;
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    //}catch(Exception ex)
            //    //{
            //    //   Console.WriteLine(ex.InnerException);
            //    //}
            //}catch (Exception ex)
            //{
            //  Console.WriteLine(ex.InnerException);

            //}
            //return View(product);
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
    }
}
