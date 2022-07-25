using System;
using System.IO;

namespace Directory_And_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarDiretoriosGlobo();
            CriarArquivo();

            var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            var destino = Path.Combine(Environment.CurrentDirectory,
                                                    "globo",
                                                    "América do Sul",
                                                    "Brasil",
                                                    "brasil.txt");
            //Organizado assim apenas para fins estéticos
            //Se o nome do arquivo acima for informado diferente, ele será renomeado ao mover/copiar
            MoverArquivo(origem, destino);
            CopiarArquivo(origem, destino);
        }


        static void CopiarArquivo(string pathOrigem, string pathDestino)
        {
            if (!File.Exists(pathOrigem)) //Verificando se arquivo de origem existe
            {
                Console.WriteLine("Arquivo de origem não existe");
                return;
            }

            if (File.Exists(pathOrigem)) //Verificando se o arquivo já existe na pasta de destino
            {
                Console.WriteLine("Arquivo já existe na pasta de destino");
                return;

                File.Copy(pathOrigem, pathDestino);
            }
        }

        static void MoverArquivo(string pathOrigem, string pathDestino)
        {
            if (!File.Exists(pathOrigem)) //Verificando se arquivo de origem existe
            {
                Console.WriteLine("Arquivo de origem não existe");
                return;
            }

            if (File.Exists(pathOrigem)) //Verificando se o arquivo já existe na pasta de destino
            {
                Console.WriteLine("Arquivo já existe na pasta de destino");
                return;
            }

            File.Move(pathOrigem, pathDestino);
        }

        static void CriarArquivo()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            if (!File.Exists(path)) //Verificar se já existe antes de criar o arquivo
            {
                using var sw = File.CreateText(path);
                sw.WriteLine("População: 213MM");
                sw.WriteLine("IDH: 0,901");
                sw.WriteLine("Dados atualizados em: 20/04/2018");
            }
        }

        static void CriarDiretoriosGlobo()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "globo");
            if (!Directory.Exists(path)) //Verificar se já existe antes de criar os diretórios
            {
                var dirGlobo = Directory.CreateDirectory(path); //Criar diretório (pasta)
                                                                // Ao utiliar var, automaticamente é retornado um DirectoryInfo que será armazenado em dirGlobo
                                                                // Através disso é possível trabalhar com subdiretórios

                var dirAmNorte = dirGlobo.CreateSubdirectory("América do Norte");
                var dirAmCentral = dirGlobo.CreateSubdirectory("América Central");
                var dirAmSul = dirGlobo.CreateSubdirectory("América do Sul");

                dirAmNorte.CreateSubdirectory("USA");
                dirAmNorte.CreateSubdirectory("México");
                dirAmNorte.CreateSubdirectory("Canada");

                dirAmCentral.CreateSubdirectory("Costa Rica");
                dirAmCentral.CreateSubdirectory("Panamá");

                dirAmSul.CreateSubdirectory("Brasil");
                dirAmSul.CreateSubdirectory("Argentina");
                dirAmSul.CreateSubdirectory("Paraguai");
            }
        }


    }
}
