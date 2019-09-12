using System;
using System.IO;
using Utils;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateLog();
            WatcherDirectory();

            Console.Read();
        }

        private static void WatcherDirectory()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(DirectoryPath.IN);

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            // Caso algum arquivo no diretório seja modificado, criado, deletado ou renomedo
            // O evento é disparado para monitorar os arquivos
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            CreateLog();
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            CreateLog();
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            CreateLog();
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            CreateLog();
        }

        private static void CreateLog()
        {
            new SalesDirectoryFile();
        }
    }
}
