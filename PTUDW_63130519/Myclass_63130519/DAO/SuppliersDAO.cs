using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class SuppliersDAO
    {
            //Copy noi dung cua class CATEGORIES, thay the Categories bang Suppliers
            private MyDBContext_63130519 db = new MyDBContext_63130519();

            //INDEX
            public List<Suppliers_63130519> getList()
            {
                return db.Suppliers.ToList();
            }

            //INDEX chi voi staus 1,2        
            public List<Suppliers_63130519> getList(string status = "ALL")//status 0,1,2
            {
                List<Suppliers_63130519> list = null;
                switch (status)
                {
                    case "Index"://1,2
                        {
                            list = db.Suppliers.Where(m => m.Status != 0).ToList();
                            break;
                        }
                    case "Trash"://0
                        {
                            list = db.Suppliers.Where(m => m.Status == 0).ToList();
                            break;
                        }
                    default:
                        {
                            list = db.Suppliers.ToList();
                            break;
                        }
                }
                return list;
            }
            //DETAIL
            public Suppliers_63130519 getRow(int? id)
            {
                if (id == null)
                {
                    return null;
                }
                else
                {
                    return db.Suppliers.Find(id);
                }
            }

            //INSERT
            public int Insert(Suppliers_63130519 row)
            {
                db.Suppliers.Add(row);
                return db.SaveChanges();
            }

            //EDIT
            public int Update(Suppliers_63130519 row)
            {
                db.Entry(row).State = EntityState.Modified;
                return db.SaveChanges();
            }

            //DELETE
            public int Delete(Suppliers_63130519 row)
            {
                db.Suppliers.Remove(row);
                return db.SaveChanges();
            }
    }
}
