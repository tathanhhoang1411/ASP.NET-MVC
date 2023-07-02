using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Models;
namespace WEB2.Draw
{
    public class ChiTietGioHangDraw
    {
        NhaHang_Entities1 db = new NhaHang_Entities1();
        public List<ChiTietGioHang> ListChiTietGioHang( string  sdt)
        {
            var query =

                             (from ctgh in db.ChiTietGioHangs

                              join gh in db.GioHangs on ctgh.ID_GioHang equals gh.ID
                              join ma in db.MonAns on ctgh.ID_MonAn equals ma.IdMonAn
                              where gh.SDT == sdt
                              orderby ctgh.ThayDoiCuoiCung
                              select ctgh) ;
            return query.ToList();

        }
    }
}