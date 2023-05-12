namespace LinkedListTest
{
  class LinkedList
  {
    public static void Test()
    {
      // trong linked list 

      LinkedList<string> tencacbaihoc = new LinkedList<string>();
      var bh1 = tencacbaihoc.AddFirst("bai hoc 1");
      var bh3 = tencacbaihoc.AddLast("bai hoc 3");
      var bh2 = tencacbaihoc.AddAfter(bh1,"bai hoc 2");

      Console.WriteLine("Duyệt từ đầu đến cuối------");
      var node = tencacbaihoc.First;
      while (node!=null)
      {
        Console.WriteLine(node.Value);
        node = node.Next;
      }
      Console.WriteLine("Duyệt từ cuối lên đầu------");
      node = tencacbaihoc.Last;
      while(node!=null)
      {
        Console.WriteLine(node.Value);
        node=node.Previous;
      }
      // foreach (var item in tencacbaihoc)
      // {
      //  Console.WriteLine(item);
      // }
    }
  }
}