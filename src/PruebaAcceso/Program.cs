using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAcceso
{
  class Program
  {
    static void Main()
    {
      //new Ado.ConsultaAdo().EjecutarMedicion();
      new Dapper.ConsultaDapper().EjecutarMedicion();

      Console.WriteLine();
      Console.WriteLine("Los tiempos estan en segundos");
      Console.WriteLine();
      Console.WriteLine("Terminado...");
      Console.ReadLine();
    }
  }
}
