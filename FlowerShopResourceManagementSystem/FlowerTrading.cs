using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Торговля цветами.
  /// </summary>
  internal class FlowerTrading
  {
    /// <summary>
    /// Номер операции.
    /// </summary>
    public int IdSale { get; private set; }

    /// <summary>
    /// Список элементов для торговли.
    /// </summary>
    public List<FlowerInventoryItem> TradingElements { get; set; }

    /// <summary>
    /// Дата проведения торговой операции.
    /// </summary>
    public DateTime Date {  get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="tradingElements">Список элементов инвентаря цветов.</param>
    public FlowerTrading(List<FlowerInventoryItem> tradingElements)
    {
      TradingElements = tradingElements;
      Date = DateTime.Now;
    }
  }
}
