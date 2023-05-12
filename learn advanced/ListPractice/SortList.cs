namespace ListPractic
{
  class SortList
  {
    public static void Test()
    {
      // key lưu trữ là chuỗi, giá trị là products
      // bản chất là lưu 2 danh sách 
      SortedList<string, Products> products = new SortedList<string, Products>();
      products["sp1"] = new Products(){Name="Điện thoại", ID=090, Price=989,Origin="VietNam"};
      products["sp2"] = new Products(){Name="Máy Tính", ID=090, Price=989,Origin="VietNam"};
      products["sp3"] = new Products(){Name="Cái Quạt", ID=090, Price=989,Origin="VietNam"};

     
      var keys = products.Keys;
      var Values = products.Values;

      Console.WriteLine("------keys------");
      foreach (var k in keys)
      {
        Console.WriteLine("key nè :::::  "+k);
      }
      Console.WriteLine("------Value------");
      foreach (var v in Values)
      {
        Console.WriteLine("vlue Name nè :::::  "+v.Name);
      }

        Console.WriteLine("----Keys value pair ----");
      foreach (KeyValuePair<string,Products> pro in products)
      {
        var key = pro.Key;
        Console.WriteLine("đây là : "+key);
        var value = pro.Value;
        Console.WriteLine("vlue Name nè :::::  "+value.Name);
      }
    
    }
  }
}