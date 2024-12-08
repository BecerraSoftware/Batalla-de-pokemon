using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.Interfaces;
using ORDINARIO_RAUL.PokemonAtributos;

namespace ORDINARIO_RAUL.Clases
{
    public abstract class MovimientoBase : IMovimiento
    {
        public string Nombre { get; set; }

        public TiposPokemond Tipo { get; set; }

        public MovimientoClase Clase { get; set; }

        public int? Potencia { get; set; }
        public int? Precision { get; set; }

        public List<IEfecto> efectos { get; }

        public bool TieneObjetivo { get; }
        protected MovimientoBase(string nombre, TiposPokemond tipo, MovimientoClase clase,
            int? potencia, int? precision, List<IEfecto> efectos, bool tieneObjetivo)
        {
            if (precision.HasValue && (precision < 0 || precision > 100))
                throw new ArgumentException("La precisión debe estar entre 0 y 100.");

            Nombre = nombre;
            Tipo = tipo;
            Clase = clase;
            Potencia = potencia;
            Precision = precision;
            this.efectos = efectos ?? new List<IEfecto>();
            TieneObjetivo = tieneObjetivo;
        }
        public abstract void EjecutarMovimiento(IPokemond atacante, IPokemond objetivo, Batalla batalla);
    }
}

