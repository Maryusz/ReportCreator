using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Report_Creator.Logic
{

    public abstract class CSVReader<T>
    {

        public TextFieldParser TxtFieldParser { get; private set; }

        public CSVReader(string path, string [] delimiters)
        {
            TxtFieldParser = new TextFieldParser(path);
            TxtFieldParser.Delimiters = delimiters;
            TxtFieldParser.TrimWhiteSpace = true;
            TxtFieldParser.HasFieldsEnclosedInQuotes = true;
        }

        public abstract List<T> Items();
    }
}
