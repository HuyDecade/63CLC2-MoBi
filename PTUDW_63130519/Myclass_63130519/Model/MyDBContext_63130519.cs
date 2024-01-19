using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    public class MyDBContext_63130519: DbContext
    {
        public MyDBContext_63130519() : base("name = StrConnect") { }
        public DbSet<Categories_63130519> Caregories { get; set; }
        public DbSet<Contacts_63130519> Contacts { get; set; }
        public DbSet<Links_63130519> Links { get; set; }
        public DbSet<Menus_63130519> Menus { get; set; }
        public DbSet<OrderDetails_63130519> OrderDetails { get; set; }
        public DbSet<Orders_63130519> Orders { get; set; }
        public DbSet<Posts_63130519> Posts { get; set; }
        public DbSet<Products_63130519> Products { get; set; }
        public DbSet<Sliders_63130519> Sliders { get; set; }
        public DbSet<Suppliers_63130519> Suppliers { get; set; }
        public DbSet<Topics_63130519> Topics { get; set; }
        public DbSet<Users_63130519> Users { get; set; }
    }
}
