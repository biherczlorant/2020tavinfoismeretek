using System;
using System.Collections.Generic;
using System.IO;

namespace _2020tavinfoismeretek
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 3. feladat
            List<Feladvany> lista = new List<Feladvany>();
            foreach(var i in File.ReadLines("feladvanyok.txt"))
            {
                lista.Add(new Feladvany(i));
            }
            Console.WriteLine($"3. feladat: Beolvasva {lista.Count} feladvány.");
            // 4. feladat
            int bekermeret = 0;
            do
            {
                Console.WriteLine("4. feladat: Kérem a feladvány méretét [4..9]: ");
                bekermeret = Convert.ToInt32(Console.ReadLine());
            } while (bekermeret>9 || bekermeret<4);
            int negyesszamol = 0;
            List<Feladvany> a = new List<Feladvany>();
            foreach(var i in lista)
            {
                if(i.Meret == bekermeret)
                {
                    negyesszamol++;
                    a.Add(i);
                }
            }
            Console.WriteLine($"{bekermeret}x{bekermeret} méretű feladványból {negyesszamol} darab van tárolva.");
            // 5. feladat
            Random random = new Random();
            int randomindex = 0;
            do
            {
                randomindex = random.Next(0, a.Count-1);
            } while (a[randomindex].Meret != bekermeret);
            Console.WriteLine($"5. feladat: A kiválasztott feladvány:\n{a[randomindex].Kezdo}");
            // 6. feladat
            double nullacnt = 0;
            foreach(var i in a[randomindex].Kezdo)
            {
                if(i != '0')
                {
                    nullacnt++;
                }
                
            }
            Console.WriteLine($"6. feladat: A feladvány kitöltöttsége: {Math.Round(Convert.ToDouble(nullacnt/a[randomindex].Kezdo.Length*100))}%");
            // 7. feladat
            Console.WriteLine("7. feladat: A feladvány kirajzolva: ");
            a[randomindex].Kirajzol();
            // 8. feladat
            StreamWriter streamWriter = new StreamWriter($"sudoku{bekermeret}.txt");
            foreach (var i in a)
            {
                streamWriter.WriteLine(i.Kezdo);
            }
            streamWriter.Flush();
            streamWriter.Close();
            Console.WriteLine($"8. feladat: sudoku{bekermeret}.txt állomány {a.Count} darab feladvánnyal létrehozva.");

        }
    }
}
