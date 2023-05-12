using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Models;

namespace EFCore2_LinQ.Seeds
{
	public class CategoryDetailSeed
	{
		public static void CreateCateGoryDetail()
		{
			using var dbContext = new ShopDbContext();
			var categoriesDetail = new CategoryDetail[]{
				new CategoryDetail(){UserId=1,
														Created=new DateTime(2023,02,10),
														Updated=new DateTime(2023,02,10),
														CountCate=0,CategoryDetailID=1
														},
				new CategoryDetail(){UserId=2,
														Created=new DateTime(2022,12,10),
														Updated=new DateTime(2023,08,20),
														CountCate=0,CategoryDetailID=2
														},
				new CategoryDetail(){UserId=3,
														Created=new DateTime(2021,02,25),
														Updated=new DateTime(2023,005,09),
														CountCate=0,CategoryDetailID=3
														},
			};
			dbContext.AddRange(categoriesDetail);
			var kq =dbContext.SaveChanges();
			if(kq!=null)
			{
				Console.WriteLine($"So dong catedetail dc tao la {kq} ");
			}
		}	
	}
}