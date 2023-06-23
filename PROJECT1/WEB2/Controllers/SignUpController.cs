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
        [HttpPost]
        public ActionResult XuLySignUp(TaiKhoan model, string rpw)
        {
            if (ModelState.IsValid 
                && model.DiaChi != null && model.Email != null
                && model.MatKhau != null && model.SDT != null)/* người dùng có nhập các ô */
            {
                var taikhoan = new TaiKhoanDraw();
                if (taikhoan.IsNotSDT(model.SDT.Trim()) && model.SDT.Trim().Length >=10 && taikhoan.IsNumber(model.SDT.Trim()))
                    /*Nếu không tồn tại SDT này (Nghĩa là không trùng khóa chính), chuỗi dài hơn 10, là chuỗi số*/
                {
       
                   if(model.MatKhau.Trim()==rpw.Trim())
                    {
                       if(model.DiaChi.Trim().Length>=20)
                        {
                            model.LoaiTK = 2;/* loại tài khoản bàng 2 thì là tài khoản của khách hàng*/
                            model.TrangThai = 1;/*trạng thái bằng 1 là tài khoản có thể sử dụng */
                            taikhoan.XuLySignUp(model);
                            return RedirectToAction("index", "Menu");
                        }
                        else
                        {
                            ModelState.AddModelError("DiaChi", "'Address' must have more than 20 characters");
                            return View("index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("MatKhau", "2 Passwords do not match!");
                        return View("index");
                    }
                }
                else/*Nếu có  tồn tại SDT này (Nghĩa là  trùng khóa chính), độ dài chuỗi bé hơn 10, không là chuối số */
                {
                    ModelState.AddModelError("SDT", "Account already exists, Invalid phone number, or it's not phone number!");
                    return View("index");
                }
               
            }
            else{
                ModelState.AddModelError("", "Don't leave fields blank!");
                return View("index");
            }
        }
    }
}