﻿using KonyhaSeged.ReceptModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace KonyhaSeged.Services
{
    internal class DatabaseService
    {
        // =====================================================================
        //  KAPCSOLAT
        // =====================================================================

        private const string ConnectionString = "server=localhost;uid=root;pwd=;database=konyhaseged";

        /// <summary>
        /// Létrehoz és megnyit egy új MySQL kapcsolatot.
        /// A hívó felelőssége a using/Dispose.
        /// </summary>
        private MySqlConnection GetOpenConnection()
        {
            MySqlConnection myConnection = new MySqlConnection(ConnectionString);
            myConnection.Open();
            return myConnection;
        }

        /// <summary>
        /// Végrehajt egy nem-lekérdező parancsot (INSERT/UPDATE/DELETE)
        /// a megadott paraméterekkel, és visszaadja az érintett sorok számát.
        /// </summary>
        /// <returns>Az érintett sorok száma, hiba esetén -1</returns>
        private int ExecuteNonQuery(string commandText, params MySqlParameter[] parameters)
        {
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterekkel (SQL injection ellen védve)
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = commandText
                    })
                    {
                        // Paraméterek hozzáadása (@parameter placeholder-ekhez)
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // Parancs végrehajtása
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            // Sikertelen művelet esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // =====================================================================
        //  ALAPANYAGOK  –  CRUD
        // =====================================================================

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
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT alapanyag_id, nev FROM alapanyagok;"
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
        /// Visszaad egy alapanyagot azonosító alapján, vagy null-t, ha nincs ilyen.
        /// </summary>
        public Alapanyag ReadAlapanyagById(int alapanyagId)
        {
            // Alapanyag lekérése
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterrel
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT alapanyag_id, nev FROM alapanyagok WHERE alapanyag_id = @alapanyag_id;"
                    })
                    {
                        // Paraméter hozzáadása (SQL injection ellen védve)
                        cmd.Parameters.AddWithValue("@alapanyag_id", alapanyagId);

                        // Alapanyag objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                int id = myReader.GetInt32("alapanyag_id");
                                string nev = myReader.GetString("nev");
                                return new Alapanyag(id, nev);
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

            // Nincs találat
            return null;
        }

        /// <summary>
        /// Új alapanyag beszúrása.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool CreateAlapanyag(string nev)
        {
            // Alapanyag beszúrása paraméterezett paranccsal
            return ExecuteNonQuery(
                "INSERT INTO alapanyagok (nev) VALUES (@nev);",
                new MySqlParameter("@nev", nev)) > 0;
        }

        /// <summary>
        /// Meglévő alapanyag nevének módosítása.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool UpdateAlapanyag(int alapanyagId, string nev)
        {
            // Alapanyag módosítása paraméterezett paranccsal
            return ExecuteNonQuery(
                "UPDATE alapanyagok SET nev = @nev WHERE alapanyag_id = @alapanyag_id;",
                new MySqlParameter("@nev", nev),
                new MySqlParameter("@alapanyag_id", alapanyagId)) > 0;
        }

        /// <summary>
        /// Alapanyag törlése azonosító alapján.
        /// A hozzavalok sorok a FOREIGN KEY CASCADE miatt automatikusan törlődnek.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool DeleteAlapanyag(int alapanyagId)
        {
            // Alapanyag törlése paraméterezett paranccsal
            return ExecuteNonQuery(
                "DELETE FROM alapanyagok WHERE alapanyag_id = @alapanyag_id;",
                new MySqlParameter("@alapanyag_id", alapanyagId)) > 0;
        }

        // =====================================================================
        //  HOZZÁVALÓK  –  CRUD
        // =====================================================================

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
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT recept_id, alapanyag_id, mennyiseg FROM hozzavalok;"
                    })
                    {
                        // Hozzavalo objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int recept_id = myReader.GetInt32("recept_id");
                                int alapanyag_id = myReader.GetInt32("alapanyag_id");
                                string mennyiseg = myReader.GetString("mennyiseg");

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
        /// Visszaadja egy adott recept összes hozzávalóját.
        /// </summary>
        public List<Hozzavalo> ReadHozzavalokByRecept(int receptId)
        {
            // Tárolólista létrehozása
            List<Hozzavalo> hozzavalok = new List<Hozzavalo>();

            // Hozzavalok lekérése recept szerint
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterrel
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT recept_id, alapanyag_id, mennyiseg FROM hozzavalok WHERE recept_id = @recept_id;"
                    })
                    {
                        // Paraméter hozzáadása (SQL injection ellen védve)
                        cmd.Parameters.AddWithValue("@recept_id", receptId);

                        // Hozzavalo objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int r_id = myReader.GetInt32("recept_id");
                                int a_id = myReader.GetInt32("alapanyag_id");
                                string mennyiseg = myReader.GetString("mennyiseg");

                                hozzavalok.Add(new Hozzavalo(r_id, a_id, mennyiseg));
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
        /// Új hozzávaló kapcsolat beszúrása egy recepthez.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool CreateHozzavalo(int receptId, int alapanyagId, string mennyiseg)
        {
            // Hozzavalo beszúrása paraméterezett paranccsal
            return ExecuteNonQuery(
                "INSERT INTO hozzavalok (recept_id, alapanyag_id, mennyiseg) " +
                "VALUES (@recept_id, @alapanyag_id, @mennyiseg);",
                new MySqlParameter("@recept_id", receptId),
                new MySqlParameter("@alapanyag_id", alapanyagId),
                new MySqlParameter("@mennyiseg", mennyiseg)) > 0;
        }

        /// <summary>
        /// Hozzávaló mennyiségének módosítása.
        /// A hozzavalok táblának nincs saját kulcsa, ezért a (recept_id, alapanyag_id)
        /// párost használjuk azonosításra.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool UpdateHozzavalo(int receptId, int alapanyagId, string mennyiseg)
        {
            // Hozzavalo módosítása paraméterezett paranccsal
            return ExecuteNonQuery(
                "UPDATE hozzavalok SET mennyiseg = @mennyiseg " +
                "WHERE recept_id = @recept_id AND alapanyag_id = @alapanyag_id;",
                new MySqlParameter("@mennyiseg", mennyiseg),
                new MySqlParameter("@recept_id", receptId),
                new MySqlParameter("@alapanyag_id", alapanyagId)) > 0;
        }

        /// <summary>
        /// Hozzávaló kapcsolat törlése.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool DeleteHozzavalo(int receptId, int alapanyagId)
        {
            // Hozzavalo törlése paraméterezett paranccsal
            return ExecuteNonQuery(
                "DELETE FROM hozzavalok " +
                "WHERE recept_id = @recept_id AND alapanyag_id = @alapanyag_id;",
                new MySqlParameter("@recept_id", receptId),
                new MySqlParameter("@alapanyag_id", alapanyagId)) > 0;
        }

        // =====================================================================
        //  RECEPTEK  –  CRUD
        // =====================================================================

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
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT recept_id, nev, leiras, elkeszitesi_ido, kategoria, allergenek FROM receptek;"
                    })
                    {
                        // Recept objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                int recept_id = myReader.GetInt32("recept_id");
                                string nev = myReader.GetString("nev");
                                string leiras = myReader.GetString("leiras");
                                int elkeszitesi_ido = myReader.GetInt32("elkeszitesi_ido");
                                string kategoria = myReader.GetString("kategoria");

                                // Az allergenek oszlop NULL-t is tartalmazhat (DEFAULT NULL)
                                string allergenek = myReader.IsDBNull(myReader.GetOrdinal("allergenek"))
                                    ? null
                                    : myReader.GetString("allergenek");

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

        /// <summary>
        /// Visszaad egy receptet azonosító alapján, vagy null-t, ha nincs ilyen.
        /// </summary>
        public Recept ReadReceptById(int receptId)
        {
            // Recept lekérése
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterrel
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "SELECT recept_id, nev, leiras, elkeszitesi_ido, kategoria, allergenek " +
                                      "FROM receptek WHERE recept_id = @recept_id;"
                    })
                    {
                        // Paraméter hozzáadása (SQL injection ellen védve)
                        cmd.Parameters.AddWithValue("@recept_id", receptId);

                        // Recept objektum létrehozása a beolvasott adatokból
                        using (MySqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                int id = myReader.GetInt32("recept_id");
                                string nev = myReader.GetString("nev");
                                string leiras = myReader.GetString("leiras");
                                int elkeszitesi_ido = myReader.GetInt32("elkeszitesi_ido");
                                string kategoria = myReader.GetString("kategoria");

                                // Az allergenek oszlop NULL-t is tartalmazhat
                                string allergenek = myReader.IsDBNull(myReader.GetOrdinal("allergenek"))
                                    ? null
                                    : myReader.GetString("allergenek");

                                return new Recept(id, nev, leiras, elkeszitesi_ido, kategoria, allergenek);
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

            // Nincs találat
            return null;
        }

        /// <summary>
        /// Új recept beszúrása. Az új recept_id-t az adatbázis generálja (AUTO_INCREMENT).
        /// </summary>
        /// <returns>Az új recept_id, vagy -1 hiba esetén</returns>
        public int CreateRecept(string nev, string leiras, int elkeszitesiIdo, string kategoria, string allergenek)
        {
            // Recept beszúrása
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterekkel
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "INSERT INTO receptek (nev, leiras, elkeszitesi_ido, kategoria, allergenek) " +
                                      "VALUES (@nev, @leiras, @elkeszitesi_ido, @kategoria, @allergenek);"
                    })
                    {
                        // Paraméterek hozzáadása (SQL injection ellen védve)
                        cmd.Parameters.AddWithValue("@nev", nev);
                        cmd.Parameters.AddWithValue("@leiras", leiras);
                        cmd.Parameters.AddWithValue("@elkeszitesi_ido", elkeszitesiIdo);
                        cmd.Parameters.AddWithValue("@kategoria", kategoria);

                        // NULL engedélyezett az allergenek oszlopon
                        cmd.Parameters.AddWithValue("@allergenek",
                            (object)allergenek ?? DBNull.Value);

                        // Parancs végrehajtása
                        cmd.ExecuteNonQuery();

                        // Az AUTO_INCREMENT által generált azonosító visszaadása
                        return (int)cmd.LastInsertedId;
                    }
                }
            }

            // Sikertelen beszúrás esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Meglévő recept módosítása.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool UpdateRecept(int receptId, string nev, string leiras, int elkeszitesiIdo, string kategoria, string allergenek)
        {
            // Recept módosítása
            try
            {
                // Csatlakozás az adatbázishoz
                using (MySqlConnection myConnection = GetOpenConnection())
                {
                    // MySQL parancs létrehozása paraméterekkel
                    using (MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = myConnection,
                        CommandText = "UPDATE receptek SET nev = @nev, leiras = @leiras, " +
                                      "elkeszitesi_ido = @elkeszitesi_ido, kategoria = @kategoria, " +
                                      "allergenek = @allergenek WHERE recept_id = @recept_id;"
                    })
                    {
                        // Paraméterek hozzáadása (SQL injection ellen védve)
                        cmd.Parameters.AddWithValue("@nev", nev);
                        cmd.Parameters.AddWithValue("@leiras", leiras);
                        cmd.Parameters.AddWithValue("@elkeszitesi_ido", elkeszitesiIdo);
                        cmd.Parameters.AddWithValue("@kategoria", kategoria);
                        cmd.Parameters.AddWithValue("@allergenek",
                            (object)allergenek ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@recept_id", receptId);

                        // Parancs végrehajtása
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }

            // Sikertelen módosítás esetén
            catch (MySqlException ex)
            {
                // Hibaüzenet kiírása
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Recept törlése azonosító alapján.
        /// A hozzavalok sorok a FOREIGN KEY CASCADE miatt automatikusan törlődnek.
        /// </summary>
        /// <returns>true, ha sikeres volt</returns>
        public bool DeleteRecept(int receptId)
        {
            // Recept törlése paraméterezett paranccsal
            return ExecuteNonQuery(
                "DELETE FROM receptek WHERE recept_id = @recept_id;",
                new MySqlParameter("@recept_id", receptId)) > 0;
        }
    }
}