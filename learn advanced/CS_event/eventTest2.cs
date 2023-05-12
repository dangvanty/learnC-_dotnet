namespace CS_event
{

  /*
    publiser --> class --> phát sự kiện
    subcriber --> class --> nhận sự kiện

  */
  class DuLieuNhap : EventArgs
  {
    public int  data {set;get;}
    public DuLieuNhap (int x) => data = x;
  }
  public delegate void skNhapSo2 (int x);
  class UserInput2
  {
    // public event skNhapSo1 sknhapso1;

// tương đương delegate void KIEU (object ? sender, EventArgs args)
    public event EventHandler sknhapso2; 
    public void Input()
    {
      do
      {
        Console.Write("Nhập vào số: ");
        string s = Console.ReadLine();
        int i = Int32.Parse(s);
        sknhapso2?.Invoke(this,new DuLieuNhap(i)); // phat sk 
      } while (true);
     
    }
  }

  class TinhCan2
  {
    public void Sub (UserInput2 input)
    {
      // nhận sk
      input.sknhapso2 += Can;
    }
    public void Can (object sender, EventArgs e)
    {
      DuLieuNhap duLieuNhap = (DuLieuNhap)e;
      int x = duLieuNhap.data;
      Console.WriteLine($"Căn bậc 2 của số {x} là: {Math.Sqrt(x)}");
    }
  }

  class TinhBinhPhuong2
  {
    public void Sub(UserInput2 input)
    {
      input.sknhapso2 += BinhPhuong;
    }
    public void BinhPhuong (object sender, EventArgs e )
    {
      DuLieuNhap  duLieuNhap = (DuLieuNhap)e;
      int x = duLieuNhap.data;
      Console.WriteLine($"Bình phương của số {x} là: {x*x}");
    }
  }
  partial class eventTest1
  {
    public static void showTest2(){

      Console.CancelKeyPress += (sender, e)=>{
        Console.WriteLine();
        Console.WriteLine("Thoát ứng dụng");
      };

      // publisher
      UserInput2 userInput2 = new UserInput2();

      // Đăng ký sự kiện với hàm lambda
      userInput2.sknhapso2 += (sender, e)=>{
        DuLieuNhap duLieuNhap = (DuLieuNhap)e;
        int x = duLieuNhap.data;
        Console.WriteLine($"Bạn vừa nhập số {x} nè");
      };
      //subcriber1
      TinhCan2 tinhCan = new TinhCan2();
      tinhCan.Sub(userInput2);

      //subcriber2
      TinhBinhPhuong2 tinhBinhPhuong = new TinhBinhPhuong2();
      tinhBinhPhuong.Sub(userInput2);

      userInput2.Input();
    }
   
  }
}