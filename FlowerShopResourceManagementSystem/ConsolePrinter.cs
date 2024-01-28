using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Вывод текста на консоль.
  /// </summary>
  internal class ConsolePrinter
  {
    /// <summary>
    /// Получить строку с информацией о цветке.
    /// </summary>
    /// <param name="flower">Цветок.</param>
    /// <returns>Информация о цветке.</returns>
    private string GetFlowerDetails(Flower flower)
    {
      string info = $"Название цветка: {flower.Name}, цена: {flower.Price}";
      return info;
    }

    /// <summary>
    /// Вывод информации о цветке.
    /// </summary>
    /// <param name="flower">Цветок.</param>
    public void PrintFlowerDetails(Flower flower)
    {
      string info = GetFlowerDetails(flower);
      Console.WriteLine(info);
    }

    /// <summary>
    /// Вывод информации об элементе цветка.
    /// </summary>
    /// <param name="flowerItem">Элемент цветка.</param>
    public void PrintFlowerItemDetails(FlowerInventoryItem flowerItem)
    {
      string info = $"{GetFlowerDetails(flowerItem.Flower)}, количество равно {flowerItem.NumberFlowers}";
      Console.WriteLine(info);
    }

    /// <summary>
    /// Вывод списка с элементами инвентаря цветов.
    /// </summary>
    /// <param name="flowerItems">Список с элементами инвентаря цветок.</param>
    public void PrintListFlowersInventoryItem(List<FlowerInventoryItem> flowerItems)
    {
      Console.WriteLine($"{"Название".PadRight(15)} {"Цена".PadRight(5)} {"Количество".PadRight(10)}");

      foreach (FlowerInventoryItem flower in flowerItems) 
      {
        Console.WriteLine($"{flower.Flower.Name.PadRight(15)} {flower.Flower.Price.ToString().PadRight(5)} {flower.NumberFlowers.ToString().PadRight(5)}");
      }
    }

    /// <summary>
    /// Вывод списка поставщиков.
    /// </summary>
    /// <param name="suppliers">Список поставщиков.</param>
    public void PrintListSupplier(List<FlowerSupplier> suppliers)
    {
      int count = 1;
      foreach (FlowerSupplier supplier in suppliers)
      {
        Console.WriteLine($"{count}. Наименование поставщика: {supplier.Name}");
        count++;
      }
    }

    /// <summary>
    /// Вывод экзепляра поставщика.
    /// </summary>
    /// <param name="supplier">Экзепляр поставщика.</param>
    public void PrintSupplierFlowers(FlowerSupplier supplier)
    {
      int count = 1;
      foreach(var flower in supplier.flowers)
      {
        Console.WriteLine($"{count}. Название: {flower.Name}; Цена: {flower.Price}");
        count++;
      }
    }

    /// <summary>
    /// Вывод сообщение и получения строки.
    /// </summary>
    /// <param name="message">Сообщения для вывода.</param>
    /// <returns>Введеная строка.</returns>
    public string GetInput(string message = "")
    {
      Console.WriteLine(message);
      string inputString = Console.ReadLine();
      return inputString;
    }

    /// <summary>
    /// Вывод сообщения.
    /// </summary>
    /// <param name="message">Сообщения для вывода.</param>
    public void PrintText(string message = "")
    {
      Console.WriteLine(message);
    }

    /// <summary>
    /// Считывания нажатой клавиши.
    /// </summary>
    /// <param name="message">Сообщения для вывода.</param>
    /// <returns>Информация о нажатой клавиши.</returns>
    public ConsoleKeyInfo GetKey(string message = "")
    {
      Console.WriteLine(message);
      ConsoleKeyInfo consoleKey = Console.ReadKey(true);
      return consoleKey;
    }

    /// <summary>
    /// Очистка консоли.
    /// </summary>
    public void Clear()
    {
      Console.Clear();
    }
  }
}
