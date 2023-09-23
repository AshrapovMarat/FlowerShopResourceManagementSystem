using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopResourceManagementSystem
{
  internal interface ICRUD
  {
    void Create();

    void Read();

    void Update();

    void Delete();
  }
}
