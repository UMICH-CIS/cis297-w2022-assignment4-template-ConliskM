using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// Patient class, verifies information format before storing
    /// </summary>
    class Patient
    {
        string _id;
        public string ID
        {
            get => _id;
            set
            {
                if (value.Length != 4)
                {
                    throw new FormatException("Patient ID must be 4 digits.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Patient ID must be all numerals.");
                    }
                }
                _id = value;
            }
        }
        public string Name { get; set; } 
        decimal _balance;
        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0M)
                {
                    throw new NegativeException("Balance cannot be negative.");
                }

                _balance = value;
            }
        }

        /// <summary>
        /// Constructor, initializes with provided values
        /// </summary>
        /// <param name="newID"></param>
        /// <param name="newName"></param>
        /// <param name="newBalance"></param>
        public Patient(string newID, string newName, decimal newBalance)
        {
            ID = newID;
            Name = newName;
            Balance = newBalance;
        }

        /// <summary>
        /// Updates balance if patient pays/owes more
        /// </summary>
        /// <param name="amountPaid">
        /// amountPaid should be negative to add to balance owed
        /// </param>
        public void UpdateBalance(decimal amountPaid)
        {
            Balance -= amountPaid;
        }
    }
}
