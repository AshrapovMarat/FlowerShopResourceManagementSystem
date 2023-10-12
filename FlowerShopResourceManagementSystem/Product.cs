using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  public class Product
  {
    #region Поля и свойства
    [Key]
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
    /// Количество всего купленых товаров.
    /// </summary>
    public int TotalPurchasesCount {  get; set; }

    /// <summary>
    /// Количество всего проданных товаров.
    /// </summary>
    public int TotalSalesCount { get; set; }

    /// <summary>
    /// Общая стоимость покупки товаров.
    /// </summary>
    public double TotalCostPurchased { get; set; }

    /// <summary>
    /// Общая стоимость продажи товаров.
    /// </summary>
    public double TotalSalesValue { get; set; }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название товара.</param>
    /// <param name="price">Цена товара.</param>
    /// <param name="quantityInStock">Количество товара.</param>
    public Product(string name, double price, int quantityInStock)
    {
      Name = name;
      Price = price;
      QuantityInStock = quantityInStock;
      TotalPurchasesCount += quantityInStock;
      TotalCostPurchased += quantityInStock * price;
    }

    #endregion
  }
}
