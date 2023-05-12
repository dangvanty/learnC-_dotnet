namespace PthTinhIndex
{
  
  class Vector1
  {
    double x;
    double y;

    public Vector1(double _x, double _y)
    {
      x=_x;
      y=_y;
    }

    public void Info()
    {
      Console.Write($"Tọa độ điểm x : {x}  ,");
      Console.WriteLine($"Tọa độ điểm y : {y}");
    }

    public static Vector1 operator+(Vector1 v1, double x)
    {
      double a = v1.x + x;
      double b = v1.y + x;
      Vector1 v = new Vector1(a,b);
      return v;
    }

    // indexxer::
    public double this[int i]
    {
      set {
        switch (i)
        {
          case 0:
            x=value;
            break;
          case 1:
            y=value;
            break;
          default:
            throw new Exception("Chỉ số sai");
        }
      }

      get {
        switch (i)
        {
          case 0:
            return x;
          case 1:
            return y;
          default:
            throw new Exception("chỉ số sai");
        }
      }
    }
  }

  partial class PthTinhIndexTest
  {
    public static void Test3()
    {
      Vector1 v1 = new Vector1(2,4);
      var v = v1 + 10;
      v.Info();
      Console.WriteLine($"tọa độ x là {v[0]}");
    }
  }
}