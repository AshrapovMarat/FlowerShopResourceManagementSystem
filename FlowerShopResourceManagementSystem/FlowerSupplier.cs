using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Поставщик цветов.
  /// </summary>
  internal class FlowerSupplier
  {
    /// <summary>
    /// Название поставщика.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Контактная информация.
    /// </summary>
    public string ContactInformation { get; set; }

    /// <summary>
    /// Список товаров у поставщика.
    /// </summary>
    public List<Flower> flowers;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название постащика.</param>
    /// <param name="contactInformation">Контактная информация.</param>
    /// <param name="flowers">Список товаров у поставщика.</param>
    public FlowerSupplier(string name, string contactInformation, List<Flower> flowers)
    {
      Name = name;
      ContactInformation = contactInformation;
      this.flowers = flowers;
    }
  }
}
