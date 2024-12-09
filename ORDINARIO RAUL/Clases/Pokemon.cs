using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.PokemonAtributos;
using System;
using System.Collections.Generic;

namespace ORDINARIO_RAUL.Clases
{
    public class Pokemon : IPokemond
    {
        private string _name;
        public string Name { get { return _name; } }

        public int Nivel { get; set; }

        private int _vidaMaxima;
        public int VidaMaxima { get { return _vidaMaxima; } set => _vidaMaxima = value; }

        private int _vidaActual;
        public int VidaActual { get => _vidaActual; set => _vidaActual = value > 0 ? value : 0; }

        private int _ataque;
        public int Ataque { get => _ataque; set => _ataque = value > 0 ? value : 0; }

        private int _ataqueEspecial;
        public int AtaqueEspecial { get => _ataqueEspecial; set => _ataqueEspecial = value > 0 ? value : 0; }

        private double _defenza;
        public double Defenza { get => _defenza; set => _defenza = value > 0 ? value : 0; }
        private double _defenzaEspecial;
        public double DefenzaEspecial { get => _defenzaEspecial; set => _defenzaEspecial = value > 0 ? value : 0; }
        private double _velocidad;
        public double Velocidad { get => _velocidad; set => _velocidad = value > 0 ? value : 0; }

        public List<TiposPokemond> Tipos {  get; set; }

        public List<Movimiento> Movimientos { get; set; }

        public bool Paralizado;

        public Pokemon(string name, int vidaMaxima, int ataque, int ataqueEspecial, double defenza,
            double defenzaEspecial, double velocidad, List<TiposPokemond> tipos, List<Movimiento> movimientos)
        {
            _name = name;
            VidaMaxima = vidaMaxima;
            VidaActual = VidaMaxima;
            Ataque = ataque;
            AtaqueEspecial = ataqueEspecial;
            Defenza = defenza;
            DefenzaEspecial = defenzaEspecial;
            Velocidad = velocidad;
            Tipos = tipos;
            Movimientos = movimientos;
        }

        public void RecibirDaño(int daño)
        {
            VidaActual = Math.Max(VidaActual - daño, 0);
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"{Name} - Nivel: {Nivel}, Vida: {VidaActual}/{VidaMaxima}");
        }



    }
}