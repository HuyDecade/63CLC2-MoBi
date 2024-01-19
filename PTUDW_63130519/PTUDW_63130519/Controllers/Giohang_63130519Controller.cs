using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
using PTUDW_63130519.Library;

namespace PTUDW_63130519.Controllers
{
    public class Giohang_63130519Controller : Controller
    {
        ProductsDAO productsDAO = new ProductsDAO();
        XCart xcart = new XCart();
        // GET: Cart
        public ActionResult Index()
        {
            //da co thong tin trong gio hang, lay thong tin cua session -> ep  kieu ve list 
            List<CartItem> list = xcart.GetCart();
            return View("Index", list);
        }

        //////////////////////////////////////////////////////////////////
        ///Them vao gio hang
        public ActionResult AddCart(int productid)
        {
            Products_63130519 products = productsDAO.getRow(productid);
            CartItem cartitem = new CartItem(products.Id, products.Name, products.Img, products.Price, 1);
            //Them vao gio hang voi danh sách list phan tu = Session = MyCart
            XCart xcart = new XCart();
            List<CartItem> list = xcart.AddCart(cartitem, productid);
            //chuyen huong trang
            return RedirectToAction("Index", "Giohang_63130519");
        }

        //////////////////////////////////////////////////////////////////
        ///DelCart
        public ActionResult CartDel(int productid)
        {
            xcart.DelCart(productid);
            return RedirectToAction("Index", "Giohang_63130519");
        }

        //////////////////////////////////////////////////////////////////
        ///CartUpdate
        public ActionResult CartUpdate(FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["capnhat"]))//nut ThemCategory duoc nhan
            {
                var listamount = form["amount"];
                //chuyen danh sach thanh dang mang: vi du 1,2,3,...
                var listarr = listamount.Split(',');//cat theo dau ,
                xcart.UpdateCart(listarr);
            }
            return RedirectToAction("Index", "Giohang_63130519");
        }

        //////////////////////////////////////////////////////////////////
        ///CartUpdate
        public ActionResult CartDelAll()
        {
            xcart.DelCart();
            return RedirectToAction("Index", "Giohang_63130519");
        }

        //////////////////////////////////////////////////////////////////
        ///ThanhToan
        public ActionResult ThanhToan()
        {
            //Kiem tra thong tin dang nhap trang nguoi dung = Khach hang
            if (Session["UserCustomer"].Equals(""))
            {
                return Redirect("~/dang-nhap");//chuyen huong den URL
            }
            return View("ThanhToan");
        }
    }
}