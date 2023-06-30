using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Models;
namespace WEB2.Draw
{
    public class GioHangDraw
    {
        NhaHang_Entities1 db = new NhaHang_Entities1();
        public void TaoGioHang(GioHang giohang)
        {

            db.GioHangs.Add(giohang);
            db.SaveChanges();
        }
    }
}