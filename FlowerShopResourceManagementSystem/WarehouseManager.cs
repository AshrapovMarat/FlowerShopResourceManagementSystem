using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление складом.
  /// </summary>
  internal class WarehouseManager
  {
    /// <summary>
    /// Управление элементами инвентаря цветов.
    /// </summary>
    private FlowerInventoryItemManager flowerInventoryItemManager;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public WarehouseManager()
    {
      flowerInventoryItemManager = new FlowerInventoryItemManager();
    }

    /// <summary>
    /// Добавить цветок на склад.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    public void CreateFlower(string name, double cost, int quantity = 0)
    {
      flowerInventoryItemManager.Add(name, cost, quantity);
    }

    /// <summary>
    /// Удалить цветок со склада.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    public void DeleteFlower(string name)
    {
      flowerInventoryItemManager.Delete(name);
    }

    /// <summary>
    /// Изменить количество цветков на складе.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <param name="quantity">На какую величину изменить количество цветов.</param>
    public void ChangerFlowerQuantity(string name, int quantity)
    {
      flowerInventoryItemManager.ChangerFlowerQuantity(name, quantity);
    }

    /// <summary>
    /// Получить экземпляр цветка.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <returns>Экземпляр цветка.</returns>
    public FlowerInventoryItem GetFlower(string name)
    {
      return flowerInventoryItemManager.Get(name);
    }

    /// <summary>
    /// Получить список цветов.
    /// </summary>
    /// <returns>Список цветов.</returns>
    public List<FlowerInventoryItem> GetAllFlowers()
    {
      return flowerInventoryItemManager.FlowerInventoryItems;
    }
  }
}
