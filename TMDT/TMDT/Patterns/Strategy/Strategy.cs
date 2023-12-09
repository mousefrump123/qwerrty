
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;

namespace TMDT.Patterns
{
    public class Strategy
    {
        public interface IVoucherValidationStrategy
        {
            bool Validate(VOUCHERSHOP voucher);
        }
        public class StartDateValidationStrategy : IVoucherValidationStrategy
        {
            public bool Validate(VOUCHERSHOP voucher)
            {
                // Implement logic to validate the start date of the voucher
                DateTime currentDate = DateTime.Now.Date;
                return voucher.NGAYBD > currentDate;
            }
        }
        public class EndDateValidationStrategy : IVoucherValidationStrategy
        {
            public bool Validate(VOUCHERSHOP voucher)
            {
                // Implement logic to validate the end date of the voucher
                DateTime currentDate = DateTime.Now.Date;
                return voucher.NGAYKT < currentDate;
            }
        }
    }
}