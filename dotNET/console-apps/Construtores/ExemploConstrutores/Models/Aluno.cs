using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploConstrutores.Models
{
    public class Aluno : Pessoa //Herdando Pessoa
    {
        public Aluno(string nome, string sobrenome, string disciplina) : base(nome, sobrenome)
        //base (semelhante ao this) é utilizado para se referir a algo da classe mãe
        {
            System.Console.WriteLine("Construtor classe aluno!");
        }
    }
}