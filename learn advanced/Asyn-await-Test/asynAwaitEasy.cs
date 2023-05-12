namespace AsynAwaitTest
{
  
  partial class AsynAwait
  {
    static void DoSomeThing(int seconds, string msg, ConsoleColor color)
    {
      // Thread.Sleep --> luoong hien tai se dung lai; 
      // Thread.Sleep(5000);
      lock(Console.Out)
      {
        Console.ForegroundColor=color;
        Console.WriteLine($"{msg, 10} ...Start");
        Console.ResetColor();
      }
      
     
      for (int i = 0; i <= seconds; i++)
      {
        lock(Console.Out)
        {
          Console.ForegroundColor = color;
          Console.WriteLine($"{msg, 10} {i,2}");
          Console.ResetColor();
        }
        Thread.Sleep(1000);
      }
      lock(Console.Out)
      {
      Console.ForegroundColor=color;
      Console.WriteLine($"{msg, 10} ...End");
      Console.ResetColor();
      }
    }
   public static void Test()
   {
    // synchronous
    // Console.WriteLine("-----");
    // DoSomeThing(6,"T1", ConsoleColor.Red);
    // DoSomeThing(10,"T2", ConsoleColor.Green);
    // DoSomeThing(9,"T3", ConsoleColor.Yellow);
    // Console.WriteLine("Hello-World");

    // asynchronous: 
    // Task 
    //Cach1: 
    // Task t2 = new Task(Action); // ()=>{}
    Task t2 = new Task(
      ()=>{
        DoSomeThing(10,"T2", ConsoleColor.Green);
      }
    );

    Task t3 = new Task(
      (object ob)=>{
        string tentacvu = (string)ob;
        DoSomeThing(9,tentacvu, ConsoleColor.Yellow);
      }
    ,"T3");

    // khởi chạy::::
    t2.Start(); // Thread rieng
    t3.Start(); // Thread rieng
    DoSomeThing(6,"T1", ConsoleColor.Red);

    t2.Wait();
    t3.Wait();

    // Task.WaitAll(t2,t3) --> đảm bảo 2 task vụ hoàn thành.
    // Task t3 = new Task(Action<Object>, Object); //(Object ob)=>{}
    Console.WriteLine("Hello-World");
    Console.ReadKey();
   } 

   static async Task Task2()
   {
    Task t2 = new Task(
      ()=>{
        DoSomeThing(5, "T2",ConsoleColor.DarkBlue);
      }
    );
    t2.Start();

    await t2;
    Console.WriteLine("T2 hoan thanh");
   }
   static async Task Task3()
   {
    Task t3 = new Task(
      (object ob)=>{
        string tentacvu = (string)ob;
        DoSomeThing(9,tentacvu, ConsoleColor.Yellow);
      }
    ,"T3");
    t3.Start();
    await t3;
    Console.WriteLine("T3 hoan thanh");
   }

   public static async Task Test1()
   {
    Task t2 = Task2();
    Task t3 = Task3();

    DoSomeThing(11, "T1", ConsoleColor.Blue);
    // Task.WaitAll(t2,t3);
    await t2;
    await t3;
    Console.WriteLine("Press any key");
    Console.ReadKey();
   }

   static async Task<string> Task4()
   {
    //Cach1: 
    // Task<string> t3 = new Task<string>(Func<string>); //()=>{return string..};
      Task<string> t4 = new Task<string>(
        ()=>{
          DoSomeThing(5,"T4",ConsoleColor.DarkRed);
          return "Return for t4";
        }
      );
      t4.Start();
      string kq4 = await t4;
      Console.WriteLine("Ket thuc task 4");
      return kq4;
   }
   static async Task<string> Task5 ()
   {
    //Cach2:
    // Task<string> t4 = new Task<string>(Func< object, string>, object); //(object ob)=>{return string..};
      Task<string> t5 = new Task<string>(
        (object ob)=>{
          string t = (string)ob;
          DoSomeThing(2,t,ConsoleColor.Green);
          return "Return task 5";
        }
      ,"T5");

      t5.Start();
      string kq5 = await t5;
      Console.WriteLine("Ket thuc task 5");
      return kq5;

   }
   public static async Task Test2()
   {

    Task<string> t4 = Task4();
    Task<string> t5 = Task5();
    //  Task.WaitAll(t4,t5);
    DoSomeThing(1,"t1",ConsoleColor.Black);
    Console.WriteLine("oodfdf");
    Task.WaitAll(t4,t5);
    


    Console.WriteLine(t4.Result);
    Console.WriteLine(t5.Result);
    Console.WriteLine("End");
    Console.ReadKey();
   }
  }

}