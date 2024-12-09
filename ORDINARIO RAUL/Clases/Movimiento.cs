using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.Interfaces;
using ORDINARIO_RAUL.PokemonAtributos;
using PokemonBattle;

namespace ORDINARIO_RAUL.Clases
{
    public class Movimiento : IMovimiento
    {
        public string Nombre { get; set; }

        public TiposPokemond Tipo { get; set; }

        public MovimientoClase Clase { get; set; }

        public int? Potencia { get; set; }
        public int? Precision { get; set; }

        public Movimiento(string nombre, TiposPokemond tipo, MovimientoClase clase,
            int? potencia, int? precision)
        {
            if (precision.HasValue && (precision < 0 || precision > 100))
                throw new ArgumentException("La precisión debe estar entre 0 y 100.");

            Nombre = nombre;
            Tipo = tipo;
            Clase = clase;
            Potencia = potencia;
            Precision = precision;
        }
        public void EjecutarMovimiento(IPokemond atacante, IPokemond objetivo, Batalla batalla)
        {
            if (Precision == null || new Random().Next(1, 101) <= Precision)
            {
                if (Potencia.HasValue)
                {
                    int ataque = Clase == MovimientoClase.Fisico ? atacante.Ataque : atacante.AtaqueEspecial;
                    double defensa = Clase == MovimientoClase.Fisico ? objetivo.Defenza : objetivo.DefenzaEspecial;
                    double efectividad = batalla.CalcularEfectividad(Tipo, objetivo.Tipos);
                    int daño = (int)((((2 * atacante.Nivel / 5.0 + 2) * Potencia.Value * ataque / defensa) / 50 + 2) * efectividad);
                    objetivo.RecibirDaño(daño);
                    Console.WriteLine($"{atacante.Name} usó {Nombre} y causó {daño} de daño. (Efectividad: {efectividad})");
                }
            }
            else
            {
                Console.WriteLine($"{atacante.Name} falló el ataque {Nombre}.");
            }
        }
    }
}

