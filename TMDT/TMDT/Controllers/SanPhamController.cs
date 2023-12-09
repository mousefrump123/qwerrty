﻿using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TMDT.Models;
using TMDT.Patterns.Interfaces;

namespace TMDT.Controllers
{
    public class SanPhamController : Controller
    {
        TMDTEntities db = new TMDTEntities();
        
        // GET: SanPham
        public ActionResult SanPham(int? size, int? page, string currentFilter, string searchString)
        {
            
            SANPHAM sp = new SANPHAM();
            var email = Session["Email"] as string;
            if (email == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("DangNhap", "Register");
            }

            //MySingleton.Instance.Init(email);
            //var products = MySingleton.Instance.GetSanPhamList();

            //// Thực hiện tìm kiếm nếu có chuỗi tìm kiếm
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products
            //        .Where(p => p.TENSP.Contains(searchString))
            //        .ToList();
            //}

            //// Lưu trạng thái tìm kiếm hiện tại
            //currentFilter = searchString;

            //var pageNumber = page ?? 1;
            //int pageSize = size ?? 10;
            //var pagedVouchers = products
            //    .ToPagedList(pageNumber, pageSize);

            //return View(pagedVouchers);
            // Lấy thông tin của người dùng trong cơ sở dữ liệu
            var nguoidung = db.NGUOIDUNGs.SingleOrDefault(kh => kh.EMAIL == email);
            if (nguoidung != null) // Kiểm tra xem người dùng có tồn tại hay không
            {
                // Lấy thông tin của cửa hàng nếu tồn tại, sau đó lưu ID của cửa hàng vào sản phẩm
                var cuahang = db.CUAHANGs.SingleOrDefault(ch => ch.IDND == nguoidung.IDND);

                if (cuahang != null) // Kiểm tra xem cửa hàng có tồn tại hay không
                {
                    sp.IDCUAHANG = cuahang.IDCUAHANG;
                    // Lấy danh sách sản phẩm theo IDCUAHANG
                    var products = db.SANPHAMs
                        .Where(p => p.IDCUAHANG == sp.IDCUAHANG)
                        .OrderByDescending(p => p.TENSP);

                    // Thực hiện tìm kiếm nếu có chuỗi tìm kiếm
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        products = (IOrderedQueryable<SANPHAM>)products.Where(p => p.TENSP.Contains(searchString));
                    }
                    // Lưu trạng thái tìm kiếm hiện tại
                    currentFilter = searchString;
                    var pageNumber = page ?? 1;
                    int pageSize = size ?? 10;
                    var pagedVouchers = products.ToPagedList(pageNumber, pageSize);
                    return View(pagedVouchers);

                }
            }
            return RedirectToAction("ErrorPage"); // Xử lý khi không tìm thấy cửa hàng hoặc người dùng
        }

        public ActionResult ChonNganhHang()
        {
            LOAISP loaisp = new LOAISP();
            loaisp.ListCate = db.LOAISPs.ToList<LOAISP>();
            return PartialView(loaisp);
        }

        public ActionResult THDienThoai()
        {
            THDIENTHOAI tHDIENTHOAI = new THDIENTHOAI();
            tHDIENTHOAI.ListBrand = db.THDIENTHOAIs.ToList<THDIENTHOAI>();
            return PartialView(tHDIENTHOAI);
        }

        public ActionResult MauSac()
        {
            MAUSAC mausac = new MAUSAC();
            mausac.ListColor = db.MAUSACs.ToList<MAUSAC>();
            return PartialView(mausac);
        }

        public ActionResult THThoiTrang()
        {
            THTHOITRANG tHTHOITRANG = new THTHOITRANG();
            tHTHOITRANG.ListBrands = db.THTHOITRANGs.ToList<THTHOITRANG>();
            return PartialView(tHTHOITRANG);
        }

        public ActionResult SizeThoiTrang()
        {
            SIZETHOITRANG sIZETHOITRANG = new SIZETHOITRANG();
            sIZETHOITRANG.ListSize = db.SIZETHOITRANGs.ToList<SIZETHOITRANG>();
            return PartialView(sIZETHOITRANG);
        }

