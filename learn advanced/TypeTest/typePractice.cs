using System.Reflection;

namespace TypeTest
{
  // attribute:::
  // [AttributeName(thamso)]
  partial class User 
  {
    // [AttributeName(thamsokhoitao)]
    public string Name {set;get;}
    public int Age {set;get;}
    public string PhoneNumber {set;get;}
    public string Email {set;get;}
    [Obsolete("Phuong thuc nay ko su dung nua can thay boi showInfo()")]
    public void PrintUser()=>Console.WriteLine(Name);

  }
  partial class typePractice
  {
    // Type --> class, struct..., int, bool 
    // Attribute 
    // Reflection --> thông tin kiểu dữ liệu, kiểu thực thi 
    // AttributeName 
    public static void Test()
    {
      int[] a ={1,3,5,6} ;
      var typeA = a.GetType();
      Console.WriteLine(typeA.FullName);
       
      Console.WriteLine("----- cac thuoc tinh -----");
      
      typeA.GetProperties().ToList().ForEach(
        (PropertyInfo o)=>{
          Console.WriteLine(o.Name);
        }
      );
      
      Console.WriteLine("----- các phuong thuc----");
      typeA.GetMethods().ToList().ForEach(
        (MethodInfo o)=>{
          Console.WriteLine(o);
        }
      );
    }

    public static void Test1()
    {
      User user = new User(){
        Name = "tyDang",
        Age = 30,
        PhoneNumber ="089080098",
        Email = "tydang@gmail.com"
      };

      var properties = user.GetType().GetProperties();

      foreach (PropertyInfo proper in properties)
      {
        string name = proper.Name;
        var value = proper.GetValue(user);
        Console.WriteLine($"{name}  : {value}");
      }
    }
    public static void Test2()
    {
      User user = new User(){
        Name = "tyDang",
        Age = 30,
        PhoneNumber ="089080098",
        Email = "tydang@gmail.com"
      };

      user.PrintUser();
    }
  }
}