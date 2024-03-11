using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Konyvtar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Books> books = new List<Books>();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var i in lines)
            {
                string[] items = i.Split(',');
                Books books_object = new Books(items[0], items[1], items[2], items[3], items[4]);
                books.Add(books_object);
            }

            Console.WriteLine("4.Feladat: ");
            foreach (var i in books)
            {
                Console.WriteLine($"{i.sorszam}. {i.kategoria} {i.cim} {i.ar}Ft {i.db}db");
            }
           
            Console.WriteLine("\n5.Feladat: ");
            int db_konyv = 0;
            foreach(var i in books)
            {
                db_konyv += i.db;
            }
            Console.WriteLine($"Összesen {db_konyv} darab könyv van.");

            Console.WriteLine("\n6.Feladat: ");
            Console.WriteLine("A Regény kategóriába tartozó könyvek: ");
            foreach (var i in books)
            {
                if (i.kategoria == "Regény")
                {
                    Console.WriteLine($"{i.cim}, ára: {i.ar}");
                }
            }

            Console.WriteLine("\n7.Feladat: ");
            Dictionary<string, int> categ = new Dictionary<string, int>();

            foreach (var i in books)
            {
                if (categ.ContainsKey(i.kategoria))
                {
                    categ[i.kategoria]++;
                }
                else
                {
                    categ[i.kategoria] = 1;
                }
            }

            Console.WriteLine("Kategóriák:");
            foreach (var i in categ)
            {
                Console.WriteLine($"{i.Key}: {i.Value}db termék");
            }

            Console.WriteLine("\n8.Feladat: ");
            List<Books> cheapests = new List<Books>();
            Books cheapest = books[0];
            cheapests.Add( cheapest );
            foreach (var i in books)
            {
                if (i.ar < cheapest.ar)
                {
                    cheapests.Clear();
                    cheapest = i;
                    cheapests.Add(cheapest);
                }
                else if (i.ar == cheapest.ar)
                {
                    cheapests.Add(i);
                }
            }
            Console.WriteLine("A legolcsóbb termékek: ");
            foreach (var i in cheapests)
            {
                Console.WriteLine($"Kategória: {i.kategoria}, Cím: {i.cim}, Ár: {i.ar}");
            }

            Console.ReadKey();
        }
    }
}