        public ActionResult THGiay()
        {
            THGIAY tHGIAY = new THGIAY();
            tHGIAY.ListBrands = db.THGIAYs.ToList<THGIAY>();
            return PartialView(tHGIAY);
        }

        public ActionResult SizeGiay()
        {
            SIZEGIAY sIZEGIAY = new SIZEGIAY();
            sIZEGIAY.ListSize = db.SIZEGIAYs.ToList<SIZEGIAY>();
            return PartialView(sIZEGIAY);
        }

        private IProductFactory GetProductFactory(string selectedCategoryId)
        {
            switch (selectedCategoryId)
            {
                case "1":
                    return new DienThoaiFactory();
                case "2":
                    return new ThoiTrangFactory();
                case "3":
                    return new GiayFactory();
                default:
                    return null;
            }
        }

        // GET: SanPham/Create
        public ActionResult TaoSanPham() 
        {
            ViewModelSanPham sp = new ViewModelSanPham();
            return View(sp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoSanPham(ViewModelSanPham model, string selectedCategoryId)
        {
            // Step 1: Get the appropriate product factory based on the selected category
            IProductFactory productFactory = GetProductFactory(selectedCategoryId);

            if (productFactory != null)
            {
                // Step 2: Use the factory to create an instance of the appropriate product
                IProduct product = productFactory.CreateProduct();

                // Step 3: Use the created product as needed
                ViewBag.ProductDescription = product.GetDescription();
            }

            var email = Session["Email"] as string;
            if (email == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Dangnhap", "DNhap");
            }

            // Lấy thông tin của người dùng trong cơ sở dữ liệu
            var nguoidung = db.NGUOIDUNGs.SingleOrDefault(kh => kh.EMAIL == email);

            if (nguoidung != null) // Kiểm tra xem người dùng có tồn tại hay không
            {
                // Lấy thông tin của cửa hàng nếu tồn tại, sau đó lưu ID của cửa hàng vào sản phẩm
                var cuahang = db.CUAHANGs.SingleOrDefault(ch => ch.IDND == nguoidung.IDND);

                if (cuahang != null) // Kiểm tra xem cửa hàng có tồn tại hay không
                {
                    model.SANPHAM.IDCUAHANG = cuahang.IDCUAHANG;
                }
            }
            //// Lưu ảnh vào thư mục ~/Content/Data/Hinh
            if (model.UploadImage1 != null && model.UploadImage2 != null && model.UploadImage3 != null)
            {
                string filename1 = Path.GetFileNameWithoutExtension(model.UploadImage1.FileName);
                string extension1 = Path.GetExtension(model.UploadImage1.FileName);
                filename1 = filename1 + extension1;
                string filename2 = Path.GetFileNameWithoutExtension(model.UploadImage2.FileName);
                string extension2 = Path.GetExtension(model.UploadImage2.FileName);
                filename2 = filename2 + extension2;
                string filename3 = Path.GetFileNameWithoutExtension(model.UploadImage3.FileName);
                string extension3 = Path.GetExtension(model.UploadImage3.FileName);
                filename3 = filename3 + extension3;

                model.SANPHAM.HINHANH1 = "~/Content/Hinh/" + filename1;
                model.SANPHAM.HINHANH2 = "~/Content/Hinh/" + filename2;
                model.SANPHAM.HINHANH3 = "~/Content/Hinh/" + filename3;

                model.UploadImage1.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename1));
                model.UploadImage2.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename2));
                model.UploadImage3.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename3));
            }
                // Kiểm tra giá bán, số lượng tồn và phần trăm giảm
                if (model.SANPHAM.GIABAN >= 0 && model.SANPHAM.SOLUONGTON >= 0 && model.SANPHAM.PHANTRAMGIAM >= 0 && model.SANPHAM.PHANTRAMGIAM <= 100)
                {

                    model.SANPHAM.GIAGIAM = model.SANPHAM.GIABAN - (model.SANPHAM.GIABAN * model.SANPHAM.PHANTRAMGIAM / 100);
                    // Đặt ngày tạo hiện tại
                    model.SANPHAM.NGAYTAO = DateTime.Now;
                    model.SANPHAM.IDPHEDUYET = 1;
                    CTGIAY ct = new CTGIAY();
                    model.CTGIAY = ct;

                    
                    model.SANPHAM.IDLOAISP = Convert.ToInt32(selectedCategoryId);
                

                    string selectedColor = Request.Form["IDMAUSAC"];
                    model.SANPHAM.IDMAUSAC = Convert.ToInt32(selectedColor);

                    string selecteDBrand = Request.Form["IDTHDIENTHOAI"];

                    string selectTTBrand = Request.Form["IDTHTHOITRANG"];

                    string selectGBrand = Request.Form["IDTHGIAY"];

                    string selectSizeTT = Request.Form["IDSIZETT"];
                
                    string selectSizeG = Request.Form["IDSIZEGIAY"];


                // Thêm vào cơ sở dữ liệu dựa trên LoaiSP
                switch (selectedCategoryId)
                    {
                        case "1":
                            model.CTDIENTHOAI.IDLOAISP = Convert.ToInt32(selectedCategoryId);
                            model.CTDIENTHOAI.IDTHDIENTHOAI = Convert.ToInt32(selecteDBrand);
                            db.CTDIENTHOAIs.Add(model.CTDIENTHOAI);
                            int idSANPHAM = model.SANPHAM.IDSANPHAM;
                            model.CTDIENTHOAI.IDSANPHAM = idSANPHAM;
                            break;
                        case "2":
                            model.CTTHOITRANG.IDLOAISP = Convert.ToInt32(selectedCategoryId);
                            model.CTTHOITRANG.IDTHTHOITRANG = Convert.ToInt32(selectTTBrand);
                            model.CTTHOITRANG.IDSIZETT = Convert.ToInt32(selectSizeTT);
                            db.CTTHOITRANGs.Add(model.CTTHOITRANG);
                            int idSANPHAM2 = model.SANPHAM.IDSANPHAM;
                            model.CTTHOITRANG.IDSANPHAM = idSANPHAM2;
                            break;
                        case "3":
                            ct.IDLOAISP = Convert.ToInt32(selectedCategoryId);
                            ct.IDTHGIAY = Convert.ToInt32(selectGBrand);
                            ct.IDSIZEGIAY = Convert.ToInt32(selectSizeG);
                            db.CTGIAYs.Add(model.CTGIAY);
                            int idSANPHAM3 = model.SANPHAM.IDSANPHAM;
                            model.CTGIAY.IDSANPHAM = idSANPHAM3;
                            break;
                        default:
                            // Xử lý mặc định hoặc lỗi nếu có
                            break;
                    }
                    db.SANPHAMs.Add(model.SANPHAM);
                    db.SaveChanges();
                    return RedirectToAction("SanPham");
                }
                else
                {
                    if (model.SANPHAM.GIABAN < 0)
                    {
                        ModelState.AddModelError("GIABAN", "Giá bán phải lớn hơn hoặc bằng 0.");
                    }
                    if (model.SANPHAM.SOLUONGTON < 0)
                    {
                        ModelState.AddModelError("SOLUONGTON", "Số lượng tồn phải lớn hơn hoặc bằng 0.");
                    }
                    if (model.SANPHAM.PHANTRAMGIAM < 0 || model.SANPHAM.PHANTRAMGIAM > 100)
                    {
                        ModelState.AddModelError("PHANTRAMGIAM", "Phần trăm giảm phải trong khoảng từ 0 đến 100.");
                    }
                }

            return View(model);
        }

        public ActionResult CapNhat(int id)
        {
            // Fetch the SANPHAM entity from the database 
            var sanPhamEntity = db.SANPHAMs.Where(s => s.IDSANPHAM == id).FirstOrDefault();
            var ctDienThoai = db.CTDIENTHOAIs.Where(s => s.IDSANPHAM == id).FirstOrDefault();
            var ctThoiTrang = db.CTTHOITRANGs.Where(s => s.IDSANPHAM == id).FirstOrDefault();
            var ctGiay = db.CTGIAYs.Where(s => s.IDSANPHAM == id).FirstOrDefault();

            // Create a ViewModelSanPham object and initialize it with the entity data 
            var viewModel = new ViewModelSanPham
            {
                SANPHAM = sanPhamEntity,
                CTDIENTHOAI = ctDienThoai,
                CTTHOITRANG = ctThoiTrang,
                CTGIAY = ctGiay,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CapNhat(ViewModelSanPham model)
        {

            var email = Session["Email"] as string;
            if (email == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Dangnhap", "DNhap");
            }

            // Lấy thông tin của người dùng trong cơ sở dữ liệu
            var nguoidung = db.NGUOIDUNGs.SingleOrDefault(kh => kh.EMAIL == email);

            if (nguoidung != null) // Kiểm tra xem người dùng có tồn tại hay không
            {
                // Lấy thông tin của cửa hàng nếu tồn tại, sau đó lưu ID của cửa hàng vào sản phẩm
                var cuahang = db.CUAHANGs.SingleOrDefault(ch => ch.IDND == nguoidung.IDND);

                if (cuahang != null) // Kiểm tra xem cửa hàng có tồn tại hay không
                {
                    // Lấy thông tin sản phẩm cần chỉnh sửa
                    var sanpham = db.SANPHAMs.FirstOrDefault(sp => sp.IDSANPHAM == model.SANPHAM.IDSANPHAM && sp.IDCUAHANG == cuahang.IDCUAHANG);

                    if (sanpham != null)
                    {
                        string selectedColor = Request.Form["IDMAUSAC"];

                        string selecteDBrand = Request.Form["IDTHDIENTHOAI"];

                        string selectTTBrand = Request.Form["IDTHTHOITRANG"];

                        string selectGBrand = Request.Form["IDTHGIAY"];

                        string selectSizeTT = Request.Form["IDSIZETT"];

                        string selectSizeG = Request.Form["IDSIZEGIAY"];

                        // Lưu ảnh vào thư mục ~/Content/Images/
                        if (model.UploadImage1 != null)
                        {
                            string filename1 = Path.GetFileNameWithoutExtension(model.UploadImage1.FileName);
                            string extension1 = Path.GetExtension(model.UploadImage1.FileName);
                            filename1 = filename1 + extension1;

                            sanpham.HINHANH1 = "~/Content/Hinh/" + filename1;
                            model.UploadImage1.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename1));
                        }
                        if (model.UploadImage2 != null)
                        {
                            string filename2 = Path.GetFileNameWithoutExtension(model.UploadImage2.FileName);
                            string extension2 = Path.GetExtension(model.UploadImage2.FileName);
                            filename2 = filename2 + extension2;

                            sanpham.HINHANH2 = "~/Content/Hinh/" + filename2;
                            model.UploadImage2.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename2));
                        }
                        if (model.UploadImage3 != null)
                        {
                            string filename3 = Path.GetFileNameWithoutExtension(model.UploadImage3.FileName);
                            string extension3 = Path.GetExtension(model.UploadImage3.FileName);
                            filename3 = filename3 + extension3;

                            sanpham.HINHANH3 = "~/Content/Hinh/" + filename3;
                            model.UploadImage3.SaveAs(Path.Combine(Server.MapPath("~/Content/Hinh/"), filename3));
                        }


                        sanpham.IDMAUSAC = Convert.ToInt32(selectedColor);
                        sanpham.TENSP = model.SANPHAM.TENSP;
                        sanpham.MOTASANPHAM = model.SANPHAM.MOTASANPHAM;
                        sanpham.GIABAN = model.SANPHAM.GIABAN;
                        sanpham.SOLUONGTON = model.SANPHAM.SOLUONGTON;
                        sanpham.PHANTRAMGIAM = model.SANPHAM.PHANTRAMGIAM;
                        sanpham.GIAGIAM = sanpham.GIABAN - (sanpham.GIABAN * sanpham.PHANTRAMGIAM / 100);

                        // Cập nhật thông tin sản phẩm và chi tiết dựa trên LoaiSP
                        switch (sanpham.IDLOAISP)
                        {
                            case 1: // Loại sản phẩm DIENTHOAI
                                var ctdienthoai = db.CTDIENTHOAIs.FirstOrDefault(ct => ct.IDSANPHAM == sanpham.IDSANPHAM);
                                if (ctdienthoai != null)
                                {
                                    // Cập nhật thông tin sản phẩm và chi tiết DIENTHOAI
                                    
                                    ctdienthoai.IDTHDIENTHOAI = model.CTDIENTHOAI.IDTHDIENTHOAI;
                                    ctdienthoai.IDTHDIENTHOAI = Convert.ToInt32(selecteDBrand);
                                    ctdienthoai.MANHINH = model.CTDIENTHOAI.MANHINH;
                                    ctdienthoai.DOPHANGIAI = model.CTDIENTHOAI.DOPHANGIAI;
                                    ctdienthoai.CAMERA = model.CTDIENTHOAI.CAMERA;
                                    ctdienthoai.HEDH = model.CTDIENTHOAI.HEDH;
                                    ctdienthoai.CHIPXULY = model.CTDIENTHOAI.CHIPXULY;
                                    ctdienthoai.ROM = model.CTDIENTHOAI.ROM;
                                    ctdienthoai.RAM = model.CTDIENTHOAI.RAM;
                                    ctdienthoai.MANGDIDONG = model.CTDIENTHOAI.MANGDIDONG;
                                    ctdienthoai.SOKHESIM = model.CTDIENTHOAI.SOKHESIM;
                                    ctdienthoai.PIN = model.CTDIENTHOAI.PIN;

                                    // Cập nhật các thông tin khác nếu cần
                                    // ...
                                }
                                break;
                            case 2: // Loại sản phẩm THOITRANG
                                var ctthoitrang = db.CTTHOITRANGs.FirstOrDefault(ct => ct.IDSANPHAM == sanpham.IDSANPHAM);
                                if (ctthoitrang != null)
                                {
                                    // Cập nhật thông tin sản phẩm và chi tiết THOITRANG
                                    ctthoitrang.IDTHTHOITRANG = Convert.ToInt32(selectTTBrand);
                                    ctthoitrang.IDSIZETT = Convert.ToInt32(selectSizeTT);
                                    ctthoitrang.CHATLIEU = model.CTTHOITRANG.CHATLIEU;

                                    // Cập nhật các thông tin khác nếu cần
                                    // ...
                                }
                                break;
                            case 3: // Loại sản phẩm GIAY
                                var ctgiay = db.CTGIAYs.FirstOrDefault(ct => ct.IDSANPHAM == sanpham.IDSANPHAM);
                                if (ctgiay != null)
                                {
                                    // Cập nhật thông tin sản phẩm và chi tiết GIAY
                                    ctgiay.IDTHGIAY = Convert.ToInt32(selectGBrand);
                                    ctgiay.IDSIZEGIAY = Convert.ToInt32(selectSizeG);

                                    // Cập nhật các thông tin khác nếu cần
                                    // ...
                                }
                                break;
                        }

                        // Lưu các thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();
                        return RedirectToAction("SanPham");
                    }
                }
            }
            // Nếu không tìm thấy sản phẩm hoặc có lỗi, bạn có thể xử lý tại đây (chẳng hạn, hiển thị thông báo lỗi)
            return View("Error"); // Hoặc chuyển hướng đến trang lỗi            
        }
        public ActionResult ApplyDiscount(int productId, int discountPercentage)
        {
            // Retrieve the base SANPHAM from the database or any other source
            var baseProduct = db.SANPHAMs.FirstOrDefault(p => p.IDSANPHAM == productId);

            if (baseProduct != null)
            {
                // Create a PromotionDecorator with the specified discount percentage
                IPromotionDecorator promotionDecorator = new PromotionDecorator(discountPercentage);

                // Create a PromotedSANPHAM instance by decorating the baseProduct
                PromotedSANPHAM promotedProduct = new PromotedSANPHAM(baseProduct, promotionDecorator);

                // Access the enhanced functionality
                int discountedPrice = promotedProduct.GetDiscountedPrice();

                // Now you can use the discounted price as needed

                return View("ProductWithDiscount", promotedProduct);
            }
            else
            {
                return View("Error");
            }
        }
    }
}