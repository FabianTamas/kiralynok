using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiralynok
{
    class Tabla
    {
        private char[,] T;
        private char Urescella;
        private int UresOszlopokSzama;
        private int UresSorokSzama;
        
        public Tabla(char ch)
        {
            T = new char[8,8];
            Urescella = ch;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = Urescella;
                }
            }
        }

        public void Elhelyez(int N)
        {
            // 1. Véletlen helyérték létrehozása
            //    - Random osztály értékkészlet:[0,7]
            //    - Véletlen sor, oszlop kell
            //    - Elhelyezzük a "K"-t csak akkor
            //           HA!!! ÜRES -> "#"

            Random vel = new Random();
            for (int i = 0; i < N; i++)
            {
                int sor = vel.Next(0,8);
                int oszlop = vel.Next(0,8);
                while (T[sor, oszlop] == 'K')
                {
                    sor = vel.Next(0, 8);
                    oszlop = vel.Next(0, 8);
                }
                T[sor, oszlop] = 'K';
            }
        }

        public void FajlbaIr(StreamWriter fajl)
        {
            //fajl.WriteLine("ez egy szöveg");
            for (int i = 0; i < 8; i++)
            {
                string sor = "";
                for (int j = 0; j < 8; j++)
                {
                    sor += T[i, j];
                }
                fajl.WriteLine(sor);
            }
        }

        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0} ",T[i,j]);
                    //Console.WriteLine($"{T[i,j]} ");
                    //Console.WriteLine(T[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool UresOszlop(int oszlop)
        {
            int i = 0;
            while (i < 8 && T[i, oszlop] == '#')
            {
                i++;
            }
            if (i<8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool UresSor(int sor)
        {
            int i = 0;
            while (i < 8 && T[sor, i] == '#')
            {
                i++;
            }
            if (i < 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");

            Tabla t = new Tabla('#');
            Tabla[] tablak = new Tabla[64];

            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            Console.WriteLine();
            Console.Write("Mennyi királynőt szeretnél elhelyezni? ");
            t.Elhelyez(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            t.Megjelenit();
            Console.WriteLine();
            Console.Write("Hányadik oszlopban keresel? ");
            t.UresOszlop(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.Write("Hányadik sorban keresel? ");
            t.UresSor(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("Az üres oszlopok és sorok száma: ");
            Console.WriteLine();

            int uresSor = 0;
            int uresOszlop = 0;

            for (int i = 0; i < 8; i++)
            {
                if (t.UresOszlop(i))
                {
                    uresOszlop++;
                }
                if (t.UresSor(i))
                {
                    uresSor++;
                }
            }
            Console.WriteLine("Üres oszlopok száma: {0} Üres sorok száma: {1}", uresOszlop,uresSor);

            StreamWriter ki = new StreamWriter("adatok.txt");

            for (int i = 0; i < 64; i++)
            {
                tablak[i] = new Tabla('*');
            }

            for (int i = 0; i < 64; i++)
            {
                tablak[i].Elhelyez(i+1);
                tablak[i].FajlbaIr(ki);
                ki.WriteLine();
            }

            ki.Close();

            Console.ReadKey();
        }
    }
}
