using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBrain.Models;
using CashBrain.DAL;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace CashBrain.Controllers
{
    
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminHome(AdminQuestion AdqAnswer)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DLL objDB = new DLL();
                int result = objDB.InsertQuestion(AdqAnswer);
                ModelState.Clear(); //clearing model
                ModelState.AddModelError("", "Record Added Successfully");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Test(AdminQuestion AdqAnswer)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DLL objDB = new DLL();
                int result = objDB.InsertQuestion(AdqAnswer);
                ModelState.Clear(); //clearing model
                ModelState.AddModelError("", "Record Added Successfully");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllQuestions()
        {
           // var bytes = new UTF8Encoding().GetBytes("");
            //var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
          

            AdminQuestion objCustomer = new AdminQuestion();
            DLL objDB = new DLL(); //calling class DBdata
            objCustomer.ShowallQuestion = objDB.Selectalldata();
            ViewBag.ShowDetails = false;
            return View(objCustomer);
        }

        public JsonResult List()
        {
            DLL objDB = new DLL();
            AdminQuestion objCustomer = new AdminQuestion();
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:62904/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            MyAPIGet(cons).Wait();
            return Json(objCustomer.ShowallQuestion = objDB.Selectalldata(), JsonRequestBehavior.AllowGet);
        }

        static async Task MyAPIGet(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/Demo/list");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var abc = res.Content.ReadAsStringAsync();
                    string outr = abc.Result.ToString();
                    
                }
            }
        }

        public JsonResult Add(AdminQuestion AdqAnswer)
        {
            DLL objDB = new DLL();
           // int result = objDB.InsertQuestion(AdqAnswer);
            return Json(objDB.InsertQuestion(AdqAnswer), JsonRequestBehavior.AllowGet);
        }
    }
}