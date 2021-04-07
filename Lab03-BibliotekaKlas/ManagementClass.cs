using Lab03_BibliotekaKlas.Podklasy_dokumentu;
using Lab03_BibliotekaKlas.Podklasy_dokumentu.Book_subclass;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lab03_BibliotekaKlas.Exception;

namespace Lab03_BibliotekaKlas
{
    public class ManagementClass : Object
    {
        public ManagementClass()
        {
        }

        public List<Document> documents = new List<Document>();

        public void InitializingList()
        {
            documents.Add(new Book(1, "Jak Przestać się bać.", 2020, 368, "Ellen Hendriksen"));
//            documents.Add(new Book(2, "Delirium.", 2011, 480, "Lauren Oliver"));
            documents.Add(new Book(3, "Pandemonium.", 2012, 376, "Lauren Oliver"));
            documents.Add(new Book(4, "Requiem.", 2013, 392, "Lauren Oliver"));
            documents.Add(new Book(5, "Delirium. Opowiadania.", 2015, 194, "Lauren Oliver"));

            documents.Add(new Volume(22, "Delirium.", 2011, 480, "Lauren Oliver", 1, 4));
            documents.Add(new Volume(33, "Pandemonium.", 2012, 376, "Lauren Oliver", 2, 4));
            documents.Add(new Volume(44, "Requiem.", 2013, 392, "Lauren Oliver", 3, 4));
            documents.Add(new Volume(55, "Delirium. Opowiadania.", 2015, 194, "Lauren Oliver", 4, 4));

            documents.Add(new Magazine(111, "Czasopismo numer 1", 2013, 50, 1, 1));
            documents.Add(new Magazine(222, "Czasopismo numer 2", 2012, 50, 2, 2));
            documents.Add(new Magazine(333, "Czasopismo numer 3", 2014, 50, 3, 3));
            documents.Add(new Magazine(444, "Czasopismo numer 4", 2016, 50, 4, 4));
            documents.Add(new Magazine(555, "Czasopismo numer 5", 2012, 50, 5, 1));

        }
        public void AddDocument(Document document)
        {
            if (documents.Any(e => e.ISBN.Equals(document.ISBN)))
            {
                throw new MyException($"Taki ISBN '{document.ISBN}' już istnieje. ISBN musi być unikalny.");
            }
            else if (document is Volume volume1)
            {
                if (documents.Any(e => e.Title.Equals(volume1.Title)))
                {
                    if (documents.Any(e => e is Volume volume && volume.VolumeNumber.Equals(volume1.VolumeNumber)))
                    {
                        throw new MyException($"Tom o takim tytule '{volume1.Title}' i numerze tomu '{volume1.VolumeNumber}' już istnieje.");
                    }
                }
                if (volume1.VolumeNumber > volume1.NumberOfAllVolumes)
                {
                    throw new MyException($"Książka nie ma tyle tomów.");
                }
            }
            else if (documents.Any(e => e.YearPublishment < 1448))
            {
                throw new MyException($"Nie możesz podać {document.YearPublishment} roku, druk wynaleziono troszeczkę później");
            }
            documents.Add(document);
            Console.WriteLine("Dodano");
        }
        public void CreateNewDocument()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Książka.");
            Console.WriteLine("2. Tom.");
            Console.WriteLine("3. Czasopismo.");
            Console.ForegroundColor = ConsoleColor.White;

            String key;
            key = Console.ReadLine();

            Console.WriteLine("Podaj ISBN: ");
            int ISBN = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj tytuł: ");
            string tytul = Console.ReadLine();
            Console.WriteLine("Podaj rok wydania: ");
            int rok = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj liczbę stron: ");
            int numberPages = int.Parse(Console.ReadLine());

            switch (key)
            {
                case "1":
                    Console.WriteLine("Podaj Autora: ");
                    string authora = Console.ReadLine();
                    AddDocument(new Book(ISBN, tytul, rok, numberPages, authora));
                    break;
                case "2":
                    Console.WriteLine("Podaj Autora: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Podaj numer tomu wydania: ");
                    int volumeNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj liczbę wszystkich tomów: ");
                    int all = int.Parse(Console.ReadLine());
                    AddDocument(new Volume(ISBN, tytul, rok, numberPages, author, volumeNumber, all));
                    break;
                case "3":
                    Console.WriteLine("Podaj numer czasopisma: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj częstotliwość: \n" +
                        "\t 1. dziennik\n" +
                        "\t 2. tygodnik\n" +
                        "\t 3. miesięcznik\n" +
                        "\t 4. rocznik");
                    int frequency = int.Parse(Console.ReadLine());
                    AddDocument(new Magazine(ISBN, tytul, rok, numberPages, number, frequency));                    
                    break;
                default:
                    break;
            }
        }
        public Document FindDocument(int ISBN)
        {
            Document document = null;
            foreach (var item in documents)
            {
                if (item.ISBN == ISBN)
                {
                    document = item;
                }
            }
            return document;
        }
        public void FindDocumentsByPhrase(string pharse)
        {
            foreach (var item in documents)
            {
                if (item.Title.ToLower().Contains(pharse.ToLower()))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void FindMagazinesByFrequences(int frequency)
        {
            foreach (var item in documents)
            {
                if (item is Magazine magazine && magazine.MyFrequency.Equals((Frequency) frequency))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void FindVolumesByTitle(string title)
        {
            foreach (var item in documents)
            {
                if (item is Volume && item.Title.ToLower().Contains(title.ToLower()))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

    }
}
