using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso
{
  public static class MedidorVelocidad
  {
    public static void EjecutarMedicion(this IConsulta consulta)
    {
      consulta.IniciarSesion();

      var timer = Stopwatch.StartNew();
      for (int i = 0; i < 100; i++)
      {
        consulta.Ejecutar();
      }
      timer.Stop();
      consulta.TerminarSesion();

      Console.WriteLine(consulta.Nombre + "\t\t" + timer.Elapsed.TotalSeconds);
    }
  }
}
