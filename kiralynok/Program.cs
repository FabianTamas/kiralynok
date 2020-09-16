using System;
using System.Collections.Generic;
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

        public void Elhelyez()
        {

        }

        public void FajlbaIr()
        {

        }

        public void Megjelenit()
        {

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
            Elhelyez();
            FajlbaIr();
            Megjelenit();
            Tabla();
            UresOszlop();
            UresSor();

            Console.WriteLine("Királynők feladat");
            Console.ReadKey();
        }
    }
}
