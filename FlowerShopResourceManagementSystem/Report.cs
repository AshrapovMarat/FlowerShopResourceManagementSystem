using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Отчет
  /// </summary>
  internal class Report
  {
    ProductService productService;
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="productService"></param>
    public Report(ProductService productService)
    {
      this.productService = productService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pathSaveFile"></param>
    /// <param name="nameFieldSort"></param>
    public void CreatReport(string pathSaveFile, string nameFieldSort = "Без сортировки")
    {
      string json = File.ReadAllText("Products.json");
      List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);
      SortReport(products);
      Console.WriteLine("Выберите действие которое хотите выполнить: \n1. Создать отчет.\n2. Поменять сортировку в отчете.\n3. Выйти в главное окно.\n");
      var key = Console.ReadKey(true).Key;
      switch (key)
      {
        case ConsoleKey.D1:
          Console.WriteLine("Напишите путь к каталогу, в котором будет сохранен файл.");
          string directoryPath = Console.ReadLine();
          Console.WriteLine("Напишите название файла.");
          string nameReport = Console.ReadLine();
          CreateFile(directoryPath + "\\" + nameReport, productService, products);
          break;
        case ConsoleKey.D2:
          CreatReport("");
          break;
        case ConsoleKey.D3:
          break;
      }
    }

    void SortReport(List<Product> products)
    {
      Console.Clear();
      Console.WriteLine("Напишите по какому полю хотите остортировать список товаров: \n1. По имени.\n2. По цене.\n3. По количеству товаров на складе.\n4. По количеству закупленых товаров.\n5. По количеству проданных товаров.\n");
      var key = Console.ReadKey(true).Key;
      Console.Clear();
      switch (key)
      {
        case ConsoleKey.D1:
          products.Sort((x, y) => x.Name.CompareTo(y.Name));
          Console.WriteLine("Список отсортирован по имени.");
          Console.WriteLine(productService.GetProductList(products));
          //productService.ProductListOutput(products, "Name");
          break;
        case ConsoleKey.D2:
          products.Sort((x, y) => x.Price.CompareTo(y.Price));
          Console.WriteLine("Список отсортирован по цене.");
          Console.WriteLine(productService.GetProductList(products));
          //productService.ProductListOutput(products, "Price");
          break;
        case ConsoleKey.D3:
          products.Sort((x, y) => x.QuantityInStock.CompareTo(y.QuantityInStock));
          Console.WriteLine("Список отсортирован по количеству товаров на складе.");
          Console.WriteLine(productService.GetProductList(products));
          //productService.ProductListOutput(products, "QuantityInStock");
          break;
        case ConsoleKey.D4:
          products.Sort((x, y) => x.TotalPurchasesCount.CompareTo(y.TotalPurchasesCount));
          Console.WriteLine("Список отсортирован по закупленым товарам.");
          Console.WriteLine(productService.GetProductList(products));
          //productService.ProductListOutput(products, "TotalPurchasesCount");
          break;
        case ConsoleKey.D5:
          products.Sort((x, y) => x.TotalSalesCount.CompareTo(y.TotalSalesCount));
          Console.WriteLine("Список отсортирован по проданым товаром.");
          Console.WriteLine(productService.GetProductList(products));
          break;
      }
    }

    void CreateFile(string path, ProductService productService, List<Product> products)
    {
      if(!Directory.Exists(Path.GetDirectoryName(path))) 
      {
        throw new DirectoryNotFoundException();
      }
      if (File.Exists(Path.GetFileName(path))) 
      {
        File.Create(path).Close();
      }
      File.WriteAllText(path, productService.GetProductList(products));
    }
  }
}
