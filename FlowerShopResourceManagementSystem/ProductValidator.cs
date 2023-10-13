using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Валидатор для товаров.
  /// </summary>
  public static class ProductValidator 
  {
    #region Методы

    /// <summary>
    /// Проверка введенных данных для поля имени на корректность.
    /// </summary>
    /// <param name="inputName">Введенное имя.</param>
    /// <returns>Имя товара.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь вел пустую строку.</exception>
    public static string ValidateName(string inputName)
    {
      inputName = inputName.Trim();
      if (inputName != "")
      {
        return inputName;
      }
      else
      {
        throw new FormatException("Введена пустая строка.");
      }
    }

    /// <summary>
    /// Проверка введенных данных для поля цена на корректность.
    /// </summary>
    /// <param name="inputPrice">Введеная цена.</param>
    /// <returns>Цена товара.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь ввел некорректное число.</exception>
    public static double ValidatePrice(string inputPrice) 
    {
      if (double.TryParse(inputPrice.Trim(), out double price) && price >= 0)
      {
        var priceSplit = price.ToString().Split(',');
        if (priceSplit.Count() == 1)
        {
          return price;
        }
        else if (priceSplit.Count() == 2)
        {
          if (!(priceSplit[1].Length > 2))
          {
            return price;
          }
        }
      }
      throw new FormatException("Введено некоректое число.");
    }

    /// <summary>
    /// Проверка введенных данных для поля количество товаров на корректность.
    /// </summary>
    /// <param name="inputQuantity">Введенное количество товара.</param>
    /// <returns>Количество товара.</returns>
    /// <exception cref="FormatException">Возникает когда пользователь ввел некорректное число.</exception>
    public static int ValidateQuantity(string inputQuantity)
    {
      if (int.TryParse(inputQuantity.Trim(), out int quantity) && quantity >= 0)
      {
        return quantity;
      }
      else
      {
        throw new FormatException("Введено некоректое число.");
      }
    }

    #endregion
  }
}
