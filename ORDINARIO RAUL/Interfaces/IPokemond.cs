using ORDINARIO_RAUL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORDINARIO_RAUL.Interfaces;

namespace ORDINARIO_RAUL.PokemonAtributos
{
    public interface IPokemond
    {
        double Vida { get; set; }
        int Ataque { get; set; }
        int AtaqueEspecial { get; set; }
        double Defenza { get; set; }
        double DefenzaEspecial { get; set; }
        double Velocidad { get; set; }


    }
}
