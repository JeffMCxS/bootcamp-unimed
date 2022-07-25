using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploConstrutores.Models
{
    public class Matematica
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Matematica(int x, int y)
        {
            X = x;
            Y = y;

            Calculadora.EventoCalculadora += EventHandler; //Inscrevendo o EventHandler no EventoCalculadora
            //Quando ocorrer alguma ação no EventoCalculadora, o conteúdo do EventHandler também será executado
        }

        public void Somar()
        {
            Calculadora.Somar(X, Y);
        }

        public void EventHandler() //Evento
        {
            System.Console.WriteLine("Método executado");
        }
    }
}