using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class MenusDAO
    {
        private MyDBContext_63130519 db = new MyDBContext_63130519();
        //Hien thi danh sach toan bo Loai san pham: SELCT * FROM
        public List<Menus_63130519> getList(string status = "All")
        {
            List<Menus_63130519> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Menus.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Menus.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Menus.ToList();
                        break;
                    }
            }
            return list;
        }
        //Hien thi danh sach thoa 2 dieu kien cho tran nguoi dung
        public List<Menus_63130519> getListByParentId(int parentid, string position)
        {
            return db.Menus.Where(m => m.ParentID == parentid && m.Status == 1 && m.Position == position).OrderBy(m => m.Order).ToList();
        }
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Menus_63130519 getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Menus.Find(id);
            }
        }

        ///Them moi mot mau tin
        public int Insert(Menus_63130519 row)
        {
            db.Menus.Add(row);
            return db.SaveChanges();
        }

        ///Cap nhat mot mau tin
        public int Update(Menus_63130519 row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        ///Xoa mot mau tin Xoa ra khoi CSDL
        public int Delete(Menus_63130519 row)
        {
            db.Menus.Remove(row);
            return db.SaveChanges();
        }
    }
}