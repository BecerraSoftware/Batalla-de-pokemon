using ORDINARIO_RAUL.Clases;
using ORDINARIO_RAUL.Interfaces;
using System;
using System.Collections.Generic;
using ORDINARIO_RAUL.Enums;

namespace PokemonBattle
{
    public class Program
    {
         static void Main(string[] arg)
        {
            var chispa= new Movimiento("Chispa", TiposPokemond.Electrico, MovimientoClase.Especial, 65, 100);
            var lanzallamas = new Movimiento("Lanzallamas", TiposPokemond.Fuego, MovimientoClase.Especial, 90, 100);
            var hojaNavaja = new Movimiento("Hoja Navaja", TiposPokemond.Hierba, MovimientoClase.Fisico, 70, 100);
            var pistolaAgua = new Movimiento("Pistola Agua", TiposPokemond.Agua, MovimientoClase.Especial, 60, 100);

            // Crear un pokemond de tipo agua y planta

            var bulbasaur = new Pokemon("Bulbasaur", 45, 49, 49, 65, 65, 45,
                new List<TiposPokemond> { TiposPokemond.Hierba,TiposPokemond.Agua},
                new List<Movimiento> { hojaNavaja, pistolaAgua});

            var charizard= new Pokemon("Charizard", 78, 84, 78, 78, 85, 100,
                new List<TiposPokemond> { TiposPokemond.Fuego, TiposPokemond.Electrico },
                new List<Movimiento> { lanzallamas, chispa });

            var batalla = new Batalla(charizard,bulbasaur);
            batalla.Iniciar();




        }
    }
}
