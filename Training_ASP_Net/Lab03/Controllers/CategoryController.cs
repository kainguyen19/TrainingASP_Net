using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;
using Lab3.ViewModels;

namespace Lab3.Controllers
{
    public class CategoryController : Controller
    {
        BabyShopEntities db = new BabyShopEntities();

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.Where(c => c.IsDelete == false).ToList<Category>();
            return View(categories);
        }

        public ActionResult SetActive(int id)
        {
            Category category = db.Categories.Single(c => c.ID == id);
            category.IsActive = !category.IsActive;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Single(c => c.ID == id);

            //Xu ly xoa that khi moi tao Category nhung cho co Product thuoc ve Category nay
            int numOfProduct = db.Products.Where(p => p.CategoryID == category.ID).Count();
            
            if (numOfProduct == 0)
                db.Categories.Remove(category);
            else
                category.IsDelete = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel cate)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                
                category.Name = cate.Name;

                category.IsActive = true;
                category.IsDelete = false;

                db.Categories.Add(category);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Single(c => c.ID == id);

            CategoryViewModel cate = new CategoryViewModel();

            cate.ID = category.ID;
            cate.Name = category.Name;
            cate.IsDelete = category.IsDelete;
            cate.IsActive = category.IsActive;
            cate.CreatedAt = category.CreatedAt;
            cate.UpdatedAt = category.UpdatedAt;

            return View(cate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel cate)
        {
            if(ModelState.IsValid)
            {
                Category category = db.Categories.Single(c => c.ID == cate.ID);
                
                category.Name = cate.Name;
                category.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cate);
        }
    }
}