using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_Fluent_API.Models;

namespace EFCore2_Fluent_API.Controllers
{
    public class ProductController
    {public static void ReadProducts()
		{
			using var dbContext= new ShopDbContext();

			// LINQ;
			var products = dbContext.products.ToList();
			products.ForEach(p=>p.PrintInfor());
		}
		public static void FindProductById(int id)
		{
			using var dbContext = new ShopDbContext();
			var product = (from p in dbContext.products 
										where p.ProductId == id
										select p
										).FirstOrDefault();

			//--------- Lay tham chieu den cate tu pro;  
			var e = dbContext.Entry(product);
			e.Reference(p=>p.Category).Load();

			//---- 
			if(product !=null)
			{
				product.PrintInfor();
			}
			if(product.Category !=null)
			{
				Console.WriteLine($"{product.Category.CategoryName} -- {product.Category.Description}");

			}else{
				Console.WriteLine("Category == null");
			}
		}
		public static void PrintInforProduct()
		{
			using var dbContext = new ShopDbContext();
			var kq = from p in dbContext.products
							join c in dbContext.category on p.CateID equals c.CategoryID
							select new {
								name = p.ProductName,
								category = c.CategoryName,
								price= p.Price
							};
			kq.Take(2).ToList().ForEach(p=>Console.WriteLine(p));	
		}
        
    }
}