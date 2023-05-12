using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Models;

namespace EFCore2_LinQ.Controllers
{
    public class CategoryController
    {
        public static void FindCategoryByID(int id)
		{
			using var dbContext = new ShopDbContext();
			var category = (from c in dbContext.category
											where c.CategoryID == id
											select c
											).FirstOrDefault();

			if(category!=null)
			{
				Console.WriteLine($"{category.CategoryName} -  {category.Description}");
			}
			//--- load tat ca sp cua cate // --> them UseLazy... trong shopContext nen ko can nua
			// var e = dbContext.Entry(category);
			// e.Collection(c=>c.Products).Load();
			//----
			// show tat ca product trong cate
			if(category.Products !=null)
			{
				Console.WriteLine("So san pham: "+category.Products.Count);
				category.Products.ForEach(p=>p.PrintInfor());
			}
			else{Console.WriteLine("Products =null");}
		}
		public static void DeleteById(int id)
		{
			using var dbContext = new ShopDbContext();
			var category = (from c in dbContext.category 
											where c.CategoryID==id select c).FirstOrDefault();
			dbContext.Remove(category);
			var row_affects =dbContext.SaveChanges();
			if(row_affects!=null)
			{
				Console.WriteLine($"So dong thay doi la: {row_affects}");
			} 
		}
    }
}