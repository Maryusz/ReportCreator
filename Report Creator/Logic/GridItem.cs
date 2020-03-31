using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Creator.Logic
{

    /// <summary>
    /// Represents a GridItem
    /// </summary>
    public class GridItem
    {
        #region Private Members

        // Represents the MLFB backing member
        private string m_mlfb;

        #endregion

        #region Public Members
        public int DetailID { get; set; }
        public int Quantity { get; set; }
        public string MLFB 
        {
            get
            {
                return m_mlfb;
            }

            set
            {
                if (value == "IT2:NUOVA ANAGRAFIC")
                    m_mlfb = "ANAGRAFICA NON SIEMENS";
                else
                    m_mlfb = value;
            }
        }
        public string SerialNumber { get; set; }
        public string AnomalyDescription { get; set; }
        public string Notes { get; set; }

        public string RD { get; set; }
        #endregion

        #region Default Constructor
        public GridItem(string detailID, string quantity, string rd, string mlfb, string mlfb2, string serialNumber, string anomalyDescription, string notes)
        {
            DetailID = Int32.Parse(detailID);
            Quantity = Int32.Parse(quantity);
            RD = rd;
            MLFB = mlfb;
            MLFB = mlfb2;
            SerialNumber = serialNumber;
            AnomalyDescription = anomalyDescription;
            Notes = notes;

        }
        #endregion

    }
}
