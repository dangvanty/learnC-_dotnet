namespace TestP
{

  class nestP
  {
    public Manyfactory manufactory{set;get;}
    public class Manyfactory
    {
      public string Name {set;get;}
      public Manyfactory(string name){
        this.Name = name;
      }
      public string showName()
      {
       return $"{this.Name}" ;
      }
    }
   

    public void ShowManyfactory ()
    {
      string namF = manufactory.showName();
      Console.WriteLine(namF);
    }
  }
}