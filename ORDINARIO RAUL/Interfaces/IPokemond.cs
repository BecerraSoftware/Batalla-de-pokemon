using ORDINARIO_RAUL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORDINARIO_RAUL.Interfaces;
using ORDINARIO_RAUL.Enums;

namespace ORDINARIO_RAUL.PokemonAtributos
{
    public interface IPokemond
    {
        string Name { get; }
        int Nivel { get; set; }
        int VidaActual { get; set; }
        int VidaMaxima { get; set; }
        int Ataque { get; set; }
        int AtaqueEspecial { get; set; }
        double Defenza { get; set; }
        double DefenzaEspecial { get; set; }
        double Velocidad { get; set; }
        List<TiposPokemond> Tipos { get; set; }

        List<Movimiento> Movimientos { get; set; }
         void RecibirDaño(int daño);

    }
}
