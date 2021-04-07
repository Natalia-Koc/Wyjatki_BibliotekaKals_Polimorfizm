namespace Lab03_BibliotekaKlas.Podklasy_dokumentu
{
    public class Magazine : Document
    {
        public int Number { get; set; }
        public Frequency MyFrequency { get; set; }

        public Magazine()
        {
        }

        public Magazine(int iSBN, string title, int yearPublishment, int numberPages, int numberMagazine, int myFrequency)
            : base (iSBN, title, yearPublishment, numberPages)
        {
            Number = numberMagazine;
            MyFrequency = (Frequency)myFrequency;
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
            return base.ToString() + $", Magazine number: {Number}, Częstotliwość: {MyFrequency}";
        }

        public override string Print()
        {
            return "Drukowanie Czasopisma.";
        }
    }
}
