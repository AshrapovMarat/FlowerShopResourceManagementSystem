using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Склад.
  /// </summary>
  internal class Warehouse
  {
    /// <summary>
    /// Список цветов на складе.
    /// </summary>
    public List<FlowerInventoryItem> flowers;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="flowers">Список цветов.</param>
    public Warehouse(List<FlowerInventoryItem> flowers)
    {
      this.flowers = flowers;
    }

    /// <summary>
    /// Получить список цветов.
    /// </summary>
    /// <returns>Список цветов.</returns>
    public List<FlowerInventoryItem> GetFlowers()
    {
      return flowers;
    }

    /// <summary>
    /// Получить объект типа FlowerItem.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <returns>Экземпляр цветка.</returns>
    public FlowerInventoryItem GetFlowerItem(string name)
    {
      foreach (var item in flowers)
      {
        if (item.Flower.Name == name)
        {
          return item;
        }
      }
      throw new InvalidOperationException();
    }

    /// <summary>
    /// Добавить новый цветок в список.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <param name="cost">Цена цветка.</param>
    /// <param name="numberFlower">Колечество цветков</param>
    public void AddFlowers(string name, double cost, int numberFlower)
    {
      FlowerInventoryItem flower = GetFlowerItem(name);
      if (flower == null)
      {
        flowers.Add(new FlowerInventoryItem(new Flower(name, cost), numberFlower));
      }
      else
      {
        throw new InvalidOperationException();
      }
    }

    /// <summary>
    /// Изменить количество цветков.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <param name="count">На сколько надо изменить количетсво цветков.</param>
    public void ChangeFlowerQuantity(string name, int count)
    {
      FlowerInventoryItem flower = GetFlowerItem(name);
      if (flower != null)
      {
        flower.NumberFlowers += count;
      }
    }

    /// <summary>
    /// Изменить цену товара.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <param name="price">Новая цена цвтека.</param>
    public void ChangeFlowerPrice(string name, double price)
    {
      FlowerInventoryItem flower = GetFlowerItem(name);
      if (flower != null)
      {
        flower.Flower.Price = price;
      }
    }
  }
}
