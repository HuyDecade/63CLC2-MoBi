using PTUDW_63130519;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.Serialization;

namespace PTUDW_63130519
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            //Luu Ma nguoi dang nhap quan ly
            Session["UserID"] = "1";
            //Gio hang
            Session["MyCart"] = "";//khoi tao gia tri = NULL
            //Luu Thong tin dang nhap cua nguoi dung
            Session["UserCustomer"] = "";
        }
    }
}