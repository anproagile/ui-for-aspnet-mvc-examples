﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIMVC5.Models
{
    public static class VendorRepository
    {
        public static IEnumerable<Vendor> Vendors
        {
            get
            {
                IEnumerable<Vendor> result = (IEnumerable<Vendor>)HttpContext.Current.Session["Vendors"];

                if (result == null)
                {
                    HttpContext.Current.Session["Vendors"] = result = GenerateVendors();
                }

                return result;
            }
        }

        public static IEnumerable<Vendor> GetVendorsByCustomer(int customerId)
        {
            return Vendors.Where(p => p.CustomerId == customerId);
        }

        private static IEnumerable<Vendor> GenerateVendors()
        {
            var idx = 1;
            var list = new List<Vendor>();

            for (var i = 1; i <= 5; i++)
            {
                list.Add(new Vendor
                {
                    VendorId = idx,
                    VendorName = "Vendor" + idx,
                    CustomerId = i
                });

                idx += 1;

                list.Add(new Vendor
                {
                    VendorId = idx,
                    VendorName = "Vendor" + idx,
                    CustomerId = i
                });
            }

            return list;
        }
    }
}