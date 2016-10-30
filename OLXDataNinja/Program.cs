using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using OLXDataNinja.Models;

namespace OLXDataNinja
{
    class Program
    {
        static void Main( string[] args )
        {
            var trainingData = new List<TrainingDataModel>();

            try
            {
                using (var reader = new TextFieldParser(Constants.TrainingData[0]))
                {
                    reader.Delimiters = new[] {"\t"};
                    for (var i = 0; i < 1000; i++)
                    {
                        trainingData.Add(TrainingDataParser.Parse(reader?.ReadLine().Split('\t')));
                    }
                }
            }
            catch (MalformedLineException ex)
            {
                Console.WriteLine($"Error on line {ex.LineNumber}: {ex.Data}");
            }
            Console.WriteLine($"{trainingData.Count} announcements loaded");
            Console.ReadKey();
        }
    }
}
