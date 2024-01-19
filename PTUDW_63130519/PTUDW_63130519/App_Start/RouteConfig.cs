﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PTUDW_63130519
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Khai bao cho URL co dinh: tat-ca-san-pham
            routes.MapRoute(
               name: "Tatcasanpham",
               url: "tat-ca-san-pham",
               defaults: new { controller = "Site_63130519", action = "Product2", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: tat-ca-bai-viet
            routes.MapRoute(
               name: "Tatcabaiviet",
               url: "tat-ca-bai-viet",
               defaults: new { controller = "Site_63130519", action = "Post", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: lien-he
            routes.MapRoute(
               name: "Lienhe",
               url: "lien-he",
               defaults: new { controller = "Lienhe_63130519", action = "Index", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: gio-hang
            routes.MapRoute(
               name: "Giohang",
               url: "gio-hang",
               defaults: new { controller = "Giohang_63130519", action = "Index", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: thanh-toan
            routes.MapRoute(
               name: "Thanhtoan",
               url: "thanh-toan",
               defaults: new { controller = "Giohang_63130519", action = "ThanhToan", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: dăng-nhap
            routes.MapRoute(
               name: "DangNhap",
               url: "dang-nhap",
               defaults: new { controller = "Khachhang_63130519", action = "DangNhap", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: tim-kiem
            routes.MapRoute(
               name: "Timkiem",
               url: "tim-kiem",
               defaults: new { controller = "Timkiem_63130519", action = "Index", id = UrlParameter.Optional }
           );

            //khai bao cho URL dong
            routes.MapRoute(
              name: "Siteslug",
              url: "{slug}",
              defaults: new { controller = "Site_63130519", action = "Index", id = UrlParameter.Optional }
          );

            //gia tri mac dinh
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site_63130519", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}