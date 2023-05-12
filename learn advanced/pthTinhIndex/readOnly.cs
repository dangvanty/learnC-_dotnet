namespace PthTinhIndex
{
  class Student
  {
    public readonly string name;
    public Student (string _name)
    {
      this.name = _name;
    }
  }

  class Vector 
  {
    double x;
    double y;

    public Vector(double _x, double _y)
    {
      x= _x;
      y= _y;
    }

    public  void Info()
    {
      Console.Write($"Tọa độ x = {x} ,  ");
      Console.WriteLine($"Tọa độ y = {y}");
    }

    // khai báo toán tử cộng
    // vector <-- vector + vector
    public static Vector operator+(Vector v1, Vector v2)
    {
      // return new Vector(v1.x+v2.x , v1.y + v2.y);
      double x = v1.x + v2.x;
      double y = v1.y + v2.y;
      Vector v = new Vector(x,y);
      return v;
    }
  }
  partial class PthTinhIndexTest
  {
    public static void Test1()
    {
      Student st1 = new Student("Tỵ Nè");

      Console.WriteLine(st1.name);
    }
    public static void Test2()
    {
      Vector vt1 = new Vector(4,6);
      Vector vt2 = new Vector(9,6);

      // cộng 2 vector: (x1+x2; y1+y2);
      var v = vt1+vt2;
      vt1.Info();
      vt2.Info();
      v.Info();
    }
    
  }
}