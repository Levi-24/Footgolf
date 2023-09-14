using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA230914_01
{
    class Program
    {
        static void Main()
        {
            var versenyzok = new List<Versenyzo>();
            using var sr = new StreamReader(
                @"..\..\..\src\fob2016.txt",
                Encoding.UTF8);
            while (!sr.EndOfStream)versenyzok.Add(new Versenyzo(sr.ReadLine()));

            Console.WriteLine($"3. feladat: Versenyzők száma: {versenyzok.Count}");

            int nokSzama = versenyzok.Count(v => !v.Kategoria);
            float nokAranya = nokSzama / (float)versenyzok.Count * 100;
            Console.WriteLine($"4. feladat: Női versenyzpők aránya: {nokAranya:0.00}%");


        }
    }
}
