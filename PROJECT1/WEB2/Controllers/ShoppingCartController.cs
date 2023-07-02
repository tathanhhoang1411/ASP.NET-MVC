using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Draw;
using WEB2.Models;
using System.Web.Mvc;

namespace WEB2.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index(int  a)//a là Id_monan
        {
            if (Session["usr"] == null)
            {
                return RedirectToAction("index", "SignIn");
            }
            else
            {
                string  sdt = (string)Session["usr"];
                var ctgh = new ChiTietGioHangDraw();
                ViewBag.listgiohang=ctgh.ListChiTietGioHang(sdt );
                return View();
            }
          
        }
    }
}