namespace Lab03_BibliotekaKlas.Podklasy_dokumentu.Book_subclass
{
    public class Volume : Book
    {
        public int VolumeNumber { get; set; }
        public int NumberOfAllVolumes { get; set; }

        public Volume()
        {
        }

        public Volume(int iSBN, string title, int yearPublishment, int numberPages, string author, int volumeNumber, int numberOfAllVolumes)
             : base(iSBN, title, yearPublishment, numberPages, author)
        {
            VolumeNumber = volumeNumber;
            NumberOfAllVolumes = numberOfAllVolumes;
        }

        public override string ToString()
        {
            return base.ToString() + $", Volume number: {VolumeNumber}, Number of all volumes: {NumberOfAllVolumes}";
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string Print()
        {
            return "Drukowanie tomu książki.";
        }
    }
}
