using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLBroker.Controllers
{
    [test]
    public class TestController : Controller
    {
        
        public ActionResult Index()
        {
            Service.BGThread a = new Service.BGThread();
            a.Run();
            return View();
        }
    }
}