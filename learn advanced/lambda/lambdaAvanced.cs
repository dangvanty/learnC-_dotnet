namespace lambdaTest
{
  partial class TestLambda
  {
    public static void testLamAdvanced1()
    {
      int [] mang = {1,2,3,4,67,89};
      // kiểu mảng có 1 số phương thức truyền tham số là 1 lambda
      var kq = mang.Select(
        (x)=>{
        return Math.Sqrt(x);
        }
      );

      foreach (var item in kq)
      {
        Console.WriteLine($"Cac phan tu : {item}");
      }

    }
    public static void testLamAdvanced2()
    {
      int [] mang = {2,3,54,646};
      mang.ToList().ForEach(
        (x)=>{
          if(x%2==0){
            Console.WriteLine($"số chẵn {x}");
          }
        }
        );
    }
    public static void testLamAdvanced3()
    {
      int [] mang = {1,4,65,767,5454,43};
      // trả về mảng có các phần từ lớn hơn 45
      var kq= mang.Where (x=>x>45);
      foreach (var item in kq)
      {
        Console.WriteLine($"test vs where {item}");
      }
    }
  }
}