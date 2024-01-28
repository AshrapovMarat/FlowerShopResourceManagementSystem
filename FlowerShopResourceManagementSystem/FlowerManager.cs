using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление цветами.
  /// </summary>
  internal class FlowerManager
  {
    /// <summary>
    /// Список цветов.
    /// </summary>
    private List<Flower> flowers;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="flowers">Список цветов.</param>
    public FlowerManager(List<Flower> flowers)
    {
      this.flowers = flowers;
    }

    /// <summary>
    /// Добавить объект цветка.
    /// </summary>
    /// <param name="flower">Объект цветка.</param>
    public void Add(Flower flower)
    {
      flowers.Add(flower);
    }

    /// <summary>
    /// Удалить объект цветка.
    /// </summary>
    /// <param name="flower">Объект цветка.</param>
    public void Delete(Flower flower)
    {
      flowers.Remove(flower);
    }

    /// <summary>
    /// Обновить данные цветка.
    /// </summary>
    /// <param name="flower">Объект цветка.</param>
    public void Update(Flower flower)
    {
      Flower flowerToUpdate = Get(flower.Name);
      flowerToUpdate.Price = flower.Price;
    }

    /// <summary>
    /// Получить объект цветок.
    /// </summary>
    /// <param name="name">Название цветка.</param>
    /// <returns>Объект цветка.</returns>
    public Flower Get(string name)
    {
      foreach (var flower in flowers)
      {
        if (flower.Name == name) return flower;
      }
      throw new InvalidOperationException();
    }

    /// <summary>
    /// Получить список цветов.
    /// </summary>
    /// <returns>Список цветов.</returns>
    public List<Flower> GetFlowers()
    {
      return flowers;
    }
  }
}
