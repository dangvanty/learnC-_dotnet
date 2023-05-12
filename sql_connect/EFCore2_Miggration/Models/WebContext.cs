using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2_Miggration.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCore2_Miggration.Models
{
	public class WebContext : DbContext
	{
		public DbSet<Article> Articles {set;get;} 
		public DbSet<Tag> Tags {set;get;}

		public DbSet<ArticleTag> ArticleTags {set;get;}

		public readonly string ConnectStrring = ConfigMySql.UrlConfig();
	
		public static readonly ILoggerFactory loggerFactory =LoggerFactory.Create(builder=>{
			// builder.AddFilter(DbLoggerCategory.Database.Command.Name,LogLevel.Warning);
			builder.AddFilter(DbLoggerCategory.Query.Name,LogLevel.Information);
			builder.AddConsole();

		});

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(ConnectStrring);
			optionsBuilder.UseLoggerFactory(loggerFactory);       // bật logger
		} 

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ArticleTag>(entity=>{
				entity.HasIndex(articleTag=>new{articleTag.ArticleId, articleTag.TagId})
							.IsUnique();

			});
		}
		
			 
	}
}