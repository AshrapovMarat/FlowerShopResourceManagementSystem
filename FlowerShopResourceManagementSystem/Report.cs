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
  /// Отчет.
  /// </summary>
  internal class Report
  {
    #region Поля и свойства

    /// <summary>
    /// Экзмемпляр для работы с объектами Product.
    /// </summary>
    ProductService productService;

    #endregion

    #region Методы
    /// <summary>
    /// Создать отчет.
    /// </summary>
    public void CreateReport()
    {
      string json = File.ReadAllText("Products.json");
      List<Product> products = ConnectorDB.GetProducts();
      this.SortReport(products);
      Console.WriteLine("Выберите действие которое хотите выполнить: \n1. Создать отчет.\n2. Поменять сортировку в отчете.\n3. Выйти в главное окно.\n");
      var key = Console.ReadKey(true).Key;
      switch (key)
      {
        case ConsoleKey.D1:
          Console.WriteLine("Напишите путь к каталогу, в котором будет сохранен файл.");
          string directoryPath = Console.ReadLine();
          Console.WriteLine("Напишите название файла.");
          string nameReport = Console.ReadLine();
          this.CreateFile(directoryPath + "\\" + nameReport + ".txt", productService, products);
          break;
        case ConsoleKey.D2:
          CreateReport();
          break;
        case ConsoleKey.D3:
          break;
      }
    }

    /// <summary>
    /// Сортировка отчета.
    /// </summary>
    /// <param name="products">Список товаров.</param>
    void SortReport(List<Product> products)
    {
      Console.Clear();
      Console.WriteLine("Напишите по какому полю хотите остортировать список товаров: \n1. По имени.\n2. По цене.\n3. По количеству товаров на складе." +
        "\n4. По количеству закупленых товаров.\n5. По количеству проданных товаров.\n6. По общей стоимости покупки товаров.\n7. По общей стоимости продажи товаров.");
      var key = Console.ReadKey(true).Key;
      Console.Clear();
      switch (key)
      {
        case ConsoleKey.D1:
          products.Sort((x, y) => x.Name.CompareTo(y.Name));
          Console.WriteLine("Список отсортирован по имени.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D2:
          products.Sort((x, y) => x.Price.CompareTo(y.Price));
          Console.WriteLine("Список отсортирован по цене.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D3:
          products.Sort((x, y) => x.QuantityInStock.CompareTo(y.QuantityInStock));
          Console.WriteLine("Список отсортирован по количеству товаров на складе.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D4:
          products.Sort((x, y) => x.TotalPurchasesCount.CompareTo(y.TotalPurchasesCount));
          Console.WriteLine("Список отсортирован по количеству всего купленых товаров.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D5:
          products.Sort((x, y) => x.TotalSalesCount.CompareTo(y.TotalSalesCount));
          Console.WriteLine("Список отсортирован по количеству всего проданных товаров.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D6:
          products.Sort((x, y) => x.TotalCostPurchased.CompareTo(y.TotalCostPurchased));
          Console.WriteLine("Список отсортирован по общей стоимости покупки товаров.");
          Console.WriteLine(productService.GetProductList(products));
          break;
        case ConsoleKey.D7:
          products.Sort((x, y) => x.TotalSalesValue.CompareTo(y.TotalSalesValue));
          Console.WriteLine("Список отсортирован по общей стоимости продажи товаров.");
          Console.WriteLine(productService.GetProductList(products));
          break;

      }
    }

    /// <summary>
    /// Создание файла с отчетом.
    /// </summary>
    /// <param name="path">Путь в котором сохраниться отчет.</param>
    /// <param name="productService">Экземпляр объекта для работы с товарами.</param>
    /// <param name="products">Список товаров.</param>
    /// <exception cref="DirectoryNotFoundException">Возникает, если не найден путь к файлу.</exception>
    void CreateFile(string path, ProductService productService, List<Product> products)
    {
      if (!Directory.Exists(Path.GetDirectoryName(path)))
      {
        throw new DirectoryNotFoundException("Каталог не найден.");
      }
      if (File.Exists(Path.GetFileName(path)))
      {
        File.Create(path).Close();
      }

      File.WriteAllText(path, productService.GetProductList(products));
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="productService">Экзмемпляр для работы с объектами Product.</param>
    public Report(ProductService productService)
    {
      this.productService = productService;
    }

    #endregion
  }
}