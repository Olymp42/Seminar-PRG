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
    static void PrintBattleGround(string[,] arrayToPrint) //vykresli pole
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
    static string[,] GenerateBattleGround(int battleGroundSize) //vygeneruje  ciste pole
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
    static int NumberTest() // test vstupu pro cislo - rozpozna jestli uzivatel napsal cislo v rozmezi 10-15
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
    static int NumberInBattleGroundTest(int battleGroundSize) // rozpozna jestli je cislo v poli
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
         
    static string OrientationTest() // rozpozna jestli uzivatel zadal spravnou orientaci
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
                // rozpozna jestli uzivatel zadal validni souradnice pro lod, jestli se lod vejde do pole nebo jestli se neprekriva.
    static (int coordinatesY, int coordinatesX) ShipPlacementTest(int battleGroundSize, string shipType,int shipSize, string orientation, string[,] battleGround)
        {
            int coordinatesX = 0;
            int coordinatesY = 0;
            int test = 1;
            while(test!= 0)
            {
                int test1 = 1;
            while(test1 != 0)
            {
                test1 = 0;
                 Console.WriteLine("zadej X souradnici lode (cislo v rozmezi 0 - " + battleGroundSize + ")");
                 coordinatesX = NumberInBattleGroundTest(battleGroundSize);
                 Console.WriteLine("zadej Y souradnici lode (cislo v rozmezi 0 - " + battleGroundSize + ")");
                 coordinatesY = NumberInBattleGroundTest(battleGroundSize);
            
                    if(orientation == "vertikalne")
                    {
                        if(coordinatesY + shipSize-1 <= battleGroundSize )
                        {  
                            
                            for(int i =0; i <= shipSize; i++)
                            {
                                if(battleGround[coordinatesY+i-1,coordinatesX] == "-")
                                {
                                    test = 0;
                                }
                                else
                                {   
                                    Console.WriteLine("Lode se prekrivaji zkus jine souradnice");
                                    test1 = 1;
                                }
                            }
                        }  
                        else
                        {
                            Console.WriteLine("Lod se nevejde do hraciho pole, zadej jine Y");
                        }
                        
                    }
                    else
                    {
                        if(coordinatesX + shipSize-1 <= battleGroundSize )
                        {                  
                            for(int i =0; i <= shipSize; i++)
                            {
                                if(battleGround[coordinatesY,coordinatesX+i-1] == "-")
                                {
                                    test = 0;
                                }
                                else
                                {   
                                    Console.WriteLine("Lode se prekrivaji zkus jine souradnice");
                                    test1 = 1;
                                }
                            }
                         
                        }  
                        else
                        {   
                            Console.WriteLine("Lod se nevejde do hraciho pole, zadej Jine X");
                        }
                    
                          
                    } 
            }           
            }
            return(coordinatesY: coordinatesX,coordinatesX: coordinatesY);
        }
    static string[,] ShipPlacement(int battleGroundSize, string[,] playerBattleGround,int shipSize,string shipType) //prida lode do pole
        {
                 Console.WriteLine(" zadej orientaci (vertikalne nebo horizontalne)");
            
                string orientation = OrientationTest();
                ( int coordinatesX, int coordinatesY) = ShipPlacementTest(battleGroundSize,shipType,shipSize,orientation,playerBattleGround);
                
            for( int i = 0; i < shipSize; i++)
                {
                    if(orientation == "horizontalne")
                    {
   
                       playerBattleGround[coordinatesY,coordinatesX + i] = shipType;
                        
                    }
                    else
                    {
                        playerBattleGround[coordinatesY + i,coordinatesX] = shipType;
                    }
                }
            return(playerBattleGround);
        }
    static string[,] ComputerShipPlacement(int battleGroundSize, string[,] battleGround,int shipSize,string shipType) // prida lode pocitace do pole a urci jejich orientaci
        {
            Random rnd = new Random();
            string orientation = null;
            int orientationNumber = rnd.Next(1,2);
            if(orientationNumber == 1)
                {
                    orientation = "horizontalne";
                }
            else
                {
                    orientation = "vertikalne";
                }
                ( int coordinatesX, int coordinatesY) = ComputerShipPlacementTest(battleGroundSize,shipType,shipSize,orientation,battleGround);
                
            for( int i = 0; i < shipSize; i++)
                {
                    if(orientation == "horizontalne")
                    {
   
                       battleGround[coordinatesY,coordinatesX + i] = shipType;
                        
                    }
                    else
                    {
                        battleGround[coordinatesY + i,coordinatesX] = shipType;
                    }
                }
            return(battleGround);
        }
        // vygeneruje validni souradnice pro umisteni lodi pocitace
    static (int coordinatesY, int coordinatesX) ComputerShipPlacementTest(int battleGroundSize, string shipType,int shipSize, string orientation, string[,] battleGround)
        {
            Random rnd = new Random();
            int coordinatesX = 0;
            int coordinatesY = 0;
            int test = 1;
            while(test!= 0)
            {
                int test1 = 1;
            while(test1 != 0)
            {
                test1 = 0;
                 coordinatesX = rnd.Next(battleGroundSize);
                 coordinatesY = rnd.Next(battleGroundSize);
            
                    if(orientation == "vertikalne")
                    {
                        if(coordinatesY + shipSize <= battleGroundSize )
                        {  
                            
                            for(int i =0; i <= shipSize; i++)
                            {
                                if(battleGround[coordinatesY+i,coordinatesX] == "-")
                                {
                                    test = 0;
                                }
                                else
                                {   
                                    
                                    test1 = 1;
                                }
                            }
                        }  
                        
                    }
                    else
                    {
                        if(coordinatesX + shipSize <= battleGroundSize )
                        {                  
                            for(int i =0; i <= shipSize; i++)
                            {
                                if(battleGround[coordinatesY,coordinatesX+i] == "-")
                                {
                                    test = 0;
                                }
                                else
                                {   
                                    test1 = 1;
                                }
                            }
                         
                        }  
                    } 
            }           
            }
        
            return(coordinatesY: coordinatesX,coordinatesX: coordinatesY);
        }
    static string[,] PlayerShooting(string [,] computerBattleGround, string [,] playerShootingBattleGround, int battleGroundSize)
        {
            int lineBombardation = 3;
            string shotType = " ";
            Console.WriteLine("vyber typ strely, (normalni,plosna bombardace), plosne bombardace zbiva: " + lineBombardation );
            shotType = ShotTypeTest();
            if(shotType == "plosna bombardace")
            {
                Console.WriteLine("urci orientaci plosne bombardace (horizontlane, vertikalne)");
                string orientation = OrientationTest();
                int coordinatesX = 0;
                int coordinatesY = 0;
                int test = 1;
                while(test!= 0)
                {
                    Console.WriteLine("zadej X souradnici leveho/horniho plicka bombardace (cislo v rozmezi 0 - " + battleGroundSize + ")");
                    coordinatesX = NumberInBattleGroundTest(battleGroundSize);
                    Console.WriteLine("zadej Y souradnici leveho/horniho plicka bombardace (cislo v rozmezi 0 - " + battleGroundSize + ")");
                    coordinatesY = NumberInBattleGroundTest(battleGroundSize);
            
                        if(orientation == "vertikalne")
                        {
                            if(coordinatesY + 2 <= battleGroundSize )
                            {  
                            
                                for(int i = 0; i <= 3; i++)
                                {
                                    if(computerBattleGround[coordinatesY+i-1,coordinatesX] == "-")
                                    {
                                        test = 0;
                                        Console.WriteLine(coordinatesY+i + "," + coordinatesX + "voda" );
                                        playerShootingBattleGround[coordinatesY + i, coordinatesX] = "0";
                                    }
                                    else
                                    {   
                                        Console.WriteLine(coordinatesY+i + "," + coordinatesX + " zasah");
                                        test = 0;
                                        playerShootingBattleGround[coordinatesY + i, coordinatesX] = "W";
                                    }
                                }
                            }  
                            else
                            {
                                Console.WriteLine("Bombardovani se nevejde do hraciho pole, zadej jine Y");
                            }
                        
                        }
                        else
                        {
                            if(coordinatesX + 2 <= battleGroundSize )
                            {                  
                                for(int i =0; i <= 3; i++)
                                {
                                    if(computerBattleGround[coordinatesY,coordinatesX+i-1] == "-")
                                    {
                                        test = 0;
                                        Console.WriteLine(coordinatesY + "," + coordinatesX+i + "voda" );
                                        playerShootingBattleGround[coordinatesY, coordinatesX + i] = "0";
                                    }
                                    else
                                    {   
                                        Console.WriteLine(coordinatesY + "," + coordinatesX+i + " zasah");
                                        test = 0;
                                        playerShootingBattleGround[coordinatesY, coordinatesX + i] = "W";

                                        
                                    }
                                }   
                         
                            }  
                            else
                            {   
                                Console.WriteLine("Bombardovani se nevejde do hraciho pole, zadej jine X");
                            }
                    
                          
                        }    
                          
                }
            }


        }
        static int ShipDestroyedTest(string[,] battleGround, int coordinatesX, int coordinatesY, int i)
        {
            if(battleGround[coordinatesY,coordinatesX+i-1] == "L")
            {
                for(int j = 0; i <= 5;j++)
                {
                    
                }
                                               
                                            
            }
        }

        
     static string ShotTypeTest() // rozpozna jestli uzivatel zadal spravny typ munice
         {
            string shotTypeToTest = " ";
            int test = 1;
             while (test != 0) 
                {
                   shotTypeToTest = Console.ReadLine();
                    if(shotTypeToTest == "normalni")
                        {
                            test = 0;
                        }
                    else if(shotTypeToTest == "plosna bombardace")
                        {
                            test = 0;
                        }
                     else
                        {
                            Console.WriteLine("nenapsal jsi - normalni nebo plosna bombardace, zkus to znovu");
                        }
                      
                      
                }    
            return(shotTypeToTest);
         }
        static void Main(string[] args)
        {            string[,] array = new string[5, 5];
            Console.WriteLine("Vitam te ve hre Battle Ship");
            Console.WriteLine("Jako prvni si zvol rozmery pole (10 - 15)");
                int battleGroundSize = NumberTest()-1;
                string[,] playerBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] computerBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] playerShotBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] computerShotBattleGround = GenerateBattleGround(battleGroundSize);
                PrintBattleGround(playerBattleGround);
            Console.WriteLine("rozmisti lode");
            Console.WriteLine("Letadlova lod - souradnice se vztahuji k levemu/hornimu policku lode");
                playerBattleGround = ShipPlacement(battleGroundSize, playerBattleGround,5,"L");
                PrintBattleGround(playerBattleGround);
            Console.WriteLine("Bitevni lod - souradnice se vztahuji k levemu/hornimu policku lode");
                playerBattleGround = ShipPlacement(battleGroundSize, playerBattleGround,4,"B");
                PrintBattleGround(playerBattleGround);
             Console.WriteLine("Kriznik - souradnice se vztahuji k levemu/hornimu policku lode");
                playerBattleGround = ShipPlacement(battleGroundSize, playerBattleGround,3,"K");
                PrintBattleGround(playerBattleGround);
            Console.WriteLine("Ponorka - souradnice se vztahuji k levemu/hornimu policku lode");
                playerBattleGround = ShipPlacement(battleGroundSize, playerBattleGround,3,"P");
                PrintBattleGround(playerBattleGround);
            Console.WriteLine("Torpedoborec - souradnice se vztahuji k levemu/hornimu policku lode");
                playerBattleGround = ShipPlacement(battleGroundSize, playerBattleGround,2,"T");
                PrintBattleGround(playerBattleGround);
                computerBattleGround = ComputerShipPlacement(battleGroundSize,computerBattleGround,5,"L");
                computerBattleGround = ComputerShipPlacement(battleGroundSize,computerBattleGround,4,"B");
                computerBattleGround = ComputerShipPlacement(battleGroundSize,computerBattleGround,3,"K");
                computerBattleGround = ComputerShipPlacement(battleGroundSize,computerBattleGround,3,"P");
                computerBattleGround = ComputerShipPlacement(battleGroundSize,computerBattleGround,2,"T");
                Console.WriteLine("pole pocitace");
                PrintBattleGround(computerBattleGround);





            Console.Read();
        }
    }
}

