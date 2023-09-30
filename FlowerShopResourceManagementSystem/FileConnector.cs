using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace FlowerShopResourceManagementSystem
{
  internal class FileConnector
  {
    public string Path { get; set; }

    public FileConnector(string path)
    {
      Path = path;
    }


    public List<Product> GetProductsFromFile()
    {
      string json = File.ReadAllText("Products.json");
      if (json != "")
      {
        return JsonSerializer.Deserialize<List<Product>>(json);
      }

      return new List<Product>();
    }

    public void SaveProduct(List<Product> products)
    {
      using (FileStream fs = new FileStream("Products.json", FileMode.OpenOrCreate))
      {
        string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        File.WriteAllText("Products.json", json);
      }
    }
  }
}
