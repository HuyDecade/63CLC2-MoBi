using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class CategoriesDAO
    {
        private MyDBContext_63130519 db = new MyDBContext_63130519();

        //SELECT * FROM ...
        public List<Categories_63130519> getList()
        {
            return db.Caregories.ToList();
        }
        public List<Categories_63130519> getListByPareantId(int parentid = 0)
        {
            return db.Caregories.Where(m => m.ParentID == parentid && m.Status == 1).OrderBy(m => m.Order).ToList();
        }
        //Select * from cho Index chi voi status 1,2
        public List<Categories_63130519> getList(string status = "ALL")//status = 0,1,2
        {
            List<Categories_63130519> list = null;
            switch (status)
            {
                case "Index"://1,2
                    {
                        list = db.Caregories.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash"://0
                    {
                        list = db.Caregories.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Caregories.ToList();
                        break;
                    }
            }
            return list;
        }

        //Details
        public Categories_63130519 getRow(int? id)
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                return db.Caregories.Find(id);
            }
        }

        //Hien thi danh sach 1 mau tin (ban ghi) voi kieu string = slug
        public Categories_63130519 getRow(string slug)
        {

            return db.Caregories.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
        }

        //Tao moi mau tin
        public int Insert(Categories_63130519 row)
        {
            db.Caregories.Add(row);
            return db.SaveChanges();
        }

        //Cap nhat mau tin
        public int Update(Categories_63130519 row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        //Xoa mau tin
        public int Delete(Categories_63130519 row)
        {
            db.Caregories.Remove(row);
            return db.SaveChanges();
        }
    }
}
