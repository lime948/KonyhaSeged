namespace KonyhaSeged.ReceptModels
{
    /// <summary>
    /// Hozzavalo osztály a `hozzavalok` tábla alapján
    /// </summary>
    internal class Hozzavalo
    {
        /// <summary>
        /// A hozzávaló által összeköötött recept azonosítója
        /// </summary>
        private int recept_id;

        /// <summary>
        /// Az alapanyag azonosítója
        /// </summary>
        private int alapanyag_id;

        /// <summary>
        /// A hozzávaló mennyisége
        /// </summary>
        private int mennyiseg;

        /// <summary>
        /// A hozzávaló által összeköötött recept azonosítója
        /// </summary>
        public int Recept_id { get => recept_id; set => recept_id = value; }

        /// <summary>
        /// Az alapanyag azonosítója
        /// </summary>
        public int Alapanyag_id { get => alapanyag_id; set => alapanyag_id = value; }

        /// <summary>
        /// A hozzávaló mennyisége
        /// </summary>
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }

        /// <summary>
        /// Hozzavalo konstruktora paraméterekkel
        /// </summary>
        /// <param name="recept_id">A hozzávaló által összeköötött recept azonosítója</param>
        /// <param name="alapanyag_id">Az alapanyag azonosítója</param>
        /// <param name="mennyiseg">A hozzávaló mennyisége</param>
        public Hozzavalo(int recept_id, int alapanyag_id, int mennyiseg)
        {
            Recept_id = recept_id;
            Alapanyag_id = alapanyag_id;
            Mennyiseg = mennyiseg;
        }

        /// <summary>
        /// Hozzavalo konstruktora paraméterek nélkül
        /// </summary>
        public Hozzavalo()
        { 
        
        }
    }
}
