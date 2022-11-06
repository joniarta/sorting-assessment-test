using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment.Sorter.ConsoleApp
{
    class Program
    {
        private static int _commandLevel = 0;
        private static List<FileInfo> _fileTochoose = new List<FileInfo>();

        static void Main(string[] args)
        {
            var alive = true;

            ShowStartMenu();

            while (alive)
            {
                var action = ShowActionInput();

                switch (_commandLevel)
                {
                    case 1:
                        switch (action)
                        {
                            case 0:
                                _commandLevel = 0;

                                ShowStartMenu();
                                break;

                            default:
                                SortAndSaveOnFile(action);

                                Console.WriteLine("Please choose another file or go back to start menu.");
                                break;
                        }
                        break;

                    default:
                        switch (action)
                        {
                            case 3:
                                alive = false;
                                break;
                            default:
                                _commandLevel = 1;

                                ShowUnsortedFiles();
                                break;
                        }
                        break;
                }
            }

            ShowExit();
        }

        static void ShowStartMenu()
        {
            Console.Clear();

            Console.WriteLine("==========++++ Assessment Sorter Console ++++========== ");
            Console.WriteLine("");

            Console.WriteLine("1. Show file in unsorted directory");
            Console.WriteLine("2. Reload unsorted directory");
            Console.WriteLine("3. Exit");
            Console.WriteLine("");
            Console.WriteLine("==========++++ ------------------------- ++++========== ");
        }

        static void ShowUnsortedFiles()
        {
            Console.Clear();

            Console.WriteLine("==========++++ Assessment Sorter Console ++++========== ");
            Console.WriteLine("");

            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Unsorted");

            var directoryInfo = new DirectoryInfo(pathFolder);

            _fileTochoose.Clear();
            _fileTochoose.AddRange(directoryInfo.GetFiles());

            Console.WriteLine("File(s) to sort: ");
            Console.WriteLine("-------------------------------------");
            
            for (int i = 0; i < _fileTochoose.Count; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), _fileTochoose[i].Name);
            }

            Console.WriteLine("");
            Console.WriteLine("0. Back to start menu");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------"); 
            Console.WriteLine("");
            Console.WriteLine("==========++++ ------------------------- ++++========== ");
        }

        static void ShowExit()
        {
            Console.Clear();
            Console.WriteLine("Thank You!!! @};--");
            Console.ReadKey();
        }

        static int ShowActionInput()
        {
            var action = -1; 

            Console.Write("Please choose the action: ");

            while (true)
            {
                var input = Console.ReadLine();

                var valid = int.TryParse(input, out action);
                
                if (valid)
                {
                    switch (_commandLevel)
                    {
                        case 1:
                            if (_fileTochoose.Count == 0)
                            {
                                valid = action == 0;
                            } 
                            else
                            {
                                valid = (action >= 0 && action <= _fileTochoose.Count);
                            }
                            
                            break;

                        default:
                            valid = (action >= 1 && action <= 3);
                            break;
                    }
                }

                if (!valid) 
                {
                    Console.WriteLine("Invalid action!");
                    Console.Write("Please choose the action: ");
                }
                else
                {
                    break;
                }
            }

            return action;
        }

        static void SortAndSaveOnFile(int action)
        {
            FileInfo file = _fileTochoose[action - 1];

            if (File.Exists(file.FullName))
            {
                var list = PersonNameList.LoadFromFile(file.FullName);
                list.Sort();

                var destinationFile = Path.Combine(Directory.GetCurrentDirectory(), 
                    "Files", "Sorted", 
                    file.Name.Contains("unsorted") ? 
                        file.Name.Replace("unsorted", "sorted") 
                        : string.Format("sorted-{0}", file.Name));

                list.SaveToFile(destinationFile);

                Console.WriteLine("");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Sorted Names: ");
                Console.WriteLine("-------------------------------------");

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", (i + 1), list[i].Fullname);
                }

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Eror: File does not exist!");
            }            
        }
    }
}
