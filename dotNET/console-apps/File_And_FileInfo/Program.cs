using System;
using System.IO;
using static System.Console;

namespace File_And_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = Environment.CurrentDirectory + "\\teste.txt"; //Alternativa
            //var path = Path.Combine(Environment.CurrentDirectory, "teste.txt");
            //var path = Path.Combine("C:\\temp", "teste.txt"); //Alternativa
            //var path = Path.Combine(@"C:\temp", "teste.txt");  //Alternativa

            //File.Create(path);

            /*  Utilizando Flush

                var sw = File.CreateText(path); //CreateText retorna um StreamWriter
                //E é através dele que se escreve no arquivo, então é preciso armazená-lo
                //em uma variável (sw nesse caso)
                
                sw.WriteLine("Esta é a linha 1 do arquivo");
                sw.WriteLine("Esta é a linha 2 do arquivo");
                sw.WriteLine("Esta é a linha 3 do arquivo");
                // Até o momento os dados estão armazenados na memória

                sw.Flush(); //Flush descarrega os dados para o arquivo txt
            */

            /*  Alternativa sem o Flush. o Using chamará o Dispose para efetuar a liberação
                dos dados antes da aplicação encerrar. Se for definido {} afetará somente o
                escopo interno.

                using (var sw = File.CreateText(path))
                {
                sw.WriteLine("Esta é a linha 1 do arquivo");
                sw.WriteLine("Esta é a linha 2 do arquivo");
                sw.WriteLine("Esta é a linha 3 do arquivo");
                }
            */

            //-------------------------------------------------------------------


            WriteLine("Digite o nome do arquivo:");
            var nome = ReadLine();

            nome = LimparNome(nome);

            var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");

            CriarArquivo(path);

            WriteLine("Digite enter para finalizar ...");
            ReadLine();
        }


        static string LimparNome(string nome)
        {
            foreach (var @char in Path.GetInvalidFileNameChars())
            //Precisa usar @ em palavras reservadas do .NET
            {
                nome = nome.Replace(@char, '-');
                //Percorre cada caracter e substitui os inválidos por -
            }
            return nome;
        }
        static void CriarArquivo(string path)
        {
            try
            {
                using var sw = File.CreateText(path);
                sw.WriteLine("Esta é a linha 1 do arquivo");
                sw.WriteLine("Esta é a linha 2 do arquivo");
                sw.WriteLine("Esta é a linha 3 do arquivo");
            }
            catch
            {
                WriteLine("O nome do arquivo está inválido!");
            }
        }




    }
}
