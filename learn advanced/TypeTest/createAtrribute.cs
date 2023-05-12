using System.Reflection;

namespace TypeTest
{
  // attribute:::
  // [AttributeName(thamso)]
  /*
  Mo ta: 
    - thongtinchitiet: 

  */
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]// mota duoc su dung o dau (lop, property, method)
  class MotaAttribute:Attribute
  {
    public string Thongtinchitiet {set;get;}
    public MotaAttribute(string _thongtinchitiet)
    {
      Thongtinchitiet=_thongtinchitiet;
    }

  }
  [Mota("class user")]
  class User2 
  {
    [Mota("Ten nguoi dung")]
    public string Name {set;get;}
    [Mota("tuoi nguoi dung")]
    public int Age {set;get;}
    [Mota("điện thoại người dùng")]
    public string Phone{set;get;}
    [Mota("Email người dùng")]
    public string Email {set;get;}
  }
   partial class typePractice
   {
    public static void Test3()
    {
      User2 user2 = new User2()
      {
        Name="Tydang",
        Age=839,
        Email="tydang@gmail.com",
        Phone="9089098908"
      };

      var properties = user2.GetType().GetProperties();

      foreach (PropertyInfo property in properties)
      {
        foreach (var attr in property.GetCustomAttributes(false))
        {
          MotaAttribute mota = attr as MotaAttribute; // === (MotaAttribute)attr;
          if(mota!=null)
          {
            Console.WriteLine(mota.Thongtinchitiet);
            var value = property.GetValue(user2);
            var name = property.Name;
            Console.WriteLine($"({name}) - {mota.Thongtinchitiet} --{value} ");
          }
        }
      }
    }
   }
}