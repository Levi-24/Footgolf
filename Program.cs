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

            Console.WriteLine("6.Feladat: ");
            var nb = versenyzok
                .Where(v => !v.Kategoria)
                .OrderBy(v => v.Osszpont)
                .Last();
            Console.WriteLine($"\tNév: {nb.Nev}");
            Console.WriteLine($"\tEgyesület: {nb.Egyesulet}");
            Console.WriteLine($"\tÖsszpont: {nb.Osszpont}");

            Console.WriteLine("7.Feladat: kiírás");
            using var sw = new StreamWriter(
                path: @"..\..\..\src\osszpontFF.txt",
                append: false,
                Encoding.UTF8);

            foreach (var v in versenyzok)
            {
                if (v.Kategoria) sw.WriteLine($"{v.Nev};{v.Osszpont}");
            }

            Console.WriteLine("8.Feladat: ");
            var egyesuletek = versenyzok
                .GroupBy(v => v.Egyesulet)
                .Where(x => x.Count() > 3 && x.Key is not null);

            foreach (var kvp in egyesuletek)
            {
                Console.WriteLine($"\t {kvp.Key} - {kvp.Count()}");
            }
        }
    }
}
