using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Управление финансами магазина.
  /// </summary>
  internal class ShopFinancesManager
  {
    /// <summary>
    /// Финансы магазина.
    /// </summary>
    public ShopFinances ShopFinances { get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ShopFinancesManager()
    {
      ShopFinances = new ShopFinances();
    }

    /// <summary>
    /// Метод для добавления прибыли.
    /// </summary>
    /// <param name="amount">Денежная сумма.</param>
    public void AddIncome(double amount)
    {
      ShopFinances.TotalIncome += amount;
      ShopFinances.CurrentBalance += amount;
    }

    /// <summary>
    /// Метод для вычета расходов.
    /// </summary>
    /// <param name="amount">Денежная сумма.</param>
    public void DeductExpenses(double amount)
    {
      ShopFinances.TotalExpenses += amount;
      ShopFinances.CurrentBalance -= amount;
    }
  }
}
