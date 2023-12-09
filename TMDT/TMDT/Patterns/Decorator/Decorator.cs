
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TMDT.Patterns
{
    //áp dụng trong sanpham.cs
    public class Decorator
    {
        public interface IProduct
        {
            string GetDescription();
            
        }

        public class ConcreteProduct : IProduct
        {
            public string GetDescription()
            {
                return "Basic product";
            }
        }

        public class ProductDecorator : IProduct
        {
            private IProduct _product;

            public ProductDecorator(IProduct product)
            {
                _product = product;
            }

            public virtual string GetDescription()
            {
                return _product.GetDescription();
            }
        }

        public class PremiumProductDecorator : ProductDecorator
        {
            public PremiumProductDecorator(IProduct product) : base(product) { }

            public override string GetDescription()
            {
                return base.GetDescription() + " with premium features";
            }
        }

    }
}