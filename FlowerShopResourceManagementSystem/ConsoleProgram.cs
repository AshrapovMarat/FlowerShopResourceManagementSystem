using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlowerShopResourceManagementSystem
{
  internal class ConsoleProgram
  {
    public void StartProgram()
    {
      FileConnector connector = new FileConnector("");
      ProductService productService = new ProductService(connector.GetProductsFromFile());
      string name, newName;
      double price, newPrice;
      int quantity;
      while (true)
      {
        Console.WriteLine("Напишите какие действия вы хотите сделать:\n1. Вывести весь список продуктов.\n2. Добавить товар.\n3. Изменить цену товара.\n4. Изменить название товара.\n" +
          "5. Изменить цену товара.\n6. Увеличить количество товара.\n7. Уменьшить количество товара.\n8. Удалить товар.");
        var key = Console.ReadKey(true).Key;
        Console.Clear();
        switch (key)
        {
          // Вывести весь список продуктов.
          case ConsoleKey.D1:
            ProductListOutput(productService.GetProducts());
            break;

          // Добавить товар.
          case ConsoleKey.D2:
            name = ReadName();
            price = ReadPrice();
            quantity = ReadQuantity();
            productService.AddProducts(name, price, quantity);
            connector.SaveProduct(productService.GetProducts());
            break;

          // Изменить цену товара.
          case ConsoleKey.D3:
            name = ReadName();
            price = ReadPrice("Введите новую цену товара: ");
            productService.ChangeProductPrice(name, price);
            break;

          // Изменить название товара.
          case ConsoleKey.D4:
            name = ReadName();
            newName = ReadName("Введите новое название товара: ");
            productService.ChangeProductName(name, newName);
            break;

          // Изменить цену товара.
          case ConsoleKey.D5:
            name = ReadName();
            newPrice = ReadPrice("Введите новую цену товара");
            productService.ChangeProductPrice(name, newPrice);
            break;

          // Увеличить количество товара.
          case ConsoleKey.D6:
            name = ReadName();
            quantity = ReadQuantity();
            productService.IncreaseTheNumberOfProducts(name, quantity);
            break;

          // Уменьшить количество товара.
          case ConsoleKey.D7:
            name = ReadName();
            quantity = ReadQuantity();
            productService.ReduceTheNumberOfProducts(name, quantity);
            break;

          // Удалить товар.
          case ConsoleKey.D8:
            name = ReadName();
            productService.DeleteProduct(name);
            break;
        }
      }
    }

    /// <summary>
    /// Вывод списка товаров.
    /// </summary>
    /// <param name="products">Список товаров.</param>
    void ProductListOutput(List<Product> products)
    {
      int maxLengthName = 0;
      int maxLengthPrice = 0;
      int maxLengthQuantity = 0;
      foreach (var product in products)
      {
        if (product.Name.Length > maxLengthName)
        {
          maxLengthName = product.Name.Length;
        }
        if (product.Price.ToString().Length > maxLengthPrice)
        {
          maxLengthPrice = product.Price.ToString().Length;
        }
        if (product.QuantityInStock.ToString().Length > maxLengthQuantity)
        {
          maxLengthQuantity = product.QuantityInStock.ToString().Length;
        }
      }
      foreach (var product in products)
      {
        //Console.WriteLine(string.Format($"|{product.Name, maxLengthName}|{2,3}|{4,5}", product.Name, maxLengthName - 1, product.Price, -maxLengthPrice - 1, product.QuantityInStock, -maxLengthQuantity - 1));
      }
    }

    /// <summary>
    /// Прочитать с консоли название товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщение, что надо ввести.</param>
    /// <returns>Возращает имя товара введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь ввел пустую строку.</exception>
    string ReadName(string textMessage = "Введите название товара: ")
    {
      Console.Write(textMessage);
      string name = Console.ReadLine();
      if (name != null)
      {
        return name;
      }
      else
      {
        throw new FormatException("Введена пустая строка.");
      }
    }

    /// <summary>
    /// Прочитать с консоли цену товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщение, что надо ввести.</param>
    /// <returns>Возращает цену товара введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь ввел пустую строку.</exception>
    double ReadPrice(string textMessage = "Введите цену товара: ")
    {
      Console.Write(textMessage);
      double price = Convert.ToDouble(Console.ReadLine());
      if (!(price.ToString().Split('.', ',').Length > 2))
      {
        return price;
      }
      else
      {
        throw new FormatException("Введено не коректое число.");
      }
    }

    /// <summary>
    /// Прочитать с консоли количество товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщение, что надо ввести.</param>
    /// <returns>Возращает количество товара введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь вел не корректное число.</exception>
    int ReadQuantity(string textMessage = "Введите количество товара: ")
    {
      Console.Write(textMessage);
      //int quantity = Convert.ToInt32(Console.ReadLine().Count() == 0 ? throw new FormatException("Введена пустая строка.") : Console.ReadLine());
      int quantity = Convert.ToInt32(Console.ReadLine());
      if (quantity != null)
      {
        return quantity;
      }
      else
      {
        throw new FormatException("Введена пустая строка.");
      }
    }
  }
}
