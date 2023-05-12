using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore2_LinQ.Controllers
{
	public class ProductController
	{
		public static void ReadProducts()
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
		public static void ShowProductsDESC()
		{
			using var dbContext = new ShopDbContext();
			
			var products = dbContext.products
											.Where(p=>p.Price>1000)
											.OrderByDescending(p=>p.Price)
											.Take(10);
			foreach (var item in products)
			{
				item.PrintInfor();
			}

		}
		public static void ShowProductInfo()
		{
			using var dbContext = new ShopDbContext();
			var products = from p in dbContext.products
										join c1 in dbContext.category on p.CateID equals c1.CategoryID
										join c2 in dbContext.category on p.CateID2 equals c2.CategoryID into t
										from d in t.DefaultIfEmpty()
										select new {
											Name = p.ProductName,
											CateName1 =c1.CategoryName,
											CateName2 = (d==null)?"Cte Null" : d.CategoryName,
											Price = p.Price 
										};
			products.ToList().ForEach(
				p=>Console.WriteLine(p)
			);
		}
		public static void AllProductWithRawQuery()
		{
			using var dbContext = new ShopDbContext();
			string Query = @"SELECT * FROM tensp t
											ORDER BY Price DESC";
			var products = dbContext.products.FromSqlRaw(Query);
			products.ToList().ForEach(p=>p.PrintInfor());
		}
		public static void SearchNameProduct(string name)
		{
			using var dbContext = new ShopDbContext();
			var products = from p in dbContext.products
											where EF.Functions.Like(p.ProductName,name)
											select p;
			products.ToList().ForEach(p=>p.PrintInfor());
		}			
  }
}