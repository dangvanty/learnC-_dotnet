namespace CS_event
{

  /*
    publiser --> class --> phát sự kiện
    subcriber --> class --> nhận sự kiện

  */
  public delegate void skNhapSo1 (int x);
  class UserInput1
  {
    public event skNhapSo1 sknhapso1;

// tương đương delegate void KIEU (object ? sender, EventArgs args)
    // public event EventHandler sknhapso1; 
    public void Input()
    {
      do
      {
        Console.Write("Nhập vào số: ");
        string s = Console.ReadLine();
        int i = Int32.Parse(s);
        sknhapso1?.Invoke(i); // phat sk 
      } while (true);
     
    }
  }

  class TinhCan1
  {
    public void Sub (UserInput1 input)
    {
      // nhận sk
      input.sknhapso1 += Can;
    }
    public void Can (int x)
    {
      Console.WriteLine($"Căn bậc 2 của số {x} là: {Math.Sqrt(x)}");
    }
  }

  class TinhBinhPhuong1
  {
    public void Sub(UserInput1 input)
    {
      input.sknhapso1 += BinhPhuong;
    }
    public void BinhPhuong (int x)
    {
      Console.WriteLine($"Bình phương của số {x} là: {x*x}");
    }
  }
  partial class eventTest1
  {
    public static void showTest1(){
      // publisher
      UserInput1 userInput1 = new UserInput1();

      // Đăng ký sự kiện với hàm lambda
      userInput1.sknhapso1 += x=>{
        Console.WriteLine($"Bạn vừa nhập số {x} nè");
      };
      //subcriber1
      TinhCan1 tinhCan = new TinhCan1();
      tinhCan.Sub(userInput1);

      //subcriber2
      TinhBinhPhuong1 tinhBinhPhuong = new TinhBinhPhuong1();
      tinhBinhPhuong.Sub(userInput1);
      userInput1.Input();
    }
   
  }
}