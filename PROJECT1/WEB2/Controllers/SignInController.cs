using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Draw;
using WEB2.Models;
namespace WEB2.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XuLySignIn(string SDT, string MatKhau)
        {
           if(ModelState.IsValid==true)
            {
                var taikhoan = new TaiKhoanDraw();
                var listtaikhoan = taikhoan.XuLySignIn(SDT, MatKhau);
                if (listtaikhoan.Count == 1)
                {
                    return RedirectToAction("index", "Menu");
                }
                else
                {
                    return RedirectToAction("index","SignIn");
                }
            }
            else
            {
                ModelState.AddModelError("", "Fill Form, please!");
                return View(SDT, MatKhau);
            }
         
        }
    }
}