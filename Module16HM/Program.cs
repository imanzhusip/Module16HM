using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module16HM
{
    using System;
    using System.IO;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в файловый менеджер!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Просмотр содержимого директории");
                Console.WriteLine("2. Создание файла/директории");
                Console.WriteLine("3. Удаление файла/директории");
                Console.WriteLine("4. Копирование файла/директории");
                Console.WriteLine("5. Перемещение файла/директории");
                Console.WriteLine("6. Чтение из файла");
                Console.WriteLine("7. Запись в файл");
                Console.WriteLine("8. Показать лог операций");
                Console.WriteLine("9. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayDirectoryContents();
                        break;
                    case "2":
                        CreateFileOrDirectory();
                        break;
                    case "3":
                        DeleteFileOrDirectory();
                        break;
                    case "4":
                        CopyFileOrDirectory();
                        break;
                    case "5":
                        MoveFileOrDirectory();
                        break;
                    case "6":
                        ReadFromFile();
                        break;
                    case "7":
                        WriteToFile();
                        break;
                    case "8":
                        ShowLog();
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        static void DisplayDirectoryContents()
        {
            Console.WriteLine("Введите путь к директории:");
            string path = Console.ReadLine();

            try
            {
                string[] files = Directory.GetFiles(path);
                string[] directories = Directory.GetDirectories(path);

                Console.WriteLine("\nФайлы:");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                Console.WriteLine("\nДиректории:");
                foreach (string directory in directories)
                {
                    Console.WriteLine(Path.GetFileName(directory));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void CreateFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (файл - F, директория - D):");
            string typeChoice = Console.ReadLine();

            Console.WriteLine("Введите путь и имя:");
            string path = Console.ReadLine();

            try
            {
                if (typeChoice.ToLower() == "f")
                {
                    File.Create(path).Close();
                    Console.WriteLine("Файл создан успешно.");
                }
                else if (typeChoice.ToLower() == "d")
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Директория создана успешно.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (файл - F, директория - D):");
            string typeChoice = Console.ReadLine();

            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();

            try
            {
                if (typeChoice.ToLower() == "f")
                {
                    File.Delete(path);
                    Console.WriteLine("Файл удален успешно.");
                }
                else if (typeChoice.ToLower() == "d")
                {
                    Directory.Delete(path, true);
                    Console.WriteLine("Директория удалена успешно.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void CopyFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (файл - F, директория - D):");
            string typeChoice = Console.ReadLine();

            Console.WriteLine("Введите путь и имя исходного файла/директории:");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Введите путь и имя целевого файла/директории:");
            string destinationPath = Console.ReadLine();

            try
            {
                if (typeChoice.ToLower() == "f")
                {
                    File.Copy(sourcePath, destinationPath, true);
                    Console.WriteLine("Файл скопирован успешно.");
                }
                else if (typeChoice.ToLower() == "d")
                {
                    CopyDirectory(sourcePath, destinationPath);
                    Console.WriteLine("Директория скопирована успешно.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void MoveFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (файл - F, директория - D):");
            string typeChoice = Console.ReadLine();

            Console.WriteLine("Введите путь и имя исходного файла/директории:");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Введите путь и имя целевого файла/директории:");
            string destinationPath = Console.ReadLine();

            try
            {
                if (typeChoice.ToLower() == "f")
                {
                    File.Move(sourcePath, destinationPath);
                    Console.WriteLine("Файл перемещен успешно.");
                }
                else if (typeChoice.ToLower() == "d")
                {
                    Directory.Move(sourcePath, destinationPath);
                    Console.WriteLine("Директория перемещена успешно.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ReadFromFile()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"Содержимое файла:\n{content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void WriteToFile()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Введите текст для записи:");
            string content = Console.ReadLine();

            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("Текст записан в файл успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowLog()
        {
            try
            {
                string logFilePath = "log.txt";
                if (File.Exists(logFilePath))
                {
                    string logContent = File.ReadAllText(logFilePath);
                    Console.WriteLine($"Лог операций:\n{logContent}");
                }
                else
                {
                    Console.WriteLine("Лог операций не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void CopyDirectory(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationPath, fileName);
                File.Copy(file, destFile, true);
            }

            string[] dirs = Directory.GetDirectories(sourcePath);
            foreach (string dir in dirs)
            {
                string dirName = Path.GetFileName(dir);
                string destDir = Path.Combine(destinationPath, dirName);
                CopyDirectory(dir, destDir);
            }
        }
    }

}
