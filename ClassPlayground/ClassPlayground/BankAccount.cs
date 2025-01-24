using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        public int accountNumber;
        public string holderName;
        public string currency ;
        public int balance;
        
        public BankAccount (string Name, string currency)
        {
            
            Random rnd = new Random();
            accountNumber = rnd.Next(100000000, 1000000000);
            holderName = Name;
            this.currency = currency;
            balance = 0;
            
            
        }
        
        public  int Deposit (int amount)
        {
            
            balance += amount;
            return balance;
        }
        public int GetBalance () 
        {
            Console.WriteLine("Na uctu je: " + balance);
            return balance;
        }
        public int MoneyAmount(int amount, string currency, string accountCurrency)
        {
            if (accountCurrency == "CZK")
            {
                int amountInCzk;
                if (currency == "EUR")
                {
                    amountInCzk = amount * 25;
                }
                else
                {
                    amountInCzk = amount;
                }
                return (amountInCzk);
            }
            else
            {
                int amountInEur;
                if (currency =="CZK")
                {
                    amountInEur = amount / 25;
                }
                else
                {
                    amountInEur= amount;
                }
                return (amountInEur);
            }
        }
        public int Withdraw (int amount, int balance) 
        {
            if(balance >= amount) 
            {
                balance = balance - amount;
            }
            else
            {
                Console.WriteLine("na ucte neni dostatek penez");
                
            }
            return balance;
        }
  /*    public int Transfer (int firstAccnountNumber, int secondAccnountNumber,int amount)
        {
          if (balance >= amount)
            {
                balance = balance - amount;
            }
            else
            {
                Console.WriteLine("na ucte neni dostatek penez");

            }
            return balance;
        }*/

        


    }
}
