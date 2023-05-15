using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor6_PageModel.Models;

namespace Razor6_PageModel.Services
{
    public class ProductServices
    {
        private List<Product> product = new List<Product>();
        public ProductServices()
        {
            LoadProduct();
        }

        public Product FindByID(int id)
        {
            var qr = from p in product
            where p.Id == id select p;
            return qr.FirstOrDefault();
        }
        public List<Product> AllProduct()=>product;
        public void LoadProduct()
        {
            product.Clear();
            product.Add(new Product(){
                Id=1,
                Name="Product 1",
                Price=90,
                Decription="san pham 1"
            });
            product.Add(new Product(){
                Id=2,
                Name="Product 2",
                Price=690,
                Decription="san pham 2"
            });
            product.Add(new Product(){
                Id=3,
                Name="Product 3",
                Price=390,
                Decription="san pham 3"
            });
            product.Add(new Product(){
                Id=4,
                Name="Product 4",
                Price=903,
                Decription="san pham 4"
            });
        }
    }
}