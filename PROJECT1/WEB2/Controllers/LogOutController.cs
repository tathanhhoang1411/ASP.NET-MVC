using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB2.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XuLyLogOut()
        {
            Session["usr"] = null;// khi người dùng bấm logout sẽ gọi đến method XuLyLogOut và xóa session
            Session["avt"] = null;
            return RedirectToAction("index", "SignIn");
        }

    }
}