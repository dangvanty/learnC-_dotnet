using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_MVC.Models;

namespace Learn_MVC.Service
{
    public class ProductServices: List<Product>
    {
        public ProductServices()
        {
            this.AddRange( new Product[]{
                new Product(){ID=1, Name="iPhoneX",Quantity=89,Description="Day la Iphone"},
                new Product(){ID=2,Name="iPhone7",Quantity=8,Description="Day la Iphone"},
                new Product(){ID=3,Name="iPhone4",Quantity=4,Description="Day la Iphone"},
                new Product(){ID=4,Name="iPhone8",Quantity=19,Description="Day la Iphone"},
            });
        }
    }
}