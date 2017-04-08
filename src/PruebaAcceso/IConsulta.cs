using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso
{
  public interface IConsulta
  {
    string Nombre { get; }
    double TotalSegundos { get; set; }
    void IniciarSesion();
    void TerminarSesion();
    IEnumerable<Order> Ejecutar();
  }
}
