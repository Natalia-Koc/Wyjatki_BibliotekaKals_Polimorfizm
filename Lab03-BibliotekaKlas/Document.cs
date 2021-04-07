using System;

namespace Lab03_BibliotekaKlas
{
    public abstract class Document : Object
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int YearPublishment { get; set; }
        public int NumberPages { get; set; }

        public Document()
        {
        }

        public Document(int iSBN, string title, int yearPublishment, int numberPages)
        {
            ISBN = iSBN;
            Title = title;
            YearPublishment = yearPublishment;
            NumberPages = numberPages;
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, The year of publishment: {YearPublishment}, Number of pages: {NumberPages}";
        }

        public abstract string Print();
    }
}
