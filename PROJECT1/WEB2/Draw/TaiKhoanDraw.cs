using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Models;

namespace WEB2.Draw
{
   
    public class TaiKhoanDraw
    {
        public NhaHang_Entities1 db = new NhaHang_Entities1();

        public List<TaiKhoan> XuLySignIn(String SDT, string MatKhau)
        {
            return db.TaiKhoans.Where(m => m.SDT == SDT.Trim() && m.MatKhau==MatKhau.Trim()).ToList();
        }
        public bool IsNumber(string sdt)
        {
            foreach (Char c in sdt)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsNotSDT(string sdt)
        {
            var listSDT = (from taikhoan in db.TaiKhoans
                         where taikhoan.SDT == sdt
                         select taikhoan).ToList();
            if(listSDT.Count==0)
             {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void XuLySignUp(TaiKhoan taikhoan)
        {

            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();
        }
    }
}