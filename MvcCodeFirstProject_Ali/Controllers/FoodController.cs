using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcCodeFirstProject_Ali.Models;
using MvcCodeFirstProject_Ali.ViewModels;

using AutoMapper;
using PagedList;

namespace MvcCodeFirstProject_Ali.Controllers
{

    public class FoodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        [Route("Home")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var foods = from t in db.Foods
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(t => t.FoodName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    foods = foods.OrderByDescending(t => t.FoodName);
                    break;
                default:
                    foods = foods.OrderBy(t => t.FoodName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(foods.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodVM foodVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(foodVM.ImageFile.FileName);
                string extention = Path.GetExtension(foodVM.ImageFile.FileName);
                HttpPostedFileBase postedFile = foodVM.ImageFile;
                int length = postedFile.ContentLength;

                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extention;
                        foodVM.ImagePath = "~/AppFiles/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                        foodVM.ImageFile.SaveAs(fileName);
                        var food = Mapper.Map<Food>(foodVM);

                        db.Foods.Add(food);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {

                            ModelState.Clear();
                            return RedirectToAction("Index", "Food");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data not inserted')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                    }
                }
                else
                {
                    TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                }
            }
            return View();


        }

        public ActionResult Edit(int? id)
        {
            var query = db.Foods.Single(t => t.FoodID == id);
            Session["Image"] = query.ImagePath;

            var food = Mapper.Map<Food, FoodVM>(query);
            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodVM foodVM)
        {

            if (ModelState.IsValid == true)
            {
                if (foodVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(foodVM.ImageFile.FileName);
                    string extention = Path.GetExtension(foodVM.ImageFile.FileName);
                    HttpPostedFileBase postedFile = foodVM.ImageFile;
                    int length = postedFile.ContentLength;
                    if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extention;
                            foodVM.ImagePath = "~/AppFiles/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                            foodVM.ImageFile.SaveAs(fileName);

                            var food = Mapper.Map<Food>(foodVM);


                            db.Entry(food).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                ModelState.Clear();
                                return RedirectToAction("Index", "Food");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    foodVM.ImagePath = Session["Image"].ToString();
                    var food = Mapper.Map<Food>(foodVM);

                    db.Entry(food).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Food");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                    }
                }
            }
            return View();


        }


        public ActionResult Delete(int? id)
        {
            var query = db.Foods.Single(t => t.FoodID == id);
            var food = Mapper.Map<Food, FoodVM>(query);
            return View(food);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FoodVM foodVM)
        {
            var query = db.Foods.Single(t => t.FoodID == id);
            var trainee = Mapper.Map<Food, FoodVM>(query);
            db.Foods.Remove(query);  // 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

