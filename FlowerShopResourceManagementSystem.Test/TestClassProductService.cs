namespace FlowerShopResourceManagementSystem.Test
{
  public class TestClassProductService
  {
    [TestCase("Лилия", 12.42, 34)]
    [TestCase("Роза", 12.42, 34)]
    [TestCase("Астра", 12.42, 34)]
    public void CheckExistingUserErrorTest(string name, double price, int quantity)
    {
      List<Product> products = new List<Product>
      {
        new Product("Лилия", 22.54, 12),
        new Product("Роза", 22.54, 12),
        new Product("Астра", 22.54, 12)
      };
      var productServis = new ProductService(products);

      Assert.Throws<InvalidOperationException>(() => productServis.AddProduct(name, price, quantity));
    }
  }

  // Проверить метод ReduceTheNumberOfProducts в классе ProductService


  // Проверить методы для чтения с консоли
}