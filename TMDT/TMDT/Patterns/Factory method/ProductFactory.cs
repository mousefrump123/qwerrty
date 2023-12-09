
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TMDT.Patterns.Interfaces
{
    public interface IProductFactory
    {
        IProduct CreateProduct();
    }

    public class DienThoaiFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new DienThoai();
        }
    }

    public class ThoiTrangFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ThoiTrang();
        }
    }

    public class GiayFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new Giay();
        }
    }

}