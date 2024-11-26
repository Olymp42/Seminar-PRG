using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program

    {
        static void PrintBattleGround(string[,] arrayToPrint)
        {
            for(int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {

                    Console.Write(arrayToPrint[i,j] + " ");
                }
                 Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static string[,] GenerateBattleGround(int battleGroundSize)
        {
            string[,] battleGround = new string[battleGroundSize+1,battleGroundSize+1];
            for (int i = 0; i <= battleGroundSize; i++)
            {
                for (int j = 0; j <= battleGroundSize; j++)
                {
                     battleGround[i,j] = "-";
                }
            }
            return(battleGround);
        }
        static int NumberTest() // test vstupu pro cislo
        {
            int numberToTest = 0;
            int test = 1;
             while (test != 0) 
                {
                try
                     {
                         numberToTest = int.Parse(Console.ReadLine()); 
                          
                        if(numberToTest >= 10 && numberToTest <= 15 )
                        {
                            test = 0; 
                        }
                        else
                        {
                            Console.WriteLine("Nenapsal jsi cislo v rozmezi 10 - 15");
                        }
                    }
                catch
                     {
                      Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                      }
            }    
            return(numberToTest);
         }
         static int NumberInBattleGroundTest(int battleGroundSize)
         {
            int numberToTest = 0;
            int test = 1;
             while (test != 0) 
                {
                try
                     {
                         numberToTest = int.Parse(Console.ReadLine()); 
                          
                        if(numberToTest >= 0 && numberToTest <= battleGroundSize )
                        {
                            test = 0; 
                        }
                        else
                        {
                            Console.WriteLine("Nenapsal jsi cislo v rozmezi 0 - " + battleGroundSize);
                        }
                    }
                catch
                     {
                      Console.WriteLine("nenapsal jsi cislo, zkus to znovu");
                      }
            }    
            return(numberToTest);
         }
         
         static string OrientationTest()
         {
            string orientationToTest = " ";
            int test = 1;
             while (test != 0) 
                {
                    orientationToTest = Console.ReadLine();
                    if(orientationToTest == "vertikalne")
                        {
                            test = 0;
                        }
                    else if(orientationToTest == "horizontalne")
                        {
                            test = 0;
                        }
                     else
                        {
                            Console.WriteLine("nenapsal jsi - vertikalne nebo horizontalne, zkus to znovu");
                        }
                      
                      
                }    
            return(orientationToTest);
         }
        static int ShipPlacementTest(int battleGroundSize, string shipType,int shipSize, string orientation)
        {
            int coordinates = 0;
            int test = 1;
            while(test!= 0)
            {
                Console.WriteLine("zadej X souradnici lode (cislo v rozmezi 0 - " + battleGroundSize + ")");
                int coordinatesX = NumberInBattleGroundTest(battleGroundSize);
                Console.WriteLine("zadej Y souradnici lode (cislo v rozmezi 0 - " + battleGroundSize + ")");
                int coordinatesY = NumberInBattleGroundTest(battleGroundSize);
            
                    if(orientation == "vertikalne")
                    {
                        if(coordinatesY + shipSize <= battleGroundSize )
                        {  
                         test = 0;
                         coordinates = coordinatesY;
                        }  
                        else
                        {
                            Console.WriteLine("Lod se nevejde do hraciho pole, zadej jine Y");
                        }
                    }
                    else
                    {
                        if(coordinatesX + shipSize <= battleGroundSize )
                        {                   
                         test = 0;
                         coordinates = coordinatesX;
                        }  
                        else
                        {
                            Console.WriteLine("Lod se nevejde do hraciho pole, zadej Jine X");
                        }
                    }
            }
            return(coordinates);
        }
        static string[,] AircraftCarrierPlacement(int battleGroundSize, string[,] battleGround)
        {
            int shipSize = 5;
            string shipType = "L";
            Console.WriteLine("Letadlova lod - souradnice se vztahuji k levemu/hornimu policku lode");
            Console.WriteLine(" zadej orientaci (vertikalne nebo horizontalne)");
                string orientation = OrientationTest();
            
                int coordinatesX = ShipPlacementTest(battleGroundSize,shipType,shipSize,orientation);
            
                int coordinatesY = ShipPlacementTest(battleGroundSize,shipType,shipSize,orientation);
            for( int i = 0; i < shipSize; i++)
                {
                    if(orientation == "horizontalne")
                    {
   
                       battleGround[coordinatesX-1,coordinatesY + i-1] = shipType;
                        
                    }
                    else
                    {
                        battleGround[coordinatesX + i-1,coordinatesY-1] = shipType;
                    }
                }
            return(battleGround);
        }


static void Main(string[] args)
        {            string[,] array = new string[5, 5];
            Console.WriteLine("Vitam te ve hre Battle Ship");
            Console.WriteLine("Jako prvni si zvol rozmery pole (10 - 15)");
                int battleGroundSize = NumberTest()-1;
                string[,] playerBattleGround = GenerateBattleGround(battleGroundSize);
                PrintBattleGround(playerBattleGround);
                string[,] computerBattleGround = GenerateBattleGround(battleGroundSize);
            Console.WriteLine("rozmisti lode");
                playerBattleGround = AircraftCarrierPlacement(battleGroundSize, playerBattleGround);
                PrintBattleGround(playerBattleGround);
                 



            Console.Read();
        }
    }
}
