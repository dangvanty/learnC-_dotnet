namespace ListPractic
{
  class ListEasy
  {
    public static void Test()
    {
      List<int> ds1 = new List<int>();
      ds1.Add(100);
      ds1.Add(103);
      Console.WriteLine($"Count of List {ds1.Count()}");
      ds1.RemoveAt(0);
      Console.WriteLine(ds1[0]);
      // add nhieu: 
      ds1.AddRange(new int[]{2,45,78});
      Console.WriteLine($"Count of List {ds1.Count()}");
      
      // Insert: 
      ds1.Insert(0,45);
      Print(ds1);
      Console.WriteLine("------");
      ds1.RemoveAllElement(45);
      Print(ds1);


    }

    public static void Print (List<int> ds)
    {
      foreach (var item in ds)
      {
        Console.WriteLine(item);
      }
    }
  }
  static class RemoveAllE
  {
    public static void RemoveAllElement(this List<int>ds,int a)
    {
      if(!ds.Contains(a))
      {
        return;
      }
      ds.Remove(a);
      RemoveAllElement(ds,a);
    }
  }
}