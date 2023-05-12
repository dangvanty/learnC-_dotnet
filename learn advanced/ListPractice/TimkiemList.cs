namespace ListPractic
{
  class ListFind
  {
    public static void Test()
    {
      List<int> ds1 = new List<int>(){1,34,657,57,4};

      var ok = ds1.Find(
        (e)=>e>9
      );
      
      var nice = ds1.FindAll(
        (e)=>e>9
      );
      PrintList(nice);
    }
    public static void PrintList(List<int> ds)
    {
      Console.WriteLine("----- Print list int----");
      foreach (var item in ds)
      {
        
       Console.WriteLine(item);
      }
    }
    public static void Test1()
    {
      List<Products> dsPro = new List<Products>(){
        new Products(){ID=20,Name="ok",Price=900,Origin="noName"},
        new Products(){ID=29,Name="ok3",Price=970,Origin="VietNam"},
        new Products(){ID=89,Name="ok",Price=80,Origin="TQ"},
        new Products(){ID=66,Name="ok3",Price=400,Origin="HanQuoc"}
      };

      var ok = dsPro.FindAll(
        (e)=>e.ID>10
      );
      Console.WriteLine("-------Id lớn hơn 10--------");
      foreach (var item in ok)
      {
       Console.WriteLine(item.Name+"---"+item.ID);
      }
      
       dsPro.Sort(
        (e1,e2)=>{
          if(e1.Price>e2.Price) return 1;
          if(e1.Price==e2.Price) return 0;
          return -1;
        }
      );
      Console.WriteLine("-------Sort tu be den lon theo price--------");
      foreach (var item in dsPro)
      {
      Console.WriteLine(item.Name+"---"+item.ID + "---" + item.Price);
      }


    }
  }

  class Products
  {
    public int ID {set;get;}
    public string Name{set;get;}
    public int Price {set;get;}
    public string Origin{set;get;}
  }
}