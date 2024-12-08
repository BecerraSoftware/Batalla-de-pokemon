using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Interfaces
{
    public interface ICalculadorDeDaño
    {
        int Calcular(
           int nivel,
           int? potencia,
           int ataque,
           int defensa,
           double tipo1Efectividad,
           double tipo2Efectividad,
           bool critico = false);

    }
        
        
}
