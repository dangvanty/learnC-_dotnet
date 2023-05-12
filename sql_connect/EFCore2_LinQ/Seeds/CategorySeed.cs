using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Models;

namespace EFCore2_LinQ.Seeds
{
	public class CategorySeed
	{
		public static void CreateCateGory()
		{
			using var dbContext = new ShopDbContext();

			var categories = new Category[]{
				new Category(){CategoryName="Dien thoai", Description="Cac loai dien thoai"},
				new Category(){CategoryName="Dung cu", Description="Cac dung cu"},
				new Category(){CategoryName="Do uong", Description="Cac do uong"},
			};

			dbContext.AddRange(categories);

			var kq = dbContext.SaveChanges();
			if(kq != null)
			{
				Console.WriteLine($"Da tao dc {kq} loai sp");
			}
		}
	}
}