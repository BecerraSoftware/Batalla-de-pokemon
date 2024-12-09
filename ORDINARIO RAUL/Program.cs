using ORDINARIO_RAUL.Clases;
using ORDINARIO_RAUL.Interfaces;
using System;
using System.Collections.Generic;
using ORDINARIO_RAUL.Enums;
using ORDINARIO_RAUL.Efectos;

namespace PokemonBattle
{
    public class Program
    {
        static void Main(string[] arg)
        {
            //efectos de Rottom
           var ataquePrimero = new Efecto("Ataque Primero", 1, (atacante, objetivo, batalla) =>
            {
                atacante.Velocidad = 1000;
                Console.WriteLine($"{objetivo.Name} ataca Primero");
            });

            var AumentarDefenza50= new Efecto("Aumentar Defenza 50", 2, (atacante, objetivo, batalla) =>
            {
                objetivo.DefenzaEspecial += 50;
                Console.WriteLine($"{objetivo.Name} aumento su defenza en 50.");
            }); 

            //efectos de Ludicolo
            var absorverVida = new Efecto("Absorver Vida", 1, (atacante, objetivo, batalla) =>
            {//GUARDAR La vida que se absorvio
                int daño = (int)(objetivo.VidaMaxima*.1);
                objetivo.RecibirDaño(daño);
                atacante.VidaActual += daño/4;
                Console.WriteLine($"{atacante.Name} absorvio {daño/4} de vida.");
            });

            var ReduccionDeAtaqueAEnemigosAl90Menos = new Efecto("Reduccion de Ataque a enemigos al 90% menos", 2, (atacante, objetivo, batalla) =>
            {
                objetivo.Ataque = (int)(objetivo.Ataque * 0.9);
                Console.WriteLine($"{objetivo.Name} su ataque se redujo al 90%.");
            });






            //movimientos DE ROTTOM
            var tacleada = new Movimiento("tacleada", TiposPokemond.Normal, MovimientoClase.Fisico, 40, 100);
            var AtaqueRapido = new Movimiento("Ataque Rapido", TiposPokemond.Normal, MovimientoClase.Fisico, 50, 100);
            AtaqueRapido.Efectos.Add(ataquePrimero);
            var trueno = new Movimiento("Trueno", TiposPokemond.Electrico, MovimientoClase.Especial, 70, 100);
            var reforzar = new Movimiento("reforzar", TiposPokemond.Normal, MovimientoClase.Especial, null, null);
            reforzar.Efectos.Add(AumentarDefenza50);

            //movimientos de Ludicolo
            var chorroDeAgua = new Movimiento("Chorro de agua", TiposPokemond.Agua, MovimientoClase.Especial, 60, 100);
            var Terremoto = new Movimiento("Terremoto", TiposPokemond.Tierra, MovimientoClase.Fisico, 80, 100);
            var Absorver = new Movimiento("Absorver", TiposPokemond.Hierba, MovimientoClase.Especial, 40, 100);
            Absorver.Efectos.Add(absorverVida);
            var DobleEquipo = new Movimiento("Doble Equipo", TiposPokemond.Normal, MovimientoClase.Especial, null, null);
            DobleEquipo.Efectos.Add(ReduccionDeAtaqueAEnemigosAl90Menos);



            //Pokemones de raul examen

            var Ludicolo = new Pokemon("Ludicolo", 150, 10, 30, 10, 25, 15,
                new List<TiposPokemond> { TiposPokemond.Agua, TiposPokemond.Hierba },
                new List<Movimiento> { chorroDeAgua, Terremoto, Absorver, DobleEquipo });

            var RotomMicrohondas=new Pokemon("Rotom Microhondas",120,25,25,15,20,10,
                new List<TiposPokemond> {TiposPokemond.Fuego,TiposPokemond.Electrico },
                new List<Movimiento> { tacleada, AtaqueRapido, trueno, reforzar });



            var batle = new Batalla(Ludicolo, RotomMicrohondas);


            batle.Iniciar();






            var quemadura = new Efecto("Quemadura", 2, (atacante, objetivo, batalla) =>
             {
                 int daño = objetivo.VidaMaxima / 22; // Daño residual del 1/16 de la vida máxima
                 objetivo.RecibirDaño(daño);
                 Console.WriteLine($"{objetivo.Name} sufre {daño} de daño debido a quemaduras.");
             });

            var chispa = new Movimiento("Chispa", TiposPokemond.Electrico, MovimientoClase.Especial, 65, 100);
            var lanzallamas = new Movimiento("Lanzallamas", TiposPokemond.Fuego, MovimientoClase.Especial, 90, 100);
            lanzallamas.Efectos.Add(quemadura);
            var hojaNavaja = new Movimiento("Hoja Navaja", TiposPokemond.Hierba, MovimientoClase.Fisico, 70, 100);
            var pistolaAgua = new Movimiento("Pistola Agua", TiposPokemond.Agua, MovimientoClase.Especial, 60, 100);
            // Crear un pokemond de tipo agua y planta

            var bulbasaur = new Pokemon("Bulbasaur", 45, 49, 49, 65, 65, 45,
                new List<TiposPokemond> { TiposPokemond.Hierba, TiposPokemond.Agua },
                new List<Movimiento> { hojaNavaja, pistolaAgua });

            var charizard = new Pokemon("Charizard", 78, 84, 78, 78, 85, 100,
                new List<TiposPokemond> { TiposPokemond.Fuego, TiposPokemond.Electrico },
                new List<Movimiento> { lanzallamas, chispa });





        }
    }
}
