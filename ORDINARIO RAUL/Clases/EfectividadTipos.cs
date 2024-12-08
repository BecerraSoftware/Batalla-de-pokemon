using ORDINARIO_RAUL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Clases
{
    public static class EfectividadTipos
    {
        private static readonly Dictionary<(
            TiposPokemond ataca,
            TiposPokemond objetivo), double> Efectividades = new Dictionary<(TiposPokemond ataca, TiposPokemond objetivo), double>
            {
                { (TiposPokemond.Fuego, TiposPokemond.Agua),2 }
                {(TiposPokemond.) }
            };

        public static double Calcular(TiposPokemond atacante, TiposPokemond objetivo)
        {
            return Efectividades.TryGetValue((atacante, objetivo), out var efectividad) ? efectividad : 1;
        }

    }
}
