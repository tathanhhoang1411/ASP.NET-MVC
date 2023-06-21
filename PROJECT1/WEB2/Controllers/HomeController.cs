using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Models;
using WEB2.Draw;
namespace WEB2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ListMonAn = new MonAnDraw();
            ViewBag.listmonan = ListMonAn.ListMonAn();
            var ListCategory = new CategoryDraw();
            ViewBag.listcategory = ListCategory.ListCategory();
            return View();
        }
   

    }
}