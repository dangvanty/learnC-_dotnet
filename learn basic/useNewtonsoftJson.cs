using Newtonsoft.Json;

class Product 
{
  public string Name {set;get;}
  public DateTime Expiry {set;get;}
  public string[] Sizes {set;get;}
}
class Movie
{
  public string Name {set;get;}
  public DateTime ReleaseDate{set;get;}
  public string[] Genres{set;get;}
}
class useNewtonsoftJson
{
 
  public static void TestSerializeJson (){

    Product product = new Product();
    product.Name = "Apple";
    product.Expiry = new DateTime(2008, 12, 28);
    product.Sizes = new string[] { "Small" };
    string json = JsonConvert.SerializeObject(product);
    Console.WriteLine($"kieu du lieu {json.GetType()}");
    Console.WriteLine(json+"nhuw qqq");
// {
//   "Name": "Apple",
//   "Expiry": "2008-12-28T00:00:00",
//   "Sizes": [
//     "Small"
//   ]
// }
  }

  public static void TestDeserializeJson()
  {
    string json = @"{
      'Name': 'Bad Boys',
      'ReleaseDate': '1995-4-7T00:00:00',
      'Genres': [
        'Action',
        'Comedy'
      ]
    }";
    Movie m = JsonConvert.DeserializeObject<Movie>(json);
    Console.WriteLine($"Name: {m.Name} \nRelease: {m.ReleaseDate.ToShortDateString()} \nGenter:{JsonConvert.SerializeObject(m.Genres)}");
  }
}