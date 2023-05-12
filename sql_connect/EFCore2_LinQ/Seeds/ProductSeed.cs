using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Models;

namespace EFCore2_LinQ.Seeds
{
	public class ProductSeed
	{
		public static void CreateProduct()
		{
			using var dbContext = new ShopDbContext();
			var c1 = (from c in dbContext.category where c.CategoryID==1 select c ).FirstOrDefault();
			var c2 = (from c in dbContext.category where c.CategoryID==2 select c ).FirstOrDefault();
			var c3 = (from c in dbContext.category where c.CategoryID==3 select c ).FirstOrDefault();

			dbContext.Add(new Product(){ProductName="Iphone10",Price=902000,CateID=1});
			dbContext.Add(new Product(){ProductName="But bi",Price=1900,Category=c3});
			dbContext.Add(new Product(){ProductName="Coca cola",Price=9200,Category=c2});
			dbContext.Add(new Product(){ProductName="Pepsi",Price=800,Category=c2});
			dbContext.Add(new Product(){ProductName="IphoneX",Price=908920,Category=c1});
			dbContext.Add(new Product(){ProductName="Samsung",Price=798000,Category=c1,CateID2=2});	

			var kq = dbContext.SaveChanges();
			if(kq!=null)
			{
				Console.WriteLine($"So dong Sp dc them la {kq}");
			}
		}
	}
}