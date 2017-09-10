using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBrain.DAL;
using CashBrain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CashBrain.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuizDemo()
        {
            return View();
        }

        public JsonResult List()
        {
            DLL objDB = new DLL();
            AdminQuestion objCustomer = new AdminQuestion();
            AdminQuestion students = null;
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri("http://localhost:62904/api/");
                var responseTask = client.GetAsync("Demo2");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                   var readtask = result.Content.ReadAsAsync<AdminQuestion>();
                    readtask.Wait();
                    students = readtask.Result;
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
         
            return Json(objCustomer.ShowallQuestion = students.ShowallQuestion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CustomerHomepage()
        {
            return View();
        }
      
    }
}