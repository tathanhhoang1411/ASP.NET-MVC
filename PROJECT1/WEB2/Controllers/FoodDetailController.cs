using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Draw;
using WEB2.Models;
namespace WEB2.Controllers
{
    public class FoodDetailController : Controller
    {
        // GET: FoodDetail
        public ActionResult Index(int id)
        {
           
                try
                {
                    var ListCategory = new CategoryDraw();
                    ViewBag.listcategory = ListCategory.ListCategory();
                    var ListMonAn = new MonAnDraw();
                    var listmonan = ListMonAn.ListFoodDetail(id);
                    if (IsNotNull(listmonan) == true)
                    {
                        ViewBag.listdetailfood = listmonan;
              
                    }
                    else
                    {
                    return RedirectToAction("index", "Menu");
                    }
                    return View();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
        }
        public bool IsNotNull(List<MonAn> ma)
        {
            if (ma.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}