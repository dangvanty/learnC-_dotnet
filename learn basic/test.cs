namespace ok 
{
class Test :IDisposable
{
  public string Name{set;get;}
  public Test(string name){
    this.Name = name;
    Console.WriteLine();
  }

  public void Dispose()
  {
    // not thing 
    throw new NotImplementedException();
  }
}

}
