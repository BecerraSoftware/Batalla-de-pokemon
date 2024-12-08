using ORDINARIO_RAUL.PokemonAtributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Clases.Efectos
{
    public class EfectoCampo : Interfaces.IEfecto
    {
        public void AplicarEfecto(IPokemond objetivo)
        {

        }

        public void AplicarEfecto(Batalla batalla)
        {
            batalla.AntesDeAtaque += DuplicarDaño;
        }
        private void DuplicarDaño(Pokemon ataca,MovimientoBase movimiento)
        {
            if (movimiento.Potencia.HasValue)
            {
                Console.WriteLine($"El campo duplica el daño {movimiento.Nombre}. ");
                movimiento.Potencia *= 2;
            }
        }
    }
}
