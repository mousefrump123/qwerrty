
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;

namespace TMDT.Patterns.Iterator
{
    // Create a new class for the iterator
    public class FavoriteProductsIterator : IEnumerable<SANPHAM>
    {
        private readonly NGUOIDUNG nguoidung;

        // Constructor to initialize with the user
        public FavoriteProductsIterator(NGUOIDUNG nguoidung)
        {
            this.nguoidung = nguoidung;
        }

        // Implement the GetEnumerator method for the iterator
        public IEnumerator<SANPHAM> GetEnumerator()
        {
            // Implement logic to fetch favorite product IDs and yield each product
            foreach (var productId in GetFavoriteProductIds())
            {
                var product = nguoidung.SANPHAMs.FirstOrDefault(p => p.IDSANPHAM == productId);
                if (product != null)
                {
                    yield return product;
                }
            }
        }

        // Custom method to get favorite product IDs
        private IEnumerable<int> GetFavoriteProductIds()
        {

            // Assuming that SANPHAMs is the collection of favorite products
            return nguoidung.SANPHAMs.Select(p => p.IDSANPHAM);
        }

        // Implement the IEnumerable interface for non-generic collections
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}