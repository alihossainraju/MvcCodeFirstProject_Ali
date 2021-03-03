using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcCodeFirstProject_Ali;
using MvcCodeFirstProject_Ali.Models;
namespace MvcCodeFirstProject_Ali.Controllers
{
    public class ReporterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Reporter
        private ApplicationDbContext _context;
        public ReporterController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.Reporters.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Reporter user)
        {
            _context.Reporters.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Reporters.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Reporter user)
        {
            var data = _context.Reporters.FirstOrDefault(x => x.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Reporters.FirstOrDefault(x => x.Id == ID);
            _context.Reporters.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}