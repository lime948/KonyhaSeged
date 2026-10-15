namespace KonyhaSeged.ReceptModels
{
    // Hozzavalo osztály a `hozzavalok` tábla alapján
    // field és Property név = Adatbázisban oszlopnév
    internal class Hozzavalo
    {
        private int recept_id;
        private int alapanyag_id;
        private int mennyiseg;

        public int Recept_id { get => recept_id; set => recept_id = value; }
        public int Alapanyag_id { get => alapanyag_id; set => alapanyag_id = value; }
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }

        public Hozzavalo(int recept_id, int alapanyag_id, int mennyiseg)
        {
            Recept_id = recept_id;
            Alapanyag_id = alapanyag_id;
            Mennyiseg = mennyiseg;
        }

        public Hozzavalo()
        { 
        
        }
    }
}
