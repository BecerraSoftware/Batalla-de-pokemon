using ORDINARIO_RAUL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORDINARIO_RAUL.PokemonAtributos;

namespace ORDINARIO_RAUL.Interfaces
{
    public interface IEfecto
    {
        void AplicarEfecto(IPokemond objetivo);
        void AplicarEfecto(Batalla batalla);
    }
}
