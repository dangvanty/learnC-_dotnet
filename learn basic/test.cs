namespace ok 
{
class Test :IDisposable
{
  public string Name{set;get;}
  public Test(string name){
    this.Name = name;
    Console.WriteLine();
    // not ne
  }

  public void Dispose()
  {
    throw new NotImplementedException();
  }
}

}
