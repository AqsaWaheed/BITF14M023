using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using online_shopping.Controllers;
using online_shopping.Models;

namespace online_shopping.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        Database2Entities3 db = new Database2Entities3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
        public ActionResult blog_single()
        {
            return View();
        }
        public ActionResult blog()
        {
            return View();
        }
        public ActionResult cart()
        {
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult contact_us()
        {
            return View();
        }
      
        public ActionResult product_details()
        {
            return View();
        }
        public ActionResult shop()
        {
            ViewBag.Message = "Your shop page.";
            return View();
        }





        public ActionResult login()
        {

            return View();

        }


        [HttpPost]
        public ActionResult addUserconfirm(client c)
        {

            db.clients.Add(c);
            db.SaveChanges();
            return RedirectToAction("Display");
        }



        public ActionResult Display()
        {
            return View(db.clients.ToList());

        }



        public ActionResult UpdateItem(int id)
        {
            item it = db.items.Find(id);
            if (it == null)
            {
                return HttpNotFound();
            }
            return View(it);

        }
        [HttpPost]
        public ActionResult updateItemConfirm(int id)
        {
            /*string ID = Request["id"];
            int i = Int32.Parse(id);*/

            item it = db.items.Find(id);

            string cde = Request["code"];
            string ctgry = Request["category"];
            string name = Request["IName"];



            int c = Int32.Parse(cde);

            it.IID = id;
            it.code = c;
            it.category = ctgry;
            it.IName = name;


            db.SaveChanges();
            return RedirectToAction("DisplayItem");

        }




        public ActionResult DisplayItem()
        {
            return View(db.items.ToList());

        }


        public ActionResult addItem()
        {

            return View();

        }


        [HttpPost]
        public ActionResult addItemconfirm(item c)
        {

            db.items.Add(c);
            db.SaveChanges();
            return RedirectToAction("DisplayItem");
        }



        public ActionResult Delete(int id)
        {
            item it = db.items.Find(id);
            db.items.Remove(it);
            db.SaveChanges();


            return RedirectToAction("DisplayItem");

        }




        public ActionResult Admin_login()
        {

            return View();

        }


        [HttpPost]
        public ActionResult addAdminConfirm(admin a)
        {

            db.admins.Add(a);
            db.SaveChanges();
            return RedirectToAction("DisplayItem");
        }
       
    }
}