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
  /// <summary>
  /// Класс реализует функционал для работы в консоли.
  /// </summary>
  internal class ConsoleProgram
  {
    /// <summary>
    /// Метод, который запускает начало работы программы.
    /// </summary>
    public void StartProgram()
    {
      FileConnector connector = new FileConnector();
      ProductService productService = new ProductService(connector.GetProductsFromFile());
      string name, newName;
      double price, newPrice;
      int quantity;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("Напишите какие действия вы хотите сделать:\n1. Вывести весь список продуктов.\n2. Добавить товар.\n3. Изменить цену товара.\n4. Изменить название товара.\n" +
          "5. Увеличить количество товара.\n6. Уменьшить количество товара.\n7. Удалить товар.\n8. Создать отчет.");
        var key = Console.ReadKey(true).Key;
        Console.Clear();
        switch (key)
        {
          // Вывести весь список продуктов.
          case ConsoleKey.D1:
            Console.WriteLine(productService.GetProductList(productService.GetProducts()));
            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            break;

          // Добавить товар.
          case ConsoleKey.D2:
            try
            {
              name = ReadName("Введите название товара, которого хотите добавить: ");
              price = ReadPrice("Введите цену товара, которого хотите добавить: ");
              quantity = ReadQuantity("Введите количество товара, которого хотите добавить: ");
              productService.AddProducts(name, price, quantity);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Изменить цену товара.
          case ConsoleKey.D3:
            try
            {
              name = ReadName("Введите название товара, цену которого хотите ихменить: ");
              price = ReadPrice("Введите новую цену товара: ");
              productService.ChangeProductPrice(name, price);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey(); 
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Изменить название товара.
          case ConsoleKey.D4:
            try
            {
              name = ReadName("Введите название товара, у которого хотите изменить название: ");
              newName = ReadName("Введите новое название товара: ");
              productService.ChangeProductName(name, newName);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Увеличить количество товара.
          case ConsoleKey.D5:
            try
            {
              name = ReadName("Введите название товара, у которого хотите увеличить количество товара: ");
              quantity = ReadQuantity("Введиет на сколько хотите увеличить количество товара: ");
              productService.IncreaseTheNumberOfProducts(name, quantity);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Уменьшить количество товара.
          case ConsoleKey.D6:
            try
            {
              name = ReadName("Введите название товара, у которого хотите уменьшить количество товара: ");
              quantity = ReadQuantity("Введиет на сколько хотите уменьшить количество товара: ");
              productService.ReduceTheNumberOfProducts(name, quantity);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Удалить товар.
          case ConsoleKey.D7:
            try
            {
              name = ReadName("Напишите название товара, которого хотите удалить: ");
              productService.DeleteProduct(name);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            connector.SaveProduct(productService.GetProducts());
            break;

          // Создать отчет.
          case ConsoleKey.D8:
            Report report = new Report(productService);
            report.CreatReport("");
            connector.SaveProduct(productService.GetProducts());
            break;
        }
      }
    }



    /// <summary>
    /// Прочитать с консоли название товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщение, что надо ввести.</param>
    /// <returns>Возращает имя товара введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь ввел пустую строку.</exception>
    string ReadName(string textMessage)
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
