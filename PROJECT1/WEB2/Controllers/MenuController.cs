using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Draw;
using WEB2.Models;

namespace WEB2.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            var ListCategory = new CategoryDraw();
            ViewBag.listcategory = ListCategory.ListCategory();
            var ListMonAn = new MonAnDraw();
            ViewBag.listmonan = ListMonAn.ListMonAn();
            
            return View();
        }
        public bool IsNotNull(List<MonAn> ma)
        {
            if(ma.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ActionResult ListItemFood(string  a)
        {
            try
            {
                var ListCategory = new CategoryDraw();
                ViewBag.listcategory = ListCategory.ListCategory();
                var ListMonAn = new MonAnDraw();
              var listmonan = ListMonAn.ListItemFood(a.Trim());
                if (IsNotNull(listmonan)==true) 
                {
                    ViewBag.listmonan = listmonan;
                    ViewBag.error = "";
                }
                else
                {
                    ViewBag.error = "There is no list of dishes you searched for";
                    ViewBag.listmonan= ListMonAn.ListMonAn();
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }

    }
}