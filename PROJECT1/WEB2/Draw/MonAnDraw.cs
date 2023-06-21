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
        public List<MonAn> ListMonAn()
        {
          
            return db.MonAns.Where(m => m.TrangThai == 1).ToList();
        }
        public List<MonAn> ListItemFood(int Id)
        {
            return db.MonAns.Where(m => m.IdLoaiMonAn ==Id).ToList();
        }
      
    }
}