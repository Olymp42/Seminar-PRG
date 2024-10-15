using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace RecursionPlayground
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // Nacteme cislo n, pro ktere budeme pocitat jeho faktorial a n-ty prvek Fibonacciho posloupnosti.
            int factorial = Factorial(n); // Prvni zavolani pro vypocet faktorialu, ulozeni do promenne factorial.
            int fibonacci = Fibonacci(n-2,1,1,1); // Prvni zavolani pro vypocet Fibonacciho posloupnosti, ulozeni do promenne fibonacci.
            Console.WriteLine($"Pro cislo {n} je faktorial {factorial} a {n}. prvek Fibonacciho posloupnosti je {fibonacci}"); // Vypsani vysledku uzivateli.
            Console.Read();

            
        } 

        static int Factorial(int n)
        {
            int result = 1;
            // TODO: Urci ukoncovaci podminku pro faktorial a zavolej Factorial zevnitr se spravnym parametrem / vypoctem.
            if (n > 0)
            {
                result = n * Factorial(n - 1);
            }
            return result; // TODO: Uprav, aby Factorial vracel spravnou hodnotu.
        }
        static int Fibonacci(int n,int result,int x, int y)
            
        {
           
            
                                                      // Console.WriteLine(result);
            if(n > 0)
            {
            
                x = y;
                y = result;      
                  
                                                             Console.WriteLine($"{n} a {y} a {x}");

                result = x + y;
                Console.WriteLine("r:" + result);
                result = Fibonacci(n-1,result,x,y);
                                                            //Console.WriteLine("ddddd");
                                                            
                Console.WriteLine(result +" ddd");

            }


            // TODO: Urci ukoncovaci podminku pro Fibonacciho a zavolej Fibonacci zevnitr se spravnym parametrem / vypoctem.
            return result; // TODO: Uprav, aby Fibonacci vracel spravnou hodnotu.
        }
    }
}

