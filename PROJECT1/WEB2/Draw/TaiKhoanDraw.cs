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
        public bool Istrue()
        {
            
            return true;
        }
        public List<TaiKhoan> XuLySignIn(String SDT, string MatKhau)
        {
            return db.TaiKhoans.Where(m => m.SDT == SDT.Trim() && m.MatKhau==MatKhau.Trim()).ToList();
        }
    }
}