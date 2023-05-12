namespace interfaces
{
  interface OutActivity
  {
    public void Batminton();
    public void Football();
  }
  interface learning
  {
    public void Math();
  }
  class Student : OutActivity, learning
  {
    public void Batminton()
    {
      Console.WriteLine("studen play batminton!!!!!");
    }

    public void Football()
    {
      Console.WriteLine("Student play football!!!!!!!");
    }

    public void Math()
    {
      Console.WriteLine("Student learn math!!!!!!!");
    }

  }
}