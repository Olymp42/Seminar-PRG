using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
/*
* ZADANI
* Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
* 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
* 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
* 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
* 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
* 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
* 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
*    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
* 7) Vypis promennou result do konzole
* 
* Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
* 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
* 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
* 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
*       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
* 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
*/




internal class Program
{
    private static void Main(string[] args)
    {
        string firstNumberString  = string.Empty;
        float firstNumber = 0;
        string secondNumberString = string.Empty;
        float secondNumber =0;
        double result = 0;
        string operation = string.Empty;
        double firstNumberDouble;
        int test = 1;
        string x;
        string variableName =  string.Empty;
        string variableValueString = string.Empty;
        float variableValue =0;
        float power = 0;
        string powerString = string.Empty;

        Console.WriteLine("chces si definovat promenou? napis ano, ne");  //pojmenovani a pridani hodnty promenne
        x = Console.ReadLine();
        if (x == "ano")
        {
            Console.WriteLine("napis nazev promenne");
            variableName = Console.ReadLine();
            Console.WriteLine("napis hodnotu promenne");
            variableValueString = Console.ReadLine();
            variableValue = Convert.ToSingle(variableValueString);
            ;
        }
        while (test != 0) // test vstupu pro prvni cislo
        {
            Console.WriteLine("napis prvni cislo");
            try
            {
                firstNumberString = Console.ReadLine();               
                if (firstNumberString == variableName)
                {
                    firstNumber = variableValue;
                    test =0;
                } 
                else
                {
                    firstNumber = Convert.ToSingle(firstNumberString);
                    test = 1;
                }               
                
            }
            catch
            {
                Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                test = 2;
            }
            if (test != 2)
            {
                test = 0;
            }
        }
        test = 1;
        while (test != 0) //test vstupu pro operaci
        {
            Console.WriteLine("napis operaci: +,-,/,*, na druhou, odmocnit, sinus, na x-tou");

            operation = Console.ReadLine();
            if (operation == "+" || operation == "-" || operation == "/" || operation == "*" || operation == "na druhou" || operation == "odmocnit" || operation == "sinus" || operation == "na x-tou")
            {
                test = 0;
            }
            else
            {
                Console.WriteLine("nenapsal jsi sprvnou operaci, zkus to znovu");
            }
        }
        test = 1;

        switch (operation) // urcuje kterou operaci provede
        {
            case "+": // scitani
                while (test != 0)
                {
                    Console.WriteLine("napis druhe cislo");
                    try
                    {
                        secondNumberString = Console.ReadLine();
                        if (secondNumberString == variableName)
                {
                    secondNumber = variableValue;
                    test =0;
                } 
                else
                {
                    secondNumber = Convert.ToSingle(secondNumberString);
                    test = 1;
                }                      
                    }
                    catch
                    {
                        Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                        test = 2;
                    }
                    if (test != 2)
                    {
                        test = 0;
                    }
                }
                result = firstNumber + secondNumber;
                Console.WriteLine("vysledek je:" + result);
                break;
            case "-": // odcitani
                while (test != 0)
                {
                    Console.WriteLine("napis druhe cislo");
                    try
                    {
                        secondNumberString = Console.ReadLine();
                         if (secondNumberString == variableName)
                {
                    secondNumber = variableValue;
                    test =0;
                } 
                else
                {
                    secondNumber = Convert.ToSingle(secondNumberString);
                    test = 1;
                }                      
                    }
                    catch
                    {
                        Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                        test = 2;
                    }
                    if (test != 2)
                    {
                        test = 0;
                    }
                }
                result = firstNumber - secondNumber;
                Console.WriteLine("vysledek je:" + result);
                break;
            case "/": // deleni
                while (test != 0)
                {
                    Console.WriteLine("napis druhe cislo");
                    try
                    {
                        secondNumberString = Console.ReadLine();
                         if (secondNumberString == variableName)
                {
                    secondNumber = variableValue;
                    test =0;
                } 
                else
                {
                    secondNumber = Convert.ToSingle(secondNumberString);
                    test = 1;
                }                      
                    }
                    catch
                    {
                        Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                        test = 2;
                    }
                    if (test != 2)
                    {
                        test = 0;
                    }
                }
                result = firstNumber / secondNumber;
                Console.WriteLine("vysledek je:" + result);
                break;
            case "*": // nasobeni
                while (test != 0)
                {
                    Console.WriteLine("napis druhe cislo");
                    try
                    {
                        secondNumberString = Console.ReadLine();
                         if (secondNumberString == variableName)
                {
                    secondNumber = variableValue;
                    test =0;
                } 
                else
                {
                    secondNumber = Convert.ToSingle(secondNumberString);
                    test = 1;
                }                      
                    }
                    catch
                    {
                        Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                        test = 2;
                    }
                    if (test != 2)
                    {
                        test = 0;
                    }
                }
                result = firstNumber * secondNumber;
                Console.WriteLine("vysledek je:" + result);
                break;
            case "na druhou": // umocnovani na druhou
                result = firstNumber * firstNumber;
                Console.WriteLine("vysledek je:" + result);
                break;
            case "odmocnit": // odmocnovani
                firstNumberDouble = Convert.ToDouble(firstNumberString);
                result = Math.Sqrt(firstNumberDouble);
                Console.WriteLine("vysledek je:" + result);
                break;
            case "sinus": // vypocitani siusu
                result = Math.Sin(firstNumber);
                Console.WriteLine("vysledek je:" + result);
                break;
            case "na x-tou": // umocnovani na cokoliv
            while (test != 0)
                {
                    Console.WriteLine("napis na kolikatou chces prvni cislo");;
                    try
                    {
                        powerString = Console.ReadLine();
                         if (powerString == variableName)
                {
                    power = variableValue;
                    test =0;
                } 
                else
                {
                    power = Convert.ToSingle(powerString);
                    test = 1;
                }                
                    }
                    catch
                    {
                        Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                        test = 2;
                    }
                    if (test != 2)
                    {
                        test = 0;
                    }
                }
                result = Math.Pow(firstNumber,power);
                Console.WriteLine("vysledek je:" + result);
            break;
        }
        
        Console.Read(); //ReadKey mi nefungoval
    }
}


//Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
