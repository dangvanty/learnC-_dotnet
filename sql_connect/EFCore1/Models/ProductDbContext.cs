using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore1.ConfigConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore1.Models
{
    public class ProductDbContext : DbContext
    {
        // tao logger
        public static readonly ILoggerFactory loggerFactory =LoggerFactory.Create(builder=>{
            builder.AddFilter(DbLoggerCategory.Query.Name,LogLevel.Information);
            // builder.AddFilter(DbLoggerCategory.Database.Name,LogLevel.Information);
            builder.AddConsole();

        });

        // DbContext hieu la moi dong cua bang tuong ung voi kieu Product
        public DbSet<Product> products {set;get;}

        // private const string connectString = @"server=127.0.0.1;database=learnefcsharp;user id=root;password=MYSQL_ROOT_PASSWORD;port=3306"
        private string connectString = ConfigMySql.UrlConfig();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseMySQL(connectString);
        }
    }
}