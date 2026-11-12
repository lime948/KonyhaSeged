using KonyhaSeged.ReceptModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace KonyhaSeged.Services
{
    internal class DatabaseService
    {
        private const string ConnectionString = "server=localhost;uid=root;pwd=;database=konyhaseged";

        /// <summary>
        /// Visszaadja az összes alapanyagot az adatbázisból.
        /// </summary>
        /// <returns>Egy Alapanyag objektumokat tartalmazó listát</returns>
        public List<Alapanyag> ReadAlapanyagok()
        {
            // Tárolólista létrehozása
            List<Alapanyag> alapanyagok = new List<Alapanyag>();
            
            // Alapanyagok lekérése
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
                {
                    myConnection.Open();

                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT * FROM alapanyagok;"
                    })
                    {
                        // Alapanyag objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int alapanyag_id = myReader.GetInt32("alapanyag_id");
                                string nev = myReader.GetString("nev");
                                alapanyagok.Add(new Alapanyag(alapanyag_id, nev));
                            }
                        }
                    }
                }
            }

            // Sikertelen lekérés esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
            }

            // Lista visszaadása
            return alapanyagok;
        }

        /// <summary>
        /// Visszaadja az összes hozzávalót az adatbázisból.
        /// </summary>
        /// <returns>Egy Hozzavalo objektumokat tartalmazó listát</returns>
        public List<Hozzavalo> ReadHozzavalok()
        {
            // Tárolólista létrehozása
            List<Hozzavalo> hozzavalok = new List<Hozzavalo>();

            // Hozzavalok lekérése
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
                {
                    myConnection.Open();

                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT * FROM hozzavalok;"
                    })
                    {
                        // Hozzavalo objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int recept_id = myReader.GetInt32("recept_id");
                                int alapanyag_id = myReader.GetInt32("alapanyag_id");
                                int mennyiseg = myReader.GetInt32("mennyiseg");

                                hozzavalok.Add(new Hozzavalo(recept_id, alapanyag_id, mennyiseg));
                            }
                        }
                    }
                }
            }

            // Sikertelen lekérés esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
            }

            // Lista visszaadása
            return hozzavalok;
        }

        /// <summary>
        /// Visszaadja az összes receptet az adatbázisból.
        /// </summary>
        /// <returns>Egy Recept objektumokat tartalmazó listát</returns>
        public List<Recept> ReadReceptek()
        {
            // Tárolólista létrehozása
            List<Recept> receptek = new List<Recept>();

            // Receptek lekérése
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
                {
                    myConnection.Open();

                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT * FROM receptek;"
                    })
                    {
                        // Hozzavalo objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int recept_id = myReader.GetInt32("recept_id");
                                string nev = myReader.GetString("nev");
                                string leiras = myReader.GetString("leiras");
                                int elkeszitesi_ido = myReader.GetInt32("elkeszitesi_ido");
                                string kategoria = myReader.GetString("kategoria");
                                string allergenek = myReader.GetString("allergenek");

                                receptek.Add(new Recept(recept_id, nev, leiras, elkeszitesi_ido, kategoria, allergenek));
                            }
                        }
                    }
                }
            }

            // Sikertelen lekérés esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
            }

            // Lista visszaadása
            return receptek;
        }
    }
}
