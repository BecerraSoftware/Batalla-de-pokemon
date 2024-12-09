using ORDINARIO_RAUL.PokemonAtributos;
using System;

namespace ORDINARIO_RAUL.Clases
{

    public class Efecto
    {
        public string Nombre { get; private set; }
        public Action<IPokemond, IPokemond, Batalla> Aplicar { get; private set; }


        public Efecto(string nombre,Action<IPokemond,IPokemond,Batalla> aplicar)
        {
            Nombre = nombre;
            Aplicar = aplicar;
        }

    }


}
