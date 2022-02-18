using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    /// <summary>
    /// Program class containing main
    /// </summary>
    class PatientRecordSystem
    {
        /// <summary>
        /// Main function, asks user for patient information to store to file
        /// Asks user for ID to search, and for minimum balance to search
        /// Displays those patients if found
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string newID = "\0",
                newName,
                fileName = "PatientRecords.txt";
            decimal newBalance;

            FileStream fs = File.Open(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);

            Console.WriteLine("Welcome!");

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the next patient's information, or \"-1\" to exit.");
                    Console.Write("ID: ");
                    newID = Console.ReadLine();

                    if (newID == "-1")
                    {
                        break;
                    }

                    Console.Write("Name: ");
                    newName = Console.ReadLine();
                    Console.Write("Balance owing: ");
                    newBalance = decimal.Parse(Console.ReadLine());

                    Patient newPatient = new Patient(newID, newName, newBalance);
                    streamWriter.WriteLine($"{newPatient.ID} {newPatient.Name} {newPatient.Balance}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Formatting error: {e.Message}");
                }
                catch (NegativeException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            streamWriter.Close();
            fs.Close();

            DisplayPatients.All(fileName);

            Console.Write("Press enter to continue.");
            Console.ReadLine();

            while (true) 
            {
                try
                {
                    Console.Clear();
                    Console.Write("Enter the ID of the patient you would like to search for, or \"-1\" to exit: ");
                    newID = Console.ReadLine();

                    if (newID == "-1")
                    {
                        break;
                    }

                    DisplayPatients.FindByID(newID, fileName);
                    Console.Write("Press enter to continue.");
                    Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Formatting error: {e.Message}");
                }
                catch (NegativeException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Enter the minimum balance you would like to display, or \"-1\" to exit");
                    newBalance = decimal.Parse(Console.ReadLine());

                    if (newBalance == -1M)
                    {
                        break;
                    }

                    DisplayPatients.MinBalance(newBalance, fileName);

                    Console.Write("Press enter to continue.");
                    Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Formatting error: {e.Message}");
                }
                catch (NegativeException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}
