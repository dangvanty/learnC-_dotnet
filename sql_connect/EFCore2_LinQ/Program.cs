using EFCore2_LinQ.Controllers;
using EFCore2_LinQ.Seeds;
class Program
{
  static void Main (string [] arg)
  {
    // Tao db
    // ShopController.DropDatabase();
    // ShopController.CreateDatabase();

    // Tao Seed 
    // CategorySeed.CreateCateGory();
    // CategoryDetailSeed.CreateCateGoryDetail();
    // ProductSeed.CreateProduct();
    
    // Query with Linq
    // ProductController.ShowProductsDESC();
    // ProductController.ShowProductInfo();
    ProductController.AllProductWithRawQuery();
    // ProductController.SearchNameProduct("%o%");

  }
}