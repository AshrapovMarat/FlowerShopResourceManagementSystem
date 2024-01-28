using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление торговлей цветами.
  /// </summary>
  internal class FlowerTradingManager
  {
    /// <summary>
    /// Управление складом.
    /// </summary>
    private WarehouseManager warehouseManager;

    /// <summary>
    /// Управление финансами магазина.
    /// </summary>
    private ShopFinancesManager shopFinancesManager;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="warehouseManager">Управление складом.</param>
    /// <param name="shopFinancesManager">Управление финансами магазина.</param>
    public FlowerTradingManager(/*List<FlowerTrading> sales,*/ WarehouseManager warehouseManager, ShopFinancesManager shopFinancesManager) 
    {
      this.warehouseManager = warehouseManager;
      this.shopFinancesManager = shopFinancesManager;
    }

    /// <summary>
    /// Совершить продажу цветков.
    /// </summary>
    /// <param name="flowerInventoryItems">Список цветов для продажи.</param>
    public void SellFlowers(List<FlowerInventoryItem> flowerInventoryItems)
    {
      FlowerTrading sales = new FlowerTrading(flowerInventoryItems);

      double totalPrice = CalculateTotalPrice(sales.TradingElements);
      shopFinancesManager.AddIncome(totalPrice);

      foreach(var flower in sales.TradingElements)
      {
        warehouseManager.ChangerFlowerQuantity(flower.Flower.Name, - flower.NumberFlowers);
      }
    }

    /// <summary>
    /// Купить у поставщика цветы.
    /// </summary>
    /// <param name="flowerInventoryItems">Список цветов для покупки у поставщика.</param>
    public void BuyFromSupplier(List<FlowerInventoryItem> flowerInventoryItems)
    {
      FlowerTrading purchases = new FlowerTrading(flowerInventoryItems);

      double totalPrice = CalculateTotalPrice(purchases.TradingElements);
      shopFinancesManager.DeductExpenses(totalPrice);

      foreach (var flower in purchases.TradingElements)
      {
        warehouseManager.ChangerFlowerQuantity(flower.Flower.Name, flower.NumberFlowers);
      }
    }

    /// <summary>
    /// Рассчитать общую стоимость цветов.
    /// </summary>
    /// <param name="inventoryItems">Список элементов инвенторя цветок.</param>
    /// <returns>Общая стоимость цветов.</returns>
    private double CalculateTotalPrice(List<FlowerInventoryItem> inventoryItems)
    {
      double totalPrice = 0;
      foreach (FlowerInventoryItem item in inventoryItems)
      {
        totalPrice += item.NumberFlowers * item.Flower.Price;
      }
      return totalPrice;
    }
  }
}
