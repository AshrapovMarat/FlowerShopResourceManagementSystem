using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  internal class ConsoleProgram
  {
    public void StartProgram()
    {
      FileConnector connector = new FileConnector("");
      ProductService productService = new ProductService(connector.GetProductsFromFile());
      while (true)
      {
        Console.WriteLine("Напишите какие действия вы хотите сделать:\n1. Вывести весь список продуктов.\n2. Добавить товар.\n3. Изменить цену товара.\n4. Изменить название товара.\n" +
          "5. Изменить цену товара.\n6. Увеличить количество товара.\n7. Уменьшить количество товара.\n8. Удалить товар.");
        var key = Console.ReadKey().Key;
        switch (key)
        {
          // Вывести весь список продуктов.
          case ConsoleKey.D1:
            ProductListOutput(productService.GetProducts());
            break;
          // Добавить товар.
          case ConsoleKey.D2:

            break;
          // Изменить цену товара.
          case ConsoleKey.D3:

            break;
          // Изменить название товара.
          case ConsoleKey.D4:

            break;
          // Изменить цену товара.
          case ConsoleKey.D5:

            break;
          // Увеличить количество товара.
          case ConsoleKey.D6:

            break;
          // Уменьшить количество товара.
          case ConsoleKey.D7:

            break;
          // Удалить товар.
          case ConsoleKey.D8:

            break;
        }
      }
    }

    void ProductListOutput(List<Product> products)
    {
      foreach (var product in products)
      {
        Console.WriteLine(string.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", product.Name, product.Price, product.QuantityInStock));
      }
    }
  }
}
