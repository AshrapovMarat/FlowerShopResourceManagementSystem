using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление элементами инвентаря цветка.
  /// </summary>
  internal class FlowerInventoryItemManager
  {
    /// <summary>
    /// Список элементов инвентаря цветка.
    /// </summary>
    public List<FlowerInventoryItem> FlowerInventoryItems {  get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public FlowerInventoryItemManager()
    {
      FlowerInventoryItems = new List<FlowerInventoryItem>();
    }

    /// <summary>
    /// Найти элемент инвентаря цветка.
    /// </summary>
    /// <param name="name">Название.</param>
    /// <returns>Экземпляр элемента инвентаря цветка.</returns>
    public FlowerInventoryItem Get(string name)
    {
      foreach(var item in FlowerInventoryItems)
      {
        if (item.Flower.Name == name)
        {
          return item;
        }
      }
      return null;
    }

    /// <summary>
    /// Изменить свойство количество цветков у элемент инвентаря цветка.
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="quantity">На какую величину изменить количество цветка.</param>
    public void ChangerFlowerQuantity(string name, int quantity)
    {
      FlowerInventoryItem flowerInventoryItem = Get(name);
      if (flowerInventoryItem != null)
      {
        flowerInventoryItem.NumberFlowers += quantity;
      }
    }

    /// <summary>
    /// Добавить новый элемент инвентаря цветка.
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="cost">Цена.</param>
    /// <param name="quantity">На какую величину изменить количество цветка.</param>
    public void Add(string name, double cost, int quantity = 0)
    {
      FlowerInventoryItems.Add(new FlowerInventoryItem(new Flower(name, cost), quantity));
    }

    /// <summary>
    /// Удалить элемент инвентаря цветка.
    /// </summary>
    /// <param name="name">Название.</param>
    public void Delete(string name)
    {
      FlowerInventoryItem flowerInventoryItem = Get(name);
      if (flowerInventoryItem != null)
      {
        FlowerInventoryItems.Remove(flowerInventoryItem);
      }
    }
  }
}
