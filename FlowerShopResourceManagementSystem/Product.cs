using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  internal class Product
  {
    #region Свойства
    /// <summary>
    /// Название товара.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Количество товара на складе.
    /// </summary>
    public int QuantityInStock { get; set; }

    /// <summary>
    /// Общее количество купленных товаров.
    /// </summary>
    public int TotalPurchasesCount {  get; set; }

    /// <summary>
    /// Общее количество проданных товаров.
    /// </summary>
    public int TotalSalesCount { get; set; }

    #endregion

    #region Конструктор
    public Product(string name, double price, int quantity) 
    {
      Name = name;
      Price = price;
      Quantity = quantity;
    }
    #endregion
  }
}
