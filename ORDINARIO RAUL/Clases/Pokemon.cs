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

        private double _vidaMaxima;
        public double VidaMaxima { get { if (_vidaMaxima > 100) { return 100; } return _vidaMaxima; } set => _vidaMaxima = value; }

        private double _vidaActual;
        public double VidaActual { get => _vidaActual; set => _vidaActual = value > 0 ? value : 0; }

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

        public Pokemon(string name, double vidaMaxima, int ataque, int ataqueEspecial, double defenza,
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
            VidaActual = Math.Max(VidaActual - daño,0);
        }



        //private TiposPokemond _tipoPrimario;
        //private TiposPokemond? _tipoSecundario;

        //public TiposPokemond TipoPrimario
        //{
        //    get => _tipoPrimario;
        //    private set
        //    {
        //        if (_tipoSecundario.HasValue && _tipoSecundario.Value == value)
        //        {
        //            throw new Exception("No puede tener dos iguales tipos secundario");
        //        }
        //        _tipoPrimario = value;
        //    }
        //}

        //public TiposPokemond? TipoSecundario
        //{
        //    get => _tipoSecundario;
        //    private set
        //    {
        //        if (value.HasValue && value.Value == _tipoPrimario) { throw new Exception("No puede tener dos iguales tipos secundario"); }
        //        _tipoSecundario = value;
        //    }
        ////}

        //public Pokemon(string nombre, double vidaMaxima, int ataque, int ataqueEspecial, double defenza, double defenzaEspecial, double velocidad, TiposPokemond tipoPrimario, TiposPokemond tipoSecundario)
        //{
        //    VidaMaxima = vidaMaxima;
        //    VidaActual = VidaMaxima;
        //    Ataque = ataque;
        //    AtaqueEspecial = ataqueEspecial;
        //    Defenza = defenza;
        //    DefenzaEspecial = defenzaEspecial;
        //    Velocidad = velocidad;
        //    TipoPrimario = tipoPrimario;
        //    TipoSecundario = tipoSecundario;

        //}   
        //public Pokemon(string nombre, double vida, int ataque, int ataqueEspecial, double defenza, double defenzaEspecial, double velocidad, TiposPokemond tipoPrimario)
        //{
        //    //Vida = vida;
        //    Ataque = ataque;
        //    AtaqueEspecial = ataqueEspecial;
        //    Defenza = defenza;
        //    DefenzaEspecial = defenzaEspecial;
        //    Velocidad = velocidad;
        //    TipoPrimario = tipoPrimario;

        //}

        public void MostrarEstado()
        {
            Console.WriteLine($"{Name} - Nivel: {Nivel}, Vida: {VidaActual}/{VidaMaxima}");
        }



    }
}