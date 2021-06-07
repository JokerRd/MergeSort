using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class GeneratorArrays
    {
        private readonly long lengthArray;

        private readonly long lengthStrInArray;

        private const string GenerateStr = "qwertyuiopasdfghjklzxcvbnm";


        public GeneratorArrays(long lengthArray, long lengthStrInArray)
        {
            this.lengthArray = lengthArray;
            this.lengthStrInArray = lengthStrInArray;
        }

        public string[] GenerateArray()
        {
            var random = new Random();
            var result = new string[lengthArray];
            for (var i = 0; i < lengthArray; i++)
            {
                var builder = new StringBuilder();
                for (var j = 0; j < lengthStrInArray; j++)
                {
                    builder.Append(GenerateStr[random.Next(0, GenerateStr.Length - 1)]);
                }
                result[i] = builder.ToString();
            }
            return result;
        }

    }
}