using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Финансы магазина.
  /// </summary>
  internal class ShopFinances
  {
    /// <summary>
    /// Общая сумма доходов магазина.
    /// </summary>
    public double TotalIncome { get; set; } 

    /// <summary>
    /// Общая сумма расходов магазина.
    /// </summary>
    public double TotalExpenses { get; set; }

    /// <summary>
    /// Текущий баланс магазина.
    /// </summary>
    public double CurrentBalance { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ShopFinances() 
    {
      CurrentBalance = TotalIncome - TotalExpenses;
    }

  }
}
