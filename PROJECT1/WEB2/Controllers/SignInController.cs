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
            if (Session["usr"] != null)//đã đăng nhập thi tra ve view menu
            {
                return RedirectToAction("index", "Menu");
            }
            else//chưa đăng nhập
            {
                return View();
            }
         
        }
        [HttpPost]
        public ActionResult XuLySignIn(string SDT, string MatKhau)
        {
            if (SDT!="" && MatKhau != "")/* có điền vào ô  SDT, mat khẩu*/
            {
          
                    var taikhoan = new TaiKhoanDraw();
                    var listtaikhoan = taikhoan.XuLySignIn(SDT, MatKhau);
                    if (listtaikhoan.Count == 1)/* nếu điền đúng TK */
                    {
                    Session.Timeout = 60;
                    Session["usr"] = listtaikhoan[0].SDT;
                  
                    Session["avt"] = listtaikhoan[0].Avatar;
                    return RedirectToAction("index", "Menu");
                    }
                    else
                    {
                        ModelState.AddModelError("", "NoCorrect account or password");
                        return View("Index");
                    }
  
            }
            else/* ko điền vào ô  SDT, mật khẩu*/
            {
                ModelState.AddModelError("", "Don't leave fields blank!");
                if (SDT == "")
                {
 
                    ModelState.AddModelError("SDT", "Fill in the Phone Number .box");
           
                }
                if (MatKhau == "")
                {

                    ModelState.AddModelError("MatKhau", "Fill in the Password .box");

                }
                return View("index");
            }
        }
    }
}