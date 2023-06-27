using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Models;
namespace WEB2.Draw
{
    public class MonAnDraw
    {
        public NhaHang_Entities1 db = new NhaHang_Entities1();
       public  List<MonAn> ListMonAn()
        {
            return db.MonAns.Where(m => m.TrangThai == 1).OrderBy(m=>m.TenMonAn).ToList();
        }
        public List<MonAn> ListItemFood(string loaimonan)
        {

            var query = (from monan in db.MonAns
                         join cate in db.Categories on monan.IdLoaiMonAn equals cate.ID
                         where cate.LoaiMonAn ==loaimonan
                         orderby monan.TenMonAn 
                         select monan
                         );
            return query.ToList();
        }
        public List<MonAn> ListFoodDetail(string tenmonan)
        {
            var query = (from monan in db.MonAns
                         join cate in db.Categories on monan.IdLoaiMonAn equals cate.ID
                         where monan.TenMonAn ==tenmonan
                         orderby monan.TenMonAn
                         select monan
                        );
            return query.ToList();
        }


    }
}