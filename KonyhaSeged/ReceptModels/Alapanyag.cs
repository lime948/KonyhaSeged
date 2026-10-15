namespace KonyhaSeged.ReceptModels
{
    // Alapanyag osztály az `alapanyagok` tábla alapján
    // field és Property név = Adatbázisban oszlopnév
    internal class Alapanyag
    {
        private int alapanyag_id;
        private string nev;

        public int Alapanyag_id { get => alapanyag_id; set => alapanyag_id = value; }
        public string Nev { get => nev; set => nev = value; }

        public Alapanyag(int alapanyag_id, string nev)
        {
            Alapanyag_id = alapanyag_id;
            Nev = nev;
        }

        public Alapanyag() 
        {
        
        }
    }
}
