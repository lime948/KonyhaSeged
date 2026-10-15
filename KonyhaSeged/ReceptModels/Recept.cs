namespace KonyhaSeged.ReceptModels
{
    // Recept osztály a `receptek` tábla alapján
    // field és Property név = Adatbázisban oszlopnév
    internal class Recept
    {
        private int recept_id;
        private string nev;
        private string leiras;
        private int elkeszitesi_ido;
        private string kategoria;
        private string allergenek;

        public int Recept_id { get => recept_id; set => recept_id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Leiras { get => leiras; set => leiras = value; }
        public int Elkeszitesi_ido { get => elkeszitesi_ido; set => elkeszitesi_ido = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Allergenek { get => allergenek; set => allergenek = value; }

        public Recept(int recept_id, string nev, string leiras, int elkeszitesi_ido, string kategoria, string allergenek)
        {
            Recept_id = recept_id;
            Nev = nev;
            Leiras = leiras;
            Elkeszitesi_ido = elkeszitesi_ido;
            Kategoria = kategoria;
            Allergenek = allergenek;
        }

        public Recept()
        {

        }
    }
}
