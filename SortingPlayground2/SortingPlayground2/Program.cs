using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace SortingPlayground
{
    internal class Program
    {
        //Pokud si nejsi jistý/á, co dělat, podívej se do prezentace, na videa na YT, co jsem doporučoval, googluj a nebo mě zavolej a já ti poradím.

        static int[] BubbleSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            for (int i = 0; i < sortedArray.Length; i++)
            {
                for ( int l = 0; l < sortedArray.Length-1; l++)
                {
                    if (sortedArray[l] > sortedArray[l + 1])
                    {
                     int x = sortedArray[l];
                     int y = sortedArray[l + 1];
                    sortedArray[l] = y;
                    sortedArray[l + 1] = x;
                    }
                }
            }
            return sortedArray;
        }

        static int[] SelectionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            for (int i = 0; i < sortedArray.Length-1; i++)
            {
                int minimum = i;
                for(int l = i+1; l < sortedArray.Length; l++)
                {
                    if(sortedArray[l] < sortedArray[minimum])
                    {
                        minimum = l;
                    }       
                }   
                if(minimum != i)
                    {
                        int x = sortedArray[minimum];
                        int y = sortedArray[i];
                        sortedArray[minimum] = y;
                        sortedArray[i] = x;
                    }         
            }
            return sortedArray;
        }

        static int[] InsertionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            for (int i = 1; i < sortedArray.Length;i++)
            {
                 int l = i;
                 while (l > 0 && sortedArray[l-1] > sortedArray[l])
                 {
                        int x = sortedArray[l-1];
                        int y = sortedArray[l];
                        sortedArray[l-1] = y;
                        sortedArray[l] = x;
                        l = l-1;    
                    
                 }
            }
            return sortedArray;
        }
        static int[] MergeSort(int[]arrayOne, int[]arrayTwo, int[]array)
        {
            
            int[] sortedArray = new int[array.Length];
                while(arrayOne.Length > 0 && arrayTwo.Length > 0)
                {
                    if(arrayOne[0]> arrayTwo[0])
                    {
                        sortedArray[sortedArray.Length-1] = arrayTwo[0]; /*na konec sortedArray pridam prvek na indexu 0 v arrayTwo*/
                        for(int i = 0; i < arrayTwo.Length-1; i++)   // smaze z arrayTwo element na indexu 0
                        {
                            arrayTwo[i] = arrayTwo[i+1];
                        }
                    }
                    else 
                    {
                        sortedArray[sortedArray.Length-1] = arrayOne[0]; /*na konec sortedArray pridam prvek na indexu 0 v arrayOne*/
                        for(int i = 0; i < arrayOne.Length-1; i++)   // smaze z arrayOne element na indexu 0
                        {
                            arrayOne[i] = arrayOne[i+1];
                        }
                    }
                    while (arrayOne.Length > 0 )
                    {
                        sortedArray[sortedArray.Length-1] = arrayOne[0]; /*na konec sortedArray pridam prvek na indexu 0 v arrayOne*/
                        for(int i = 0; i < arrayOne.Length-1; i++)   // smaze z arrayOne element na indexu 0
                        {
                            arrayOne[i] = arrayOne[i+1];
                        }
                    }
                    while(arrayTwo.Length > 0)
                    {
                       sortedArray[sortedArray.Length-1] = arrayTwo[0]; /*na konec sortedArray pridam prvek na indexu 0 v arrayTwo*/
                        for(int i = 0; i < arrayTwo.Length-1; i++)   // smaze z arrayTwo element na indexu 0
                        {
                            arrayTwo[i] = arrayTwo[i+1];
                        } 
                    }
                }
            return sortedArray;
        }
        static int[] Divide(int[] array)
        {
             int[] dividedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
                if(dividedArray.Length == 1 )
                {
                    return dividedArray;
                }
                int dividedArrayLenght = dividedArray.Length;       //rozdeli pole na pul
                int [] arrayOne = new int[dividedArrayLenght/2];
                for(int i =0; i < arrayOne.Length; i++)
                {               
                    arrayOne[i] = dividedArray[i];
                }
                int [] arrayTwo = new int[dividedArrayLenght/2];
                for(int i = dividedArrayLenght/2+1; i < 2*arrayTwo.Length; i++)
                {
                    arrayTwo[i] = dividedArray[i];
                }
                arrayOne = Divide( arrayOne);
                arrayTwo = Divide(arrayTwo);

             return MergeSort(arrayOne, arrayTwo,array);
        }
        //Naplní pole náhodnými čísly mezi 1 a velikostí pole.
        static void FillArray(int[] array)
        
        {
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, array.Length + 1);
            }
        }

        //Vypíše pole do konzole.
        static void WriteArrayToConsole(int[] array, string arrayName)
        {
            Console.Write(arrayName + " = [");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        //Zavolá postupně Bubble sort, Selection sort a Insertion sort pro zadané pole (a vypíše jeho jméno pro přehlednost)
        static void SortArray(int[] array, string arrayName, int[] dividedArray, int [] mergedArray)
        {
            Console.WriteLine($"Řadím {arrayName}:");
            int[] sortedArray;
            
            

            sortedArray = BubbleSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Bubble sortem");

            sortedArray = SelectionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Selection sortem");

            sortedArray = InsertionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Insertion sortem");

            sortedArray = MergeSort(array,dividedArray, mergedArray);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Merge sortem");


            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            
            int[] smallArray = new int[10];
            FillArray(smallArray);

            int[] mediumArray = new int[100];
            FillArray(mediumArray);

            int[] largeArray = new int[1000];
            FillArray(largeArray);

            WriteArrayToConsole(smallArray, "Malé pole");
            SortArray(smallArray, "Malé pole",mediumArray,mediumArray);

            WriteArrayToConsole(mediumArray, "Střední pole");
            SortArray(mediumArray, "Střední pole",mediumArray,mediumArray);

            //WriteArrayToConsole(largeArray, "Velké pole");
            //SortArray(largeArray, "Velké pole");

            Console.Read();
        }
    }
}