using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using OLXDataNinja.Models;

namespace OLXDataNinja
{
    class Program
    {
        static void Main( string[] args )
        {
            var trainingData = new List<TrainingDataModel>();

            var timer = new Stopwatch();
            timer.Start();
            try
            {
                using (var reader = new StreamReader(Constants.TrainingData[0]))
                {
                    //reader.Delimiters = new[] {"\t"};
                    for (var i = 0; i < 1000; i++)
                    {
                        var readLine = reader.ReadLine();
                        if ( readLine != null )
                            trainingData.Add(TrainingDataParser.Parse(readLine.Split('\t')));
                    }
                }
            }
            catch (MalformedLineException ex)
            {
                Console.WriteLine($"Error on line {ex.LineNumber}: {ex.Data}");
            }
            finally
            {
                timer.Stop();
            }
            Console.WriteLine($"{trainingData.Count} announcements loaded in {timer.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
