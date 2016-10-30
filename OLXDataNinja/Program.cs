using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using OLXDataNinja.Models;

namespace OLXDataNinja
{
    class Program
    {
        static void Main( string[] args )
        {
            var trainingData = new List<TrainingDataModel>();
            var bagOfWords = new HashSet<string>();

            var timer = new Stopwatch();
            timer.Start();
            try
            {
                using (var reader = new StreamReader(Constants.TrainingData[0]))
                {
                    //while (!reader.EndOfStream)
                    for ( var i = 0; i < 1000; i++ )
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

            bagOfWords = Program.bagOfWords(trainingData);
            Console.WriteLine($"{trainingData.Count} announcements loaded in {timer.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        public static HashSet<string> bagOfWords(List<TrainingDataModel> trainingData)
        {
            var tempBag = new HashSet<string>();
            foreach ( var trainingDataModel in trainingData )
            {
                foreach ( var s in trainingDataModel.Title.Split(' ', '\\', '/', '-', '*', ',') )
                {
                    if(s.Length > 10)
                        Console.Write($"{s}\t");
                    if ( !tempBag.Contains(s) )
                        tempBag.Add(s);
                }
            }
            return tempBag;
        }
    }
}
