using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Creator.Logic
{
    public class PracticeCreator : CSVReader<Practice>
    {

        public PracticeCreator(string path, string[] delimiters) : base(path, delimiters)
        {

        }
        public override List<Practice> Items()
        {
            // creates an empty list of practices
            var listOfPractices = new List<Practice>();

            while (!TxtFieldParser.EndOfData)
            {
                // a single line of data from the file as string array
                var data = TxtFieldParser.ReadFields();

                // It tries to parse the id ddt to an int, to avoid to elaborate the header as a practice/item
                int idDDT = 0;
                try
                {
                    idDDT = Int32.Parse(data[0]);
                }
                catch (FormatException)
                {
                    // it its catched, it ignores the line
                }

                // If idDDT is correctly parsed, it checks if a practice is already in the listOfPractices with that idDDT
                if (listOfPractices.Any(p => p.DDTID == idDDT))
                {
                    // TODO: se contiene la pratica, non aggiungerla, ma creare solo l'oggetto che va aggiunto alla pratica esistente
                }
                else
                {
                    // TODO: se non esiste, ricavare la pratica già esistente, creare l'oggetto e aggiungerlo.

                }

            }
        }

        /// <summary>
        /// Creates a single practice from a line of data
        /// </summary>
        /// <param name="lineOfData"></param>
        /// <returns></returns>
        private Practice CreatePractice(string[] lineOfData)
        {
            var practice = new Practice
            (
                idDDT: lineOfData[0],
                clientName: lineOfData[6],
                documentReference: lineOfData[14],
                documentDate: lineOfData[15]
            ) ;

            return practice;
        }


        /// <summary>
        /// Creates a single Grid Item from a line of data
        /// </summary>
        /// <param name="lineOfData">Line from the file</param>
        /// <returns></returns>
        private GridItem CreateItem(string[] lineOfData)
        {
            var item = new GridItem
                (
                detailID: lineOfData[1],
                quantity: lineOfData[29],
                rd: lineOfData[3],
                mlfb: lineOfData[24],
                mlfb2: lineOfData[40],
                serialNumber: lineOfData[28],
                anomalyDescription: lineOfData[37],
                notes: lineOfData[34]
                );

            return item;
        }
    }
}
