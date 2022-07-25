using System;
using System.IO;

namespace FileSystemWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Monitora as alterações feita nos arquivos 
            Execute a aplicação e efetue as alterações pelo Explorer do Windows,
            a aplicação informará cada alteração feita via terminal */

            var path = @"c:\temp\globo";
            using var fsw = new FileSystemWatcher(path);
            fsw.Created += OnCreated;
            fsw.Created += OnDeleted;
            fsw.Created += OnRenamed;

            fsw.EnableRaisingEvents = true; //Dizer que quer que os eventos sejam disparados
            fsw.IncludeSubdirectories = true; //Incluir subdiretorios nas alterações

            Console.WriteLine($"Monitorando eventos na pasta {path}");
            Console.WriteLine("Pressione [enter] para finalizar...");
            Console.ReadLine();

            void OnCreated(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine($"Foi criado o arquivo {e.Name}");
            }

            void OnDeleted(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine($"Foi excluído o arquivo {e.Name}");
            }

            Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
            {
                throw new NotImplementedException();
            }

        }
    }
}
