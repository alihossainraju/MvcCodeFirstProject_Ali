using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using MvcCodeFirstProject_Ali.Models;

namespace MvcCodeFirstProject_Ali.Controllers
{
    public class OrdersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Traveller> OrderAndTravellerList = db.Travellers.ToList();
            return View(OrderAndTravellerList);
        }

        public ActionResult SaveOrder(string name, String address, Order[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
                var travellerid = Guid.NewGuid();
                Traveller model = new Traveller();
                model.TravellerID = travellerid;
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Travellers.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Order O = new Order();
                    O.OrderID = orderId;
                    O.ProductName = item.ProductName;
                    O.Quantity = item.Quantity;
                    O.Price = item.Price;
                    O.Amount = item.Amount;
                    O.TravellerID = travellerid;
                    db.Orders.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditOrder(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.TravellerID = new SelectList(db.Travellers, "TravellerID", "Name", order.TravellerID);
            return View(order);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder([Bind(Include = "OrderID,ProductName,Quantity,Price,Amount,TravellerID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TravellerID = new SelectList(db.Travellers, "TravellerID", "Name", order.TravellerID);
            return View(order);
        }



        public ActionResult EditTraveller(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Traveller cus = db.Travellers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }

            return View(cus);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTraveller([Bind(Include = "TravellerID,Name,Address,OrderDate")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traveller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traveller);
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