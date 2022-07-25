namespace ExemploPOO.Interfaces
{
    public interface ICalculadora
    {
        int Somar(int num1, int num2);
        int Subtrair(int num1, int num2);

        //Como já foi implementado aqui, não precisa ser feito na Classe
        //Funciona apenas no C# 8.0, .NET 3.0 ou superior
        int Multiplicar(int num1, int num2)
        {
            return num1 * num2;
        }

        int Dividir(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}