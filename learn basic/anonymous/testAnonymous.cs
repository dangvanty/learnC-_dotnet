namespace TestAnonymous
{
  class Anonymous
  {
    public class Student
    {
      public string Name {set;get;}
      public int Age {set;get;}
    }
    public static void Show()
    {
      List<Student> students = new List<Student>(){
        new Student(){Name="TyDang", Age=30},
        new Student(){Name="Khang", Age=90},
        new Student(){Name="LyTieu Long", Age=10},
        new Student(){Name="Oklaa", Age=24}
      };

      var ketqua = from sv in students
                   where sv.Age >3
                   select new {
                    name= sv.Name,
                    age = sv.Age
                   };
      foreach (var kq in ketqua)
      {
       Console.WriteLine($"ten la {kq.name}, tuoi la {kq.age}");
      }
    }
  }
}