using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_LinQ.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore2_LinQ.Models
{
	public class ShopDbContext :DbContext
	{
		    // tao logger
		public static readonly ILoggerFactory loggerFactory =LoggerFactory.Create(builder=>{
			builder.AddFilter(DbLoggerCategory.Query.Name,LogLevel.Information);
			builder.AddConsole();

		});

		// DbContext hieu la moi dong cua bang tuong ung voi kieu Product
		public DbSet<Product> products {set;get;}
		public DbSet<Category> category {set;get;}

		// private const string connectString = @"server=127.0.0.1;database=learnefcsharp;user id=root;password=MYSQL_ROOT_PASSWORD;port=3306"
		private string connectString = ConfigMySql.UrlConfig();

		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseLoggerFactory(loggerFactory);
			optionsBuilder.UseMySQL(connectString);
			// optionsBuilder.UseLazyLoadingProxies();// tu dong nap cac referen ko can phai
		}	

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Fluent API 

			// 3 cach anh xạ
			/*
			c1: var entity = modelBuilder.Entity<Product>();
			c2: var entity = modelBuilder.Entity(typeof(Product))
			c3: modelBuilder.Entity<Product>(entity=>entity. --> Fluent APi )
			*/
			modelBuilder.Entity<Product>(entity=>{
				// tableMapping 
				entity.ToTable("TenSP");

				// Pk
				entity.HasKey(p=>p.ProductId);

				// Index;
				entity.HasIndex(p=>p.Price).HasDatabaseName("index-product-price");

				// Relative
				entity.HasOne(p=>p.Category)
							.WithMany()     								//Category khong co Property ~ product
							.HasForeignKey("CateID")		// Dat cot tham chieu cho product
							.OnDelete(DeleteBehavior.Cascade)  // Casecade --> khi xoa phan 1 thi phan nhieu bi xoa theo
							.HasConstraintName("FK_Product_Cate_1"); // dat ten khoa ngoai

				entity.HasOne(p=>p.Category2)
							.WithMany(c=>c.Products)		// Category co Property ~ Product ==> thuc hien lazyload
							.HasForeignKey("CateID2")
							.OnDelete(DeleteBehavior.NoAction)		// NoAction --> khi xoa phan 1 thi phan nhieu ko co tac dong j
							.HasConstraintName("FK_Product_Cate_2"); 


				// thiet lap property tren cac cot cua bang 
				entity.Property(p=>p.ProductName)
							.HasColumnName("ProductName")  // sua ten cho cot
							.HasColumnType("varchar")				// sua kieu du lieu
							.HasMaxLength(60)							// Do dai du lieu
							.IsRequired(false); 					// cho phep null hay ko 

				entity.Property(p=>p.Price)
							.HasColumnName("Price")
							.HasColumnType("Decimal(15,3)")
							.IsRequired(true)
							.HasDefaultValue(0);
			});

			// Thiet lap 1-1 cho cate và catedetail
			modelBuilder.Entity<CategoryDetail>(entity=>{
				entity.HasOne(cd=>cd.Category)
							.WithOne(c=>c.CategoryDetail)
							.HasForeignKey<CategoryDetail>(c=>c.CategoryDetailID)  // chọn FK tren bang cateDetail: lay cateDtlID tham chieu tới CateID
							.OnDelete(DeleteBehavior.Cascade);
			});
		}	
	}
}