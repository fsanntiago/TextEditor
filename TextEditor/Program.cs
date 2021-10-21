using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir texto");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("3 - Apagar arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    OpenFile();
                    break;
                case 2:
                    EditFile();
                    break;
                case 3:
                    DeleteFile();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }

        static void EditFile()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SaveFile(text);
        }

        static void SaveFile(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.Clear();
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

        static void DeleteFile()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do aquivo que deseja excluir?");
            string path = Console.ReadLine();
            string extension = Path.GetExtension(path);

            if (extension != ".txt")
            {
                Console.WriteLine("EROO");
                Console.ReadLine();
                Menu();
            }

            Console.WriteLine("Tem certeza?");
            Console.WriteLine("S - Sim");
            Console.WriteLine("N - Nao");
            char res = char.Parse(Console.ReadLine().ToUpper());

            if (res == 'N')
            {
                Console.WriteLine("Cancelado");
                Console.ReadLine();
                Menu();
            }

            File.Delete(path);
            Console.Clear();
            Console.WriteLine($"Arquivo {path} foi excluido com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
