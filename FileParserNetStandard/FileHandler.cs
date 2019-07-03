using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            List<string> lines = new List<string>();

            try
            {   // Open the text file using a stream reader.
                using (var sr = new StreamReader(filePath))

                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {

            using (TextWriter tw = new StreamWriter(filePath))
            {
                foreach (var row in rows)
                {
                    var csv = string.Join(delimeter.ToString(), row);
                    tw.WriteLine(csv);
       
                }
                tw.Close();
            }
            
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {
            List<List<string>> parsed = new List<List<string>>();

            foreach (var row in data)
            {
                var newRow = new List<string>();
                var split = row.Split(delimeter);
                foreach (var item in split)
                { 
                    newRow.Add(item);
                }
                parsed.Add(newRow);
            }

            return parsed;

        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> parsed = new List<List<string>>();

            foreach (var row in data)
            {
                var newRow = new List<string>();
                var split = row.Split(',');
                foreach (var item in split)
                {
                    newRow.Add(item);
                }
                parsed.Add(newRow);
            }

            return parsed;
        }
    }
}