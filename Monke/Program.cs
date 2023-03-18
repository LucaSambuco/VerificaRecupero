using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace Monke
{
    internal class Program
    {
        const int NUM_AUTO_SUL_PONTE = 4;
        static SemaphoreSlim semaphore;

        static Object _lockConsole = new Object();
        static Object _lockParcheggio = new Object();
        static Object _lockPassa = new Object();
        static Object _lockCorsia = new Object();

        static List<Thread> passa;
        static List<string> parcheggio = new List<string>();
        static bool levatoio = true;
        static bool[] corsia = new bool[NUM_AUTO_SUL_PONTE];
        static int numeromacchina = 1;
        static int rigamacchina = 8;
        static int n = 0;
        //Commento




        static void SfondoPonte()
        {
            SetCursorPosition(50, 0);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 1);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 2);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 3);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 4);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 5);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 6);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 7);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 8);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(45, 9);
            Write("════════════════");
            SetCursorPosition(55, 9);
            Write("════════════════");
            SetCursorPosition(50, 9);
            Write("════════════════");
            SetCursorPosition(50, 15);
            Write("════════════════");
            SetCursorPosition(55, 15);
            Write("════════════════");
            SetCursorPosition(45, 15);
            Write("════════════════");
            SetCursorPosition(50, 16);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 17);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 18);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 19);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 20);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 21);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 22);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 23);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 24);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 25);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 26);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 27);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            SetCursorPosition(50, 28);
            Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        }
        static void Menu()
        {
            while (true)
            {
                var key = ReadKey(true).Key;
                if (key == ConsoleKey.O)
                {
                    levatoio = true;
                    lock (_lockConsole)
                    {
                        SetCursorPosition(45, 9);
                        Write("════════════════");
                        SetCursorPosition(55, 9);
                        Write("════════════════");
                        SetCursorPosition(50, 9);
                        Write("════════════════");
                        SetCursorPosition(50, 15);
                        Write("════════════════");
                        SetCursorPosition(55, 15);
                        Write("════════════════");
                        SetCursorPosition(45, 15);
                        Write("════════════════");
                        SetCursorPosition(50, 10);
                        Write("                 ");
                        SetCursorPosition(50, 11);
                        Write("                 ");
                        SetCursorPosition(50, 12);
                        Write("                 ");
                        SetCursorPosition(50, 13);
                        Write("                 ");
                        SetCursorPosition(50, 14);
                        Write("                 ");
                    }
                }
                else if (key == ConsoleKey.C)
                {
                    levatoio = false;
                    lock (_lockConsole)
                    {
                        SetCursorPosition(50, 9);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 10);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 11);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 12);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 13);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 14);
                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                        SetCursorPosition(50, 15);

                        Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    }
                }else if (key == ConsoleKey.A)
                {

                    parcheggio.Add("Auto" + numeromacchina);
                    SetCursorPosition(0, rigamacchina);
                    Write(parcheggio[numeromacchina-1]);
                    numeromacchina++;
                    rigamacchina++;
                    n++;
                }

            }


            






           
            
            


        }
        static void Macchina()
        {
            while (true)
            {
                if (levatoio == true && n>0)
                {
                    rigamacchina--;
                    int posMacchina = 40;                   
                    do
                    {
                        Thread.Sleep(30);
                        lock (_lockParcheggio)
                        {
                            SetCursorPosition(posMacchina, 10);
                            Write("     Auto");
                            posMacchina++;
                        }

                    } while (posMacchina < 80);
                    SetCursorPosition(0, rigamacchina);
                    Write("       ");
                    n--;
                }          
            }            
        }
        static void Macchina1()
        {
            while (true)
            {
                if (levatoio == true && n > 1)
                {
                    rigamacchina--;
                    int posMacchina = 40;
                    do
                    {
                        Thread.Sleep(30);
                        lock (_lockParcheggio)
                        {
                            SetCursorPosition(posMacchina, 11);
                            Write("     Auto");
                            posMacchina++;
                        }

                    } while (posMacchina < 80);
                    SetCursorPosition(0, rigamacchina);
                    Write("       ");
                    n--;
                }
            }
        }
        static void Macchina2()
        {
            while (true)
            {
                if (levatoio == true && n > 2)
                {
                    rigamacchina--;
                    int posMacchina = 40;
                    do
                    {
                        Thread.Sleep(30);
                        lock (_lockParcheggio)
                        {
                            SetCursorPosition(posMacchina, 12);
                            Write("     Auto");
                            posMacchina++;
                        }

                    } while (posMacchina < 80);
                    SetCursorPosition(0, rigamacchina);
                    Write("       ");
                    n--;
                }
            }
        }
        static void Macchina3()
        {
            while (true)
            {
                if (levatoio == true && n > 3)
                {
                    rigamacchina--;
                    int posMacchina = 40;
                    do
                    {
                        Thread.Sleep(30);
                        lock (_lockParcheggio)
                        {
                            SetCursorPosition(posMacchina, 13);
                            Write("     Auto");
                            posMacchina++;
                        }

                    } while (posMacchina < 80);
                    SetCursorPosition(0, rigamacchina);
                    Write("       ");
                    n--;
                }
            }
        }




        static void Main(string[] args)
        {
            Write("Luca Silvestro Sambuco 4G");
            CursorVisible = false;
            Thread thMacchina= new Thread(Macchina);
            Thread thMacchina1 = new Thread(Macchina1);
            Thread thMacchina2 = new Thread(Macchina2);
            Thread thMacchina3 = new Thread(Macchina3);
            Thread thSfondoPonte = new Thread(SfondoPonte);
             Thread thponteLevatoio = new Thread(Menu);

            thMacchina.Start();
            thMacchina1.Start();
            thMacchina2.Start();
            thMacchina3.Start();
            thSfondoPonte.Start();
            thponteLevatoio.Start();
 
            
        }
    }
  }

