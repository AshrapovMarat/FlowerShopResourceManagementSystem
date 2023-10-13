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
  public class ProductService : IProductService
  {

    #region Методы

    public void AddProduct(string name, double price, int quantity)
    {
      List<Product> products = this.GetProducts();
      if (products.FindIndex(p => p.Name == name) >= 0)
      {
        throw new InvalidOperationException("Товар с таким названием уже существует.");
      }
      else
      {
        ConnectorDB.Add(new Product(name, price, quantity));
      }
    }

    public List<Product> GetProducts() => ConnectorDB.GetProducts();

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

    public void ChangeProductPrice(string nameProduct, double newPrice)
    {
      var product = this.GetProduct(nameProduct);
      product.Price = newPrice;
      ConnectorDB.Update(product);
    }

    public void ChangeProductName(string oldNameProduct, string newNameProduct)
    {
      var product = this.GetProduct(oldNameProduct);
      product.Name = newNameProduct;
      ConnectorDB.Update(product);
    }

    public void IncreaseTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = this.GetProduct(nameProduct);
      product.QuantityInStock += numberOfProducts;
      product.TotalPurchasesCount += numberOfProducts;
      product.TotalCostPurchased += numberOfProducts * product.Price;
      ConnectorDB.Update(product);
    }

    public void ReduceTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = this.GetProduct(nameProduct);
      if ((product?.QuantityInStock - numberOfProducts) < 0)
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

    public void DeleteProduct(string nameProduct)
    {
      var product = this.GetProduct(nameProduct);
      ConnectorDB.Delete(product);
    }

    public string GetProductList(List<Product> products)
    {
      var maxLengthName = 15; // Максимальная длина строки для наименования товара, учитывая длину названия столбца.
      var maxLengthPrice = 11; // Максимальная длина строки для цены товара, учитывая длину названия столбца.
      var maxLengthQuantity = 27; // Максимальная длина строки для количества товара на складе, учитывая длину названия столбца.
      var maxLengthTotalPurchasesCount = 35; // Максимальная длина строки для количества всего купленных товаров, учитывая длину названия столбца.
      var maxLengthTotalSalesCount = 33; // Максимальная длина строки для количества всего проданных товаров, учитывая длину названия столбца.
      var maxLengthTotalCostPurchased = 31; // Максимальная длина строки для общей стоимости купленных товаров, учитывая длину названия столбца.
      var maxLengthTotalSalesValue = 31; // Максимальная длина строки для общей стоимости продажи товаров, учитывая длину названия столбца.

      // Вычисления максимальной длины строки для столбца с названием и ценой.
      foreach (var product in products)
      {
        if (product.Name.Length > maxLengthName)
        {
          maxLengthName = product.Name.Length;
        }
        if (product.Price.ToString("0.00").Length > maxLengthPrice)
        {
          maxLengthPrice = product.Price.ToString("0.00").Length;
        }
      }

      var text = new StringBuilder();

      text.Append($"{"Название товара".PadRight(maxLengthName)} | {"Цена товара".PadRight(maxLengthPrice)} " +
        $"| {"Количество товара на складе".PadRight(maxLengthPrice)} " +
        $"| {"Количество всего купленых товаров".PadRight(maxLengthTotalPurchasesCount)} " +
        $"| {"Количество всего проданых товаров".PadRight(maxLengthTotalSalesCount)} " +
        $"| {"Общая стоимость покупки товаров".PadRight(maxLengthTotalCostPurchased)} " +
        $"| {"Общая стоимость продажи товаров".PadRight(maxLengthTotalSalesValue)}");

      text.Append($"\n{new string('-', maxLengthName)}-|-{new string('-', maxLengthPrice)}-" +
        $"|-{new string('-', maxLengthQuantity)}-" +
        $"|-{new string('-', maxLengthTotalPurchasesCount)}-|-{new string('-', maxLengthTotalSalesCount)}-" +
        $"|-{new string('-', maxLengthTotalCostPurchased)}-" + $"|-{new string('-', maxLengthTotalSalesValue)}");

      foreach (var product in products)
      {
        text.Append($"\n{product.Name.PadRight(maxLengthName)} | {product.Price.ToString("0.00").PadRight(maxLengthPrice)} " +
          $"| {product.QuantityInStock.ToString().PadRight(maxLengthQuantity)} " +
          $"| {product.TotalPurchasesCount.ToString().PadRight(maxLengthTotalPurchasesCount)} " +
          $"| {product.TotalSalesCount.ToString().PadRight(maxLengthTotalSalesCount)} " +
          $"| {product.TotalCostPurchased.ToString("0.00").PadRight(maxLengthTotalCostPurchased)} " +
          $"| {product.TotalSalesValue.ToString("0.00").PadRight(maxLengthTotalSalesValue)}");
      }

      return text.ToString();
    }

    #endregion

  }
}


