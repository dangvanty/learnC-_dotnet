using Testqq;
using Abstract;
using interfaces;
using virtuals;
// var snumber = XTL.Utils.NumberToText(566776768989);
// Console.WriteLine(snumber);
// Console.ReadLine();

double number1 = -12345678.3445435;
string nu1ToText = number1.ToString("##,##");
double texttoNum = Convert.ToDouble(nu1ToText);
// 12,345,678 12345678

// Console.WriteLine($"{nu1ToText} {texttoNum}");
// Random rn = new Random();
// Console.WriteLine($"{Int32.MaxValue} --> max value");
// Console.ReadKey();

// sử dụng thư viện Json. 
useNewtonsoftJson.TestSerializeJson();
useNewtonsoftJson.TestDeserializeJson();
// Console.ReadLine();
// int n=90;
// testRefOut.Test(4,ref n);
// string s = "Anh ấy nói, ""Đây là C#""" //~ Anh ấy nói "Đây là C#"
string s = "Đặng Văn Tỵ";
string s1 = s.PadLeft(20);
Console.WriteLine(1.ToString().Replace("1","0"));
testRefOut.Clm();
TestEnum.test_enum();
TestEnum.show_value_enum();

TestProduct.Product.ShowInfo();

TestP.nestP newP = new TestP.nestP();
newP.manufactory = new TestP.nestP.Manyfactory("Hi");
newP.ShowManyfactory();

//test Generic::::::
TestGeneric.Generic.ArrayTest<int> ArrName = new TestGeneric.Generic.ArrayTest<int>();
TestGeneric.Generic.ArrayTest<string> ArrName1 = new TestGeneric.Generic.ArrayTest<string>();
ArrName.Name = 900;
ArrName.ShowName();
ArrName1.Name="hellllp";
ArrName1.ShowName();

Console.WriteLine("check::::::::");
dynamic hei = System.DateTime.Now;
Console.WriteLine(hei);

Console.WriteLine(":::::::check----anonymous--");
TestAnonymous.Anonymous.Show();

Console.WriteLine(":::::::::::check--abstract---------");

IPhone iphone = new IPhone("iphone10");
iphone.showName();

Console.WriteLine(":::::::::::check--interface---------");

Student student = new Student();
student.Batminton();

Console.WriteLine(":::::::::::check--virtual---------");

Worker worker = new Worker();
worker.setName();
worker.showInfo();

