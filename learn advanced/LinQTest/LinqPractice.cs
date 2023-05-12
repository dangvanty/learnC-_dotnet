namespace LinQTest
{
  partial class LinqPractice
  {
    
    public static void Data(out List<Brand> brands, out List<Product> products)
    {
      brands = new List<Brand>()
      {
        new Brand{ID = 1, Name = "Công ty AAA"},
        new Brand{ID = 2, Name = "Công ty BBB"},
        new Brand{ID = 4, Name = "Công ty CCC"},
      };

      products= new List<Product>()
      {
        new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
        new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
        new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
        new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
        new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
        new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
        new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),

      };
    }
    public static void TestPriceProduct()
    {
      List<Product> products;
      List<Brand> brands;
      Data(out brands,out products);

      var PricePMore400 = from pro in products
                          where pro.Price>=400
                          where pro.Colors.Contains("Xanh")
                          select pro;
      foreach (var item in PricePMore400)
      {
        Console.WriteLine($"product Name : {item}");
      }

    }
    public static void ApiHardWithLinq ()
    {
      // nạp data
      List<Product> products;
      List<Brand> brands;
      Data(out brands,out products);

      // select 
      var selectName = products.Select(
        (p)=>p.Name
      );
      // where: 
      var whereProduct = products.Where(
        (p)=> p.Price>100 && p.Price <=400
      );

      // selectMany: 
      var selectMany = products.SelectMany(
        (p)=>p.Colors
      );

      // gia trung binh sản phẩm: 
      var GiaTB = products.Average(p=>p.Price);
      Console.WriteLine("Gia trung binh : "+Math.Round(GiaTB,2));

      // join: 
      var kqJoin = products.Join(brands, p=>p.Brand, b=>b.ID, 
                    (p,b)=>{
                        return new {
                          Name = p.Name,
                          Brand = b.Name
                        };
                    });

      // group join:
      var kqGroupJoin = brands.GroupJoin(products, b=>b.ID, p=>p.Brand, 
      (brands, pros)=>{
        return new {
          BrandName = brands.Name,
          ProductsOfBrands = pros
        };
      });
      // foreach (var kq in kqGroupJoin)
      // {
      //   Console.WriteLine(kq.BrandName);
      //   foreach (var item in kq.ProductsOfBrands)
      //   {
      //     Console.WriteLine(item);
      //   }
      // }

      // take: ::
      // Console.WriteLine("-----take-----");
      // products.Take(2).ToList().ForEach(
      //   (pro)=>Console.WriteLine(pro));

      // skip::::
      // Console.WriteLine("-----skip-----");
      // products.Skip(2).ToList().ForEach(
      //   (pro)=>Console.WriteLine(pro));

      //oder by - orderbydesceding
      // products.OrderBy(p=>p.Price).ToList().ForEach(
      //   (p)=>Console.WriteLine(p)
      // );
      // Console.WriteLine("------ price ---");
      // products.OrderByDescending(p=>p.Price).ToList().ForEach(
      //   (p)=>Console.WriteLine(p)
      // );

      //Reverse
      // int [] number ={1,34,6,45,34,3434};
      // number.Reverse().ToList().ForEach(
      //   (nu)=>Console.WriteLine(nu)
      // );

      // groupby 
      // var kqGroupBy = products.GroupBy(p=>p.Price);
      
      // foreach (var group in kqGroupBy)
      // {
      //   Console.WriteLine(group.Key);
      //   foreach (var item in group)
      //   {
      //     Console.WriteLine(item);
          
      //   }
      // }

      // distinct : 
      // products.SelectMany(p=>p.Colors).Distinct().ToList().ForEach(
      //   (p)=>Console.WriteLine(p)
      // );


      // singele: 
      // var kq = products.Single(p=>p.Price==200);
      // Console.WriteLine(kq);

      // singeleOrDefault:
      // var kq1 = products.SingleOrDefault(p=>p.Price==1);
      // var value= kq1 == null ? "null" : $"{kq1}";
      // Console.WriteLine(value); 

      // any:
      // var kq = products.Any(p=>p.Price<1);
      // Console.WriteLine(kq);
      // all
      // var kq2 = products.All(P=>P.Price >1);
      // Console.WriteLine(kq2);


      // Count 
      // var kq = products.Count(p=>p.Price>300);
      // Console.WriteLine(kq);


      // ví dụ nâng cao 
      products.Where((pro)=>pro.Price>100 && pro.Price<=400)
                       .OrderByDescending((pro)=>pro.Price)
                       .Join(brands,pro=>pro.Brand,b=>b.ID,
                       (p,b)=>{
                        return new {
                          TenPro = p.Name,
                          ThuongHieu = b.Name,
                          Gia = p.Price
                        };
                       }).ToList().ForEach((pro)=>
                       Console.WriteLine(pro)
                       );
               


      // foreach (var item in ok)
      // {
      //   Console.WriteLine(item);
      // }


    }
    
  }
}