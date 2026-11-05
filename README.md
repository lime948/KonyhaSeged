# KonyhaSeged 🍳

A **KonyhaSeged** egy konyhai folyamatokat, recepteket és kamrakészletet nyilvántartó alkalmazás, amely .NET Framework alapokon, MySQL adatbázis-háttérrel működik, kiegészítve egy modern HTML alapú webes vagy hibrid felülettel.

---

## ✨ Funkciók
* 📖 **Receptkezelő:** Receptek hozzáadása, szerkesztése, törlése és kategorizálása.
* 🥕 **Alapanyag és Kamra Kezelés:** Aktuális készletek követése és figyelmeztetés, ha valami elfogyóban van.
* 🛒 **Bevásárlólista Generáló:** A hiányzó alapanyagok alapján automatikus vagy manuális bevásárlólista összeállítása.
* 🌐 **Hibrid/Webes felület:** Felhasználóbarát HTML/CSS felület a könnyebb kezelhetőségért. (TERVEZETT)

---

## 🛠️ Technológiai stack

### Backend & Adatbázis
* **Keretrendszer:** .NET Framework 4.8.1
* **Nyelv:** C#
* **Adatbázis:** MySQL
* **Fejlesztőkörnyezet:** Visual Studio 2022

### Frontend (Tervezés alatt)
* **Technológiák:** HTML5, CSS3, JavaScript
* **Szerkesztő:** Visual Studio Code (VSC), Visual Studio 2022/2026

---
<!--
## 🚀 Telepítés és Beállítás

### 1. Előfeltételek
Győződj meg róla, hogy a számítógépedre telepítve vannak az alábbiak:
* **Visual Studio 2022** (.NET asztali fejlesztés csomaggal)
* **Visual Studio Code** (a HTML/frontend szerkesztéséhez)
* **MySQL Server** és **MySQL Workbench** (vagy XAMPP / phpMyAdmin)

### 2. Adatbázis inicializálása
1. Nyisd meg a MySQL Workbench-et vagy a preferált adatbázis-kezelődet.
2. Importáld és futtasd a projekt gyökerében található `konyhaseged.sql` fájlt az adatbázis sémájának és a kiinduló adatoknak a létrehozásához.

### 3. A backend projekt futtatása
1. Klónozd a tárolót:
   ```bash
   git clone https://github.com
   ```
2. Nyisd meg a `KonyhaSeged.sln` fájlt Visual Studio-ban.
3. Ellenőrizd a MySQL adatbázis-kapcsolati karakterláncot (*Connection String*) az `App.config` fájlban, és írd át a saját MySQL felhasználónevedre és jelszavadra.
4. Nyomj egy `F5`-öt a projekt futtatásához.

### 4. A frontend (HTML) megnyitása
1. Nyisd meg a projekt frontend mappáját **Visual Studio Code**-ban.
2. A HTML oldalak teszteléséhez ajánlott a VSC **Live Server** bővítményének használata.

---
-->

## 📁 Projekt struktúra
* `KonyhaSeged/` - A C# forráskódot és a backend logikát tartalmazó főmappa.
* `KonyhaSeged.sln` - Visual Studio Solution fájl.
* `konyhaseged.sql` - A MySQL adatbázis sémáját tartalmazó SQL szkript.
* `.gitignore` & `.gitattributes` - Git konfigurációs fájlok.
