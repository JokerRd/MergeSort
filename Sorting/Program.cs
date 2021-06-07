using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу в json формате:");
            var pathToJson = Console.ReadLine();
            Console.WriteLine("Введите путь для сохранения файла с результатами:");
            var pathToSaveFile = Console.ReadLine();
            var file = new StreamReader(pathToJson ?? string.Empty);
            var json = file.ReadToEnd();
            var jObject = JObject.Parse(json);
            var results = jObject["experiments"]?.Children().ToList();
            var experimentModels = results!
                .Select(item => item.ToObject<ExperimentModel>())
                .ToList();
            var resultsSorted = new Dictionary<long, long>();
            foreach (var experimentModel in experimentModels)
            {
                var generator = new GeneratorArrays(experimentModel.LengthArray,
                    experimentModel.LengthStrInArray);
                var experimentsArrays = generator.GenerateArray();
                var allCountOperation = new Sorter(experimentsArrays).Sorted();
                resultsSorted.Add(experimentModel.LengthArray, allCountOperation);
            }

            var builder = new StringBuilder();
            foreach (var (lengthArray, countOperation) in resultsSorted)
            {
                builder.Append(lengthArray + " " + countOperation + "\n");
            }

            var writer = new StreamWriter(pathToSaveFile!, 
                false, Encoding.Default);
            Console.WriteLine("Результаты сортировки:");
            Console.WriteLine(builder.ToString());
            writer.Write(builder.ToString());
            /*
            var generator = new GeneratorArrays(1000,
                10,
                1);
            var experimentsArrays = generator.GenerateArrays();
            var sorter = new Sorter(experimentsArrays[0]);
            var result = sorter.Sorted();
            sorter.PrintArray();
            Console.WriteLine(result)*/;
        }
    }
}