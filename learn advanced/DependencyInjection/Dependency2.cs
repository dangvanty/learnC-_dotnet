namespace DependencyInjection
{

  interface IClassC
  {
    public void ActionC();
  }
  interface IClassB
  {
    public void ActionB();
  }
  class classC1 : IClassC
  {
    public classC1()
    {
      Console.WriteLine("C1 is created");
    }
    public void ActionC()
    {
      Console.WriteLine("ActionC1");
    }
  }
  class classB1 : IClassB
  {
    IClassC C_depen;
    public classB1(IClassC _classC)=>C_depen = _classC;
    public void ActionB()
    {
      Console.WriteLine("ActionB1");
      C_depen.ActionC();
    }
  }

  class classA1
  {
    IClassB B_depen;
    public classA1(IClassB _classB)=>B_depen = _classB;
    public void ActionA()
    {
      Console.WriteLine("ActionA");
      B_depen.ActionB();
    }
  }
  partial class DependencyInjectionTest
  {
    public static void Test1 ()
    {
      // khi trien khai theo interface hoac abstract class thi khi thay cac lop ke thua tu inter, abs thi deu hoat dong. 
      IClassC clsC = new classC1();
      IClassB clsB = new classB1(clsC);
      classA1 clsA = new classA1(clsB);

      clsA.ActionA();



    }
  }
}