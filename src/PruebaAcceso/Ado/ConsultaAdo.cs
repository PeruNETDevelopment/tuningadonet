using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso.Ado
{
  public class ConsultaAdo : IConsulta
  {
    private SqlConnection _conexion = null;

    public string Nombre => "ADO.Net";
    public double TotalSegundos { get; set; }

    public IEnumerable<Order> Ejecutar()
    {
      var sql = @"select o.OrderID, c.CompanyName, o.OrderDate, o.ShipName, Sum(od.UnitPrice * od.Quantity) TotalOrder
  from [Orders] o
    inner join [Order Details] od on o.OrderID = od.OrderID
    inner join [Customers] c on o.CustomerID = c.CustomerID
  group by o.OrderID, c.CompanyName, o.OrderDate, o.ShipName
  order by o.OrderID";

      var comando = new SqlCommand(sql, _conexion);
      var listaOrder = new List<Order>();
      _conexion.Open();
      var reader = comando.ExecuteReader();
      while (reader.Read())
      {
        listaOrder.Add(new Order
        {
          OrderId = reader.GetInt32(0),
          CompanyName = reader.GetString(1),
          OrderDate = reader.GetDateTime(2),
          ShipName = reader.GetString(3),
          Total = reader.GetDecimal(4)
        });
      }
      _conexion.Close();

      return listaOrder;
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
