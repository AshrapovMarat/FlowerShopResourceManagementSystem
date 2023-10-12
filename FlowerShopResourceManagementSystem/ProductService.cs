using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Класc для работы с объектами Product.
  /// </summary>
  public class ProductService
  {
    #region Методы

    /// <summary>
    /// Добавить товар в список.
    /// </summary>
    /// <param name="name">Название товара.</param>
    /// <param name="price">Цена товара.</param>
    /// <param name="quantity">Количество товара.</param>
    public void AddProduct(string name, double price, int quantity)
    {
      List<Product> products = this.GetProducts();
      var indexElemant = products.FindIndex(p => p.Name == name);
      if (indexElemant >= 0)
      {
        throw new InvalidOperationException("Товар с таким названием уже существует.");
      }
      else
      {
        ConnectorDB.Add(new Product(name, price, quantity));
      }
    }

    /// <summary>
    /// Получение всего списка товаров.
    /// </summary>
    /// <returns>Все товары.</returns>
    public List<Product> GetProducts()
    {
      return ConnectorDB.GetProducts();
    }

    /// <summary>
    /// Получение определенного товара.
    /// </summary>
    /// <param name="productName">Название товара.</param>
    /// <returns>Экземпляр товара.</returns>
    public Product GetProduct(string productName)
    {
      List<Product> products = this.GetProducts();
      Product product = products.Find(product => product.Name == productName);
      if (product == null)
      {
        throw new NullReferenceException("Объект не найден");
      }
      return product;
    }

    /// <summary>
    /// Изменить цену товара.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="newPrice">Новая цена товара.</param>
    public void ChangeProductPrice(string nameProduct, double newPrice)
    {
      var product = this.GetProduct(nameProduct);
      product.Price = newPrice;
      ConnectorDB.Update(product);
    }

    /// <summary>
    /// Изменить название товара.
    /// </summary>
    /// <param name="oldNameProduct">Название товара.</param>
    /// <param name="newNameProduct">Новое название товара.</param>
    public void ChangeProductName(string oldNameProduct, string newNameProduct)
    {
      var product = this.GetProduct(oldNameProduct);
      product.Name = newNameProduct;
      ConnectorDB.Update(product);
    }

    /// <summary>
    /// Увеличить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">Насколько надо увеличить количество товара.</param>
    public void IncreaseTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = this.GetProduct(nameProduct);
      product.QuantityInStock += numberOfProducts;
      product.TotalPurchasesCount += numberOfProducts;
      product.TotalCostPurchased += numberOfProducts * product.Price;
      ConnectorDB.Update(product);
    }

    /// <summary>
    /// Уменьшить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">Насколько надо уменьшить количество товара.</param>
    public void ReduceTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = this.GetProduct(nameProduct);
      if ((product.QuantityInStock - numberOfProducts) < 0)
      {
        throw new ArgumentOutOfRangeException("Количество товаров не может быть отрицательное количество.");
      }
      else
      {
        product.QuantityInStock -= numberOfProducts;
        product.TotalSalesCount += numberOfProducts;
        product.TotalSalesValue += numberOfProducts * product.Price;
        ConnectorDB.Update(product);
      }
    }

    /// <summary>
    /// Удалить товар.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    public void DeleteProduct(string nameProduct)
    {
      var product = this.GetProduct(nameProduct);
      ConnectorDB.Delete(product);
    }

    /// <summary>
    /// Получить таблицу со списком продуктов.
    /// </summary>
    /// <param name="products">Список продуктов.</param>
    /// <returns>Таблица со списком продуктов.</returns>
    public string GetProductList(List<Product> products)
    {
      int maxLengthName = 15; // Максимальная длина строки для наименования товара, учитывая длину названия столбца.
      int maxLengthPrice = 11; // Максимальная длина строки для цены товара, учитывая длину названия столбца.
      int maxLengthQuantity = 27; // Максимальная длина строки для количества товара на складе, учитывая длину названия столбца.
      int maxLengthTotalPurchasesCount = 35; // Максимальная длина строки для количества всего купленных товаров, учитывая длину названия столбца.
      int maxLengthTotalSalesCount = 33; // Максимальная длина строки для количества всего проданных товаров, учитывая длину названия столбца.
      int maxLengthTotalCostPurchased = 31; // Максимальная длина строки для общей стоимости купленных товаров, учитывая длину названия столбца.
      int maxLengthTotalSalesValue = 31; // Максимальная длина строки для общей стоимости продажи товаров, учитывая длину названия столбца.

      string text = string.Empty;
      foreach (var product in products)
      {
        if (product.Name.Length > maxLengthName)
        {
          maxLengthName = product.Name.Length;
        }
        if (product.Price.ToString().Length > maxLengthPrice)
        {
          maxLengthPrice = product.Price.ToString().Length;
        }
        if (product.QuantityInStock.ToString().Length > maxLengthQuantity)
        {
          maxLengthQuantity = product.QuantityInStock.ToString().Length;
        }
        if (product.TotalPurchasesCount.ToString().Length > maxLengthTotalPurchasesCount)
        {
          maxLengthTotalPurchasesCount = product.TotalPurchasesCount.ToString().Length;
        }
        if (product.TotalSalesCount.ToString().Length > maxLengthTotalSalesCount)
        {
          maxLengthTotalSalesCount = product.TotalSalesCount.ToString().Length;
        }
        if (product.TotalCostPurchased.ToString().Length > maxLengthTotalCostPurchased)
        {
          maxLengthTotalCostPurchased = product.TotalCostPurchased.ToString().Length;
        }
        if (product.TotalSalesValue.ToString().Length > maxLengthTotalSalesValue)
        {
          maxLengthTotalSalesValue = product.TotalSalesValue.ToString().Length;
        }
      }

      text += $"{"Название товара".PadRight(maxLengthName)} | {"Цена товара".PadRight(maxLengthPrice)} " +
        $"| {"Количество товара на складе".PadRight(maxLengthPrice)} " +
        $"| {"Количество всего купленых товаров".PadRight(maxLengthTotalPurchasesCount)} " +
        $"| {"Количество всего проданых товаров".PadRight(maxLengthTotalSalesCount)} " +
        $"| {"Общая стоимость покупки товаров".PadRight(maxLengthTotalCostPurchased)} " +
        $"| {"Общая стоимость продажи товаров".PadRight(maxLengthTotalSalesValue)}";

      text += $"\n{new string('-', maxLengthName)}-|-{new string('-', maxLengthPrice)}-" +
        $"|-{new string('-', maxLengthQuantity)}-" +
        $"|-{new string('-', maxLengthTotalPurchasesCount)}-|-{new string('-', maxLengthTotalSalesCount)}-" +
        $"|-{new string('-', maxLengthTotalCostPurchased)}-" + $"|-{new string('-', maxLengthTotalSalesValue)}";

      foreach (var product in products)
      {
        text += $"\n{product.Name.PadRight(maxLengthName)} | {product.Price.ToString("0.00").PadRight(maxLengthPrice)} " +
          $"| {product.QuantityInStock.ToString().PadRight(maxLengthQuantity)} " +
          $"| {product.TotalPurchasesCount.ToString().PadRight(maxLengthTotalPurchasesCount)} " +
          $"| {product.TotalSalesCount.ToString().PadRight(maxLengthTotalSalesCount)} " +
          $"| {product.TotalCostPurchased.ToString("0.00").PadRight(maxLengthTotalCostPurchased)} " +
          $"| {product.TotalSalesValue.ToString("0.00").PadRight(maxLengthTotalSalesValue)}";
      }
      return text;
    }
    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ProductService() { }

    #endregion
  }
}


