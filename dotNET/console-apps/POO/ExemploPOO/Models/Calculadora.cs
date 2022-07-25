using ExemploPOO.Interfaces;

namespace ExemploPOO.Models
{
    public class Calculadora : ICalculadora
    {

        /* Ao utilizar uma Interface é obritória a implementação de todos os seus metodos, a menos que
        o mesmo já tenha sido implementado na própria interface.
        A implementação na própria interface não pode ser feita em versões anterioes C# 8.0, .NET 3.0 */

        public int Somar(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Somar(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        public int Subtrair(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}