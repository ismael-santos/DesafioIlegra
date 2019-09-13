using Injection;
using Interface.Injection;
using System.Collections.Generic;
using System.IO;
using Utils;
using System.Linq;
using System.Text;

namespace Application
{
    /// <summary>
    /// Classe de leitura, criação dos diretórios e arquivos
    /// O arquivo de leitura deve estar no formato Codificação UTF-8 para aceitar caracteres especiais como o "ç"
    /// </summary>
    public class SalesDirectoryFile
    {
        public SalesDirectoryFile()
        {
            CreatDirectotyIfNotExists();
            CreateLog();
        }

        private void CreateLog()
        {
            IServiceSales sales = SalesInjection.Instance;
            sales.SetTypeOfData(GetAllLines());

            File.WriteAllText(DirectoryPath.OUT_AND_FILE, sales.GetSalesReport(), Encoding.UTF8);
        }

        private List<string> GetAllLines()
        {
            List<string> allLines = new List<string>();

            GetAllFiles().ForEach(file =>
            {
                //Permite que o arquivo seja aberto editado e salvo
                using (var fileStream = new FileStream(DirectoryPath.IN_CUSTOM(file), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        List<string> streamLine = new List<string>();
                        while (!streamReader.EndOfStream)
                        {
                            streamLine.Add(streamReader.ReadLine());
                        }
                        allLines.AddRange(streamLine);
                    }
                }
            });

            return allLines;
        }

        private List<string> GetAllFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath.IN);

            return dir.GetFiles().Select(file => file.Name).ToList();
        }

        private void CreatDirectotyIfNotExists()
        {
            bool existsIN = Directory.Exists(DirectoryPath.IN);
            bool existsOUT = Directory.Exists(DirectoryPath.OUT);

            if (!existsIN)
                Directory.CreateDirectory(DirectoryPath.IN);

            if (!existsOUT)
                Directory.CreateDirectory(DirectoryPath.OUT);
        }
    }
}
