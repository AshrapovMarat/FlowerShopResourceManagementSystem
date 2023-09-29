using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  internal class ProductService
  {
    List<Product> products = new List<Product>();

    #region Конструктор
    public ProductService(List<Product> products) 
    { 
      this.products = products;
    }
    #endregion

    #region Добавление товаров
    public void AddProducts(Product product)
    {
      products.Add(product);
    }

    //public void AddProducts(List<Product> products)
    //{
    //  products.AddRange(products);
    //}
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
    /// <param name="productName"></param>
    /// <returns></returns>
    public Product GetProduct(string productName)
    {
      return products.Find(product => product.Name == productName) /*== null ? throw new Exception() : products.Find(product => product.Name == productName)*/;
    }

    #endregion

    #region Редактирование товара

    /// <summary>
    /// Изменить цену товара.
    /// </summary>
    /// <param name="nameProduct"></param>
    /// <param name="newPrice"></param>
    public void ChangeProductPrice(string nameProduct, double newPrice)
    {
      var product = GetProduct(nameProduct);
      product.Price = newPrice;
    }

    /// <summary>
    /// Изменить имя товара.
    /// </summary>
    /// <param name="oldNameProduct"></param>
    /// <param name="newNameProduct"></param>
    public void ChangeProductName(string oldNameProduct, string newNameProduct)
    {
      var product = GetProduct(oldNameProduct);
      product.Name = newNameProduct;
    }

    /// <summary>
    /// Увеличить количество товаров.
    /// </summary>
    /// <param name="nameProduct"></param>
    /// <param name="numberOfProducts"></param>
    public void IncreaseTheNumberOfProducts(string nameProduct, int numberOfProducts)
    {
      var product = GetProduct(nameProduct);
      product.QuantityInStock += numberOfProducts;
    }

    /// <summary>
    /// Уменьшить количество товаров.
    /// </summary>
    /// <param name="nameProduct"></param>
    /// <param name="numberOfProducts"></param>
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
      }
    }

    #endregion

    #region Удаление товара

    public void DeleteProduct(string nameProduct)
    {
      var product = GetProduct(nameProduct);
      products.Remove(product);
    }
    #endregion

    #region Работа с БД

    public void SaveData()
    {
      FileConnector fileConnector = new FileConnector("");
      fileConnector.SaveProduct(products);
    }

    public void GetData()
    {
      FileConnector fileConnector = new FileConnector("");
      products = fileConnector.GetProductsFromFile();
    }

    #endregion


  }
}
