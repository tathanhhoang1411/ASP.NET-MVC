using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB2.Draw;
using WEB2.Models;
namespace WEB2.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XuLySignUp(TaiKhoan model)
        {
            var taikhoan = new TaiKhoanDraw();
            taikhoan.XuLySignUp(model);
            return RedirectToAction("index", "Menu");
        }
    }
}