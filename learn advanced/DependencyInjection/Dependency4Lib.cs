using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
  class DepenInjecLib
  {
    public static void Test()
    {
      // thu vien dependency Injection
      // Di Container : ServiceCollection
      // - Dang ky cac dich vu (lop)
      // - ServiceProvider --> Get service 
      var services = new ServiceCollection();

      // dang ky dich vu ....
      // IClassC, ClassC, ClassC1 

      // Singleton
      //tham so 1 chi ra ten dv, tham so 2 kieu dv tao ra
      // services.AddSingleton<IClassC,classC1>(); // dv IclassC la doi tuong cua lop classC1

      // Transient: moi lan truy cap lay ra dich vu thi doi tuong moi se tao ra
      // services.AddTransient<IClassC,classC1>(); // dv IclassC la doi tuong cua lop classC1
      // --> neu ko co doi tuong thuoc lop classC1 thi no se tu khoi tao


      // addScoped ::: 
      // trong mỗi phạm vi chỉ có 1 đối tượng tồn tại. 
      services.AddScoped<IClassC,classC1>();
      var provider = services.BuildServiceProvider();

    //  var classc= provider.GetService<IClassC>();
    for (int i = 0; i < 5; i++)
    {
      IClassC c = provider.GetService<IClassC>();
      Console.WriteLine(c.GetHashCode());
    }

    using (var scope = provider.CreateScope())
    {
      var provider1 = scope.ServiceProvider;
      for (int i = 0; i < 5; i++)
      {
        IClassC c = provider1.GetService<IClassC>();
        Console.WriteLine(c.GetHashCode());
      }
    }
    }
  }
}