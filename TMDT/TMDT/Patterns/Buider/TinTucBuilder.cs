
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static TMDT.Patterns.Builder;
using System.Web.UI.DataVisualization.Charting;
using System.Web;
using TMDT.Models;
using System.Web.Mvc;


namespace TMDT.Patterns
{
    public class TintucBuilder : ITintucBuilder
    {
        private TINTUC tintuc = new TINTUC();

        public ITintucBuilder SetTieuDe(string tieuDe)
        {
            tintuc.TIEUDE = tieuDe;
            return this;
        }

        public ITintucBuilder SetMoTa(string moTa)
        {
            tintuc.MOTA = moTa;
            return this;
        }
        
        public ITintucBuilder SetHinhAnh(HttpServerUtilityBase server, HttpPostedFileBase uploadImage1)
        {
            if (uploadImage1 != null)
            {
                string filename1 = Path.GetFileNameWithoutExtension(uploadImage1.FileName);
                string extension1 = Path.GetExtension(uploadImage1.FileName);
                filename1 = filename1 + extension1;
                tintuc.HINHANH = "~/Content/Hinh/" + filename1;
                uploadImage1.SaveAs(Path.Combine(server.MapPath("~/Content/Hinh/"), filename1));
            }
            return this;
        }

        public TINTUC Build()
        {
            // Perform any additional construction logic if needed
            return tintuc;
        }
    }
}