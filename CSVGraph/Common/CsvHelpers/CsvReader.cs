using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.CsvHelpers
{
    public class CsvReader
    {
        /// <summary>
        /// Reads a CSV file from a Stream into a list of strings
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static IEnumerable<string[]> ReadCsv(Stream stream)
        {
            char[] separator = new[] { ',' };
            string currentLine;

            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
            {
                while ((currentLine = reader.ReadLine()) != null)
                {
                    yield return currentLine.Split(separator, StringSplitOptions.None);
                }
            }
        }
    }
}
