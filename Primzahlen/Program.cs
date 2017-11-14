using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<int> Primzahlen = new List<int>();
            List<int> Vermerk = new List<int>();            
            int Zahl=3;
            int Stelle=0;
            int letzteStelle=0;
            Primzahlen.Add(2);
            Vermerk.Add(0);
            Console.WriteLine("Berechnung aller Primzahlen fängt nun an:");
            Console.ReadKey();
            Console.WriteLine(1);
            while (Zahl<=2000000)
            {
                while (Vermerk[Stelle] < Zahl)
                {
                    Vermerk[Stelle] += Primzahlen[Stelle];
                }
                if (Vermerk[Stelle] == Zahl)
                {
                    Zahl++;
                    Stelle = 0;
                }
                else
                {
                    if (Stelle < letzteStelle)
                    {
                        Stelle++;
                    }
                    else
                    {
                        Primzahlen.Add(Zahl);
                        Vermerk.Add(0);
                        Console.WriteLine(Zahl);
                        Stelle = 0;
                        letzteStelle++;
                        Zahl++;
                    }

                }
            }
            Console.ReadKey();
             



            /*
            List<double> L_Primzahl = new List<double>();
            double Zahl = 3;
            int Stelle = 0;
            int letzteStelle = 0;
            L_Primzahl.Add(2);
            Console.WriteLine("Berechnung aller Primzahlen fängt nun an:");
            Console.WriteLine(1);
            Console.ReadKey();
            while (Zahl < 2000000)
            {
                if ((Zahl%L_Primzahl[Stelle])==0)
                {
                    Zahl++;
                    Stelle = 0;
                }
                else
                {
                    if (Stelle < letzteStelle)
                    {
                        Stelle++;
                    }
                    else
                    {
                        L_Primzahl.Add(Zahl);
                        Console.WriteLine(Zahl);
                        Stelle = 0;
                        letzteStelle++;
                        Zahl++;
                    }

                }
            }
            Console.ReadKey();
            */
        }
    }
}
