using NUnit.Framework;
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
    #region Методы

    /// <summary>
    /// Метод, который запускает начало работы программы.
    /// </summary>
    public void StartProgram()
    {
      ProductService productService = new ProductService();
      string name, newName;
      double price, newPrice;
      int quantity;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("Напишите какие действия вы хотите сделать:\n1. Вывести весь список продуктов.\n2. Добавить товар." +
          "\n3. Изменить цену товара.\n4. Увеличить количество товара.\n5. Уменьшить количество товара.\n6. Удалить товар.\n7. Создать отчет.\n8. Выйти из программы.");
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
              name = this.ReadName("Введите название товара, который хотите добавить: ");
              price = this.ReadPrice("Введите цену товара, который хотите добавить: ");
              quantity = this.ReadQuantity("Введите количество товара, который хотите добавить: ");
              productService.AddProduct(name, price, quantity);
            }
            catch (СreatingElementException ex)
            {
              continue;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            break;

          // Изменить цену товара.
          case ConsoleKey.D3:
            try
            {
              name = this.ReadName("Введите название товара, цену которого хотите изменить: ");
              price = this.ReadPrice("Введите новую цену товара: ");
              productService.ChangeProductPrice(name, price);
            }
            catch (СreatingElementException ex)
            {
              continue;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            break;

          // Увеличить количество товара.
          case ConsoleKey.D4:
            try
            {
              name = this.ReadName("Введите название товара, у которого хотите увеличить количество: ");
              quantity = this.ReadQuantity("Введиет на сколько хотите увеличить количество: ");
              productService.IncreaseTheNumberOfProducts(name, quantity);
            }
            catch (СreatingElementException ex)
            {
              continue;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            break;

          // Уменьшить количество товара.
          case ConsoleKey.D5:
            try
            {
              name = this.ReadName("Введите название товара, у которого хотите уменьшить количество: ");
              quantity = this.ReadQuantity("Введиет на сколько хотите уменьшить количество: ");
              productService.ReduceTheNumberOfProducts(name, quantity);
            }
            catch (СreatingElementException ex)
            {
              continue;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            break;

          // Удалить товар.
          case ConsoleKey.D6:
            try
            {
              name = this.ReadName("Напишите название товара, который хотите удалить: ");
              productService.DeleteProduct(name);
            }
            catch (СreatingElementException ex)
            {
              continue;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.WriteLine("Для продолжения нажмите на любую клавишу.");
              Console.ReadKey();
              continue;
            }
            break;

          // Создать отчет.
          case ConsoleKey.D7:
            Report report = new Report(productService);
            report.CreateReport();
            break;

          // Выйти из программы.
          case ConsoleKey.D8:
            Environment.Exit(0);
            break;
        }
      }
    }

    /// <summary>
    /// Прочитать с консоли название товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщения, что надо ввести.</param>
    /// <returns>Возращает название товара введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает, когда пользователь ввел пустую строку.</exception>
    string ReadName(string textMessage)
    {
      Console.Write(textMessage);
      string inputName = ReadLineFromConsole();
      return ProductValidator.ValidateName(inputName);
    }

    /// <summary>
    /// Прочитать с консоли цену товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщения, что надо ввести.</param>
    /// <returns>Возращает цену товара, введеную с консоли.</returns>
    /// <exception cref="FormatException">Возникает, когда пользователь ввел пустую строку.</exception>
    double ReadPrice(string textMessage = "Введите цену товара: ")
    {
      Console.Write(textMessage);
      string inputPrice = ReadLineFromConsole();
      return ProductValidator.ValidatePrice(inputPrice);
    }

    /// <summary>
    /// Прочитать с консоли количество товара.
    /// </summary>
    /// <param name="textMessage">Вывод сообщения, что надо ввести.</param>
    /// <returns>Возращает количество товара, введеное с консоли.</returns>
    /// <exception cref="FormatException">Возникает, когда пользователь ввел некорректное число.</exception>
    int ReadQuantity(string textMessage = "Введите количество товара: ")
    {
      Console.Write(textMessage);
      string inputQuantity = ReadLineFromConsole();
      if (inputQuantity == null)
      {
        throw new FormatException("Введено не коректое число.");
      }
      return ProductValidator.ValidateQuantity(inputQuantity);
    }

    /// <summary>
    /// Считывание строки.
    /// </summary>
    /// <returns>Введеную строку.</returns>
    /// <exception cref="СreatingElementException">Вызывается когда пользователь нажимает клавишу esc.</exception>
    string ReadLineFromConsole()
    {
      StringBuilder input = new StringBuilder();
      ConsoleKeyInfo key;

      do
      {
        key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Backspace && input.Length > 0)
        {
          input.Remove(input.Length - 1, 1);
          Console.Write("\b \b");
        }
        else if (!char.IsControl(key.KeyChar))
        {
          input.Append(key.KeyChar);
          Console.Write(key.KeyChar);
        }
        else if (key.Key == ConsoleKey.Escape)
        {
          throw new СreatingElementException();
        }
      }
      while (key.Key != ConsoleKey.Enter);
      Console.WriteLine();
      return input.ToString();
    }
    #endregion
  }
}
