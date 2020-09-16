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
                if (T[sor, oszlop] == '#')
                {
                    T[sor, oszlop] = 'K';
                }
            }
            
        }

        public void FajlbaIr()
        {

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

        public int UresOszlop()
        {
            return 0;
        }

        public int UresSor()
        {
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");

            Tabla t = new Tabla('#');

            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(64);
            Console.WriteLine();
            t.Megjelenit();

            Console.ReadKey();
        }
    }
}
