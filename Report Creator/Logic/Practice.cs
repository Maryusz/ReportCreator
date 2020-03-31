using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Creator.Logic
{
    public class Practice
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

        // A set of RD present
        private HashSet<string> RDs = new HashSet<string>();

        // List of the received items
        private List<GridItem> Items = new List<GridItem>();
        #endregion

        #region Default constructor
        public Practice(string idDDT, string clientName, string documentReference, string documentDate)
        {
            // idDDT its always number
            DDTID = Int32.Parse(idDDT);
            Client = clientName;
            DDTReference = documentReference;
            DDTDate = DateTime.Parse(documentDate);
        }
        #endregion

        /// <summary>
        /// Add an Grid Item to the practice, and adds the RD present inside it.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(GridItem item)
        {
            Items.Add(item);
            RDs.Add(item.RD);
        }

        public int ItemCount()
        {
            return Items.Count;
        }


    }
}
