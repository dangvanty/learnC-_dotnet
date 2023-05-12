namespace CS_event
{

  /*
    publiser --> class --> phát sự kiện
    subcriber --> class --> nhận sự kiện

  */
  public delegate void skNhapSo (int x);
  class UserInput
  {
    public skNhapSo sknhapso{set;get;}
    public void Input()
    {
      do
      {
        Console.Write("Nhập vào số: ");
        string s = Console.ReadLine();
        int i = Int32.Parse(s);
        sknhapso?.Invoke(i); // phat sk 
      } while (true);
     
    }
  }

  class TinhCan
  {
    public void Sub (UserInput input)
    {
      // nhận sk
      input.sknhapso = Can;
    }
    public void Can (int x)
    {
      Console.WriteLine($"Căn bậc 2 của số {x} là: {Math.Sqrt(x)}");
    }
  }

  class TinhBinhPhuong
  {
    public void Sub(UserInput input)
    {
      input.sknhapso = BinhPhuong;
    }
    public void BinhPhuong (int x)
    {
      Console.WriteLine($"Bình phương của số {x} là: {x*x}");
    }
  }
  partial class eventTest1
  {
    public static void showTest(){
      // publisher
      UserInput userInput = new UserInput();
      
      //subcriber1
      TinhCan tinhCan = new TinhCan();
      tinhCan.Sub(userInput);

      //subcriber2
      TinhBinhPhuong tinhBinhPhuong = new TinhBinhPhuong();
      tinhBinhPhuong.Sub(userInput);
      userInput.Input();
    }
   
  }
}