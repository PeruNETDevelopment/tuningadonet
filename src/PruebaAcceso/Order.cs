using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso
{
  public class Order
  {
    public int OrderId { get; set; }
    public string CompanyName { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public decimal Total { get; set; }
  }
}
