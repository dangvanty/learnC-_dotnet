namespace QueueStackDicHash
{
  class HashSetTest
  {
    public static void Test()
    {
      HashSet<int> set1 = new HashSet<int>() {1,2};
      HashSet<int> set2 = new HashSet<int>() {1,6,8};

      // them phan tu: 
      set1.Add(90);

      // hợp nhau: 
      // Console.WriteLine("------UnionWith ------");
      // set1.UnionWith(set2);
      // PrintHashSetInt(set1);

      // Console.WriteLine("------Union ------");
      // set1.Union(set2);
      // PrintHashSetInt(set1);

      // Console.WriteLine("------Intersect ------");
      // set1.IntersectWith(set2);
      // PrintHashSetInt(set1);

      Console.WriteLine("------Except ------");
      set1.ExceptWith(set2);
      PrintHashSetInt(set1);


    }
    public static void PrintHashSetInt (HashSet<int> hset)
    {
       foreach (var item in hset)
       {
        Console.Write(item + " , ");
       }
       Console.WriteLine();
    }
  }
}