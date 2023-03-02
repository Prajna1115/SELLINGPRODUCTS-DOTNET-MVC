using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class CategoriesController : Controller
    {
      
            EcomContext ec = new EcomContext();
            // GET: Categories
            public ActionResult Index()
            {
                return View(ec.categories.ToList());
            }
        public ActionResult CategoryList()
        {
            return View(ec.categories.ToList());
        }
        [HttpPost]
        public ActionResult CategoryList(List<Category> categorylist)
        {
            string selectcate = "";
            foreach(Category c in categorylist)
            {
                if(c.check)
                    selectcate += c.name+',';
            }
            selectcate= selectcate.TrimEnd(',');  
            ViewBag.show = selectcate;
            return View(ec.categories.ToList());


        }
        
            public ActionResult Create()
            {
                return View();

            }
        [HttpPost]
        public ActionResult Create(Category c, HttpPostedFileBase file)
        {
            string name = file.FileName;
            string path = "~/Images/" + name;
            file.SaveAs(Server.MapPath(path));
            if (ModelState.IsValid)
            {
                c.imgPath = path;
                ec.categories.Add(c);
                ec.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
            public ActionResult Edit(int id)
            {
                return View(ec.categories.Find(id));
            }
            [HttpPost]
            public ActionResult Edit(Category c)
            {
                ec.categories.AddOrUpdate(c);
                ec.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Delete(int id)
            {
                return View(ec.categories.Find(id));

            }
            [HttpPost]
            [ActionName("Delete")]
            public ActionResult DeletePost(int id)
            {
                Category c = ec.categories.Find(id);
                ec.categories.Remove(c);
                return RedirectToAction("Index");
            }


        }
    }

    
