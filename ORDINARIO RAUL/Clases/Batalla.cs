using ORDINARIO_RAUL.PokemonAtributos;
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

        public event Action<Pokemon, MovimientoBase> AntesDeAtaque;
        public event Action<Pokemon,MovimientoBase> DespuesDeAtaque;


        public Batalla(Pokemon pokemod1, Pokemon pokemon2)
        {
            _pokemond1 = pokemod1;
            _pokemond2 = pokemon2;
        }

        public void IniciarTurno(MovimientoBase movimiento1,MovimientoBase movimiento2)
        {
          var (primerPokemon, segundoPokemon, primerMovimiento, segundoMovimiento) =
                DeterminarOrdenDeAtaque(movimiento1, movimiento2);

            if (!EjecutarMovimiento(primerPokemon, segundoPokemon, primerMovimiento))
                return;

            EjecutarMovimiento(segundoPokemon, primerPokemon, segundoMovimiento);

            
        }
        private bool EjecutarMovimiento(Pokemon atacante, Pokemon objetivo, MovimientoBase movimiento)
        {
            // Evento: Antes de atacar
            AntesDeAtaque?.Invoke(atacante, movimiento);

            // Ejecutar el movimiento
            movimiento.EjecutarMovimiento(atacante, objetivo, this);

            // Revisar si el objetivo ha caído
            if (objetivo.Vida <= 0)
            {
                Console.WriteLine($"{objetivo.Name} ha sido derrotado.");
                return false; // Terminar el turno
            }

            // Evento: Después de atacar
            DespuesDeAtaque?.Invoke(atacante, movimiento);
            return true;
        }
        private (Pokemon, Pokemon, MovimientoBase, MovimientoBase) DeterminarOrdenDeAtaque(MovimientoBase movimiento1, MovimientoBase movimiento2)
        {
            if (_pokemond1.Velocidad > _pokemond2.Velocidad || movimiento1.Precision > movimiento2.Precision)
            {
                return (_pokemond1, _pokemond2, movimiento1, movimiento2);
            }
            return (_pokemond2, _pokemond1, movimiento2, movimiento1);
        }

        private void EstadoBatalla()
        {
            Console.WriteLine($"Estado de los Pokemonds: " +
                $" {_pokemond1}" +
                $"\n " +
                $"{_pokemond2} ");
        }


    }
}
