namespace KonyhaSeged.ReceptModels
{
    /// <summary>
    /// Recept osztály a `receptek` tábla alapján
    /// </summary>
    internal class Recept
    {
        /// <summary>
        /// A recept azonosítója
        /// </summary>
        private int recept_id;

        /// <summary>
        /// A recept neve
        /// </summary>
        private string nev;

        /// <summary>
        /// A recept leírása
        /// </summary>
        private string leiras;

        /// <summary>
        /// A recept elkészítési ideje percben
        /// </summary>
        private int elkeszitesi_ido;

        /// <summary>
        /// A recept kategóriája
        /// </summary>
        private string kategoria;

        /// <summary>
        /// A recept allergénei
        /// </summary>
        private string allergenek;

        /// <summary>
        /// A recept azonosítója
        /// </summary>
        public int Recept_id { get => recept_id; set => recept_id = value; }

        /// <summary>
        /// A recept neve
        /// </summary>
        public string Nev { get => nev; set => nev = value; }

        /// <summary>
        /// A recept leírása
        /// </summary>
        public string Leiras { get => leiras; set => leiras = value; }

        /// <summary>
        /// A recept elkészítési ideje percben
        /// </summary>
        public int Elkeszitesi_ido { get => elkeszitesi_ido; set => elkeszitesi_ido = value; }

        /// <summary>
        /// A recept kategóriája
        /// </summary>
        public string Kategoria { get => kategoria; set => kategoria = value; }

        /// <summary>
        /// A recept allergénei
        /// </summary>
        public string Allergenek { get => allergenek; set => allergenek = value; }

        /// <summary>
        /// Recept konstruktora paraméterekkel
        /// </summary>
        /// <param name="recept_id">A recept azonosítója</param>
        /// <param name="nev">A recept neve</param>
        /// <param name="leiras">A recept leírása</param>
        /// <param name="elkeszitesi_ido">A recept elkészítési ideje percben</param>
        /// <param name="kategoria">A recept kategóriája</param>
        /// <param name="allergenek">A recept allergénei</param>
        public Recept(int recept_id, string nev, string leiras, int elkeszitesi_ido, string kategoria, string allergenek)
        {
            Recept_id = recept_id;
            Nev = nev;
            Leiras = leiras;
            Elkeszitesi_ido = elkeszitesi_ido;
            Kategoria = kategoria;
            Allergenek = allergenek;
        }

        /// <summary>
        /// Recept konstruktora paraméterek nélkül
        /// </summary>
        public Recept()
        {

        }
    }
}
