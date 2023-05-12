namespace Abstract
{ 
  abstract class Product
  {
    string name;
    public Product(string name)
    {
      this.name = name;
    }
    public string Name{get=>name;}
    public abstract void showName();

  }
  class IPhone : Product
  {
    public IPhone(string name):base(name)
    {
      
    }
    public override void showName()
    {
      Console.WriteLine(this.Name);
    }
  }
}