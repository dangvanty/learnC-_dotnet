class TestEnum{

// gia tri cua enum chay tu 0,1,2,....
enum Status {xac_nhan,ok,huy};
public static void test_enum(){
  int a = (int)Status.huy;
  Console.WriteLine($"Gia tri {a}");
}
public static void show_value_enum(){
  Status status = Status.xac_nhan;
  switch (status)
  {
    case Status.ok:
    case Status.huy:
      Console.WriteLine("Gia tri la xac nhan"); 
      break;
    default:
      Console.WriteLine("cha sai");
      break;
  }
}

}