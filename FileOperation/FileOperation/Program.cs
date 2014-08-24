using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperation
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter filepath to read from");
            var inputFile = Console.ReadLine();
            var inputFileName = string.IsNullOrWhiteSpace(inputFile) ? @"C:\users\vshardul\desktop\testRunEntries.txt" : inputFile;

            Console.WriteLine("Enter output filepath");
            var outputFile = Console.ReadLine();
            var outputFileName = string.IsNullOrWhiteSpace(outputFile) ? @"Output.txt" : outputFile;

            Console.WriteLine("Entries to ignore - ");
            var entriesToIgnore = long.Parse(Console.ReadLine());

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Invalid input file path");
                return;
            }

            using (var inputStream = new StreamReader(inputFileName))
            {
                if (inputStream.Peek() < 0)
                {
                    Console.WriteLine("Enpty Stream");
                    return;
                }

                var headerRow = inputStream.ReadLine();
                
                int ignoreCount = 0;
                while (ignoreCount < entriesToIgnore && inputStream.Peek() >= 0)
                {
                    inputStream.ReadLine();
                    ignoreCount++;
                }

                using (var outputStream = new StreamWriter(outputFileName))
                {
                    outputStream.WriteLine(headerRow);
                    while (inputStream.Peek() >= 0)
                    {
                        var line = inputStream.ReadLine();
                        if (line != null && line.Split('\t').Length == headerRow.Split('\t').Length)
                        {
                            outputStream.WriteLine(line);
                        }
                    }

                    outputStream.Close();
                }

                inputStream.Close();
            }

            Console.WriteLine("File content trnafer successfull");
        }

        }
    }
