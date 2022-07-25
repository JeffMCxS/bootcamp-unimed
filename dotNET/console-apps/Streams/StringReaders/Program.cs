using System;
using System.Text;
using System.IO;

namespace StringReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Caracteres na primeira linha para ler");
            sb.AppendLine("e a segunda linha");
            sb.AppendLine("e o fim");

            using var sr = new StringReader(sb.ToString()); //Pega a string do StringBuilder
            //StringReader implementa IDisposable, entao é interessante utilizar using

            var buffer = new char[10];
            // var pos = sr.Read(buffer); //Gerou um array com os 10 primeiros caracteres do StringReader
            // Console.WriteLine($"{string.Join("", buffer)}"); //Junta caracteres
            // Console.ReadLine();

            var tamanho = 0;

            /* Leitura a cada parágrafo, não recomendado quando não se sabe o tamanho do conteúdo */
            do
            {
                Console.WriteLine(sr.ReadLine());
            } while (sr.Peek() >= 0); //Peek consome o próximo caracter disponível, e se não tiver retorna -1


            /* Alternativa ao Do acima, leitura a cada X números de caracteres */
            // do
            // {
            //     var buffer = new char[10]; //Zerando o buffer
            //     tamanho = sr.Read(buffer);
            //     Console.WriteLine(string.Join("", buffer));
            //     //Console.Write(string.Join("", buffer)); //Não quebra a linha a cada iteração

            // } while (tamanho >= buffer.Length);

            Console.WriteLine("Digite [enter] para finalizar...");
            Console.ReadLine();

        }
    }
}
