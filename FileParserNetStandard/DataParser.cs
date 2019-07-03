using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            List<List<string>> newList = new List<List<string>>();

            foreach (var row in data)
            {
                var newRow = new List<string>();
                foreach (string item in row)
                {
                    newRow.Add(item.Trim());
                }
                newList.Add(newRow);
            }
            return newList;
    }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {

            return data;
        }

    }
}