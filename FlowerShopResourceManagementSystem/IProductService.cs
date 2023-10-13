using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Интерфейс для работы с объектами Product.
  /// </summary>
  internal interface IProductService
  {

    #region Методы

    /// <summary>
    /// Добавить товар в список.
    /// </summary>
    /// <param name="name">Название товара.</param>
    /// <param name="price">Цена товара.</param>
    /// <param name="quantity">Количество товара.</param>
    public void AddProduct(string name, double price, int quantity);

    /// <summary>
    /// Получение всего списка товаров.
    /// </summary>
    /// <returns>Все товары.</returns>
    public List<Product> GetProducts();

    /// <summary>
    /// Получение определенного товара.
    /// </summary>
    /// <param name="productName">Название товара.</param>
    /// <returns>Экземпляр товара.</returns>
    public Product GetProduct(string productName);

    /// <summary>
    /// Изменить цену товара.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="newPrice">Новая цена товара.</param>
    public void ChangeProductPrice(string nameProduct, double newPrice);

    /// <summary>
    /// Изменить название товара.
    /// </summary>
    /// <param name="oldNameProduct">Название товара.</param>
    /// <param name="newNameProduct">Новое название товара.</param>
    public void ChangeProductName(string oldNameProduct, string newNameProduct);

    /// <summary>
    /// Увеличить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">Насколько надо увеличить количество товара.</param>
    public void IncreaseTheNumberOfProducts(string nameProduct, int numberOfProducts);

    /// <summary>
    /// Уменьшить количество товаров.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    /// <param name="numberOfProducts">Насколько надо уменьшить количество товара.</param>
    public void ReduceTheNumberOfProducts(string nameProduct, int numberOfProducts);

    /// <summary>
    /// Удалить товар.
    /// </summary>
    /// <param name="nameProduct">Название товара.</param>
    public void DeleteProduct(string nameProduct);

    /// <summary>
    /// Получить таблицу со списком продуктов.
    /// </summary>
    /// <param name="products">Список продуктов.</param>
    /// <returns>Таблица со списком продуктов.</returns>
    public string GetProductList(List<Product> products);

    #endregion

  }
}
