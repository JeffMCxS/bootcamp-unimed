using System;
using System.IO;

namespace LerDiretorios
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\globo";
            //LerDiretorios(path);
            LerArquivos(path);

            Console.WriteLine("Digite [enter] para finalizar...");
            Console.ReadLine();
        }

        static void LerArquivos(string path)
        {
            var arquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            //O retorno é um array de string, nome completo de todos os arquivos.
            //Pode filtrar por extensão (*.doc, *.xls)
            //Em todos os diretórios

            foreach (var arquivo in arquivos)
            {
                var fileInfo = new FileInfo(arquivo);
                Console.WriteLine($"[Nome]: {fileInfo.Name}");
                Console.WriteLine($"[Tamanho]: {fileInfo.Length}");
                Console.WriteLine($"[Último acesso]: {fileInfo.LastAccessTime}");
                Console.WriteLine($"[Pasta]: {fileInfo.DirectoryName}");
                Console.WriteLine("------------------------");
            }
        }
        static void LerDiretorios(string path)
        {
            if (Directory.Exists(path)) //Verificação
            {
                var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                //É informado o diretório, um critério de busca (* = todos, p* = começa com p),
                //e o AllDirectories que é pegar pastas e subpastas. TopDirectoryOnly não inclui subpastas
                //O retorno é um array de string, path completo do diretório.

                foreach (var dir in diretorios)
                {
                    var dirInfo = new DirectoryInfo(dir);
                    Console.WriteLine($"[Nome]: {dirInfo.Name}");
                    Console.WriteLine($"[Raiz]: {dirInfo.Root}");

                    if (dirInfo.Parent != null) //Só irá acessar se não for nulo
                    {
                        Console.WriteLine($"[Pai]: {dirInfo.Parent.Name}");
                        //Parent é uma class, e DirectoryInfo é uma instancia de uma classe. Nem toda pasta terá um pai, então
                        //esse valor pode nulo. Então é preciso realizar uma verificação antes para evitar Excpetions
                    }

                    Console.WriteLine("---------------------");
                }
            }
            else
            {
                Console.WriteLine($"{path} não existe");

            }
        }


    }
}
