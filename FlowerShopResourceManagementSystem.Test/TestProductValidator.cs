using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem.Test
{
  /// <summary>
  /// Тестирование методов класса ProductValidator.
  /// </summary>
  public class TestProductValidator
  {
    /// <summary>
    /// Тестирование метода ValidateName на корректных данных.
    /// </summary>
    /// <param name="inputName">Входное значение.</param>
    /// <param name="expectedName">Ожидаемый результат.</param>
    [TestCase("Кактус", "Кактус")]
    [TestCase("Лилия    ", "Лилия")]
    [TestCase("   Роза", "Роза")]
    [TestCase("   Пион    ", "Пион")]
    public void TestValidateName(string inputName, string expectedName)
    {
      string name = ProductValidator.ValidateName(inputName);
      Assert.AreEqual(name, expectedName);
    }

    /// <summary>
    /// Тестирование метода ValidatePrice на корректных данных.
    /// </summary>
    /// <param name="inputPrice">Входное значение.</param>
    /// <param name="expectedPrice">Ожидаемый результат.</param>
    [TestCase("20,43", 20.43)]
    [TestCase("14,5", 14.5)]
    [TestCase("54", 54)]
    [TestCase(" 65,84", 65.84)]
    [TestCase("17  ", 17)]
    [TestCase("   43,54    ", 43.54)]
    public void TestValidatePrice(string inputPrice, double expectedPrice)
    {
      double price = ProductValidator.ValidatePrice(inputPrice);
      Assert.AreEqual(price, expectedPrice);
    }

    /// <summary>
    /// Тестирование метода ValidateQuantity на корректных данных.
    /// </summary>
    /// <param name="inputQuantity">Входное значение.</param>
    /// <param name="expectedQuantity">Ожидаемый результат.</param>
    [TestCase("7", 7)]
    [TestCase("29", 29)]
    [TestCase(" 52", 52)]
    [TestCase("49 ", 49)]
    [TestCase("   84  ", 84)]
    public void TestValidateQuantity(string inputQuantity, int expectedQuantity)
    {
      int quantity = ProductValidator.ValidateQuantity(inputQuantity);
      Assert.AreEqual(quantity, expectedQuantity);
    }

    /// <summary>
    /// Тестирование метода ValidateName на некорректных данных.
    /// </summary>
    /// <param name="name">Входное значение.</param>
    [TestCase("")]
    [TestCase("      ")]
    public void TestValidateNameException(string name)
    {
      Assert.Throws<FormatException>(() => ProductValidator.ValidateName(name));
    }

    /// <summary>
    /// Тестирование метода ValidatePrice на некорректных данных.
    /// </summary>
    /// <param name="price">Входное значение.</param>
    [TestCase("12,54385")]
    [TestCase("0,231")]
    [TestCase("32,a3")]
    [TestCase("1,2A1")]
    [TestCase("1A")]
    [TestCase("-10,34")]
    [TestCase("")]
    public void TestValidatePriceException(string price)
    {
      Assert.Throws<FormatException>(() => ProductValidator.ValidatePrice(price));
    }

    /// <summary>
    /// Тестирование метода ValidateQuantity на некорректных данных.
    /// </summary>
    /// <param name="quantity">Входное значение.</param>
    [TestCase("1A0")]
    [TestCase("10,34")]
    [TestCase("-54,38")]
    [TestCase("-15")]
    [TestCase("")]
    public void TestValidateQuantityException(string quantity)
    {
      Assert.Throws<FormatException>(() => ProductValidator.ValidateQuantity(quantity));
    }
  }
}
