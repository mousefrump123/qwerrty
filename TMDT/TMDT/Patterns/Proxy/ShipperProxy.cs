
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TMDT.Areas.Admin.Controllers;
using TMDT.Models;

namespace TMDT.Patterns
{
    // ShipperProxy.cs

    public class ShipperProxy : Controller
    {
        private readonly ShipperController shipperController;
        private readonly TMDTEntities db;

        public ShipperProxy()
        {
            this.shipperController = new ShipperController();
            this.db = new TMDTEntities(); // Initialize your context
        }

        // Implement any additional access control logic here

        public ActionResult DangNhap(SHIPPER shipper)
        {
            // Perform authentication logic here before delegating to ShipperController
            var objUserGet = db.SHIPPERs
                .Where(n => n.EMAIL.Equals(shipper.EMAIL) && n.MATKHAU.Equals(shipper.MATKHAU))
                .FirstOrDefault();

            if (objUserGet == null)
            {
                ViewBag.error = "Email hay Mật khẩu không đúng vui lòng nhập lại!";
                return View("DangNhap"); // You might want to return the login view with an error message
            }
            else
            {
                // Delegate to the actual ShipperController if authentication is successful
                return shipperController.DangNhap(objUserGet);
            }
        }
      
    }
}