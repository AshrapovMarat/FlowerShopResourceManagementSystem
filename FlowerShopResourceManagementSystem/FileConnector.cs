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
  /// <summary>
  /// Класс для получение и записованием данных в файл.
  /// </summary>
  internal class FileConnector
  {
    public List<Product> GetProductsFromFile()
    {
      if (!File.Exists("Products.json")) {
        File.Create("Products.json").Close();
      }

      string json = File.ReadAllText("Products.json");
      if (json != "")
      {
        return JsonSerializer.Deserialize<List<Product>>(json);
      }

      return new List<Product>();
    }

    public void SaveProduct(List<Product> products)
    {
      string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = true });
      File.WriteAllText("Products.json", json);
    }
  }
}
