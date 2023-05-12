
using EFCore2_Fluent_API.Configs;
using EFCore2_Fluent_API.Controllers;

class Program
{
  static void Main(string[] arg)
  {
    // ProductController.ReadProducts();
    ShopController.DropDatabase();
    ShopController.CreateDatabase();
    // ShopController.SeedData();
    // ProductController.FindProductById(3);
    // CategoryController.FindCategoryByID(1);

    // CategoryController.DeleteById(1);
    // ProductController.PrintInforProduct();
    
  }
}