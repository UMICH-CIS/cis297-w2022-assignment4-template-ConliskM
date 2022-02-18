using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    /// <summary>
    /// Class for displaying patients with three options:
    /// Display all, Display patient by ID, Display patients with minimum balance
    /// </summary>
    class DisplayPatients
    {
        /// <summary>
        /// Prints all patients records to the console
        /// </summary>
        /// <param name="fileName">
        /// File name to read patients from
        /// </param>
        public static void All(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();

                if (line != null)
                {
                    Console.WriteLine("All Patient Records:");
                    Console.WriteLine($"\t{line}");
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"\t{line}");
                    }
                }      
                else
                {
                    Console.WriteLine("There are currently no patient records stored.");
                }
            }
        }

        /// <summary>
        /// Displays patient with given ID, or an error message that the patient was not found
        /// </summary>
        /// <param name="findID">
        /// ID of patient being searched for
        /// </param>
        /// <param name="fileName">
        /// File name to read patients from
        /// </param>
        public static void FindByID(string findID, string fileName)
        {
            if (findID.Length != 4)
            {
                throw new FormatException("Patient ID must be 4 digits.");
            }
            for (int i = 0; i < findID.Length; i++)
            {
                if (!char.IsDigit(findID[i]))
                {
                    throw new FormatException("Patient ID must be all numerals.");
                } 
            }

            string line,
                currID;
            bool found = false;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    currID = line.Substring(0, 4);
                    if (currID == findID)
                    {
                        Console.WriteLine($"Patient {findID} found:");
                        Console.WriteLine($"\t{line}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"Patient {findID} not found.");
            }
        }

        /// <summary>
        /// Finds and displays all patients with balance greater than or equal to minBalance
        /// </summary>
        /// <param name="minBalance">
        /// Minimum balance to display patient
        /// </param>
        /// <param name="fileName">
        /// Name of file to search in
        /// </param>
        public static void MinBalance(decimal minBalance, string fileName)
        {
            if (minBalance < 0M)
            {
                throw new NegativeException("Balance cannot be negative.");
            }

            string line;
            int balanceIndex;
            decimal currBalance;
            bool found = false;
            using (StreamReader sr = new StreamReader(fileName))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    balanceIndex = line.LastIndexOf(' ');
                    currBalance = Decimal.Parse(line.Substring(balanceIndex));
                    if (minBalance <= currBalance)
                    {
                        Console.WriteLine($"\t{line}");
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"No patients found with minimum balance {minBalance}.");
                }
            }
        }
    }
}
