using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Creator.Logic
{
    class Practice
    {

        #region Header variables
        // ID of the DDT in grid as practice
        public int DDTID { get; set; }

        // Client name
        public string Client { get; set; }

        // Delivery note reference - number
        public string DDTReference { get; set; }

        // DDT date creation
        public DateTime DDTDate { get; set; }

        // A list of RD present
        public List<string> RDs { get; set; }
        #endregion

        #region Default constructor
        public Practice(string idDDT, string clientName, string documentReference, string documentDate)
        {
            DDTID = Int32.Parse(idDDT);
            Client = clientName;
            DDTReference = documentReference;
            DDTDate = DateTime.Parse(documentDate);
        }
        #endregion
    }
}
