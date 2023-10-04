using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  internal class ProductService
  {
    /// <summary>
    /// Товары.
    /// </summary>
    List<Product> products = new List<Product>();

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="products">Список товаров.</param>
    public ProductService(List<Product> products)
    {
      this.products = products;
    }

    #endregion

    #region Добавление товаров

    /// <summary>
    /// Добавить товар в список.
    /// </summary>
    /// <param name="product">Экземпляр продукта.</param>
    public void AddProducts(Product product)
    {
      products.Add(product);
    }

    /// <summary>
    /// Добавить товар в список.
    /// </summary>
    /// <param name="name">Название товара.</param>
    /// <param name="price">Цена товара.</param>
    /// <param name="quantity">Количество товара.</param>
    public void AddProducts(string name, double price, int quantity)
    {
      var indexElemant = products.FindIndex(p => p.Name == name);
      if (indexElemant >= 0)
      {
        throw new InvalidOperationException("Товар с таким названием уже существует.");
      }
      else
      {
        products.Add(new Product(name, price, quantity));
      }

    }

    #endregion

    #region Получение товаров и информацию о товаре

    /// <summary>
    /// Получение всего списка товаров.
    /// </summary>
    /// <returns></returns>
    public List<Product> GetProducts()
    {
      return products;
    }

    /// <summary>
    /// Получение определенного товара.
    /// </summary>
    /// <param name="productName">Название товара.</param>
    /// <returns></returns>
    public Product GetProduct(string productName)
    {
      return products.Find(product => product.Name == productName);
    }

    #endregion

    #region Редактирование товара

    /// <summary>
    /// Изменить цену товара.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="newPrice">Новая цена товара.</param>
    public void ChangeProductPrice(string nameProduct, double newPrice)
    {
      var product = GetProduct(nameProduct);
      product.Price = newPrice;
    }

    /// <summary>
    /// Изменить название товара.
    /// </summary>
    /// <param name="oldNameProduct">Название товара.</param>
    /// <param name="newNameProduct">Новое название товара.</param>
    public void ChangeProductName(string oldNameProduct, string newNameProduct)
    {
      var product = GetProduct(oldNameProduct);
      product.Name = newNameProduct;
    }

    /// <summary>
    /// Увеличить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">На сколько надо увеличить количество товара.</param>
    public void IncreaseTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = GetProduct(nameProduct);
      product.QuantityInStock += numberOfProducts;
      product.TotalPurchasesCount += numberOfProducts;
    }

    /// <summary>
    /// Уменьшить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">На сколько надо уменьшить количество товара.</param>
    public void ReduceTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = GetProduct(nameProduct);
      if ((product.QuantityInStock - numberOfProducts) < 0)
      {
        throw new ArgumentOutOfRangeException("Количество товаров не может быть отрицательное количество.");
      }
      else
      {
        product.QuantityInStock -= numberOfProducts;
        product.TotalSalesCount += numberOfProducts;
      }
    }

    #endregion

    #region Удаление товара
    /// <summary>
    /// Удалить товар.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    public void DeleteProduct(string nameProduct)
    {
      var product = GetProduct(nameProduct);
      products.Remove(product);
    }
    #endregion

    #region Работа с БД

    /// <summary>
    /// Сохранить данные в файл.
    /// </summary>
    public void SaveData()
    {
      FileConnector fileConnector = new FileConnector();
      fileConnector.SaveProduct(products);
    }

    /// <summary>
    /// Получить данные из файла.
    /// </summary>
    public void GetData()
    {
      FileConnector fileConnector = new FileConnector();
      products = fileConnector.GetProductsFromFile();
    }

    #endregion

    #region Вывод информации о товаре
    /// <summary>
    /// Получить таблицу со списком продуктов.
    /// </summary>
    /// <param name="products">Список продуктов.</param>
    /// <returns>Таблица со списком продуктов.</returns>
    public string GetProductList(List<Product> products)
    {
      int maxLengthName = 15; // Максимальное количество символов в столбце вместе с наименованием столбца
      int maxLengthPrice = 11; // Максимальное количество символов в столбце вместе с наименованием столбца
      int maxLengthQuantity = 17; // Максимальное количество символов в столбце вместе с наименованием столбца
      int maxLengthTotalPurchasesCount = 29; // Максимальное количество символов в столбце вместе с количеством закупленых товаров
      int maxLengthTotalSalesCount = 27; // Максимальное количество символов в столбце вместе с наименованием столбца
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
      }

      text += $"{"Название товара".PadRight(maxLengthName)} | {"Цена товара".PadRight(maxLengthPrice)} | {"Количество товара".PadRight(maxLengthPrice)} | {"Количество закупленых товаров".PadRight(maxLengthTotalPurchasesCount)} | {"Количество проданых товаров".PadRight(maxLengthTotalSalesCount)}";
      text += $"\n{new string('-', maxLengthName)}-|-{new string('-', maxLengthPrice)}-|-{new string('-', maxLengthQuantity)}-|-{new string('-', maxLengthTotalPurchasesCount)}-|-{new string('-', maxLengthTotalSalesCount)}";

      foreach (var product in products)
      {
        text += $"\n{product.Name.PadRight(maxLengthName)} | {product.Price.ToString().PadRight(maxLengthPrice)} | {product.QuantityInStock.ToString().PadRight(maxLengthQuantity)} | {product.TotalPurchasesCount.ToString().PadRight(maxLengthTotalPurchasesCount)} | {product.TotalSalesCount.ToString().PadRight(maxLengthTotalSalesCount)}";
      }
      return text;
    }
    #endregion
  }
}


