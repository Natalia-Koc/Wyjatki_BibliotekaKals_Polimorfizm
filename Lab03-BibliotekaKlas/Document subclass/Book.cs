using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_BibliotekaKlas.Podklasy_dokumentu
{
    public class Book : Document
    {
        public string Author { get; set; }

        public Book()
        {
        }

        public Book(int iSBN, string title, int yearPublishment, int numberPages, string author)
             : base(iSBN, title, yearPublishment, numberPages)
        {
            Author = author;
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
            return base.ToString() + $", Author: {Author}";
        }

        public override string Print()
        {
            return "Drukowanie książki.";
        }
    }
}
