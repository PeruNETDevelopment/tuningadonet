using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso.Dapper
{
  public class ConsultaDapper : IConsulta
  {
    private SqlConnection _conexion = null;

    public string Nombre => "Dapper";
    public double TotalSegundos { get; set; }

    public IEnumerable<Order> Ejecutar()
    {
      var sql = @"select o.OrderID, c.CompanyName, o.OrderDate, o.ShipName, Sum(od.UnitPrice * od.Quantity) Total
  from [Orders] o
    inner join [Order Details] od on o.OrderID = od.OrderID
    inner join [Customers] c on o.CustomerID = c.CustomerID
  group by o.OrderID, c.CompanyName, o.OrderDate, o.ShipName
  order by o.OrderID";

      return _conexion.Query<Order>(sql);
    }

    public void IniciarSesion()
    {
      _conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString);
    }

    public void TerminarSesion()
    {
      _conexion.Dispose();

      _conexion = null;
    }
  }
}
