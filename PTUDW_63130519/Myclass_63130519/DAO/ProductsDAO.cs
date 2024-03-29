﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    public class ProductsDAO
    {
        private MyDBContext_63130519 db = new MyDBContext_63130519();

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo san pham theo tung Categories (catid)
        public List<Products_63130519> getListByCatId(int catid, int limit)
        {
            List<Products_63130519> list = db.Products.Where(m => m.CatId == catid && m.Status == 1).Take(limit).OrderByDescending(m => m.CreateBy).ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo san pham theo tung Categories (catid)
        //danh cho trang HOME
        public List<ProductInfo_63130519> getListByListCatId(List<int> listcatid, int limit)
        {
            List<ProductInfo_63130519> list = db.Products
                .Join(
                                db.Caregories, // Bảng Categories
                                p => p.CatId, // Khóa ngoại của Products liên kết với Categories
                                c => c.Id, // Khóa chính của Categories
                                (p, c) => new { Product = p, Category = c } // Kết hợp Products và Categories
                            )
                            .Join(
                                db.Suppliers, // Bảng Suppliers
                                pc => pc.Product.SupplierId, // Khóa ngoại của Product/Category liên kết với Suppliers
                                s => s.Id, // Khóa chính của Suppliers
                                (pc, s) => new ProductInfo_63130519
                                {
                                    Id = pc.Product.Id,
                                    CatID = pc.Product.CatId,
                                    Name = pc.Product.Name,
                                    CatName = pc.Category.Name, // Lấy tên danh mục từ bảng Categories
                                    SupplierId = pc.Product.SupplierId,
                                    SupplierName = s.Name, // Lấy tên nhà cung cấp từ bảng Suppliers
                                    Slug = pc.Product.Slug,
                                    Image = pc.Product.Img,
                                    Price = pc.Product.Price,
                                    SalePrice = pc.Product.SalePrice,
                                    Amount = pc.Product.Qty,
                                    MetaDesc = pc.Product.MetaDesc,
                                    MetaKey = pc.Product.MetaKey,
                                    CreateBy = pc.Product.CreateBy,
                                    CreateAt = pc.Product.CreateAt,
                                    UpdateBy = pc.Product.UpdateBy,
                                    UpdateAt = pc.Product.UpdateAt,
                                    Status = pc.Product.Status
                                }
                            ).Where(m => m.Status == 1 && listcatid.Contains(m.CatID)).Take(limit).OrderByDescending(m => m.CreateBy).ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo san pham dua vao limit so mau tin
        //danh cho trang HOME
        public List<ProductInfo_63130519> getListBylimit(int limit)
        {
            List<ProductInfo_63130519> list = db.Products
                .Join(
                                db.Caregories, //Bang Categories
                                p => p.CatId, //Khoa ngoai cua Products lien ket voi Categories
                                c => c.Id, //Khoa chinh cua Categories
                                (p, c) => new { Product = p, Category = c } //Join Products va Categories
                            )
                            .Join(
                                db.Suppliers, //Bang Suppliers
                                pc => pc.Product.SupplierId, //Khoa ngoai cua Product lien ket voi Suppliers
                                s => s.Id, //Khoa chinh cua Suppliers
                                (pc, s) => new ProductInfo_63130519
                                {
                                    Id = pc.Product.Id,
                                    CatID = pc.Product.CatId,
                                    Name = pc.Product.Name,
                                    CatName = pc.Category.Name, //Lay Name tu Categories
                                    SupplierId = pc.Product.SupplierId,
                                    SupplierName = s.Name, //Lay ten NCC tu bang Suppliers
                                    Slug = pc.Product.Slug,
                                    Image = pc.Product.Img,
                                    Price = pc.Product.Price,
                                    SalePrice = pc.Product.SalePrice,
                                    Amount = pc.Product.Qty,
                                    MetaDesc = pc.Product.MetaDesc,
                                    MetaKey = pc.Product.MetaKey,
                                    CreateBy = pc.Product.CreateBy,
                                    CreateAt = pc.Product.CreateAt,
                                    UpdateBy = pc.Product.UpdateBy,
                                    UpdateAt = pc.Product.UpdateAt,
                                    Status = pc.Product.Status
                                }
                            ).Where(m => m.Status == 1).Take(limit).OrderByDescending(m => m.CreateBy).ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach toan bo Loai san pham: SELCT * FROM
        //danh cho trang Quan tri
        public List<ProductInfo_63130519> getList(string status = "All")
        {
            List<ProductInfo_63130519> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Products
                            .Where(p => p.Status != 0)
                            .Join(
                                db.Caregories, // Bảng Categories
                                p => p.CatId, // Khóa ngoại của Products liên kết với Categories
                                c => c.Id, // Khóa chính của Categories
                                (p, c) => new { Product = p, Category = c } // Kết hợp Products và Categories
                            )
                            .Join(
                                db.Suppliers, // Bảng Suppliers
                                pc => pc.Product.SupplierId, // Khóa ngoại của Product/Category liên kết với Suppliers
                                s => s.Id, // Khóa chính của Suppliers
                                (pc, s) => new ProductInfo_63130519
                                {
                                    Id = pc.Product.Id,
                                    CatID = pc.Product.CatId,
                                    Name = pc.Product.Name,
                                    CatName = pc.Category.Name, // Lấy tên danh mục từ bảng Categories
                                    SupplierId = pc.Product.SupplierId,
                                    SupplierName = s.Name, // Lấy tên nhà cung cấp từ bảng Suppliers
                                    Slug = pc.Product.Slug,
                                    Image = pc.Product.Img,
                                    Price = pc.Product.Price,
                                    SalePrice = pc.Product.SalePrice,
                                    Amount = pc.Product.Qty,
                                    MetaDesc = pc.Product.MetaDesc,
                                    MetaKey = pc.Product.MetaKey,
                                    CreateBy = pc.Product.CreateBy,
                                    CreateAt = pc.Product.CreateAt,
                                    UpdateBy = pc.Product.UpdateBy,
                                    UpdateAt = pc.Product.UpdateAt,
                                    Status = pc.Product.Status
                                }
                            ).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Products
                            .Where(p => p.Status == 0)
                            .Join(
                                db.Caregories, // Bảng Categories
                                p => p.CatId, // Khóa ngoại của Products liên kết với Categories
                                c => c.Id, // Khóa chính của Categories
                                (p, c) => new { Product = p, Category = c } // Kết hợp Products và Categories
                            )
                            .Join(
                                db.Suppliers, // Bảng Suppliers
                                pc => pc.Product.SupplierId, // Khóa ngoại của Product/Category liên kết với Suppliers
                                s => s.Id, // Khóa chính của Suppliers
                                (pc, s) => new ProductInfo_63130519
                                {
                                    Id = pc.Product.Id,
                                    CatID = pc.Product.CatId,
                                    Name = pc.Product.Name,
                                    CatName = pc.Category.Name, // Lấy tên danh mục từ bảng Categories
                                    SupplierId = pc.Product.SupplierId,
                                    SupplierName = s.Name, // Lấy tên nhà cung cấp từ bảng Suppliers
                                    Slug = pc.Product.Slug,
                                    Image = pc.Product.Img,
                                    Price = pc.Product.Price,
                                    SalePrice = pc.Product.SalePrice,
                                    Amount = pc.Product.Qty,
                                    MetaDesc = pc.Product.MetaDesc,
                                    MetaKey = pc.Product.MetaKey,
                                    CreateBy = pc.Product.CreateBy,
                                    CreateAt = pc.Product.CreateAt,
                                    UpdateBy = pc.Product.UpdateBy,
                                    UpdateAt = pc.Product.UpdateAt,
                                    Status = pc.Product.Status
                                }
                            ).ToList();
                        break;
                    }
                // Các trường hợp khác xử lý tương tự
                default:
                    {
                        list = db.Products
                            .Join(
                                db.Caregories,
                                p => p.CatId,
                                c => c.Id,
                                (p, c) => new { Product = p, Category = c }
                            )
                            .Join(
                                db.Suppliers,
                                pc => pc.Product.SupplierId,
                                s => s.Id,
                                (pc, s) => new ProductInfo_63130519
                                {
                                    Id = pc.Product.Id,
                                    CatID = pc.Product.CatId,
                                    Name = pc.Product.Name,
                                    CatName = pc.Category.Name,
                                    SupplierId = pc.Product.SupplierId,
                                    SupplierName = s.Name,
                                    Slug = pc.Product.Slug,
                                    Image = pc.Product.Img,
                                    Price = pc.Product.Price,
                                    SalePrice = pc.Product.SalePrice,
                                    Amount = pc.Product.Qty,
                                    MetaDesc = pc.Product.MetaDesc,
                                    MetaKey = pc.Product.MetaKey,
                                    CreateBy = pc.Product.CreateBy,
                                    CreateAt = pc.Product.CreateAt,
                                    UpdateBy = pc.Product.UpdateBy,
                                    UpdateAt = pc.Product.UpdateAt,
                                    Status = pc.Product.Status
                                }
                            ).ToList();
                        break;
                    }
            }
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Products_63130519 getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Products.Find(id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Products_63130519 getRow(string slug)
        {

            return db.Products.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Them moi mot mau tin
        public int Insert(Products_63130519 row)
        {
            db.Products.Add(row);
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Cap nhat mot mau tin
        public int Update(Products_63130519 row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Xoa mot mau tin Xoa ra khoi CSDL
        public int Delete(Products_63130519 row)
        {
            db.Products.Remove(row);
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Chi tiet san pham
        ///Trang giao dien chi tiet san pham
        public List<ProductInfo_63130519> GetProductDetailBySlug(string slug)
        {
            List<ProductInfo_63130519> list = null;
            list = db.Products
                .Where(p => p.Slug == slug && p.Status == 1)
                .Join(
                    db.Caregories,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new { Product = p, Category = c }
                )
                .Join(
                    db.Suppliers,
                    pc => pc.Product.SupplierId,
                    s => s.Id,
                    (pc, s) => new ProductInfo_63130519
                    {
                        Id = pc.Product.Id,
                        CatID = pc.Product.CatId,
                        Name = pc.Product.Name,
                        CatName = pc.Category.Name,
                        SupplierId = pc.Product.SupplierId,
                        SupplierName = s.Name,
                        Slug = pc.Product.Slug,
                        Image = pc.Product.Img,
                        Price = pc.Product.Price,
                        SalePrice = pc.Product.SalePrice,
                        Amount = pc.Product.Qty,
                        MetaDesc = pc.Product.MetaDesc,
                        MetaKey = pc.Product.MetaKey,
                        CreateBy = pc.Product.CreateBy,
                        CreateAt = pc.Product.CreateAt,
                        UpdateBy = pc.Product.UpdateBy,
                        UpdateAt = pc.Product.UpdateAt,
                        Status = pc.Product.Status,
                        //bo sung truong Slug cua Categories
                        CategorySlug = pc.Category.Slug
                    }
                ).ToList();
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Hien thi danh sach cac san pham cung loai
        ///Trang giao dien chi tiet san pham
        public List<ProductInfo_63130519> GetProductDetailByCategoryId(int catid)
        {
            var relatedProducts = db.Products
                .Where(p => p.CatId == catid && p.Status == 1)
                .Join(
                    db.Caregories,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new { Product = p, Category = c }
                )
                .Join(
                    db.Suppliers,
                    pc => pc.Product.SupplierId,
                    s => s.Id,
                    (pc, s) => new ProductInfo_63130519
                    {
                        Id = pc.Product.Id,
                        CatID = pc.Product.CatId,
                        Name = pc.Product.Name,
                        CatName = pc.Category.Name,
                        SupplierId = pc.Product.SupplierId,
                        SupplierName = s.Name,
                        Slug = pc.Product.Slug,
                        Image = pc.Product.Img,
                        Price = pc.Product.Price,
                        SalePrice = pc.Product.SalePrice,
                        Amount = pc.Product.Qty,
                        MetaDesc = pc.Product.MetaDesc,
                        MetaKey = pc.Product.MetaKey,
                        CreateBy = pc.Product.CreateBy,
                        CreateAt = pc.Product.CreateAt,
                        UpdateBy = pc.Product.UpdateBy,
                        UpdateAt = pc.Product.UpdateAt,
                        Status = pc.Product.Status
                    }
                ).ToList();

            return relatedProducts;
        }

    }
}