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

        public ActionResult ByIDMonAn(int  a)//truyền vào a là Id_monan kiểu int 
        {
            if (Session["usr"] == null)//chưa đăng nhập
            {
                return RedirectToAction("index", "SignIn");
            }
            else//người dùng đã đăng nhập
            {
                if(a<= 2147483647 && a>=0)
                {
                    string sdt = (string)Session["usr"];
                    var ctgh = new ChiTietGioHangDraw();
                    ViewBag.listchitietgiohang = ctgh.ListChiTietGioHang(sdt.Trim());
                }
                else
                {
                    return RedirectToAction("index", "Menu");
                }
             
            }

                return View();
            }
        public ActionResult BySDT(string  a)//truyền vào a là sdt kiểu string
        {
            if (Session["usr"] == null)//chưa đăng nhập
            {
                return RedirectToAction("index", "SignIn");
            }
            else//người dùng đã đăng nhập
            {
                string sdt = (string)Session["usr"];

                var ctgh = new ChiTietGioHangDraw();
                ViewBag.listchitietgiohang = ctgh.ListChiTietGioHang(sdt.Trim());
            }

            return View();
        }


    }
}