using ORDINARIO_RAUL.Clases;
using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.PokemonAtributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Interfaces
{
    public interface IMovimiento
    {
        string Nombre { get; }
        TiposPokemond Tipo { get; }
        MovimientoClase Clase { get; }
        int? Potencia { get; }
        int? Precision { get; } 
        void EjecutarMovimiento(IPokemond atacante, IPokemond objetivo, Batalla batalla);
    }
}
