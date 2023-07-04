using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Draw;
using WEB2.Models;
using PagedList;
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
        public ActionResult ListItemFood(string  a,string search)//a là Tên loại món ăn, search người dùng nhập
        {
            try
            {
                if (a!=null)
                {
                    var ListCategory = new CategoryDraw();
                    ViewBag.listcategory = ListCategory.ListCategory();
                    var ListMonAn = new MonAnDraw();
                    var listmonan = ListMonAn.ListItemFoodByCate(a.Trim());
                    if (IsNotNull(listmonan) == true)
                    {
                        ViewBag.listmonan = listmonan;
                        ViewBag.error = "";
                    }
                    else
                    {
                        ViewBag.error = "There is no list of dishes you searched for";
                        ViewBag.listmonan = ListMonAn.ListMonAn();
                    }
           
                }
                if (search != null)
                {
                    var ListCategory = new CategoryDraw();
                    ViewBag.listcategory = ListCategory.ListCategory();
                    var ListMonAn = new MonAnDraw();
                    var listmonan = ListMonAn.ListItemFoodBySearch(search.Trim());
                    if (IsNotNull(listmonan) == true)
                    {
                        ViewBag.listmonan = listmonan;
                        ViewBag.error = "";
                    }
                    else
                    {
                        ViewBag.error = "There is no list of dishes you searched for";
                        ViewBag.listmonan = ListMonAn.ListMonAn();
                    }
             
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }
        public ActionResult TimMonAn()
        {
            return View();
        }

    }
}