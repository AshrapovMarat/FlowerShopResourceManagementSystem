using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace FlowerShopResourceManagementSystem
{
  internal class FileConnector
  {
    public string Path {  get; set; }

    public FileConnector(string path)
    {
      Path = path;
    }

    public List<Product> GetProductsFromFile()
    {
      string json = File.ReadAllText("list.json");
      List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

      return products;
    }

    public void SaveProduct(List<Product> products)
    {
      using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
      {
        string json = JsonSerializer.Serialize(products);
        File.WriteAllText("list.json", json);
      }
    }
  }
}
