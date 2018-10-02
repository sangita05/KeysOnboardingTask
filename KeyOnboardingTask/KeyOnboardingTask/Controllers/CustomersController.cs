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
    public class CustomersController : Controller
    {
        private KeyDBEntities db = new KeyDBEntities();

        // GET: Customers
        public ActionResult Index()
        {
            try
            {
                var query = db.Customers.ToList();
                return View(query);
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        public JsonResult List()
        {
            using (db)
            {
                var customer = db.Customers.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Address,
                   // x.Age,
                   // x.ContactNo
                }).ToList();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
        }


        //// GET: Customers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Customer customer)
        {
           // try
          //  {
                Customer newCustomer = new Customer();
                if (ModelState.IsValid)
                {
                    newCustomer.Id = customer.Id;
                    newCustomer.Name = customer.Name;
                    newCustomer.Address = customer.Address;
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
          //  }catch(Exception ex)
           // {
           //     Console.WriteLine(ex.InnerException);
          //  }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {

           // id = 3009;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {

                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
             try
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return RedirectToAction("Index");

            }
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
