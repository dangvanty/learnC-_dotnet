namespace QueueStackDicHash
{
  class DictionaryTest
  {
    public static void Test()
    {
      Dictionary<string, int> sodem = new Dictionary<string, int>()
      {
        ["one"] = 1,
        ["two"] = 2
      };

      // thêm hoặc cập nhật
      sodem["three"] = 3;
      sodem.Add("four",4);

      // đọc

      var keys = sodem.Keys;
      foreach (var k in keys)
      {
        var value = sodem[k];
        Console.WriteLine($"tại key {k} có giá trị là {value}");  
      }
      Console.WriteLine("------- doc voi keypair ------");
      foreach (KeyValuePair<string,int> item in sodem)
      {
        var key = item.Key;
        var value = item.Value;
        Console.WriteLine($"tai key {key} co gia tri la {value}");  
      }
    }
  }
}