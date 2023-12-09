
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;

namespace TMDT.Patterns
{
    public class Prototype
    {
        public interface IVoucherPrototype
        {
            VOUCHERSHOP Clone();
        }
    }
}