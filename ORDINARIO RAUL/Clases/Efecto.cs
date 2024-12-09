using ORDINARIO_RAUL.PokemonAtributos;
using System;

namespace ORDINARIO_RAUL.Clases
{

    public class Efecto
    {
        public string Nombre { get; private set; }
        public Action<IPokemond, IPokemond, Batalla> Aplicar { get; private set; }

        public int Duracion { get; set; }
        public Efecto(string nombre,int duracion,Action<IPokemond,IPokemond,Batalla> aplicar)
        {
            Nombre = nombre;
            Aplicar = aplicar;
            Duracion = duracion;
        }

      

    }


}
