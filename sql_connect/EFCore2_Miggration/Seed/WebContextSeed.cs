using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_Miggration.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore2_Miggration.Seed
{
	public class WebContextSeed
	{
		public static void DropDatabase()
		{
			using var webContext = new WebContext();
			var dbName = webContext.Database.GetDbConnection().Database; // lay ten database
			var kq =webContext.Database.EnsureDeleted();

			if(kq)
			{
				Console.ForegroundColor=ConsoleColor.Red;
				Console.WriteLine($"Xoa thanh cong database{dbName}");
				Console.ResetColor();
			}
			else{
				Console.ForegroundColor=ConsoleColor.Yellow;
				Console.WriteLine($"Xoa that bai database {dbName}");
				Console.ResetColor();
			}
		}
		public static void CreateDatabase ()
		{
			using var webContext = new WebContext();
			var dbName = webContext.Database.GetDbConnection().Database;
			var kq = webContext.Database.EnsureCreated();
			if(kq)
			{
				Console.ForegroundColor=ConsoleColor.Green;
				Console.WriteLine($"Tao thanh cong database {dbName}");
				Console.ResetColor();
			}
			else{
				Console.ForegroundColor=ConsoleColor.Red;
				Console.WriteLine($"Tao that bai database {dbName}");
				Console.ResetColor();
			}
		}
	}
}