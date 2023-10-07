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
    #region Свойства
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
    /// Общее количество закупленных товаров.
    /// </summary>
    public int TotalPurchasesCount {  get; set; }

    /// <summary>
    /// Общее количество проданных товаров.
    /// </summary>
    public int TotalSalesCount { get; set; }

    /// <summary>
    /// Общая стоимость купленых товаров.
    /// </summary>
    public double TotalCostPurchased { get; set; }

    /// <summary>
    /// Общая стоимость проданных товаров.
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
    /// <param name="totalPurchasesCount">Общее количество закупленных товаров.</param>
    /// <param name="totalSalesCount">Общее количество проданных товаров.</param>
    /// <param name="totalCostPurchased">Общая стоимость купленных товаров.</param>
    /// <param name="totalSalesValue">Общая стоимость проданных товаров.</param>
    public Product(string name, double price, int quantityInStock, int totalPurchasesCount = 0, int totalSalesCount = 0, double totalCostPurchased = 0, double totalSalesValue = 0) 
    {
      Name = name;
      Price = price;
      QuantityInStock = quantityInStock;
      TotalPurchasesCount = totalPurchasesCount;
      TotalPurchasesCount += quantityInStock;
      TotalSalesCount = totalSalesCount;
      TotalCostPurchased = totalCostPurchased;
      TotalCostPurchased += price * quantityInStock;
      TotalSalesValue = totalSalesValue;
    }
    #endregion
  }
}
