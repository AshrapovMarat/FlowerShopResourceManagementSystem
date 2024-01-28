using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Класс для работы с поставщиками цветов.
  /// </summary>
  internal class FlowerSupplierManager
  {

    /// <summary>
    /// Список с поставщиками цветов.
    /// </summary>
    public List<FlowerSupplier> FlowerSuppliers {  get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="flowerSuppliers">Список с поставщиками цветов.</param>
    public FlowerSupplierManager(List<FlowerSupplier> flowerSuppliers)
    {
      this.FlowerSuppliers = flowerSuppliers;
    }

    /// <summary>
    /// Получить поставщика.
    /// </summary>
    /// <param name="name">Название постащика.</param>
    /// <returns>Поставщик.</returns>
    public FlowerSupplier Get(string name)
    {
      foreach (var supplier in FlowerSuppliers)
      {
        if (supplier.Name == name)
        {
          return supplier;
        }
      }
      return null;
    }

    /// <summary>
    /// Добавить поставщика.
    /// </summary>
    /// <param name="name">Название постащика.</param>
    public void Add(string name, string contactInformation, List<Flower> flowers)
    {
      FlowerSupplier supplier = Get(name);
      if (supplier == null)
      {
        FlowerSuppliers.Add(new FlowerSupplier(name, contactInformation, flowers));
      }
    }

    /// <summary>
    /// Обновить контактную информацию поставщика.
    /// </summary>
    /// <param name="name">Название постащика.</param>
    public void UpdateContactInformation(string name, string newContactInformation)
    {
      FlowerSupplier supplier = Get(name);
      if (supplier == null)
      {
        supplier.ContactInformation = newContactInformation;
      }
    }

    /// <summary>
    /// Удалить поставщика.
    /// </summary>
    /// <param name="name">Название постащика.</param>
    public void Delete(string name)
    {
      FlowerSupplier supplier = Get(name);
      if (supplier == null)
      {
        FlowerSuppliers.Remove(supplier);
      }
    }
  }
}
