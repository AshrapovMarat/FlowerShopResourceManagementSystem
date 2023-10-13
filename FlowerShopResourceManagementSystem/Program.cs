namespace FlowerShopResourceManagementSystem
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var productService = new ProductService();
      ConsoleProgram consoleProgram = ConsoleProgram.Initialize(productService);
      consoleProgram.StartProgram();
    }
  }
}