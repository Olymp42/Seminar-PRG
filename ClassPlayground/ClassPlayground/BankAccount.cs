using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        private int accountNumber;
        private string holderName;
        private string currency ;
        private int balance;
        
        public BankAccount (string Name, string currency, int Number)
        {
            holderName = Name;
            this.currency = currency;
            accountNumber = Number;
            
        }
        
        public  int Deposit (int amount, int currency)
        {
            
            balance += amount;
            return balance;
        }
        public int GetBalance () 
        {
            Console.WriteLine("Na uctu je: " + balance);
            return balance;
        }
        public (int amount, string currency) MoneyAmount()
        {
            Console.WriteLine("Kolik penez");
            int amount;
            string stringAmount = Console.ReadLine();
            try
            {
                amount = |Convert.ToInt32(stringAmount);
            }
            amount = 

            Console.WriteLine("jaka mena");
            string currency = Console.ReadLine();
            return (amount, currency);


        }
        public int Convert(int amount, string currency) 
        {
            int finalAmount;
            switch (currency) 
            {
                case "CZK":
                    finalAmount = amount;
                case "EUR":
                    finalAmount = amount * 25;
                break;
                    
            }
        }


    }
}
