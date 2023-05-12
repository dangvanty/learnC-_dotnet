using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
  abstract class classI
  {
    public abstract  void hi ();
    public classI()
    {
      Console.WriteLine("tạo nè");
    }
    public void ok ()
    {
      Console.WriteLine("ok");
    }
  }
  class classB2 : classI,IClassB
  {
    IClassC C_dependency;
    string message;

    public classB2(IClassC _classC, string msg)
    {
      C_dependency = _classC;
      message = msg;
      Console.WriteLine("ClassB is created!");
      
    }
    public void ActionB()
    {
      Console.WriteLine(message);
      C_dependency.ActionC();
    }

    public override void hi()
    {
      throw new NotImplementedException();
    }
  }
  class DepenInjecLib1
  {
    public static IClassB CreateB2 (IServiceProvider provider)
    {
      // phương thức chuyên tạo ra đối tượng class b2
      var b2 = new classB2(provider.GetService<IClassC>(),"Thực hiện tại classB");
      b2.ok();
      return b2;
    }
    public static void Test()
    {
      var services = new ServiceCollection();

      // ClassA
      // IclassC, classC, classC1
      // IclassB, classB, classB1

      services.AddSingleton<classA1,classA1>();
      services.AddSingleton<IClassC,classC1>();
      // services.AddSingleton<IClassB,classB2>(
      //   // (provider)=>{
      //   //   var b2 = new classB2(provider.GetService<IClassC>(),"Thực hiện trong classB2");
      //   //   return b2;
      //   // } doi len thanh phương thức phía trên ; 
        
      // );
      services.AddSingleton<IClassB>(CreateB2);
      

      var provider = services.BuildServiceProvider();

      classA1 a = provider.GetService<classA1>();
      a.ActionA();
    }

  }
}