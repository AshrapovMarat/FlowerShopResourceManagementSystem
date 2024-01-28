using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Цветок.
  /// </summary>
  internal class Flower
  {
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Цена за цветок.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="cost">Цена.</param>
    public Flower(string name, double cost)
    {
      Name = name;
      Price = cost;
    }
  }
}
