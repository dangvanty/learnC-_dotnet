namespace DependencyInjection
{
  /*
    Inversion of Control
    Dependency injection
    Không áp dụng kỹ thuật DI
    Áp dụng kỹ thuật DI
    Những kiểu DI
    DI Container
    Lớp ServiceCollection
    Lớp ServiceProvider
    Sử dụng DI cơ bản
    Sử dụng Delegate / Factor để đăng ký dịch vụ
    Sử dụng Options khởi tạo dịch vụ
    Sử dụng cấu hình từ file thiết lập
  */
  class classC
  {
    public void ActionC()=>Console.WriteLine("Action C start");
  }

  class classB
  {
    classC C_dependency;

    public classB(classC _classC)=>C_dependency = _classC;
    public void ActionB()
    {
      Console.WriteLine("Action B start");
      C_dependency.ActionC();
    }
  }
  class classA
  {
    classB B_dependency;
    public classA(classB _classB)=>B_dependency = _classB;
    public void ActionA()
    {
      Console.WriteLine("Action A start");
      B_dependency.ActionB();
    }
  }
  partial class DependencyInjectionTest
  {
    public static void Test ()
    {
      // class C là phụ thuộc của ClassB và ClassB là phụ thuộc của ClassA
     
      classC objC = new classC();
      classB objB = new classB(objC);
      classA objA = new classA(objB);
      /* de hoan thanh nhiem vu thi class A phai tham chieu den 
        classB va de hoan thanh nhiem vu thi classB phai tham chieu den classC
      */
      objA.ActionA();

    }
  }
}