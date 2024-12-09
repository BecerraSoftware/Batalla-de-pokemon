using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.Interfaces;
using ORDINARIO_RAUL.PokemonAtributos;
using PokemonBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORDINARIO_RAUL.Clases
{
    public class Batalla
    {
        private readonly Pokemon _pokemond1;
        private readonly Pokemon _pokemond2;

        //evento maneja efectos
        public event Action<IPokemond, IPokemond, Batalla> OnAplicarEfectos;

        public Batalla(Pokemon pokemon1, Pokemon pokemon2)
        {
            _pokemond1 = pokemon1;
            _pokemond2 = pokemon2;
        }

        public void Iniciar()
        {
            while (_pokemond1.VidaActual > 0 && _pokemond2.VidaActual > 0)
            {
                Console.WriteLine("----new Turnoo---");
                _pokemond1.MostrarEstado();
                _pokemond2.MostrarEstado();

                //Seleccionar movimientos
                IMovimiento movimiento1 = SeleccionarMovimiento(_pokemond1);
                IMovimiento movimiento2 = SeleccionarMovimiento(_pokemond2);

                // Determinar orden basado en velocidad
                IPokemond primero, segundo;
                IMovimiento movPrimero, movSegundo;

                if (_pokemond1.Velocidad >= _pokemond2.Velocidad)
                {
                    primero = _pokemond1;
                    movPrimero = movimiento1;
                    segundo = _pokemond2;
                    movSegundo = movimiento2;
                }
                else
                {
                    primero = _pokemond2;
                    movPrimero = movimiento2;
                    segundo = _pokemond1;
                    movSegundo = movimiento1;
                }


                // Ejecutar movimientos en orden
                movPrimero.EjecutarMovimiento(primero, segundo, this);

                if (segundo.VidaActual > 0)
                {
                    movSegundo.EjecutarMovimiento(segundo, primero, this);
                }
                else
                {
                    Console.WriteLine($"{segundo.Name} ha sido derrotado.");
                    break;
                }
                OnAplicarEfectos?.Invoke(primero, segundo, this);

                OnAplicarEfectos?.Invoke(segundo, primero, this);

                if (primero.VidaActual <= 0)
                {
                    Console.WriteLine($"{primero.Name} ha sido derrotado.");
                    break;
                }
            }

            Console.WriteLine("\n--- Fin de la batalla ---");
            _pokemond1.MostrarEstado();
            _pokemond2.MostrarEstado();
        }
        private void AplicarEfectos()
        {

        }
        private IMovimiento SeleccionarMovimiento(Pokemon pokemon)
        {
            Console.WriteLine($"\n{pokemon.Name}, selecciona un movimiento:");
            for (int i = 0; i < pokemon.Movimientos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemon.Movimientos[i].Nombre}");
            }
            int opcion = int.Parse(Console.ReadLine()) - 1;
            return pokemon.Movimientos[opcion];
        }
        public double CalcularEfectividad(TiposPokemond tipoMovimiento, List<TiposPokemond> tiposDefensor)
        {
            var fortalezas = new Dictionary<TiposPokemond, List<TiposPokemond>>
            {
                { TiposPokemond.Fuego, new List<TiposPokemond> { TiposPokemond.Hierba, TiposPokemond.Insecto } },
                { TiposPokemond.Agua, new List<TiposPokemond> { TiposPokemond.Fuego } },
                { TiposPokemond.Hierba, new List<TiposPokemond> { TiposPokemond.Agua } },
                { TiposPokemond.Electrico, new List<TiposPokemond> { TiposPokemond.Agua } },
                {TiposPokemond.Tierra,new List<TiposPokemond>{TiposPokemond.Fuego,TiposPokemond.Electrico } }

            };

            var debilidades = new Dictionary<TiposPokemond, List<TiposPokemond>>
            {
                { TiposPokemond.Fuego, new List<TiposPokemond> { TiposPokemond.Agua } },
                { TiposPokemond.Agua, new List<TiposPokemond> { TiposPokemond.Hierba } },
                { TiposPokemond.Hierba, new List<TiposPokemond> { TiposPokemond.Fuego } },
                { TiposPokemond.Electrico, new List<TiposPokemond> { TiposPokemond.Hierba } }
            };

            double efectividad = 1.0;

            foreach (var tipo in tiposDefensor)
            {
                if (fortalezas.ContainsKey(tipoMovimiento) && fortalezas[tipoMovimiento].Contains(tipo))
                    efectividad *= 2.0;
                if (debilidades.ContainsKey(tipoMovimiento) && debilidades[tipoMovimiento].Contains(tipo))
                    efectividad *= 0.5;
            }

            return efectividad;
        }
    }
}
