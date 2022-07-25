using System;
using System.IO;

namespace StringWriters
{
    class Program
    {
        static void Main(string[] args)
        {
            string textReaderText = "TextReader é a classe base abstrata " +
                                    "de StreamReader e StringReader, que lê caracteres " +
                                    "de streams e strings, respectivamente.\n\n" +

                                    "Crie uma instância de TextReader para abrir um arquivo de texto " +
                                    "para ler um intervalo especificado de caracteres " +
                                    "ou para criar um leitor baseado em um fluxo existente.\n\n" +

                                    "Você também pode usar uma instância de TextReader para ler " +
                                    "texto de um armazenamento de suporte personalizado usando as mesmas " +
                                    "APIs que você usaria para uma string ou um fluxo.\n\n";

            Console.WriteLine($"Texto original: {textReaderText}");

            string linha, paragrafo = null;
            var sr = new StringReader(textReaderText);

            while (true) // While True gera um looping infinito
            {
                linha = sr.ReadLine(); //Lendo um parágrafo
                if (linha != null)
                {
                    paragrafo += linha + " "; //Se a leitura for bem sucedida, acumule a linha lida no parágrafo mais um espaço
                }
                else
                {
                    paragrafo += '\n'; //Se for nulo, não houver nada, quebre uma linha
                    break; //E então finaliza o loop infinito
                }
            }

            Console.WriteLine($"Texto modificado: {paragrafo}");
            int caractereLido;
            char caracterConvertido;
            //StreamReader.Read faz a leitura dos caracteres com base nos códigos decimais da tabela ASCII,
            //então é preciso realizar a conversão dos códigos

            var sw = new StringWriter();
            sr = new StringReader(paragrafo);


            while (true)
            {
                caractereLido = sr.Read();
                if (caractereLido == -1) //Se der -1 não faz parte da tabela ASCII, ou seja, a string já foi lida completamente
                {
                    break;
                }
                //if (caractereLido = -1) break; //Alternativa de escrita

                caracterConvertido = Convert.ToChar(caractereLido); //Converte o código decimal para caracter

                if (caracterConvertido == '.')
                {
                    sw.Write("\n\n"); //Inserindo novamente as quebras de linhas após os pontos finais (.)

                    sr.Read();
                    sr.Read();
                }
                else
                {
                    sw.Write(caracterConvertido);
                }

                //Console.WriteLine($"Texto armazenado no StringWriter: {sw.ToString()}");
            }
            Console.WriteLine($"Texto armazenado no StringWriter: {sw.ToString()}");
            Console.WriteLine("\n\nDigite [enter] para finalizar...");
            Console.ReadLine();
        }
    }
}
