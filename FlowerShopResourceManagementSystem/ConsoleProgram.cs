using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    #region Поля и свойства
    /// <summary>
    /// Экземпляр класса ConsoleProgram.
    /// </summary>
    private static ConsoleProgram consoleProgram = null;

    /// <summary>
    /// Экзмемпляр для работы с объектами Product.
    /// </summary>
    IProductService ProductService { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Метод для создания единичного экземпляра данного класса.
    /// </summary>
    /// <param name="productService">Экзмемпляр для работы с объектами Product.</param>
    /// <returns>Экземпляр класса ConsoleProgram.</returns>
    public static ConsoleProgram Initialize(IProductService productService)
    {
      if (consoleProgram == null)
      {
        consoleProgram = new ConsoleProgram(productService);
      }
      return consoleProgram;
    }

    /// <summary>
    /// Метод, который запускает начало работы программы.
    /// </summary>
    public void StartProgram()
    {
      string name, newName;
      double price, newPrice;
      int quantity;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("Напишите какие действия вы хотите сделать:\n1. Вывести весь список продуктов.\n2. Добавить товар." +
          "\n3. Изменить цену товара.\n4. Увеличить количество товара.\n5. Уменьшить количество товара." +
          "\n6. Удалить товар.\n7. Создать отчет.\n8. Выйти из программы.");
        var key = Console.ReadKey(true).Key;
        Console.Clear();
        switch (key)
        {
          // Вывести весь список продуктов.
          case ConsoleKey.D1:
            try
            {
              Console.WriteLine(this.ProductService.GetProductList(this.ProductService.GetProducts()));
            }
            catch(Exception ex) 
            {
              ErrorOutput(ex);
            }
            finally
            {
              WaitForUserInput();
            }
            break;

          // Добавить товар.
          case ConsoleKey.D2:
            try
            {
              name = this.ReadName("Введите название товара, который хотите добавить: ");
              price = this.ReadPrice("Введите цену товара, который хотите добавить: ");
              quantity = this.ReadQuantity("Введите количество товара, который хотите добавить: ");
              this.ProductService.AddProduct(name, price, quantity);
            }
            catch (Exception ex)
            {
              ErrorOutput(ex);
              WaitForUserInput();
            }
            break;

          // Изменить цену товара.
          case ConsoleKey.D3:
            try
            {
              name = this.ReadName("Введите название товара, цену которого хотите изменить: ");
              price = this.ReadPrice("Введите новую цену товара: ");
              this.ProductService.ChangeProductPrice(name, price);
            }
            catch (Exception ex)
            {
              ErrorOutput(ex);
              WaitForUserInput();
            }
            break;

          // Увеличить количество товара.
          case ConsoleKey.D4:
            try
            {
              name = this.ReadName("Введите название товара, у которого хотите увеличить количество: ");
              quantity = this.ReadQuantity("Введите на сколько хотите увеличить количество: ");
              this.ProductService.IncreaseTheNumberOfProducts(name, quantity);
            }
            catch (Exception ex)
            {
              ErrorOutput(ex);
              WaitForUserInput();
            }
            break;

          // Уменьшить количество товара.
          case ConsoleKey.D5:
            try
            {
              name = this.ReadName("Введите название товара, у которого хотите уменьшить количество: ");
              quantity = this.ReadQuantity("Введите на сколько хотите уменьшить количество: ");
              this.ProductService.ReduceTheNumberOfProducts(name, quantity);
            }
            catch (Exception ex)
            {
              ErrorOutput(ex);
              WaitForUserInput();
            }
            break;

          // Удалить товар.
          case ConsoleKey.D6:
            try
            {
              name = this.ReadName("Напишите название товара, который хотите удалить: ");
              this.ProductService.DeleteProduct(name);
            }
            catch (Exception ex)
            {
              ErrorOutput(ex);
              WaitForUserInput();
            }
            break;

          // Создать отчет.
          case ConsoleKey.D7:
            Report report = Report.Initialize(this.ProductService);
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
    double ReadPrice(string textMessage)
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
    public string ReadLineFromConsole()
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
          StartProgram(); 
        }
      }
      while (key.Key != ConsoleKey.Enter);
      Console.WriteLine();
      return input.ToString();
    }

    /// <summary>
    /// Вывод сообщения ошибки.
    /// </summary>
    /// <param name="ex">Объект типа Exception.</param>
    private void ErrorOutput(Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
    
    /// <summary>
    /// Ожидание нажатия клавиши.
    /// </summary>
    private void WaitForUserInput()
    {
      Console.WriteLine("Для продолжения нажмите на любую клавишу.");
      Console.ReadKey();
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="productService">Экзмемпляр для работы с объектами Product.</param>
    private ConsoleProgram(IProductService productService)
    {
      this.ProductService = productService;
    }
    
    #endregion
  }
}
