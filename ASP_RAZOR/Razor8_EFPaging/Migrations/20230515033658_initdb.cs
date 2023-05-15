using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;
using Razor8_EFPaging.Models;

#nullable disable

namespace Razor8_EFPaging.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

                Randomizer.Seed = new Random(8675309);
                var articles = new Faker<Article>()
                                    .RuleFor(a=>a.Title,f=>f.Lorem.Sentence(5,5)) // từ 5 đến 10 từ
                                    .RuleFor(a=>a.Content,f=>f.Lorem.Paragraphs(1,4)) // dài từ 1 đến 4 para
                                    .RuleFor(a=>a.Created,f=>f.Date.Between(new DateTime(2022,5,22),new DateTime(2023,5,30)));
                    
                for (var i = 0; i < 200; i++)
                {
                    Article article = articles.Generate();
                    migrationBuilder.InsertData(
                        table:"articles",
                        columns: new []{"Title","Content","Created"},
                        values: new object[]{article.Title,article.Content,article.Created}
                    );
                    
                }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
