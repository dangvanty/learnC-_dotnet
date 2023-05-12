
using EFCore1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

class Program
{
  static void CreateDatabase()
  {
    using var DbContext =  new ProductDbContext();

    // lay ten csdl: 
    string dbName = DbContext.Database.GetDbConnection().Database;

    var kq = DbContext.Database.EnsureCreated();
    if(kq)
    {
      Console.WriteLine($"Tao db {dbName} thanh cong!");
    }else{
      Console.WriteLine($"Khong tao duoc {dbName}");
    }
  }
  static void DeleteDatabase()
  {
    using var DbContext =  new ProductDbContext();

    // lay ten csdl: 
    string dbName = DbContext.Database.GetDbConnection().Database;

    var kq = DbContext.Database.EnsureDeleted();
    if(kq)
    {
      Console.WriteLine($"Xóa {dbName} thanh cong!");
    }else{
      Console.WriteLine($"Khong xoa duoc {dbName}");
    }
  }
  static void InsertOne ()
  {
    using var DbContext = new ProductDbContext();

    /*
    - Model(Product)
    -Add, AddAsync
    - SaveChange
    */
    var p1 = new Product(){
      ProductId=90,
      ProductName="But chi",
      ProductProvider="Thien Long"
    };
    DbContext.Add(p1);
    int row_affects = DbContext.SaveChanges();

    Console.WriteLine($"Bang duoc chen them {row_affects} du lieu");
    

  }
  static void InsertMore ()
  {
    using var DbContext = new ProductDbContext();

    /*
    - Model(Product)
    -Add, AddAsync
    - SaveChange
    */
    var p1 = new Product[]{
      new Product(){ProductName="cuc Tay",ProductProvider="Ben nghe"},
      new Product(){ProductName="But may",ProductProvider="333"},
      new Product(){ProductName="Hop but",ProductProvider="thien an"},
    };
    
    DbContext.AddRange(p1);
    int row_affects = DbContext.SaveChanges();

    Console.WriteLine($"Bang duoc chen them {row_affects} du lieu");
  }
  static void ReadProductsByID(int id)
  {
    using var dbContext = new ProductDbContext();
    Product product = (from pro in dbContext.products
                        where pro.ProductId == id
                        select pro
                      ).FirstOrDefault();
    if (product !=null)
    {
      product.PrintInfor();
    }
    else{
      Console.WriteLine($"Khong co san pham tuong ung voi id = {id}");
    }
  }
  static void ReadProducts()
  {
    using var dbContext= new ProductDbContext();

    // LINQ;
    var products = dbContext.products.ToList();
    products.ForEach(p=>p.PrintInfor());

    // tim cac sp co id >= 1 va Provider co "e" roi sap xep theo giam dan id
    var productMore2 = from pro in dbContext.products
                       where pro.ProductId>=1 
                       where pro.ProductProvider.Contains("e")
                       orderby pro.ProductId descending
                       select pro;
    Console.WriteLine("-----------");
    productMore2.ToList().ForEach(p=>p.PrintInfor());
    Console.WriteLine("-----------");
    Product  product2 =  (from pro in dbContext.products
                         where pro.ProductId==2
                         select pro).FirstOrDefault(); // lay dong dau tien hoac tra ve null; 
    if(product2 !=null)
    product2.PrintInfor();            
  }
  static void ReNameProduct(int id, string newName)
  {
    using var dbContext = new ProductDbContext();

    Product product = (from pro in dbContext.products
                       where pro.ProductId == id
                       select pro 
                        ).FirstOrDefault();
    if(product!=null)
    {

      // product --> dbContext : dbContext theo doi product voi EntityEntry
      EntityEntry<Product> entry = dbContext.Entry(product);
      entry.State=EntityState.Detached; // huy theo doi --> khi thay doi product thi dbContext.saveChanges ko hieu qua
      
      product.ProductName=newName;
      int row_affects = dbContext.SaveChanges();
      Console.WriteLine($"Da sua {row_affects} du lieu");
    }

  }
  static void DeleteProductByID(int id)
  {
    using var dbContext = new ProductDbContext();

    // lay productbyid
    Product product = (from pro in dbContext.products
                       where pro.ProductId == id
                       select pro
                      ).FirstOrDefault();
    if(product!=null)
    {
      dbContext.Remove(product);
      int row_affects = dbContext.SaveChanges();
      Console.WriteLine($"So dong bi xoa la: {row_affects}");
    }
  }
  static void Main (string[] arg)
  {
    // CreateDatabase();
    // DeleteDatabase();

    //logging ::::


    // Insert, Select, Update, Delete
    // InsertOne();
    // InsertMore();
    // DeleteProductByID(90);
    // ReadProducts();
    ReadProductsByID(2);
   


  }
}