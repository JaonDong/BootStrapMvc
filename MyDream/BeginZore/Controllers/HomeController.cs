using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeginZore.IocMvc;
using RegisterClass;

namespace BeginZore.Controllers
{
    public class HomeController : MyController
    {
        protected readonly IComTest _comTest;

        public HomeController(IComTest comTest)
        {
            _comTest = comTest;
        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}