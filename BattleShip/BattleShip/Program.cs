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
                            
                            for(int i =0; i < shipSize; i++)
                            {
                                if(battleGround[coordinatesY+i,coordinatesX] == "-")
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
                            test1 =1;
                        }
                        
                    }
                    else
                    {
                        if(coordinatesX + shipSize-1 <= battleGroundSize )
                        {                  
                            for(int i =0; i < shipSize; i++)
                            {
                                if(battleGround[coordinatesY,coordinatesX+i] == "-")
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
                            test1 = 1;
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
        static (string[,] playerShootingBattleGround, int lineBombardation) PlayerShooting(string [,] computerBattleGround, string [,] playerShootingBattleGround, int battleGroundSize,int lineBombardation )
        {
             
            string shotType = " ";
            int test1 = 1;
            while(test1!= 0)
            {
                Console.WriteLine("vyber typ strely, (normalni,plosna bombardace), plosne bombardace zbiva: " + lineBombardation );
                shotType = ShotTypeTest();
                if(lineBombardation == 0)
                {
                    Console.WriteLine("Uz ti nezbivaji plosne bombardace");
                }
                else
                {
                    test1 = 0;
                }
            }
            if(shotType == "plosna bombardace")
            {
                lineBombardation--;
                Console.WriteLine("urci orientaci plosne bombardace (horizontlane, vertikalne)");
                string orientation = OrientationTest();
                int coordinatesX = 0;
                int coordinatesY = 0;
                int test = 1;
                int test2 = 1;
                while(test!= 0)
                {
                    while(test2 != 0)
                    {
                        Console.WriteLine("zadej X souradnici leveho/horniho plicka bombardace (cislo v rozmezi 0 - " + battleGroundSize + ")");
                        coordinatesX = NumberInBattleGroundTest(battleGroundSize);
                        Console.WriteLine("zadej Y souradnici leveho/horniho plicka bombardace (cislo v rozmezi 0 - " + battleGroundSize + ")");
                        coordinatesY = NumberInBattleGroundTest(battleGroundSize);
                        if(playerShootingBattleGround[coordinatesY,coordinatesX] == "-")
                        {
                            test2 =0;
                        }
                        else
                        {
                            Console.WriteLine(" na toto pole jsi uz strilel");
                        }
                    }
                            if(orientation == "vertikalne")
                            {
                                if(coordinatesY + 2 <= battleGroundSize )
                                {  
                            
                                    for(int plusY = 0; plusY <= 3; plusY++)
                                    {
                                       if(computerBattleGround[coordinatesY+plusY,coordinatesX] == "-")
                                       {
                                           test = 0;
                                           Console.WriteLine((coordinatesX+plusY) + "," + coordinatesY + " voda" );
                                           playerShootingBattleGround[coordinatesY + plusY, coordinatesX] = "0";
                                       }
                                       else
                                       {   
                                           Console.WriteLine((coordinatesX+plusY) + "," + coordinatesY + " zasah");
                                           test = 0;
                                           playerShootingBattleGround[coordinatesY + plusY, coordinatesX] = "W";
                                           ShipTypeDestroyedTest(computerBattleGround,playerShootingBattleGround, coordinatesX,coordinatesY,0,plusY);
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
                                   for(int plusX =0; plusX <= 3; plusX++)
                                   {
                                       if(computerBattleGround[coordinatesY,coordinatesX+plusX] == "-")
                                       {
                                           test = 0;
                                           Console.WriteLine((coordinatesX + plusX) + "," + coordinatesY + " voda" );
                                           playerShootingBattleGround[coordinatesY, coordinatesX + plusX] = "0";
                                       }
                                       else
                                           {   
                                           Console.WriteLine((coordinatesX + plusX)+ "," + coordinatesY + " zasah");
                                           test = 0;
                                           playerShootingBattleGround[coordinatesY, coordinatesX + plusX] = "W";  
                                           ShipTypeDestroyedTest(computerBattleGround,playerShootingBattleGround, coordinatesX,coordinatesY,plusX,0);
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
            else
            {
                int test2 = 1;
                int coordinatesX = 0;
                int coordinatesY = 0;
                while(test2 != 0) 
                {
  
                    Console.WriteLine("zadej X souradnici strely (cislo v rozmezi 0 - " + battleGroundSize + ")");
                     coordinatesX = NumberInBattleGroundTest(battleGroundSize);
                    Console.WriteLine("zadej Y souradnici strely (cislo v rozmezi 0 - " + battleGroundSize + ")");
                     coordinatesY = NumberInBattleGroundTest(battleGroundSize);
                    if(playerShootingBattleGround[coordinatesY,coordinatesX] == "-")
                    {
                        test2 = 0;
                    }
                    else
                    {
                        Console.WriteLine(" na toto pole jsi uz strilel");
                    }
                }
                if(computerBattleGround[coordinatesY,coordinatesX] == "-")
                {
                    Console.WriteLine(coordinatesX + "," + coordinatesY + " voda" );
                    playerShootingBattleGround[coordinatesY, coordinatesX] = "0";
                }
                else
                {   
                    Console.WriteLine(coordinatesX + "," + coordinatesY + " zasah");
                    playerShootingBattleGround[coordinatesY, coordinatesX] = "W";
                    ShipTypeDestroyedTest(computerBattleGround,playerShootingBattleGround, coordinatesX,coordinatesY,0,0);
                }
                
            }
            return(playerShootingBattleGround:playerShootingBattleGround, lineBombardation:lineBombardation);
        }
        static void ShipTypeDestroyedTest(string[,] battleGround, string[,] shootingBattleGround, int coordinatesX, int coordinatesY, int plusX, int plusY) // zjisti jaky typ lodi byl zasazen a podle toho posle ShipDestroyedTest informaci jak velke okoli testovat
        {
            int test = 0;
            if(battleGround[coordinatesY+plusY,coordinatesX+plusX] == "L")
            {
                for(int j = 0; j < 5;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,plusX, plusY,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 5)    
                 {
                    Console.WriteLine("zasah potopeno");
                 }                                          
            }
            if(battleGround[coordinatesY + plusY,coordinatesX+plusX] == "B")
            {
                for(int j = 0; j < 4;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,plusX,plusY,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 4)    
                 {
                    Console.WriteLine("zasah potopeno");
                 }                                          
            }
            if(battleGround[coordinatesY+plusY,coordinatesX+plusX] == "K" || battleGround[coordinatesY + plusY,coordinatesX+plusX] == "P")
            {
                for(int j = 0; j < 3;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,plusX,plusY,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 3)    
                 {
                    Console.WriteLine("zasah potopeno");
                 }                                          
            }
            if(battleGround[coordinatesY + plusY,coordinatesX+plusX] == "T")
            {
                for(int j = 0; j < 2;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,plusX, plusY,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 2)    
                 {
                    Console.WriteLine("zasah potopeno");
                 }                                          
            }

        }
        static int ShipDestroyedTest(string[,] battleGround,int plusX, int plusY, int j,int coordinatesX, int coordinatesY,int test) //zjisti jestli strela potopila lod
        {
            
                    try
                    {
                        if(battleGround[coordinatesY + plusY,coordinatesX + plusX + j] == "W")
                        {
                            test++;
                        }
                        else if(battleGround[coordinatesY + plusY,coordinatesX + plusX -j] == "W")
                        {
                            test++;
                        }
                        else if(battleGround[coordinatesY + j + plusY,coordinatesX+plusX] == "W")
                        {
                            test++;
                        }
                        else if(battleGround[coordinatesY-j + plusY,coordinatesX+plusX] == "W")
                        {
                            test++;
                        }
                    }
                    catch
                    {
                        try
                        {
                                if(battleGround[coordinatesY + plusY,coordinatesX + plusX -j] == "W")
                            {
                                test++;
                            }
                            else if(battleGround[coordinatesY + j + plusY,coordinatesX+plusX] == "W")
                            {
                                test++;
                            }
                            else if(battleGround[coordinatesY-j + plusY,coordinatesX+plusX] == "W")
                            {
                                test++;
                            }
                        }
                        catch
                        {
                            try
                            {
                                if(battleGround[coordinatesY + plusY,coordinatesX + plusX + j] == "W")
                                {
                                test++;
                                }
                                else if(battleGround[coordinatesY + j + plusY,coordinatesX+plusX] == "W")
                                {
                                    test++;
                                }
                                else if(battleGround[coordinatesY-j + plusY,coordinatesX+plusX] == "W")
                                {
                                    test++;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if(battleGround[coordinatesY + plusY,coordinatesX + plusX + j] == "W")
                                   {   
                                   test++;
                                   }
                                   else if(battleGround[coordinatesY + plusY,coordinatesX + plusX -j] == "W")
                                   {
                                       test++;
                                   }
                                   else  if(battleGround[coordinatesY-j + plusY,coordinatesX+plusX] == "W")
                                   {
                                   test++;
                                   }   
                                }   
                                catch
                                {
                                    try
                                    {
                                        if(battleGround[coordinatesY + plusY,coordinatesX + plusX + j] == "W")
                                        {
                                            test++;
                                        }
                                        else if(battleGround[coordinatesY + plusY,coordinatesX + plusX -j] == "W")
                                        {
                                            test++;
                                        }
                                        else if(battleGround[coordinatesY + j + plusY,coordinatesX+plusX] == "W")
                                        {
                                            test++;
                                        } 
                                    }
                                    catch
                                    {

                                    }
                                }
                            } 
                        }
                    }
                    return(test);   
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
        static (string[,] playerBattleGround, string[,] computerShootingBattleGround, int computerLineBombardation, int shotSuccess, int coordinatesX, int coordinatesY) ComputerShooting(string [,] playerBattleGround, string [,] computerShootingBattleGround, int battleGroundSize, int lineBombardation, int shotSuccess, int coordinatesX, int coordinatesY) // strelba pocitace

        {
            Random rnd = new Random();
            string shotType = " ";
            int shotTypeNumber = 0; //  1 = plosna bombardace, sotatni = normalni
            int test1 = 1;
            //shotSuccess  0 = voda, 1 = zasah, 2 = zniceno
            int shotDirectionY = 0; // posun po Y, po uspesnem zasahu - 1 = nahoru, 2 = dolu
            int shotDirectionX = 0; // posun po X, po uspesnem zasahu - 1 = doleva, 2 = doprava
            int shotDirection = 0; // 1 = osa Y, 2 = osa X
            while(test1!= 0) // kontroluje zbyvajici plosne bombardace a sanci ze ji pocitac pouzije
            {
                if (shotSuccess == 0 || shotSuccess == 2) //urcuje sanci na plosne bombardovani, podle uspesnosti predchozi strely
                {
                    shotTypeNumber = rnd.Next(15);
                }
                else
                {
                    shotTypeNumber = rnd.Next(5);
                }
                if(shotTypeNumber == 1)
                {
                    shotType = "plosna bombardace";
                    if(lineBombardation != 0)
                    {
                        test1 = 0;
                    }
                }
                else
                {
                    shotType = "normalni";
                    test1 = 0;
                }  
            }
            if(shotType == "plosna bombardace") // pouziti plosne bombardace
            {
                if (shotSuccess == 0 || shotSuccess == 2) // predhcozi strela nebyla uspesna, nebo s ni byla znicena lod
                { 
                    test1 = 1;
                    while(test1 != 0)
                    {
                        coordinatesX = rnd.Next(0,battleGroundSize);
                        coordinatesY = rnd.Next(0,battleGroundSize);
                        if(computerShootingBattleGround[coordinatesX,coordinatesY] != "-")
                        {
                            (playerBattleGround, computerShootingBattleGround, lineBombardation, shotSuccess, coordinatesX, coordinatesY) = ComputerLineBombardation(playerBattleGround,computerShootingBattleGround, battleGroundSize, coordinatesX, coordinatesY, lineBombardation, shotSuccess,0,0);
                            test1 = 0;
                        }
                    }
                        
                }
                else //predchozi strela byla uspesna
                {
                    test1 = 1;
                    while(test1 != 0)
                    {
                        shotDirection = rnd.Next(1,3); // 1 = Ypsilonova osa , 2 = Xova osa
                        if(shotDirection == 1) // po Y
                        {
                            if(coordinatesY == 0) // vylouci moznost nahoru , kdyz byl posledni zasah uplne nahore
                            {
                                shotDirectionY = 2;
                            }
                            else if( coordinatesY == battleGroundSize) // vylouci moznost dolu, kdyz byl posledni zasah uplne dole
                            {
                                shotDirectionY = 1;
                            }
                            else
                            {
                                shotDirectionY = rnd.Next(1,3); // 1 = nahoru, 2 = dolu
                            }
                            if(shotDirectionY == 1) // nahoru
                            {
                                if(computerShootingBattleGround[coordinatesX,coordinatesY-1] =="-")
                                {
                                (playerBattleGround, computerShootingBattleGround, lineBombardation,shotSuccess, coordinatesX, coordinatesY) = ComputerLineBombardation(playerBattleGround, computerShootingBattleGround, battleGroundSize, coordinatesX, coordinatesY, lineBombardation, shotSuccess,0,-1);
                                test1 = 0;
                                }
                            }
                            else // dolu
                            {
                                if(computerShootingBattleGround[coordinatesX,coordinatesY+1] =="-")
                                {
                                (playerBattleGround, computerShootingBattleGround, lineBombardation,shotSuccess, coordinatesX, coordinatesY) = ComputerLineBombardation(playerBattleGround, computerShootingBattleGround, battleGroundSize, coordinatesX, coordinatesY, lineBombardation, shotSuccess,0,+1);
                                test1 = 0;
                                }
                            }
                        }
                        else // po X
                        {
                            if(coordinatesX == 0) // vylouci moznost do leva, kdyz byla posledni strela uplne v levo
                            {
                                shotDirectionX = 2;
                            }
                            else if( coordinatesX == battleGroundSize) // vylouci moznost do prava, kdyz byla posledi strela uplne v pravo
                            {
                                shotDirectionX = 1;
                            }
                            else
                            {
                            shotDirectionX = rnd.Next(1,3); // 1 == doleva , 2 == doprava
                            }
                            if(shotDirectionX == 1) // doleva
                            {
                                if(computerShootingBattleGround[coordinatesX-1,coordinatesY] =="-")
                                {
                                (playerBattleGround, computerShootingBattleGround, lineBombardation,shotSuccess, coordinatesX, coordinatesY) = ComputerLineBombardation(playerBattleGround, computerShootingBattleGround, battleGroundSize, coordinatesX, coordinatesY, lineBombardation, shotSuccess,-1,0);
                                test1 = 0;
                                }
                            }
                            else // doprava
                            {
                                if(computerShootingBattleGround[coordinatesX+1 ,coordinatesY] =="-")
                                {
                                (playerBattleGround, computerShootingBattleGround, lineBombardation,shotSuccess, coordinatesX, coordinatesY) = ComputerLineBombardation(playerBattleGround, computerShootingBattleGround, battleGroundSize, coordinatesX, coordinatesY, lineBombardation, shotSuccess,-1,0);
                                test1 = 0;
                                }
                            }

                        }
                    }
                }

            }
            else // normalni utok
            {
                if (shotSuccess == 0 || shotSuccess == 2)
                {
                    test1 = 1;
                    while(test1 != 0)
                    {
                        coordinatesX = rnd.Next(0,battleGroundSize);
                        coordinatesY = rnd.Next(0,battleGroundSize);
                        if(computerShootingBattleGround[coordinatesY,coordinatesX] == "-")
                        {
                            test1 = 0;
                            if(playerBattleGround[coordinatesY,coordinatesX] == "-")
                            {
                                computerShootingBattleGround[coordinatesY, coordinatesX] = "0";
                                playerBattleGround[coordinatesY, coordinatesX] = "0";
                                shotSuccess = 0;
                            }
                            else
                            {   
                                computerShootingBattleGround[coordinatesY, coordinatesX] = "W";
                                playerBattleGround[coordinatesY, coordinatesX] = "W";
                                shotSuccess = ComputerShipTypeDestroyedTest(playerBattleGround, computerShootingBattleGround, coordinatesX,coordinatesY,0,0);;
                            }
                        }
                    }
                }
                else 
                {   
                    test1 = 1;
                    while(test1 != 0)
                    {
                        shotDirection = rnd.Next(1,3); // 1 = Ypsilonova osa , 2 = Xova osa
                        if(shotDirection == 1) // po Y
                        {
                            if(coordinatesY == 0) // vylouci moznost nahoru, kdyz byl posledni vystrel uplne na hore
                            {
                               shotDirectionY = 2;
                            }
                            else if( coordinatesY == battleGroundSize) // vylouci moznost dolu, kdyz byl posledni vystrel uplne dole
                            {
                                shotDirectionY = 1;
                            }
                            else
                            {
                                shotDirectionY = rnd.Next(1,3); // 1 = nahoru, 2 = dolu
                            }
                            if(shotDirectionY == 1) // nahoru
                            {
                                if(computerShootingBattleGround[coordinatesX,coordinatesY-1] == "-")
                                {
                                    (shotSuccess, computerShootingBattleGround, playerBattleGround, coordinatesX, coordinatesY) = NextComputerShot(playerBattleGround,computerShootingBattleGround,coordinatesX,coordinatesY,shotSuccess,0,-1);
                                test1 = 0;
                                }
                            }
                            else // dolu
                            {
                                if(computerShootingBattleGround[coordinatesX,coordinatesY+1] == "-")
                                {
                                (shotSuccess, computerShootingBattleGround, playerBattleGround, coordinatesX, coordinatesY) = NextComputerShot(playerBattleGround,computerShootingBattleGround,coordinatesX,coordinatesY,shotSuccess,0,+1);
                                test1 = 0;
                                }
                            }
                        }
                        else // po X
                        {
                            if(coordinatesX == 0) // vylouci moznost do leva, kdyz byl posledni vystrel uplne v levo
                            {
                                shotDirectionX = 2;
                            }
                            else if( coordinatesX == battleGroundSize) // vylouci moznost do prava, kdyz byl posledni vystrel uplne v pravo
                            {
                                shotDirectionX = 1;
                            }
                            else
                            {
                            shotDirectionX = rnd.Next(1,3); // 1 == doleva , 2 == doprava
                            }
                            if(shotDirectionX == 1) // doleva
                            {
                                if(computerShootingBattleGround[coordinatesX-1,coordinatesY] == "-")
                                {
                                (shotSuccess, computerShootingBattleGround, playerBattleGround, coordinatesX, coordinatesY) = NextComputerShot(playerBattleGround,computerShootingBattleGround,coordinatesX,coordinatesY,shotSuccess,-1,0);
                                test1 = 0;
                                }
                            }
                            else // doprava
                            {
                                if(computerShootingBattleGround[coordinatesX+1,coordinatesY] == "-")
                                {
                                (shotSuccess, computerShootingBattleGround, playerBattleGround, coordinatesX, coordinatesY) = NextComputerShot(playerBattleGround,computerShootingBattleGround,coordinatesX,coordinatesY,shotSuccess,+1,0);
                                test1 = 0;
                                }
                            }
                        }   
                    }   
                }
                
            }
            return(playerBattleGround: playerBattleGround, computerShootingBattleGround:computerShootingBattleGround, computerLineBombardation: lineBombardation, shotSuccess:shotSuccess, coordinatesX:coordinatesX, coordinatesY:coordinatesY);
        }
        // plosna bombardace pro pocitac
        static (string[,] playerBattleGround, string[,] computerShootingBattleGround, int lineBombardation, int shotSuccess, int coordinatesX, int coordinatesY) ComputerLineBombardation(string[,] playerBattleGround, string[,] computerShootingBattleGround, int battleGroundSize, int coordinatesX, int coordinatesY, int lineBombardation, int shotSuccess,int plusX, int plusY)
        {
            Random rnd = new Random();
            string orientation = " ";
            lineBombardation--;
            int orientationNumber = rnd.Next(1,2); // 1 = horizontalne . 2 = vertikalne
            if(orientationNumber == 1)  // rozhodne mezi vertikalne a horizontalne
            {
                orientation = "horizontalne";
            }
            else
            {
                orientation = "vertikalne";
            }
            int test = 1;
            while(test!= 0)
            {
                if(orientation == "vertikalne")
                {
                    if(coordinatesY + plusY + 2 <= battleGroundSize)
                    {          
                        for(int i = 0; i <= 3; i++)
                        {
                            if(playerBattleGround[coordinatesY+i + plusY,coordinatesX + plusX] == "-")
                            {
                                test = 0;
                                computerShootingBattleGround[coordinatesY + i + plusY, coordinatesX + plusX] = "0";
                                playerBattleGround[coordinatesY + plusY + i, coordinatesX + plusX] = "0";
                                shotSuccess = 0;
                            }
                            else
                            {   
                                test = 0;
                                computerShootingBattleGround[coordinatesY + i + plusY, coordinatesX + plusX] = "W";
                                playerBattleGround[coordinatesY + i + plusY, coordinatesX + plusX] = "W";
                                shotSuccess =  ComputerShipTypeDestroyedTest(playerBattleGround,computerShootingBattleGround, coordinatesX + plusX,coordinatesY + plusY,i,0);;
                            }
                        }
                    }
                    else
                    {
                        coordinatesY--;
                    }  
                }
                else
                {
                    if(coordinatesX + 2 + plusX <= battleGroundSize )
                    {                  
                        for(int i =0; i <= 3; i++)
                        {
                            if(playerBattleGround[coordinatesY + plusY,coordinatesX + i + plusX] == "-")
                            {
                                test = 0;
                                computerShootingBattleGround[coordinatesY + plusY, coordinatesX + i + plusX ] = "0";
                                playerBattleGround[coordinatesY + plusY, coordinatesX + i + plusX] = "0";
                                shotSuccess = 0;
                            }
                            else
                            {   
                                test = 0;
                                computerShootingBattleGround[coordinatesY + plusY, coordinatesX + i + plusX] = "W";  
                                playerBattleGround[coordinatesY + plusY, coordinatesX + i + plusX] = "W";
                                shotSuccess = ComputerShipTypeDestroyedTest(playerBattleGround,computerShootingBattleGround, coordinatesX + plusX,coordinatesY + plusY,0,i);;
                            }
                        }   
                    } 
                    else
                    {
                        coordinatesX--;
                    } 
                }      
            }   
            return(playerBattleGround:playerBattleGround,computerShootingBattleGround:computerShootingBattleGround,lineBombardation:lineBombardation,shotSuccess:shotSuccess, coordinatesX + plusX, coordinatesY + plusY);
        }
        static int ComputerShipTypeDestroyedTest(string [,] battleGround, string[,] shootingBattleGround, int coordinatesX, int coordinatesY, int i, int l)
        {
              int test = 0;
              int shotSuccess = 1;
            if(battleGround[coordinatesY,coordinatesX+i] == "L")
            {
                for(int j = 0; j < 5;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,i,l,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 5)    
                 {
                    shotSuccess = 2;
                 }                                          
            }
            if(battleGround[coordinatesY,coordinatesX+i] == "B")
            {
                for(int j = 0; j < 4;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,i,l,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 4)    
                 {
                    shotSuccess = 2;
                 }                                          
            }
            if(battleGround[coordinatesY,coordinatesX+i] == "K" || battleGround[coordinatesY,coordinatesX+i] == "P")
            {
                for(int j = 0; j < 3;j++)
                {
                    test =ShipDestroyedTest(shootingBattleGround,i,l,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 3)    
                 {
                    shotSuccess = 2;
                 }                                          
            }
            if(battleGround[coordinatesY,coordinatesX+i] == "T")
            {
                for(int j = 0; j < 2;j++)
                {
                    test = ShipDestroyedTest(shootingBattleGround,i,l,j,coordinatesX,coordinatesY,test);
                }
                 if(test == 2)    
                 {
                    shotSuccess = 2;
                 }                                          
            }
            return(shotSuccess);
        }
        static (int shotSuccess, string[,] computerShootingBattleGround, string[,] playerBattleGround, int coordinatesX, int coordinatesY) NextComputerShot(string[,] playerBattleGround, string[,] computerShootingBattleGround, int coordinatesX, int coordinatesY, int shotSuccess, int plusX, int plusY)
        {

            if(playerBattleGround[coordinatesY+plusY,coordinatesX + plusX] == "-")
                {
                        computerShootingBattleGround[coordinatesY+ plusY, coordinatesX + plusX] = "0";
                        playerBattleGround[coordinatesY+ plusY, coordinatesX + plusX] = "0";
                        shotSuccess = 0;
                }
                else
                {   
                        computerShootingBattleGround[coordinatesY + plusY, coordinatesX + plusX] = "W";
                        playerBattleGround[coordinatesY + plusY, coordinatesX + plusX] = "W";
                        shotSuccess = ComputerShipTypeDestroyedTest(playerBattleGround,computerShootingBattleGround, coordinatesX + plusX,coordinatesY + plusY,0,0);;
                }
            return(shotSuccess:shotSuccess,computerShootingBattleGround:computerShootingBattleGround,playerBattleGround:playerBattleGround, coordinatesX: (coordinatesX + plusX), coordinatesY: (coordinatesY + plusY));
        }
         
        static void Main(string[] args)
        {            
            Console.WriteLine("Vitam te ve hre Battle Ship");
            Console.WriteLine("Jako prvni si zvol rozmery pole (10 - 15)");
                int battleGroundSize = NumberTest()-1;
                int lineBombardation = 3;
                int computerLineBombaradtion =3;
                int shotSuccess = 0;
                int computerShotCoordinatesX = 0;
                int computerShotCoordinatesY = 0;
                string[,] playerBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] computerBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] playerShootingBattleGround = GenerateBattleGround(battleGroundSize);
                string[,] computerShootingBattleGround = GenerateBattleGround(battleGroundSize);
                int playerScore = 0; // 17 = hrac vyhrava
                int computerScore = 0; // 17 hrac prohrava
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
                //Console.WriteLine("pole pocitace");
                //PrintBattleGround(computerBattleGround);
                while(playerScore < 17 && computerScore < 17)
                {
                    playerScore = 0;
                    computerScore= 0;
                    for(int i =0; i <= battleGroundSize; i++)
                    {
                        for(int j = 0; j <= battleGroundSize; j++)
                        {
                            if(computerShootingBattleGround[i,j] =="w")
                            {
                                computerScore ++;
                            }
                            else if(playerShootingBattleGround[i,j] == "W" )
                            {
                                playerScore ++;
                            }
                        }
                    }
                    Console.WriteLine("jsi na rade");
                    (playerShootingBattleGround, lineBombardation) = PlayerShooting(computerBattleGround,playerShootingBattleGround,battleGroundSize,lineBombardation);
                    PrintBattleGround(playerShootingBattleGround);
                    Console.WriteLine("pocitac je na rade");
                    (playerBattleGround, computerShootingBattleGround, computerLineBombaradtion, shotSuccess, computerShotCoordinatesX,computerShotCoordinatesY ) = ComputerShooting(playerBattleGround, computerShootingBattleGround, battleGroundSize, computerLineBombaradtion, shotSuccess, computerShotCoordinatesX,computerShotCoordinatesY );
                    Console.WriteLine("tvoje pole po zasahu pocitace");
                    PrintBattleGround(playerBattleGround);
                    
                }
                if(playerScore == 17)
                {
                    Console.WriteLine("VYHRAL JSI");
                }
                else
                {
                    Console.WriteLine("PROHRAL JSI");
                }






            Console.Read();
        }
    }
}

