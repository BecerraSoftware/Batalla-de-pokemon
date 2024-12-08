using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Clases
{
    public class CalculadorDeDaño: Interfaces.ICalculadorDeDaño
    {
        public int Calcular(
           int nivel,
           int? potencia,
           int ataque,
           int defensa,
           double tipo1Efectividad,
           double tipo2Efectividad,
           bool critico = false)
        {
            if (!potencia.HasValue)
                throw new ArgumentException("El movimiento debe tener una potencia definida para calcular el daño.");

            // Fórmula básica de daño
            double baseDaño = ((2 * nivel / 5.0 + 2) * potencia.Value * ataque / defensa) / 50 + 2;

            // Modificadores
            double modificador = tipo1Efectividad * tipo2Efectividad;
            if (critico) modificador *= 1.5;

            // Resultado final
            return (int)(baseDaño * modificador);
        }
    }
}
