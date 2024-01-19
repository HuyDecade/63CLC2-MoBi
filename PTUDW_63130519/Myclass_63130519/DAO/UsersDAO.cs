using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    public class UsersDAO
    {
        private MyDBContext_63130519 db = new MyDBContext_63130519();
        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo Loai san pham: SELCT * FROM
        public List<Users_63130519> getList(string status = "All")
        {
            List<Users_63130519> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Users.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Users.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Users.ToList();
                        break;
                    }
            }
            return list;
        }
        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Users_63130519 getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Users.Find(id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Kiem tra thong tin dang nhap
        public Users_63130519 getRow(string username, string role)
        {

            return db.Users.Where(m => m.Status == 1 && m.Role == "role" && (m.Username == username || m.Email == username))
            .FirstOrDefault();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Them moi mot mau tin
        public int Insert(Users_63130519 row)
        {
            db.Users.Add(row);
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Cap nhat mot mau tin
        public int Update(Users_63130519 row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Xoa mot mau tin Xoa ra khoi CSDL
        public int Delete(Users_63130519 row)
        {
            db.Users.Remove(row);
            return db.SaveChanges();
        }
    }
}