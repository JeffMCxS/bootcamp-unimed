using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploConstrutores.Models
{
    public class Pessoa
    {
        private readonly string nome = "Leo"; //Readonly, define que os valores só podem ser setados
        //pelo construtor, ou aqui na própria declaração. É um parâmetro de somente leitura
        private readonly string sobrenome;


        //Construtor sem parâmetros
        public Pessoa()
        {
            nome = string.Empty; //Definindo valores vazios
            sobrenome = string.Empty;
        }

        //Construtor com parâmetros
        public Pessoa(string nome, string sobrenome)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            System.Console.WriteLine("Construtor classe pessoa!");
        }

        /* Se não for definido um construtor, o C# criará um automaticamente sem nenhum parâmetro 
        como contrutor default.
        Caso seja definido um construtor, o contrutor default não será criado. E se caso for necessário um,
        deverá ser criado manualmente. */


        public void Apresentar()
        {
            System.Console.WriteLine($"Olá, meu nome é: {nome} {sobrenome}");
        }
    }
}