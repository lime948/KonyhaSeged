namespace KonyhaSeged.ReceptModels
{
    /// <summary>
    /// Alapanyag osztály az `alapanyagok` tábla alapján
    /// </summary>
    internal class Alapanyag
    {
        /// <summary>
        /// Az alapanyag azonosítója
        /// </summary>
        public int Alapanyag_id { get; set; }

        /// <summary>
        /// Az alapanyag neve
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Alapanyag konstruktora paraméterekkel
        /// </summary>
        /// <param name="alapanyag_id">Az alapanyag azonosítója</param>
        /// <param name="nev">Az alapanyag neve</param>
        public Alapanyag(int alapanyag_id, string nev)
        {
            Alapanyag_id = alapanyag_id;
            Nev = nev;
        }

        /// <summary>
        /// Alapanyag konstruktora paraméterek nélkül
        /// </summary>
        public Alapanyag()
        {
        }
    }
}
