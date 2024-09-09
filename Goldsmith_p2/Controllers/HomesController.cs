using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Goldsmith_p2.Models;

namespace Goldsmith_p2.Controllers
{
    public class HomesController : Controller
    {
        private goldsmitEntities1 db = new goldsmitEntities1();

        // GET: Homes
        // GET: Customers


        public ActionResult Index(string searchBy, string search)
        {


            if (searchBy == "Phone Number")

            {

                return View(db.Customersses.Where(x => x.Phone_Number == search || search == null).ToList());
            }

            else

            {
                return View(db.Customersses.Where(x => x.Name.StartsWith(search) || search == null).ToList());

            }

        }

        // GET: Homes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerss customerss = db.Customersses.Find(id);
            if (customerss == null)
            {
                return HttpNotFound();
            }
            return View(customerss);
        }

        // GET: Homes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Phone_Number,Gold_in_grams,Total_amount,Advance_amount,Balance_amount,Date")] Customerss customerss)
        {
            if (ModelState.IsValid)
            {
                db.Customersses.Add(customerss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerss);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Homes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerss customerss = db.Customersses.Find(id);
            if (customerss == null)
            {
                return HttpNotFound();
            }
            return View(customerss);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Phone_Number,Gold_in_grams,Total_amount,Advance_amount,Balance_amount,Date")] Customerss customerss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerss);
        }

        // GET: Homes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerss customerss = db.Customersses.Find(id);
            if (customerss == null)
            {
                return HttpNotFound();
            }
            return View(customerss);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customerss customerss = db.Customersses.Find(id);
            db.Customersses.Remove(customerss);
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
