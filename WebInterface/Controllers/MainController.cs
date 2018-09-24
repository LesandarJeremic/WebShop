using Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using WebInterface.Models;

namespace WebInterface.Controllers
{
    public class MainController : Controller
    {
        Repository.Repository rep = new Repository.Repository();


        // GET: Main

        public ActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProducts()
        {

            try
            {
                var data = rep.GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception xcp)
            {

                throw;
            }


        }

        // GET: Main/Details/5
        [HttpGet]
        public ActionResult Alter(Product prod)
        {


            return View(prod);
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            try
            {
                // TODO: Add insert logic here
                rep.Add(prod);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateJson(List<Product> prod)
        {
            try
            {
                // TODO: Add insert logic here
                rep.AddList(prod);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Serialize()
            
        {
            try
            {
                rep.WriteJsonToFile();

               
                

              




                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch(Exception xcp)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }

        }
        [HttpGet]
        public ActionResult Deserialize()

        {
            try
            {
                return Json(rep.Deserialize(),JsonRequestBehavior.AllowGet);


        
            }
            catch (Exception xcp)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }

        }










        // GET: Main/Edit/5


        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Update(Product prod)
        {
            try
            {
                // TODO: Add update logic here
                rep.Update(prod);

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception xcp)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            rep.Delete(rep.Get(id));
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
