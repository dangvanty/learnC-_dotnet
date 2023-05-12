using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore2_Fluent_API.Models;

namespace EFCore2_Fluent_API.Controllers
{
    public class ShopController
    {
        public static void CreateDatabase()
		{
			using var DbContext = new ShopDbContext();
			
			var dbName = DbContext.Database.GetDbConnection().Database;
			var kq = DbContext.Database.EnsureCreated();
			if(kq){
				Console.ForegroundColor=ConsoleColor.Green;
				Console.WriteLine($"Tao {dbName} thanh cong");
				Console.ResetColor();
			}else{
				Console.ForegroundColor=ConsoleColor.Red;
				Console.WriteLine($"Tao that bai {dbName}");
				Console.ResetColor();
			}
		}
		public static void DropDatabase()
		{
			using var DbContext = new ShopDbContext();
			var dbName = DbContext.Database.GetDbConnection().Database;
			var kq = DbContext.Database.EnsureDeleted();

			if(kq)
			{
				Console.ForegroundColor=ConsoleColor.Green;
				Console.WriteLine($"Xoa {dbName} thanh cong");
				Console.ResetColor();
			}else{
				Console.ForegroundColor=ConsoleColor.Red;
				Console.WriteLine($"Xoa that bai {dbName}");
				Console.ResetColor();
			}
		}
		public static void SeedData()
		{
			using var dbContext = new ShopDbContext();
			
			// var cates = new Category[]
			// {
			// 	new Category(){CategoryName="Dien thoai", Description="Cac dien thoai"},
			// 	new Category(){CategoryName="Do uong", Description="Cac loai do uong"},
			// 	new Category(){CategoryName="Dung cu", Description="Cac dung cu hoc tap"},
			// };
			// dbContext.category.AddRange(cates);
			var c1 = (from c in dbContext.category where c.CategoryID==1 select c ).FirstOrDefault();
			var c2 = (from c in dbContext.category where c.CategoryID==2 select c ).FirstOrDefault();
			var c3 = (from c in dbContext.category where c.CategoryID==3 select c ).FirstOrDefault();

			dbContext.Add(new Product(){ProductName="Iphone10",Price=902000,CateID=1});
			dbContext.Add(new Product(){ProductName="But bi",Price=1900,Category=c3});
			dbContext.Add(new Product(){ProductName="Coca cola",Price=9200,Category=c2});
			dbContext.Add(new Product(){ProductName="Pepsi",Price=800,Category=c2});
			dbContext.Add(new Product(){ProductName="IphoneX",Price=908920,Category=c1});
			dbContext.Add(new Product(){ProductName="Samsung",Price=798000,Category=c1,CateID2=2});

			var row_affects= dbContext.SaveChanges();
			Console.WriteLine($"So dong tac dong la {row_affects}");
		}

    }
}