namespace QueueStackDicHash
{
  class QueueStackTest
  {
    public static void TestQueue()
    {
      Queue<string> hoso = new Queue<string>();
      hoso.Enqueue("Hoso1");
      hoso.Enqueue("Hoso2");
      hoso.Enqueue("Hoso3");
      hoso.Enqueue("Hoso4");

    
      var hs = hoso.Dequeue();
      Console.WriteLine($"Loại bỏ hồ sơ {hs} và còn lại {hoso.Count}");
      hs = hoso.Dequeue();
      Console.WriteLine($"Loại bỏ hồ sơ {hs} và còn lại {hoso.Count}");
      hs = hoso.Dequeue();
      Console.WriteLine($"Loại bỏ hồ sơ {hs} và còn lại {hoso.Count}");
      hs = hoso.Dequeue();
      Console.WriteLine($"Loại bỏ hồ sơ {hs} và còn lại {hoso.Count}");
    

    }
    public static void TestStack()
    {
      Stack<string> matHang = new Stack<string>();
      matHang.Push("Mat hang 1");
      matHang.Push("Mat hang 2");
      matHang.Push("Mat hang 3");
      matHang.Push("Mat hang 4");

      var delete = matHang.Pop();
      Console.WriteLine($"kq: {delete}");
      delete = matHang.Pop();
      Console.WriteLine($"kq: {delete}");
      delete = matHang.Pop();
      Console.WriteLine($"kq: {delete}");
    }
  }
}