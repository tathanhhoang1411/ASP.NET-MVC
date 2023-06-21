using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB2.Models;
namespace WEB2.Draw
{
    public class CategoryDraw
    {
        public NhaHang_Entities1 db = new NhaHang_Entities1();
        public List<Category> ListCategory()
        {
            return db.Categories.Where(m => m.TrangThai == 1).ToList();
        }
       
    }
}