using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление системой цветочного магазина.
  /// </summary>
  internal class FlowerShopSystemManager
  {
    /// <summary>
    /// Вывод информации на консоль.
    /// </summary>
    private ConsolePrinter consolePrinter;

    /// <summary>
    /// Управление продажами магазина.
    /// </summary>
    private FlowerTradingManager flowerTradingManager;

    /// <summary>
    /// Класс для работы с поставщиками цветов.
    /// </summary>
    private FlowerSupplierManager flowerSupplierManager;

    /// <summary>
    /// Управление складом.
    /// </summary>
    private WarehouseManager warehouseManager;

    /// <summary>
    /// Управление финансами магазина.
    /// </summary>
    private ShopFinancesManager shopFinancesManager;

    /// <summary>
    /// Коструктор.
    /// </summary>
    public FlowerShopSystemManager()
    {
      consolePrinter = new ConsolePrinter();
      //List<FlowerSupplier> suppliers = new List<FlowerSupplier>();
      flowerSupplierManager = new FlowerSupplierManager(
        new List<FlowerSupplier>() {
          new FlowerSupplier("Комос", "89912323132", new List<Flower>() { new Flower("Роза", 15.50), new Flower("Лилия", 20.50) }),
          new FlowerSupplier("Группа", "87282348313", new List<Flower>() { new Flower("Роза", 20.50), new Flower("Лилия", 30.50) })
      });

      warehouseManager = new WarehouseManager();
      warehouseManager.CreateFlower("Роза", 11.50, 10);
      warehouseManager.CreateFlower("Лилия", 22.50, 20);

      shopFinancesManager = new ShopFinancesManager();
      flowerTradingManager = new FlowerTradingManager(warehouseManager, shopFinancesManager);
    }

    /// <summary>
    /// Начало работы программы.
    /// </summary>
    public void Start()
    {
      while (true)
      {
        consolePrinter.Clear();
        Console.WriteLine("Введите возможное действие:");
        Console.WriteLine("1. Вывести информацию о цветах и их количестве.\n2. Продать цветок.\n3. Заказать цветы у поставщика." +
          "\n4. Вывести информацию о финансах магазина.");
        ConsoleKeyInfo consoleKey = Console.ReadKey(true);
        switch (consoleKey.Key)
        {
          case ConsoleKey.D1:
            GetAllFlower();
            Console.ReadKey(true);
            break;
          case ConsoleKey.D2:
            SellFlower();
            Console.ReadKey(true);
            break;
          case ConsoleKey.D3:
            OrderFlowersFromSupplier();
            Console.ReadKey(true);
            break;
          case ConsoleKey.D4:
            GetShopFinances();
            Console.ReadKey(true);
            break;
            //case ConsoleKey.D5:
            //  Console.ReadKey(true);
            //  break;
        }
      }
    }

    /// <summary>
    /// Получить весь ассортимет цветов.
    /// </summary>
    public void GetAllFlower()
    {
      consolePrinter.Clear();
      List<FlowerInventoryItem> flowerItems = warehouseManager.GetAllFlowers();
      consolePrinter.PrintListFlowersInventoryItem(flowerItems);
    }

    /// <summary>
    /// Продать цветок.
    /// </summary>
    public void SellFlower()
    {
      consolePrinter.Clear();
      bool isContinueSelling = true;
      List<FlowerInventoryItem> flowerForSale = new List<FlowerInventoryItem>();

      while (isContinueSelling)
      {
        string nameFlower = consolePrinter.GetInput("Введите название цветка, который хотите продать.");
        int quantity = Convert.ToInt32(consolePrinter.GetInput("Ведите количество цветов, которого хотите продать."));
        flowerForSale.Add(new FlowerInventoryItem(warehouseManager.GetFlower(nameFlower).Flower, quantity));

        ConsoleKeyInfo consoleKey = consolePrinter.GetKey("Действия:\n1. Продолжить покупки.\n2. Завершить покупки.");
        switch (consoleKey.Key)
        {
          case ConsoleKey.D1:
            consolePrinter.Clear();
            break;
          case ConsoleKey.D2:
            isContinueSelling = false;
            break;
        }
      }
      flowerTradingManager.SellFlowers(flowerForSale);
    }

    /// <summary>
    /// Купить цветы у поставщика.
    /// </summary>
    public void OrderFlowersFromSupplier()
    {
      bool isContinueShopping = true;
      var suppliers = flowerSupplierManager.FlowerSuppliers;
      List<FlowerInventoryItem> flowersForPurchase = new List<FlowerInventoryItem>();
      while (isContinueShopping)
      {
        Console.Clear();
        consolePrinter.PrintListSupplier(suppliers);
        string indexSuppliers = consolePrinter.GetInput("Выберите поставщика:");
        var flowers = suppliers[Convert.ToInt32(indexSuppliers) - 1];
        consolePrinter.Clear();
        consolePrinter.PrintSupplierFlowers(flowers);
        string indexFlower = consolePrinter.GetInput("Выберите индекс цветок, который хотите купить у поставщика:");
        int quantity = Convert.ToInt32(consolePrinter.GetInput("Ведите количество цветов, которого хотите купить."));
        flowersForPurchase.Add(new FlowerInventoryItem(flowers.flowers[Convert.ToInt32(indexFlower) - 1], quantity));
        consolePrinter.Clear();
        ConsoleKeyInfo consoleKey = consolePrinter.GetKey("Действия:\n1. Продолжить покупки.\n2. Завершить покупки.");
        switch (consoleKey.Key)
        {
          case ConsoleKey.D1:
            consolePrinter.Clear();
            break;
          case ConsoleKey.D2:
            isContinueShopping = false;
            break;
        }
      }
      flowerTradingManager.BuyFromSupplier(flowersForPurchase);

    }

    /// <summary>
    /// Получить список цветов с их количеством на складе.
    /// </summary>
    public void GetFlowerStock()
    {
      consolePrinter.Clear();
      var allFlowers = warehouseManager.GetAllFlowers();
      consolePrinter.PrintListFlowersInventoryItem(allFlowers);
    }

    /// <summary>
    /// Получить информацию о магазинах.
    /// </summary>
    public void GetShopFinances()
    {
      consolePrinter.Clear();
      consolePrinter.PrintText($"Текущий баланс: {shopFinancesManager.ShopFinances.CurrentBalance}\nОбщая сумма доходов магазина: {shopFinancesManager.ShopFinances.TotalIncome}\nОбщая сумма расходов магазина: {shopFinancesManager.ShopFinances.TotalExpenses}");
    }
  }
}
