
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TMDT.Patterns.Interfaces
{
    public interface IProduct
    {
        string GetDescription();
    }

    public class DienThoai : IProduct
    {
        public string GetDescription()
        {
            return "This is a mobile phone.";
        }
    }

    public class ThoiTrang : IProduct
    {
        public string GetDescription()
        {
            return "This is a fashion item.";
        }
    }

    public class Giay : IProduct
    {
        public string GetDescription()
        {
            return "This is a shoe.";
        }
    }

}