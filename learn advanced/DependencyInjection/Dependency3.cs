namespace DependencyInjection
{
  class Horn 
  {
    int level = 0;
    public Horn(int _lvl)=>level = _lvl;
    public void Beep ()=>Console.WriteLine($" {level} Beep ---- beep");
  }
  class Car 
  {
    Horn horn {set;get;}
    // Inject bang phuong thuc: public Horn horn {set;get;}
    // Inject bang phuong thuc khoi tao
    public Car(Horn _horn)=>horn=_horn;
    public void Beep()
    {
      horn.Beep();
    }
  }
  partial class DependencyInjectionTest
  {
    public static void Test2()
    {
      Horn horn = new Horn(9);
      Car car = new Car(horn);
      car.Beep();

    }
  }
}