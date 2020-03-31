using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Creator.Logic
{
    public class PracticeCreator : CSVReader<Practice>
    {
        #region Private Variables
        List<Practice> listOfPractices = new List<Practice>();
        #endregion

        #region Default Constructor
        public PracticeCreator(string path, string[] delimiters) : base(path, delimiters)
        {

        }
        #endregion

        #region Public methods
        public override List<Practice> Items()
        {
            // creates an empty list of practices
            

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
                    continue;
                }

                // If idDDT is correctly parsed, it checks if a practice is already in the listOfPractices with that idDDT
                if (listOfPractices.Any(p => p.DDTID == idDDT))
                {
                    // If the practice is present, it adds the item to the practice.
                    var practice = listOfPractices.Find(p => p.DDTID == idDDT);
                    practice.AddItem(CreateItem(data));
                }
                else
                {
                    // If the practice doesn't exist it creates it with the line of data received
                    var practice = CreatePractice(data);

                    // with the same line as before, it creates a line containing the ITEM data
                    practice.AddItem(CreateItem(data));

                    listOfPractices.Add(practice);

                }

            }

            return listOfPractices;
        }


        /// <summary>
        /// Returns a practice number by IDDDT, if its not present it throws ArgumentException
        /// </summary>
        /// <param name="practiceNumber">Number of the practice to be returned</param>
        /// <returns></returns>
        public Practice GetPractice(int practiceNumber)
        {
            var practice = listOfPractices.Find(p => p.DDTID == practiceNumber);

            if (practice == null) throw 
                    new ArgumentException();
            else
                return practice;
        }

        #endregion

        #region Private methods
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
        #endregion


    }
}
