using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class TopicsDAO
    {
        private MyDBContext_63130519 db = new MyDBContext_63130519();
        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo Loai san pham: SELCT * FROM
        public List<Topics_63130519> getList(string status = "All")
        {
            List<Topics_63130519> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Topics.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Topics.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Topics.ToList();
                        break;
                    }
            }
            return list;
        }
        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Topics_63130519 getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Topics.Find(id);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////
        ///Them moi mot mau tin
        public int Insert(Topics_63130519 row)
        {
            db.Topics.Add(row);
            return db.SaveChanges();
        }
        /////////////////////////////////////////////////////////////////////////////////////
        ///Cap nhat mot mau tin
        public int Update(Topics_63130519 row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        /////////////////////////////////////////////////////////////////////////////////////
        ///Xoa mot mau tin Xoa ra khoi CSDL
        public int Delete(Topics_63130519 row)
        {
            db.Topics.Remove(row);
            return db.SaveChanges();
        }
    }
}
