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
        public ActionResult XuLySignUp(TaiKhoan model, string rpw, HttpPostedFileBase avatar)
        {
            if (ModelState.IsValid 
                && model.DiaChi != null && model.Email != null
                && model.MatKhau != null && model.SDT != null
                && model.Avatar!=null )/* người dùng có nhập các ô */
            {
                var taikhoan = new TaiKhoanDraw();
                if (taikhoan.IsNotSDT(model.SDT.Trim()) && model.SDT.Trim().Length==10  && taikhoan.IsNumber(model.SDT.Trim()))
                    /*Nếu không tồn tại SDT này (Nghĩa là không trùng khóa chính), chuỗi dài 10, là chuỗi số*/
                {
       
                   if(model.MatKhau.Trim()==rpw.Trim())
                    {
                       if(model.DiaChi.Trim().Length>=10)
                        {
                            if (avatar.ContentLength > 0)/*nghĩa là đã chọn file */
                            {
                                model.LoaiTK = 2;/* loại tài khoản bàng 2 thì là tài khoản của khách hàng*/
                                model.TrangThai = 1;/*trạng thái bằng 1 là tài khoản có thể sử dụng */
                               //Xử lí lưu ảnh 
                                //B1: Xử lí Lưu file ảnh 
                                string rootFile = Server.MapPath("/Data");
                                string pathFile = rootFile + avatar.FileName;
                                avatar.SaveAs(pathFile);
                                //B2: lưu thuộc tính url hình ảnh
                                model.Avatar = "/Data/" + avatar.FileName;
                                taikhoan.XuLySignUp(model);
                                return RedirectToAction("index", "Menu");
                            }
                            else
                            {
                                ModelState.AddModelError("avatar", "Add file image!");
                                return View("index");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("DiaChi", "'Address' must have more than 10 characters");
                            return View("index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("MatKhau", "2 Passwords do not match!");
                        return View("index");
                    }
                }
                else/*Nếu có  tồn tại SDT này (Nghĩa là  trùng khóa chính), độ dài chuỗi Khác  10, không là chuối số */
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