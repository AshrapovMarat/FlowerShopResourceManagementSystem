using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Элемент инвентаря цветка.
  /// </summary>
  internal class FlowerInventoryItem
  {
    /// <summary>
    /// Цветок.
    /// </summary>
    public Flower Flower { get; private set; }

    /// <summary>
    /// Количество цветков.
    /// </summary>
    public int NumberFlowers { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="flower">Цветок.</param>
    /// <param name="numberFlowers">Количество цветков.</param>
    public FlowerInventoryItem(Flower flower, int numberFlowers) 
    {
      Flower = flower;
      NumberFlowers = numberFlowers;
    }
  }
}
