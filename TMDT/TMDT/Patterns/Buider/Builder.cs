
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TMDT.Models;

namespace TMDT.Patterns
{
    public class Builder
    {
        public interface ITintucBuilder
        {
            ITintucBuilder SetTieuDe(string tieuDe);
            ITintucBuilder SetMoTa(string moTa);
            ITintucBuilder SetHinhAnh(HttpServerUtilityBase server,HttpPostedFileBase uploadImage1);
            TINTUC Build();
        }

    }
}