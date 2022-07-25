using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploConstrutores.Models
{
    public class Calculadora
    {
        public delegate void DelegateCalculadora(); //Um Event precisa de método Delegate para ser gerado

        public static event DelegateCalculadora EventoCalculadora;
        //Calculadora possui um evento (EventoCalculadora) que outros métodos podem se inscrever neste evento

        // public static void Somar(int x, int y)
        // {
        //     System.Console.WriteLine($"Adição: {x + y}");
        // }

        // public static void Subtrair(int x, int y)
        // {
        //     System.Console.WriteLine($"Subtração: {x - y}");
        // }

        public static void Somar(int x, int y)
        {
            if (EventoCalculadora != null) //Caso haja eventos inscritos, execute o conteúdo abaixo
            {
                System.Console.WriteLine($"Adição: {x + y}");
                EventoCalculadora(); //Executa os métodos que forem inscritos (EventHandler)
            }
            else
            {
                System.Console.WriteLine("Nenhum inscrito");
            }
        }

        public static void Subtrair(int x, int y)
        {
            System.Console.WriteLine($"Subtração: {x - y}");
        }


    }
}