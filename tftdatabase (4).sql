-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 26, 2025 at 08:03 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tftdatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `anomalies`
--

CREATE TABLE `anomalies` (
  `AnomalyId` int(11) NOT NULL,
  `AnomalyName` varchar(50) DEFAULT NULL,
  `AnomalyEffect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `anomalies`
--

INSERT INTO `anomalies` (`AnomalyId`, `AnomalyName`, `AnomalyEffect`) VALUES
(1, 'Arcana Elárasztása', 'Szerezz Képesség Erőt, amely egyenlő a Mágikus Ellenállás 25%-ával. Szerezz 50 Mágikus Ellenállást.'),
(2, 'Támadás Szakértő', 'Ez a bajnok 60%-kal több Támadási Sebességet kap minden forrásból.'),
(3, 'Páncél Lavina', 'Szerezz Támadási Sebességet, amely egyenlő a Páncél 25%-ával. Szerezz 50 Páncélt.'),
(4, 'Avarecia Inkarnációja', 'Szerezz 5 aranyat. Szerezz 15%-os Sebzés Növelést, és 1%-ot minden 2 arany után, amit birtokolsz (maximum 40%).'),
(5, 'Berserker Harag', 'Szerezz 20 Képesség Erőt és 20%-os Támadási Sebességet. Háromszorozódik, ha 50%-os élet alatt vagy.'),
(6, 'Terrorista', 'Szerezz 18%-os Sebzés Növelést, duplázódik olyan egységek ellen, amelyek alacsonyabb csillagszinttel rendelkeznek.'),
(7, 'Bastion', 'Szerezz 30 Páncélt és 30 Mágikus Ellenállást. Háromszorozódik, ha 50%-os élet felett vagy.'),
(8, 'Hívó Kártya', 'Szerezz egy jelvényt, amely egy nem egyedi tulajdonságnak megfelelő, ezen bajnoktól származik.'),
(9, 'A Világ Középpontja', 'Szerezz 6 csillagot, amelyek köröznek ezen bajnok körül. Minden csillag 70 mágikus sebzést okoz és gyorsabban kering, ahogy Támadási Sebességük növekszik.'),
(10, 'Visszatérés Története', 'Szerezz 5%-os Sebzés Növelést minden 10 játékos életenként, amit elvesztettél ebben a játékban.'),
(11, 'Kozmikus Ritmus', 'Már nem nyersz Manát, hanem helyette minden 4 másodpercben aktiválják a Képességét.'),
(12, 'Öld ki a gyengéket', 'Szerezz akár 100%-os Kritikus Ütési Esélyt a célpont hiányzó Élete alapján. Minden 3 másodpercben célozd meg a legkevesebb életerővel rendelkező ellenséget a hatókörben.'),
(13, 'Mély Gyökerek', 'Szerezz 700 Életet, 25 Páncélt és 25 Mágikus Ellenállást. Nem tudnak mozogni vagy leblokkolni, és behúzzák a célpontjukat a hatókörbe.'),
(14, 'Védelmi Szakértő', 'Ez a bajnok 40%-kal több Páncélt és Mágikus Ellenállást kap minden forrásból.'),
(15, 'Leugrás', 'Első használatkor ugorj az ellenségekre, és bénítsd meg őket 2-hex sugárban 1,5 másodpercre, miközben 35%-os Támadási Sebességet és 20%-os Omnivampot kapsz.'),
(16, 'Sárkánylélek', 'Ennek a bajnoknak az első támadása egy új célpont ellen egy Sárkánylélek robbanást indít, amely 20%-os maximális Élet Igaz Sebzést okoz.'),
(17, 'Drámai Belépés', 'Harci kezdés: Ugrás a csatatérről. 6 másodperc múlva érkezz vissza, 60%-kal megnövelt maximális Élettel, és bénítsd meg az összes ellenséget 1,5 másodpercre.'),
(18, 'Páros Fegyverkezelés', 'Szerezz 2 teljesített tárgyat, amelyek megfelelnek ennek a bajnok szerepének.'),
(19, 'Sas Szem', 'Szerezz +1 hatótávolságot. Minden 2 másodpercben, amikor a hős nem mozog, szerezz 6% Támadási Sebzést.'),
(20, 'Energia Felszívás', 'Szerezz 30 Képesség Erőt. Minden alkalommal, amikor egy szövetséges meghal, szerezz 5%-ot az ő Képesség Erőből.'),
(21, 'Navori Lényege', 'A maximális mana csökkentve 10%-kal, és minden alkalommal, amikor a hős használja a Képességét, nő a mana 10%-kal (maximum 40%).'),
(22, 'Tűzgolyó', 'Minden 60 manáért dobj egy 2-hexes tűzgolyót, amely 7%-os maximális egészség valós sebzést okoz és 5 másodpercig ég.'),
(23, 'Barátság Ereje', 'Szerezz 1%-os Sebzés Növelést minden csillag szinten az asztalon. Háromcsillagos hősök 8%-ot adnak.'),
(24, 'Erősített', 'Szerezz 12%-os maximális életet. Minden 3 másodpercben, szerezz még 12%-ot (maximum 5 alkalommal).'),
(25, 'Szabad Stílus', 'Szerezz 4.5%-os Sebzés Növelést minden aktivált trait után.'),
(26, 'Óriás Méretű', 'Szerezz 1000 Életet, és hatalmasra nősz.'),
(27, 'Fejvadász', 'Szerezz 15%-os Támadási Sebességet. Minden gyilkosság után véglegesen szerezz 1%-kal többet (Hyper Roll-ban megduplázódik).'),
(28, 'Nehéz Ütés', 'A támadások bonusz fizikai sebzést okoznak, ami a hős maximális életének 20%-a (Késleltetés: 4 másodperc).'),
(29, 'Hatalom Éhsége', 'Küzdelem elején: Fogyaszd el a legközelebbi szövetségest, és szerezz 60%-ot az ő Életéből és Támadási Sebzéséből.'),
(30, 'Hipervelocitás', 'Szerezz 10%-os Támadási Sebességet. Képesség használatakor szerezz 15%-os halmozódó Támadási Sebességet a harc hátralévő részére.'),
(31, 'Ismeretlenbe', 'Ez a hős 2 körre eltűnik. Amikor visszatér, 50 Képesség Erőt és 50%-os Támadási Sebzést kap.'),
(32, 'Láthatatlanság', 'Minden 4 másodpercben válnak láthatatlanná 1 másodpercre. A következő támadásnak 100%-os Kritikus Ütési Esélye van.'),
(33, 'Gyilkos Sorozat', 'Szerezz 30 manát minden gyilkosság után.'),
(34, 'K.O.', 'Szerezz 15%-os Támadási Sebzést. Az első támadás után, miután a Képességet használod, 35%-os Kritikus Ütési Esélyt kapsz és 110%-os valós sebzést okozol.'),
(35, 'Lézer Szemek', 'Folyamatosan 80%-os Képesség Erő varázssebzést okoz minden másodpercben egy 3-hexes vonalban, és 3 másodpercig égeti az ellenségeket.'),
(36, 'Utolsó Esély', 'Első halál után, feltámadsz teljes életre, kapsz 50%-os Támadási Sebességet és 20%-os Omnivampot, de elvesztesz 12,5%-ot az Életedből minden másodpercben.'),
(37, 'Shurima Örökség', '10 másodpercnyi küzdelem után emelkedsz, szerezz 40%-ot a maximális életedből és 60%-ot a Támadási Sebességedből.'),
(38, 'Mágus Páncél', 'Szerezz Páncélt és Varázsvédelmet, ami a Képesség Erőd 40%-a.'),
(39, 'Mágikus Szakértő', 'Ez a hős 40%-kal több Képesség Erőt szerez minden forrásból.'),
(40, 'Mágikus Képzés', 'Szerezz 20 Képesség Erőt. Képesség használatakor a csapatod minden 10 mana után 2 Képesség Erőt kap.'),
(41, 'Mini Mees', 'Szerezz 3 minit, amelyek minden 3. támadásnál 30%-os Támadási Sebzést okoznak. Támadásaik csökkentik a Páncélt 5-tel.'),
(42, 'Miniatürizálás', 'Átalakulj egy tárgyá, amely a Támadási Sebzésed, Képesség Erődet, Páncélodat és Varázsvédelmedet 50%-kal adja. A felszerelt tárgyak eltűnnek.'),
(43, 'Semmi sem Vész el', 'Amikor egy szövetséges meghal, szerezz 100%-ot az ő aktuális manájából.'),
(44, 'Ezer Vágás', 'A támadások 30 bonusz valós sebzést okoznak, plusz 15 valós sebzést minden egyes alkalommal, amikor a célpontot ezzel a hatással sebzed.'),
(45, 'Hatalom Felszívás', 'Szerezz 30%-ot a Támadási Sebzésből. Minden alkalommal, amikor egy szövetséges meghal, szerezz 5%-ot az ő Támadási Sebzéséből.'),
(46, 'Védelmi Pajzs', 'Küzdelem elején és minden 8 másodpercben: 20%-os maximális élet pajzsot adsz magadnak és a 2 legalacsonyabb életű szövetségesednek 5 másodpercig.'),
(47, 'Visszanyomó', 'Szerezz 30%-os Támadási Sebességet. Képesség használatakor visszalököd a célt, ha 2 hexen belül van.'),
(48, 'Rák Ismerős', 'Halálkor egy rákot idézel, ami az ő maximális életének, Páncéljának és Varázsvédelmének 125%-át örökli.'),
(49, 'Oszd Meg Energiádat', 'Küzdelem elején: Adj 8%-ot a Támadási Sebzésedből, Képesség Erődből, Életedből, Páncélodból és Varázsvédelmedből a szomszédos szövetségeseidnek.'),
(50, 'Nyálkás Idő', 'Minden 2 másodpercben varázssebzést okozol egy 1-hexes körben, ami az ő maximális élete 100%-a, és 100%-ban gyógyítja meg a hőst a sebzés mértékében.'),
(51, 'Lassú Főzés', 'Minden másodpercben varázssebzést okozol egy 1-hexes körben, ami az ő maximális élete 4%-a. A sugár minden 6 másodpercben növekszik.'),
(52, 'Kövek Páncélja', 'Küzdelem elején: Szerezz 225 Páncélt és Varázsvédelmet. Minden másodpercben csökkent a bónusz 10-tel.'),
(53, 'Erő Edzés', 'Szerezz 20%-os Támadási Sebzést. Minden 3 támadás után a csapatod 2%-os Támadási Sebzést kap.'),
(54, 'A Befejező', 'Ez a hős támadásai és Képességei végleg elpusztítják az ellenséges hősöket 15%-os Élet alatti állapotban.'),
(55, 'Tüskés Bőr', 'Szerezz 60 Páncélt és 60 Varázsvédelmet. Amikor sebzést kapsz, okozz a blokkolt sebzés 20%-ának megfelelő varázssebzést a szomszédos ellenségeknek.'),
(56, 'Titanikus Ütések', 'A támadások további 30%-os Támadási Sebzést okoznak a célnak és a szomszédos ellenségeknek.'),
(57, 'Fagy Ujjnyoma', 'A Képesség használatok 20%-os Chill hatást alkalmaznak (csökkentik a Támadási Sebességet) az ellenségeken 4 másodpercre. Ha a Chill hatás alatt álló ellenség meghal, megdermesztik a legközelebbi ellenséget 1 másodpercre.'),
(58, 'Végső Hős', 'Szerezd meg egy 3 csillagos 1 költséges hősöd 4 csillagra!'),
(59, 'Megállíthatatlan Erő', 'Első gyilkosság után, üsd le a következő célt, és bénítsd meg őt 1,5 másodpercre, majd gyógyítsd meg az életed 10%-át.'),
(60, 'Farkas Ismerősök', 'Idézz meg 2 farkast, amelyek a hős Támadási Sebzésének 25%-ával támadnak.');

-- --------------------------------------------------------

--
-- Table structure for table `augments`
--

CREATE TABLE `augments` (
  `AugmentId` int(11) NOT NULL,
  `AugmentName` varchar(40) DEFAULT NULL,
  `AugmentRarity` varchar(15) DEFAULT NULL,
  `AugmentEffect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `augments`
--

INSERT INTO `augments` (`AugmentId`, `AugmentName`, `AugmentRarity`, `AugmentEffect`) VALUES
(1, 'Aranykeresés', 'Arany', 'Az Anomália által evolválódott bajnokok minden 2 megölt ellenfél után 2 aranyat adnak. Emellett 10 ingyenes újrapörgetést kapsz.'),
(2, 'A Mágikus Pörgetés', 'Arany', 'Pörögj 3 kockával. Kapsz jutalmakat az összegük alapján.'),
(3, 'Akadémiai Kutatás', 'Arany', 'Valahányszor építesz egy tárgyat, helyette egy kész tárgy kovácsműhelyét kapod. Az a kovácsműhely mindig egy Akadémiai tárgyat és az épített tárgyat kínálja. Kapsz 2 véletlenszerű komponenst. Kapsz egy Luxot és egy Ezrealt.'),
(4, 'Akadémiai Címert', 'Arany', 'Kapsz egy Akadémiai Emblémát és egy Leonát.'),
(5, 'Akadémiai Korona', 'Prizmatikus', 'Kapsz egy Akadémiai Emblémát és egy véletlenszerű szponzorált tárgyat.'),
(6, 'Adrenalin Lökés', 'Arany', 'A harc kezdetekor és minden 6 másodpercben minden Gyorscsapásos 85%-kal gyorsabban támad 2,50 másodpercig. Kapsz egy Nocturnet és egy Akalit.'),
(7, 'Minden, Ami Csillog', 'Arany', 'Válassz egy aranyat generáló Műtárgyat és kapsz egy Magnetikus Eltávolítót. A maximális kamatod 7-re nő.'),
(8, 'Minden, Ami Csillog+', 'Arany', 'Válassz egy aranyat generáló Műtárgyat. Kapsz egy Magnetikus Eltávolítót és 4 aranyat. A maximális kamatod 7-re nő.'),
(9, 'Kamat', 'Arany', 'Többlet arany, amit minden 10 arany megtakarítása után kapsz.'),
(10, 'Lesből Támadó Címer', 'Arany', 'Kapsz egy Lesből Támadó Emblémát és egy Camille-t.'),
(11, 'Lesből Támadó Korona', 'Prizmatikus', 'Kapsz egy Lesből Támadó Emblémát, egy Igazság Kezét és egy Camille-t.'),
(12, 'Egy Fenséges Kaland', 'Prizmatikus', 'Kapsz három 2 költségű bajnokot. Ha kettőt közülük 3 csillagosra fejlesztesz, kapsz egy loot-tel teli gömböt. Kapsz 6 újrapörgetést.'),
(13, 'Haragproblémák', 'Prizmatikus', 'Minden jelenlegi és jövőbeli befejezett tárgyad Guinsoo Haragpengékké alakul, amelyek 35 Páncélt és Mágikus Ellenállást adnak. Minden 2 Haragpengés halmozódás 1%-kal növeli a Támadó Sebzést és Képesség Erőt.'),
(14, 'Még Egy Anomália', 'Arany', 'A 4-6-os Anomália kör után kapsz egy tárgyat, amely megkettőzi a kiválasztott Anomália Hatást az arra felszerelt bajnokon.'),
(15, 'Mágikus Megtorlás', 'Arany', 'Amikor a Mágusok meghalnak, 300%-át a Képesség Erőjüknek mágikus sebzésként osztják ki az összes szomszédos egységre. Kapsz egy Vladimirt.'),
(16, 'Műtárgygyár', 'Prizmatikus', 'Minden kör elején a padon lévő befejezett tárgyaid véletlenszerű Műtárgy tárgyakká alakulnak. Kapsz egy Műtárgy Kovácsműhelyt és 2 Eltávolítót.'),
(17, 'Tüzér Címer', 'Arany', 'Kapsz egy Tüzér Emblémát és egy Tristanát.'),
(18, 'Tüzér Korona', 'Prizmatikus', 'Kapsz egy Tüzér Emblémát, egy Runaan Hurrikánt és egy Tristanát.'),
(19, 'Milyen Áron', 'Prizmatikus', 'Azonnal a 6-os szintre lépsz és kapsz 8 XP-t. Nem választhatod meg a jövőbeli kiegészítőidet.'),
(20, 'Automata Címer', 'Arany', 'Kapsz egy Automata Emblémát és egy Nocturnet.'),
(21, 'Automata Korona', 'Prizmatikus', 'Kapsz egy Automata Emblémát, egy Guardbreaker-t és egy Nocturnet.'),
(22, 'Háttér', 'Ezüst', 'A csapatod 10%-kal gyorsabban támad, ha legalább 4 szövetségesed a hátsó két sorban kezdi a harcot.'),
(23, 'Szerencsétlen Sors Védelem', 'Arany', 'A csapatod már nem tud kritikus találatot ütni. Minden 1%-nyi Kritikus Ütés Esélyt 1%-nyi Támadó Sebzéssé alakít. Kapsz egy Küzdőkesztyűt.'),
(24, 'Kiegyensúlyozott Költségvetés', 'Arany', 'A következő 4 kör elején kapsz 7 aranyat.'),
(25, 'Kiegyensúlyozott Költségvetés+', 'Arany', 'A következő 4 kör elején kapsz 10 aranyat.'),
(26, 'Tolvajok Szalagja I', 'Ezüst', 'Kapsz egy Tolvaj Kesztyűt.'),
(27, 'Csatatéri Sebek', 'Arany', 'Minden alkalommal, amikor a Őrzők támadást kapnak, 2%-kal nő a Támadó Sebzésük. Minden alkalommal, amikor a Őrzők képesség által megsérülnek, 4 Képesség Erővel gyarapodnak. Kapsz egy Vandert.'),
(28, 'A Koldusok Válogathatnak', 'Ezüst', '+3 újrapörgetést kapsz minden egyéb kiegészítő választásához. Kapsz 7 aranyat.'),
(29, 'Öv Túltöltés', 'Prizmatikus', 'Kapsz 4 Óriás Övet. Az Óriás Övek +75 bónusz Életerőt adnak.'),
(30, 'Nagy Zsák', 'Arany', 'Kapsz 3 véletlenszerű komponenst, 2 aranyat és 1 Átformálót. Az Átformálók lehetővé teszik bármely tárgy újrakészítését.'),
(31, 'Születésnapi Ajándék', 'Prizmatikus', 'Minden szintlépéskor kapsz egy 2 csillagos bajnokot. A bajnok költség szintje a szinted mínusz 4 (minimum: 1-es költség).'),
(32, 'Fekete Rózsa Címer', 'Arany', 'Kapsz egy Fekete Rózsa Emblémát.'),
(33, 'Fekete Rózsa Korona', 'Prizmatikus', 'Kapsz egy Fekete Rózsa Emblémát, egy Morellonomicont és egy Cassiopeiát.'),
(34, 'Penge Tánc', 'Ezüst', 'Kapsz egy Ireliát. A legerősebb Irelia 40%-kal gyorsabban támad és kap egy új képességet, ami lehetővé teszi számára, hogy két célpont között elrohanva fizikai sebzést okozzon mindkettőnek.'),
(35, 'Lángoló Lélek I', 'Arany', 'Kezdő harc: A legnagyobb Támadó Sebzésű bajnokod 20 Képesség Erőt és 20%-kal gyorsabb támadási sebességet kap. Minden 3 másodpercben ismétlődik egy másik szövetségen.'),
(36, 'Lángoló Lélek II', 'Prizmatikus', 'Kezdő harc: A legnagyobb Támadó Sebzésű bajnokod 35 Képesség Erőt és 30%-kal gyorsabb támadási sebességet kap. Minden 3 másodpercben ismétlődik egy másik szövetségen.'),
(37, 'Vakító Sebesség', 'Prizmatikus', 'Kapsz egy Vörös Buffot, Guinsoo\'s Rageblade-et, egy Recurve Bow-t és egy Magnetic Remover-t. Hasznos a Támadó Karakterekhez!'),
(38, 'Égető Ütés', 'Ezüst', 'A csapatod támadásai égetik célpontjaikat 5% max. életerőjükből 5 másodperc alatt. A támadások emellett csökkentik a célpontjaik kapott gyógyítást 33%-kal.'),
(39, 'Elágazás', 'Ezüst', 'Kapsz egy véletlenszerű Emblémát és egy Átformálót. Az Átformálók lehetővé teszik bármely tárgy újrakészítését.'),
(40, 'BRB', 'Arany', 'A következő 4 körben nem hajthatsz végre műveleteket. Ezt követően kapsz 2 befejezett tárgy kovácsműhelyt.'),
(41, 'Bronz Életre I', 'Arany', 'A csapatod minden Bronz szintű tulajdonság esetén 2%-kal növeli a Sebzés Erősítést.'),
(42, 'Bronz Életre II', 'Prizmatikus', 'A csapatod 2,50%-kal növeli a Sebzés Erősítést és minden Bronz szintű tulajdonságért 1,50%-kal.'),
(43, 'Bruiser Címer', 'Arany', 'Kapsz egy Bruiser Emblémát és egy Sett-t.'),
(44, 'Bruiser Korona', 'Prizmatikus', 'Kapsz egy Bruiser Emblémát, egy Redemption-t és egy Sett-t.'),
(45, 'Brutális Bosszú', 'Arany', 'Kapsz 2 Rennis-t. A legerősebb Renni képessége 35-tel olcsóbb lesz, és arra kényszeríti, hogy a legtávolabbi ellenséghez ugorjon 2 hexán belül, 125%-os sebzést okozva a célnak, míg az útjában lévő ellenségek kevesebb sebzést kapnak.'),
(46, 'Barátot Építeni!', 'Prizmatikus', 'Kapsz egy véletlenszerű 3 csillagos 1-es költségű bajnokot és 8 aranyat.'),
(47, 'Másképp Készítve', 'Arany', 'Azok az egységeid, amelyeknek nincsenek aktív tulajdonságaik, 240-530 Életerőt és 45-60%-kal gyorsabb támadási sebességet kapnak (a jelenlegi szint alapján).'),
(48, 'Erősebb Barátok I', 'Ezüst', 'Azok a szövetségesek, akik pontosan 1 másik szövetségestől kezdik a harcot, 100 Életerőt kapnak. Amikor az a bajnok meghal, a másik 10% maximális Életerő pajzsot kap 10 másodpercre.'),
(49, 'Erősebb Barátok II', 'Arany', 'Azok a szövetségesek, akik pontosan 1 másik szövetségestől kezdik a harcot, 150 Életerőt kapnak. Amikor az a bajnok meghal, a másik 12% maximális Életerő pajzsot kap 10 másodpercre.'),
(50, 'Erősebb Barátok III', 'Prizmatikus', 'Azok a szövetségesek, akik pontosan 1 másik szövetségestől kezdik a harcot, 300 Életerőt kapnak. Amikor az a bajnok meghal, a másik 15% maximális Életerő pajzsot kap 10 másodpercre.'),
(51, 'Eltemetett Kincsek III', 'Prizmatikus', 'Kapsz egy véletlenszerű tárgy alkatrészt a következő 6 kör kezdetekor (beleértve ezt a kört is).'),
(52, 'Számított Fejlesztés', 'Prizmatikus', 'Minden harcban, a legutolsó sorban 4 véletlenszerű bajnok 35%-kal több támadási sebzést és 40 képesség-erőt kap.'),
(53, 'Káoszra Hívás', 'Prizmatikus', 'Kapsz egy erőteljes és véletlenszerű jutalmat.'),
(54, 'Célzott Ütés', 'Ezüst', 'Állítsd be a nyerési sorozatodat +4-re. Kapsz 4 aranyat.'),
(55, 'Ápoló Szövetséges', 'Ezüst', 'Kapsz egy véletlenszerű 2 költségű bajnokot most. Minden szintlépéskor ugyanazt kapod újra.'),
(56, 'Ápoló Kiválasztott', 'Prizmatikus', 'Ahogy szintet lépsz, erősebb tárgyakat kapsz. Szint 4: alkatrész kovácsműhely, Szint 6: befejezett tárgy kovácsműhely, Szint 8: válassz 1-et 5 Radiáns tárgy közül.'),
(57, 'Ápoló Kegye', 'Arany', 'Kapsz egy alkatrész kovácsműhelyt, amikor elérsz 5-ös, 6-os, 7-es és 8-as szintet. A kovácsműhely 4 választási lehetőséget kínál.'),
(58, 'Ötös Kategória', 'Arany', 'Kapsz egy Runaan\'s Hurricane-t. A Runaan\'s Hurricanes 1 extra nyilat lőnek, amelyek mindegyike az eredeti sebzés 85%-át okozza.'),
(59, 'Kém-Király Címer', 'Arany', 'Kapsz egy Kém-Király Emblémát és egy Renata Glasc-ot.'),
(60, 'Kém-Király Korona', 'Prizmatikus', 'Kapsz egy Kém-Király Emblémát, egy Nashor\'s Tooth-ot és egy Smeech-et.'),
(61, 'Tiszta Elme', 'Arany', 'Ha nincsenek bajnokok a padon a játékos harc végén, kapsz 3 XP-t.'),
(62, 'Lépcsőn Fel I', 'Ezüst', 'Minden alkalommal, amikor egy szövetséges meghal, azok a szövetségesek, akik legalább egy tulajdonságot osztanak vele, 3 Képesség Erőt, 3% Támadó Sebzést, 3 Páncélt és 3 Magic Resist-et kapnak.'),
(63, 'Lépcsőn Fel II', 'Arany', 'Minden alkalommal, amikor egy szövetséges meghal, azok a szövetségesek, akik legalább egy tulajdonságot osztanak vele, 5 Képesség Erőt, 5% Támadó Sebzést, 5 Páncélt és 5 Magic Resist-et kapnak.'),
(64, 'Óramű Sebesség Növelő', 'Arany', 'A csapatod minden 3 másodpercben 10%-kal gyorsabb támadási sebességet kap a harcban.'),
(65, 'Klónozó Létesítmény', 'Arany', 'Erősíts meg egy hexát a tábla közepén. Hozz létre egy klónt ugyanabból a bajnokból 70%-os élettel és 20%-kal magasabb Mana költséggel.'),
(66, 'Zűrzavaros Elme', 'Arany', 'Nyerd meg 4 véletlenszerű 1-cost bajnokot most. Ha a padod tele van a játékos harc végén, szerezz 3 XP-t.'),
(67, 'Harci Orvos', 'Ezüst', 'Nyerd meg egy Steb-et. A legerősebb Steb képességének Mana költsége 10-nel csökken, de többé nem gyógyít. Steb varázslata 30%-os Omnivampot biztosít, és háromszor üti a célt, mindegyik ütés 70%-os sebzéssel.'),
(68, 'Komponens Büfé', 'Ezüst', 'Bármikor, amikor egy komponenst kapsz, helyette komponens anvil-t kapsz. Nyerd meg egy véletlenszerű komponenst. Az anvil 4 választási lehetőséget kínál.'),
(69, 'Hódító Jelvény', 'Arany', 'Nyerd meg egy Hódító Emblemet és egy Rell-t.'),
(70, 'Hódító Korona', 'Prizmatikus', 'Nyerd meg egy Hódító Emblemet, egy Last Whisper-t és egy Rell-t.'),
(71, 'Versenyzett', 'Arany', 'Minden játékos harc után nyerj 1 aranyat minden 2 másik játékosért, aki a padodon lévő legbal oldali bajnokot választotta.'),
(72, 'Főzőedény', 'Arany', 'Minden kör elején, minden olyan egység, amely egy Sütő Serpenyőt vagy Spatula tárgyat tart, 20 permanens Életet ad a legközelebbi bajnoknak. Nyerd meg egy Sütő Serpenyőt.'),
(73, 'Koronázás', 'Prizmatikus', 'Nyerd meg egy Taktikusi Koronát. A Taktikusi Korona, Páncél és Köpeny 30%-os Támadási Sebességet, 40%-os Támadási Sebzést és 40%-os Képesség-erőt ad a birtokosának.'),
(74, 'Korrozió', 'Ezüst', 'Az ellenséges bajnokok az első két sorban minden 2 másodpercben 3 Páncélt és Mágikus Ellenállást veszítenek.'),
(75, 'Készített Készítés', 'Ezüst', 'Minden alkalommal, amikor készítesz egy befejezett tárgyat, 3 újrarendezést kapsz.'),
(76, 'Vörös Szövetség', 'Arany', 'Nyerd meg egy Vladimir-t. A legerősebb Vladimir +3 távolságot kap, és minden támadása után 5 bónusz Manát szerez. Az ő képessége többé nem gyógyít, hanem 6%-os Sebzés Bónuszt ad, 80%-kal több sebzést okoz, és a sebzés továbboszlik a két legközelebbi ellenségre.'),
(77, 'Korona Őrzött', 'Arany', 'Nyerd meg egy Koronázottat. Az ő Koronázottjaik harc kezdeti hatása 100%-kal erősebb.'),
(78, 'Korona Ereje', 'Arany', 'Nyerd meg egy Óriási Pálcát. Az egységeid 10 Képesség-erőt és 10 Páncélt kapnak.'),
(79, 'Sötét Sikátor Ügyletek', 'Prizmatikus', 'Nyerd meg egy Gyanús Kabátot. Három játékos harc után nyerj egy Trükkös Üveglencsét.'),
(80, 'Késleltetett Kezdés', 'Ezüst', 'Add el az összes bajnokot a tábládról és a padodról. Nyerd meg 4 véletlenszerű 2 csillagos 1-es költségű bajnokot. Tudd le a Boltodat a következő 3 körre.'),
(81, 'Diverzifikált Portfólió', 'Ezüst', 'Minden körben, nyerj 1 aranyat minden 3 nem egyedi tulajdonságért, ami aktív. Nyerd meg 1 aranyat.'),
(82, 'Diverzifikált Portfólió+', 'Ezüst', 'Minden körben, nyerj 1 aranyat minden 3 nem egyedi tulajdonságért, ami aktív. Nyerd meg 4 aranyat.'),
(83, 'Dominator', 'Arany', 'A Dominátorok 20%-kal több Támadási Sebességet kapnak, miközben pajzssal rendelkeznek. Amikor egy Dominátor megöl egy ellenfelet, minden Dominátor 150 Pajzsot kap 4 másodpercre. Nyerd meg egy Cassiopeia-t.'),
(84, 'Dominator Jelvény', 'Arany', 'Nyerd meg egy Dominátor Emblemet és egy Blitzcrank-et.'),
(85, 'Dominator Korona', 'Prizmatikus', 'Nyerd meg egy Dominátor Emblemet, egy Védelmező Fogadalmat és egy Blitzcrank-et.'),
(86, 'Kettős Cél', 'Prizmatikus', 'Az első alkalommal, amikor XP-t vásárolsz minden körben, nyerj 2 aranyat. Amikor XP-t vásárolsz, újrarendezd a Boltodat.'),
(87, 'Bábu', 'Ezüst', 'Veszíts el minden bajnokot a tábládról és a padodról. Nyerd meg egy Tréning Bábut, amely a kombinált életük 70%-át képviseli.'),
(88, 'Duo Képzés', 'Arany', 'Nyerd meg 2 véletlenszerű 5 költségű bajnokot és 2 példány egy véletlenszerű komponensből.'),
(89, 'Végrehajtó Jelvény', 'Arany', 'Nyerd meg egy Végrehajtó Emblemet és egy Loris-t.'),
(90, 'Végrehajtó Korona', 'Prizmatikus', 'Nyerd meg egy Végrehajtó Emblemet, egy Végtelen Éltet és egy Loris-t.'),
(91, 'Epoch', 'Arany', 'Most, és minden szakasz elején, nyerj 6 XP-t és 2 ingyenes újrarendezést.'),
(92, 'Epoch+', 'Arany', 'Most, és minden szakasz elején, nyerj 8 XP-t és 3 ingyenes újrarendezést.'),
(93, 'Váratlan Várakozások', 'Prizmatikus', 'Most, és a következő 2 szakasz elején, dobj 3 kockát. Különféle jutalmakat nyersz a dobott értékek alapján.'),
(94, 'Szemért Szem', 'Ezüst', 'Minden 14 elhunyt szövetséges bajnok után, nyerj egy véletlenszerű komponenst (max 4).'),
(95, 'Szemért Szem+', 'Ezüst', 'Nyerd meg egy véletlenszerű komponenst. Minden 11 elhunyt szövetséges bajnok után nyerj egy új komponenst (max 3).'),
(96, 'Családi Jelvény', 'Arany', 'Nyerd meg egy Családi Emblemet és egy Violet-et.'),
(97, 'Családi Korona', 'Prizmatikus', 'Nyerd meg egy Családi Emblemet, egy Megváltást, egy Vander-t és egy Violet-et.'),
(98, 'Végső Csiszolás', 'Prizmatikus', 'Nyerd meg egy Támogató Anvilt és egy befejezett tárgy anvil-t.'),
(99, 'Találd Meg a Középpontod', 'Ezüst', 'Az a bajnokod, aki a harcot a tábla közepén kezdi, 15%-os Sebzés Bónuszt és 15%-os maximális Életet kap.'),
(100, 'Kiváló Bor', 'Ezüst', 'A padon hagyott befejezett tárgyak 4 kör után Támogató Anvilekké alakulnak.'),
(101, 'Tűzvilág Jelvény', 'Arany', 'Nyerd meg egy Tűzvilág Emblemet és egy Zeri-t.'),
(102, 'Tűzvilág Korona', 'Prizmatikus', 'Nyerd meg egy Tűzvilág Emblemet, egy Védelmező Fogadalmat és egy Scar-t.'),
(103, 'Tüzelés', 'Ezüst', 'Minden körben ellopj egy véletlenszerű bajnokot a boltodból. Nyerd meg 3 aranyat.'),
(104, 'Rugalmas', 'Prizmatikus', 'Nyerd meg 1 véletlenszerű emblemet. Minden szakasz elején nyerj egy véletlenszerű emblemet. A csapatod minden egyes tartott embléma után 30 Életet nyer.'),
(105, 'Támadások Özöne', 'Prizmatikus', 'Nyerd meg egy Zekes Heraldot. A Zekes által buffolt bajnokok 35%-os Kritikus Ütések Esélyét is kapják.'),
(106, 'Tiltott Mágia', 'Arany', 'Minden 3 kivégzés, amelyet a Fekete Rózsa bajnokai vagy Sion hajt végre, permanens 1.50%-os Támadási Sebzést és 10 Maximális Életet ad Sion-nak. Nyerd meg 3 Fekete Rózsa bajnokot.'),
(107, 'Előrelátó Gondolkodás', 'Arany', 'Veszíts el minden aranyat. 6 játékos harc után nyerd vissza az eredeti összeget és még 80 aranyat.'),
(108, 'Törött Kristályok', 'Arany', 'Amikor egy Automata bajnok kilövi a robbanását, egy második robbanást lő a legközelebbi ellenségre, amely az eredeti sebzés 50%-át okozza. Nyerd meg egy Amumu-t és egy Nocturne-t.'),
(109, 'Barátok Szellemei', 'Prizmatikus', 'Bármikor, amikor egy szövetséges bajnok meghal, a csapatod permanens 15 Életet, 2%-os Támadási Sebzést vagy 2 Képesség-erőt nyer, a halott bajnok szerepe alapján.'),
(110, 'Üvegágyú I', 'Ezüst', 'Azok az egységek, akik a hátsó sorban kezdik a harcot, 80%-os életerővel kezdik, de 12%-os Sebzés Bónuszt kapnak.'),
(111, 'Üvegágyú II', 'Arany', 'Azok az egységek, akik a hátsó sorban kezdik a harcot, 80%-os életerővel kezdik, de 20%-os Sebzés Bónuszt kapnak.'),
(112, 'Kesztyű Le', 'Arany', 'Nyerd meg egy Vander-t. A legerősebb Vander új képességet kap, amely már nem ad ellenállásokat, de 100%-kal több sebzést okoz, és hátraüti a célt, miközben 25%-os sebzést okoz minden eltalált ellenségnek.'),
(113, 'Hosszú Táv', 'Prizmatikus', 'Többé nem szerzel kamatot. Nyerd meg 15 aranyat most. Kerek kezdete: nyerj 4 XP-t.'),
(114, 'Arany a Kezdőknek', 'Arany', 'Nyerd meg egy Tréning Bábut. Minden 10 másodpercben minden Tréning Bábu 1 aranyat ad.'),
(115, 'Gólemesítés', 'Arany', 'Veszíts el minden bajnokot a tábládról és a padodról. Nyerd meg egy Gólemet, amely a kombinált életük 70%-át és a kombinált támadó sebzésük 50%-át képviseli.'),
(116, 'Jó Valamire I', 'Ezüst', 'Azok a bajnokok, akik nem tartanak tárgyat, 50%-os eséllyel 1 aranyat ejtenek halálukkor.'),
(117, 'Nagyobb Holdfény', 'Prizmatikus', 'A harc kezdete: 1 véletlenszerű 1-es költségű bajnokot frissítenek 4 csillagra az adott körre, és +15%-os Támadási Sebzést és +15 Képesség-erőt kap.'),
(118, 'Gerillaháború', 'Arany', 'A Tűzvilág bajnokai minden egyes hexán megtett lépés után 3%-os Támadási Sebzést és 3 Képesség-erőt kapnak. Nyerd meg egy Scar-t.'),
(119, 'Tükrök Csarnoka', 'Prizmatikus', 'A harc kezdete: Minden bajnok a front sorodban klónná válik, és a középső bajnoktól másolja annak képességeit. A klónok 90%-os életerőt kapnak, és 10%-kal kevesebb sebzést okoznak.'),
(120, 'Kemény Elköteleződés', 'Prizmatikus', 'Nyerd meg egy véletlenszerű emblemet. Most, és minden szakasz elején nyerj egy 1 csillagos bajnokot az adott tulajdonságból, amelynek költsége megegyezik a szakasz számával (max 5).'),
(121, 'Az Egészség a Gazdagság I.', 'Ezüst', 'A csapatod 10%-os Omnivamp-ot kap. Kapsz egy bónuszt 10 aranyat, amikor a csapatod először halmoz fel 10000 összesített gyógyítást.'),
(122, 'Az Egészség a Gazdagság II.', 'Arany', 'A csapatod 15%-os Omnivamp-ot kap. Kapsz egy bónuszt 20 aranyat, amikor a csapatod először halmoz fel 10000 összesített gyógyítást.'),
(123, 'Erőteljes Ütés', 'Arany', 'Minden 3 másodpercben, a Bruiser bajnokok 6%-os maximális Életük alapján bónuszként fizikai sebzést okoznak a következő támadásukkal. Nyerd meg egy Steb-et és egy Trundle-t.'),
(124, 'Hedge Fund', 'Prizmatikus', 'Nyerd meg 22 aranyat. A maximális kamatod 10-re nő. A kamat extra arany, amit minden 10 arany megtakarítása után kapsz.'),
(125, 'Segítség Úton', 'Ezüst', '8 játékos harc után válassz 1 a 4 Támogató tárgy közül.'),
(126, 'Hősies Szükséglet', 'Arany', 'Nyerd meg 2 Kisebb Bajnok Másolókat és 9 aranyat. Ez a tárgy lehetővé teszi egy 3 költségű vagy annál alacsonyabb bajnok másolását.'),
(127, 'Magas Feszültség', 'Arany', 'Nyerd meg egy Ióniás Szikrát. A te Ióniás Szikráid +3 hex sugárnyival és 25%-kal több sebzéssel rendelkeznek.'),
(128, 'Remélem, Működni Fog', 'Ezüst', 'Nyerd meg egy Puder-t. A legerősebb Puder robbanási sugara két hexszel megnövekszik, kevesebb sebzéses csökkenéssel, de 60%-os sebzést okoz a SZÖVETSÉGESEKNEK.'),
(129, 'Most Én Vagyok a Carry', 'Prizmatikus', 'Nyerd meg egy Gólemet egy személyre szabott támadó tárgyakkal. Minden szakasz elején erősebbé válik.'),
(130, 'Mozdíthatatlan Tárgy', 'Prizmatikus', 'Nyerd meg egy Randuin\'s Omen-t. A sugara 1 hexszel megnövekszik, és a hatása 60%-kal erősebbé válik.'),
(131, 'Bátorító Felirat', 'Arany', 'Amikor egy egység meghal, a legközelebbi szövetséges 20%-os maximális Élet Pajzsot és 10%-os halmozódó Támadási Sebzés Sebességet kap.'),
(132, 'Befektetett+', 'Prizmatikus', 'Nyerd meg 26 aranyat. Minden kör elején nyerj egy Shop újrarendezést minden 10 aranyért, amely meghaladja az 50-et (max 80 arany).'),
(133, 'Befektetett++', 'Prizmatikus', 'Nyerd meg 45 aranyat. Minden kör elején nyerj egy Shop újrarendezést minden 10 aranyért, amely meghaladja az 50-et (max 80 arany).'),
(134, 'Befektetési Stratégia I', 'Arany', 'A bajnokaid minden egyes kamatot szerzett arany után 7 permanens maximális életerőt kapnak.'),
(135, 'Befektetési Stratégia II', 'Prizmatikus', 'Nyerd meg 5 aranyat. A bajnokaid minden egyes kamatot szerzett arany után 10 permanens maximális életerőt kapnak. A maximális kamatod 7-re növekszik.'),
(136, 'Vas Eszközök', 'Ezüst', 'Nyerd meg egy komponens anvil-t és 4 aranyat. Az anvil 4 választást kínál.'),
(137, 'Tárgygyűjtő I', 'Ezüst', 'A csapatod 10 Életet nyer. Minden egyedi tárgy, amit tartanak, extra 2 Életet, 1 Támadási Sebzést és 1 Képesség-erőt ad a csapatnak.'),
(138, 'Tárgygyűjtő II', 'Arany', 'A csapatod 20 Életet nyer. Minden egyedi tárgy, amit tartanak, extra 5 Életet, 1.50 Támadási Sebzést és 1.50 Képesség-erőt ad a csapatnak.'),
(139, 'Tárgy Választó I', 'Ezüst', 'Nyerd meg 1 véletlenszerű befejezett tárgyat.'),
(140, 'Királyölő', 'Ezüst', 'Miután megnyerted a játékos harcot, nyerj 1 aranyat. Ha több élete volt, mint neked, nyerj 3 aranyat. Nyerd meg 1 aranyat most.'),
(141, 'Későbbi Játék Szakértője', 'Ezüst', 'Amikor elérsz a 9. szintre, nyerj 33 aranyat.'),
(142, 'Latens Kovácsműhely', 'Ezüst', '8 játékos harc után nyerd meg egy Artifakt anvil-t. Az anvil 4 választást kínál. Az Artifaktok erősebb tárgyak, amelyek egyedi hatással rendelkeznek.'),
(143, 'Jogalkalmazás', 'Arany', 'A végrehajtó bajnokok 10%-os Támadási Sebzést kapnak. Minden 5 Wanted ellenség halála után nyerj 6 aranyat. Nyerd meg egy Steb-et és egy Maddie-t.'),
(144, 'Szint Fel!', 'Prizmatikus', 'Amikor XP-t vásárolsz, nyerj 2-t. Nyerd meg 12-t azonnal.'),
(145, 'Felállás', 'Ezüst', 'A csapatod 2.50 Páncélt és Mágikus Ellenállást kap minden egyes egység után, aki a harc elején a két elülső sor egyikében kezd.'),
(146, 'Kis Barátok', 'Arany', 'A 4 költségű és 5 költségű bajnokok 65 Életet és 7%-os Támadási Sebzés Sebességet kapnak minden 1 költségű és 2 költségű bajnokért a tábládon.'),
(147, 'Élő Kovácsműhely', 'Prizmatikus', 'Nyerd meg egy Artifakt anvil-t most és minden 9 játékos harc után. Az Artifaktok erősebb tárgyak, amelyek egyedi hatással rendelkeznek.'),
(148, 'Magányos Hős', 'Ezüst', 'A legutolsó életben maradó egységed 100%-os Támadási Sebzés Sebességet és 30%-os Túlélőképességet kap.'),
(149, 'Hosszú Távú Barátok', 'Arany', 'A harc kezdete: A két legmesszebb lévő egységed kapcsolatot képez, és megosztják 22%-át az Életerejüknek, Mágikus Ellenállásuknak, Támadási Sebzésüknek és Képesség-erőjüknek.'),
(150, 'Loot Robbanás', 'Arany', 'A csapdázók ölésének esélye, hogy lootot dobjanak, a Kritikus Ütések Esélyével növekszik. A loot értéke is kritikus ütéssel is sebződhet, így még több lootot adhat. Nyerd meg egy Camille-t és egy Powder-t.'),
(151, 'Szerencsés Kesztyűk', 'Prizmatikus', 'A Tolvaj Kesztyűi mindig ideális tárgyakat adnak a bajnokaidnak. Nyerd meg 2 Sparring Kesztyűt. 5 kör után nyerj egy újabb Sparring Kesztyűt.'),
(152, 'Szerencsés Kesztyűk+', 'Prizmatikus', 'A Tolvaj Kesztyűk mindig a legjobb tárgyakat adják a bajnokaidnak. Szerezz 3 Küzdő Kesztyűt.'),
(153, 'Ebédpénz', 'Ezüst', 'Minden 8 sebzés, amit az ellenséges taktikánál okozol, 2 aranyat ad.'),
(154, 'Mace Végrendelete', 'Arany', 'Szerezz egy Küzdő Kesztyűt. A csapatod 8%-os támadási sebességet és 20%-os kritikus csapás esélyt kap.'),
(155, 'Őrült Vegyész', 'Ezüst', 'Szerezz egy Singed-et. A legerősebb Singed-ed nem tud támadni, de folyamatosan fut, mérgező nyomot hagyva, amely idővel varázssebzést okoz. Képessége mindig saját magát célozza, és 20%-os mindenféle gyógyulást (Omnivamp) és mozgási sebességet ad helyette.'),
(156, 'Rosszindulatú Monetizáció', 'Arany', 'Szerezz 6 aranyat. A következő 3 körben az ellenséges bajnokok 2 aranyat dobnak, amikor meghalnak.'),
(157, 'Manaáramlás I', 'Ezüst', 'A hátsó sorból harcba lépő egységeid minden támadással 3 további Manát nyernek.'),
(158, 'Manaáramlás II', 'Arany', 'A hátsó sorból harcba lépő egységeid minden támadással 5 további Manát nyernek.'),
(159, 'Maximális Képesség', 'Prizmatikus', 'A maximális szinted 7. Szerezz 1 Taktikai Pajzsot, amely +1 csapattagot ad, és 60 aranyat.'),
(160, 'Mentorálás I', 'Ezüst', 'Ha egy szövetséges egy magasabb költségű szövetséges mellett kezdi a harcot, 12%-os támadási sebességet és 150 Életerőt kap.'),
(161, 'Mentorálás II', 'Arany', 'Ha egy szövetséges egy magasabb költségű szövetséges mellett kezdi a harcot, 18%-os támadási sebességet és 220 Életerőt kap.'),
(162, 'Elmaradt Kapcsolatok', 'Ezüst', 'Szerezz egy-egy másolatot minden 1 költségű bajnokból.'),
(163, 'Holdfény', 'Arany', 'Harc kezdésekor: 2 véletlenszerű 1 költségű bajnokot 3 csillagosra fejlesztenek a kör végére, és 10%-os Támadási Sebességet és 10 Képesség Erőt kapnak.'),
(164, 'Nincs Felderítő, Nincs Fordulás', 'Arany', 'A harcban résztvevő egységeket nem lehet a kispadra tenni vagy eladni a játékos harcot követően. Minden játékos harc után azok az egységek, amelyek harcoltak, 15 Életerőt, 1,50%-os Támadási Sebességet és 1,50%-os Képesség Erőt nyernek.'),
(165, 'Nemes Áldozat', 'Arany', 'Amikor az első szövetségesed meghal minden harcban, 15 + 15%-át annak a szövetségesének Páncél és Varázsvédelem értékéből a csapatodnak adod.'),
(166, 'Ma Nem', 'Arany', 'Szerezz egy Edge of Night-ot. Az ezt tartó bajnokok 35%-os Támadási Sebességet kapnak.'),
(167, 'Noxian Guillotine', 'Arany', 'A Hódítók azokat az ellenségeket hajtják végre, akik 12% alatti Életerővel rendelkeznek. Ha végrehajtják, 5 Páncélt és Varázsvédelmet kapnak a harc hátralevő részére. Szerezz egy Darius-t és egy Draven-t.'),
(168, 'Egy Buff, Két Buff', 'Prizmatikus', 'Szerezz egy Vörös Buffot, egy Kék Buffot és egy Bajnoki Másolót.'),
(169, 'Mindenki Mindenkiért I', 'Ezüst', 'A csapatod 2%-os maximális Életerőt és 1,50%-os Sebzés Növelést kap minden egyedi 1 költségű bajnoktól a tábládon. Szerezz 2 darab 1 költségű bajnokot.'),
(170, 'Mindenki Mindenkiért II', 'Arany', 'A csapatod 3%-os maximális Életerőt és 2,50%-os Sebzés Növelést kap minden egyedi 1 költségű bajnoktól a tábládon. Szerezz 3 darab 1 költségű bajnokot.'),
(171, 'Egy, Kettő, Öt!', 'Ezüst', 'Szerezz 1 véletlenszerű komponenst, 2 aranyat és 1 véletlenszerű 5 költségű bajnokot.'),
(172, 'Egyesek, Kettesek, Hármasok', 'Ezüst', 'Szerezz 2 1 költségű bajnokot, 2 2 költségű bajnokot és 1 3 költségű bajnokot.'),
(173, 'Túlterhelt', 'Ezüst', 'A következő szakaszban csak 1 kispadhelyet kapsz. Ezután 3 tárgykomponenst kapsz.'),
(174, 'Túlgyógyítás', 'Arany', 'Minden harmadik támadás 115%-os extra sebzést okoz, és a sebzés 50%-át visszagyógyítja. A fölösleges gyógyítás pajzssá alakul, maximum 300 Életerőig.'),
(175, 'Fessétek Kékre a Várost', 'Arany', 'Amikor az első 5 Rebel meghal minden harcban, egy másolatot idéznek meg belőlük, ami 1 csillaggal gyengébb és 400 Életerővel kevesebb. Szerezz egy Akalit és egy Irelia-t.'),
(176, 'Páros Négyesek', 'Arany', 'Ha a csapatod pontosan 2 négy költségű bajnokot tartalmaz, mindegyikük 404 Életerőt és 24,40%-os Támadási Sebességet kap. Szerezz egy véletlenszerű 4 költségű bajnokot.'),
(177, 'Pandora Kispadja', 'Ezüst', 'Szerezz 2 aranyat. Minden kör kezdetén a 3 legjobb kispadhelyen lévő bajnokok véletlenszerűen átalakulnak ugyanakkora költségű bajnokokra.'),
(178, 'Pandora Tárgyai', 'Ezüst', 'Kör kezdetekor: a kispadodon lévő tárgyak véletlenszerűen változnak. Szerezz 1 véletlenszerű komponenst.'),
(179, 'Pandora Tárgyai II', 'Arany', 'Kör kezdetekor: a kispadodon lévő tárgyak véletlenszerűen változnak. Szerezz 2 véletlenszerű komponenst.'),
(180, 'Pandora Tárgyai III', 'Prizmatikus', 'Kör kezdetekor: a kispadodon lévő tárgyak véletlenszerűen változnak. Szerezz 1 véletlenszerű Radiáns tárgyat.'),
(181, 'A Türelem Erény', 'Ezüst', 'Minden körben, ha az előző körben nem vásároltál bajnokot, 2 ingyenes újrapróbálást kapsz.'),
(182, 'Türelmes Tanulmány', 'Arany', 'Játékos harc után 2 XP-t kapsz, ha nyertél, vagy 3 XP-t, ha veszítettél.'),
(183, 'Phreaky Friday', 'Prizmatikus', 'Szerezz egy Végtelen Erőt. 5 játékos harc után szerezz egy másikat. Végtelen Erő: Egy műtárgy, amely rengeteg támadó és védekező statisztikát ad.'),
(184, 'Phreaky Friday+', 'Prizmatikus', 'Szerezz egy Végtelen Erőt. 3 játékos harc után szerezz egy másikat. Végtelen Erő: Egy műtárgy, amely rengeteg támadó és védekező statisztikát ad.'),
(185, 'Áthatoló Lótusz I', 'Arany', 'A csapatod 10%-os Kritikus Ütés esélyt kap, és Képességeik képesek Kritikus Ütést végrehajtani. A Kritikus Ütések 20%-os Lenyúzást és Törést okoznak a célpontnak 3 másodpercig.'),
(186, 'Áthatoló Lótusz II', 'Prizmatikus', 'A csapatod 30%-os Kritikus Ütés esélyt kap, és Képességeik képesek Kritikus Ütést végrehajtani. A Kritikus Ütések 20%-os Lenyúzást és Törést okoznak a célpontnak 3 másodpercig.'),
(187, 'Zsákmány', 'Arany', 'Minden körben szerezz egy 1 csillagos másolatot az első bajnokról, akit az előző harcban megöltél.'),
(188, 'Pit Fighter Jelvény', 'Arany', 'Szerezz egy Pit Fighter Jelvényt és egy Urgot.'),
(189, 'Pit Fighter Korona', 'Prizmatikus', 'Szerezz egy Pit Fighter Jelvényt, egy Sterak\'s Gage-t és egy Gangplank-ot.'),
(190, 'Placebo', 'Ezüst', 'Szerezz 8 aranyat. A csapatod 1%-os Támadási Sebességet kap.'),
(191, 'Placebo+', 'Ezüst', 'Szerezz 15 aranyat. A csapatod 1%-os Támadási Sebességet kap.'),
(192, 'Hordozható Kovács', 'Arany', 'Válassz 1 az 4 Műtárgy közül. A Műtárgyak erősebb tárgyak, egyedi hatásokkal.'),
(193, 'Erősítés', 'Ezüst', 'A következő augmentálásod egy szinttel magasabb lesz.'),
(194, 'Erősített Pajzsok', 'Arany', 'Pajzs alatt az egységeid 12%-os Túlélőképességet nyernek. Az első alkalommal, amikor a szövetségesek 50% alá esnek, 125-275 Pajzsot kapnak (a szakasz alapján), 3 másodpercig.'),
(195, 'Prizmatikus Csővezeték', 'Prizmatikus', 'A következő nem-játékos harc körben további Prizmatikus Orbát dobnak, tele csodálatos zsákmánnyal. Minden Arany és Prizmatikus orb még több zsákmányt tartalmaz!'),
(196, 'Prizmatikus Jegy', 'Prizmatikus', 'Minden alkalommal, amikor az Áruházat újrapróbálod, 45%-os eséllyel kapsz egy ingyenes újrapróbálást.'),
(197, 'Díjnyertes Bokszoló', 'Arany', 'Szerezz 2 tárgykomponenst. Minden 5 győzelem után kapsz egy tárgykomponenst.'),
(198, 'Fokozódás I', 'Ezüst', 'A csapatod most 8%-os Támadási Sebességet kap. Minden következő körben 0,50%-kal többet nyernek.'),
(199, 'Fokozódás II', 'Arany', 'A csapatod most 10%-os Támadási Sebességet kap. Minden következő körben 1%-kal többet nyernek.'),
(200, 'Fokozódás III', 'Prizmatikus', 'A csapatod most 12%-os Támadási Sebességet kap. Minden következő körben 2%-kal többet nyernek.'),
(201, 'Tűzrajongó', 'Arany', 'Szerezz egy Vörös Buffot. A Lángjaid 50%-kal több sebzést okoznak.'),
(202, 'Minőség a Mennyiség Felett', 'Prizmatikus', 'Azok az egységek, akik pontosan 1 tárgyat tartanak, azt Radiánsra fejlesztik. Szerezz 2 Magnetikus Eltávolítót.'),
(203, 'Tolvaj Kesztyűi több tárgyként számítana', 'Prizmatikus', 'Tolvaj Kesztyűi több tárgyként számítanak.'),
(204, 'Gyorslövő Jelvény', 'Arany', 'Szerezz egy Gyorslövő Jelvényt és egy Akalit.'),
(205, 'Gyorslövő Korona', 'Prizmatikus', 'Szerezz egy Gyorslövő Jelvényt, egy Guinsoo\'s Rageblade-t és egy Nocturne-t.'),
(206, 'Radiáns Újraírás', 'Prizmatikus', 'Szerezz egy Mesteri Fejlesztést és 1 komponenst egy kalapács formájában. A Mesteri Fejlesztés egy tárgyat Radiánssá fejleszt!'),
(207, 'Radiáns Relikviák', 'Prizmatikus', 'Válassz 1 a 5 Radiáns tárgy közül. Szerezz egy Magnetikus Eltávolítót. A Radiáns tárgyak a befejezett tárgyak nagyon erős változatai.'),
(208, 'Eső Arany', 'Arany', 'Szerezz 8 aranyat most és minden körben 1 aranyat.'),
(209, 'Eső Arany+', 'Arany', 'Szerezz 18 aranyat most és minden körben 1 aranyat.'),
(210, 'Rebel Jelvény', 'Arany', 'Szerezz egy Rebel Jelvényt és egy Akalit.'),
(211, 'Rebel Korona', 'Prizmatikus', 'Szerezz egy Rebel Jelvényt, egy Jeweled Gauntlet-et és egy Akalit.'),
(212, 'Újrarendező', 'Ezüst', 'A tábládon lévő bajnokok véglegesen átalakulnak véletlenszerű bajnokokká, amelyek 1 költségszinttel magasabbak. Szerezz 2 Magnetikus Eltávolítót.'),
(213, 'ReinFOURcement', 'Arany', 'A következő 4 költségű bajnok, amelyet vásárolsz, azonnal 2 csillagosra frissül. Szerezz 12 aranyat.'),
(214, 'Másolás', 'Arany', 'Válassz 1 a 3 komponens közül. A következő 2 körben kapsz egy másolatot az adott komponensből.'),
(215, 'Újrapróbálás Átadás', 'Ezüst', 'Minden 1 fel nem használt Augment Újrapróbálás után 3 ingyenes bolt újrapróbálást kapsz. Szerezz 3 aranyat. Ez nem tartalmazza a kört, amelyben ezt az augmentálást választottad.'),
(216, 'Újraindítási Küldetés', 'Ezüst', 'Távolíts el minden bajnokot a tábládról és a pihenőhelyedről. Szerezz 2 véletlenszerű 2 csillagos 3 költségű bajnokot, 3 2 csillagos 2 költségű bajnokot és 1 2 csillagos 1 költségű bajnokot.'),
(217, 'Manipulált Bolt', 'Ezüst', 'A következő bolt és minden 4. bolt tartalmazni fog minden 3 költségű bajnokot.'),
(218, 'Manipulált Bolt+', 'Ezüst', 'A következő bolt és minden 4. bolt tartalmazni fog minden 3 költségű bajnokot. Szerezz 5 újrapróbálást.'),
(219, 'Kockázatos Lépések', 'Ezüst', 'A Taktikusod elveszít 20 Életet, de 7 játékos harc után 30 aranyat kapsz.'),
(220, 'Rakéta Gyűjtemény', 'Arany', 'Az Artillerist rakéták 50%-kal több sebzést okoznak. Minden 60 rakéta, amit az Artilleristjeid kilőnek, egy Collector-t ad (max. 2). Szerezz egy Tristana-t és egy Urgot-ot.'),
(221, 'Dobd el a Kockát', 'Prizmatikus', 'Szerezz egy Rascal\'s Gloves tárgyat. Ez minden körben 2 véletlenszerű Radiáns tárgyat ad. A Radiáns tárgyak a befejezett tárgyak nagyon erős változatai.'),
(222, 'Naponkénti Dobás I', 'Ezüst', 'Szerezz 11 ingyenes Bolt újrapróbálást.'),
(223, 'Mentési Kuka', 'Arany', 'Szerezz egy véletlenszerű befejezett tárgyat most, és 1 komponenst 7 játékos harc után. A bajnokok eladása felbontja a befejezett tárgyakat komponensekre (kivéve a Taktikus tárgyakat és Jelvényeket).'),
(224, 'Mentési Kuka', 'Arany', 'Szerezz egy véletlenszerű befejezett tárgyat most, és 1 komponenst 7 játékos harc után. A bajnokok eladása felbontja a befejezett tárgyakat komponensekre (kivéve a Taktikus tárgyakat és Jelvényeket).'),
(225, 'Mentési Kuka+', 'Arany', 'Szerezz egy véletlenszerű befejezett tárgyat most, és 1 komponenst 4 játékos harc után. A bajnokok eladása felbontja a befejezett tárgyakat komponensekre (kivéve a Taktikus tárgyakat és Jelvényeket).'),
(226, 'Jóllakott Mágust szövő', 'Arany', 'Képesség használat után a bajnokok 20%-os Omnivampot kapnak 3 másodpercig. A felesleges gyógyítás pajzssá alakul 300 életerőig.'),
(227, 'Bűnbak', 'Arany', 'Szerezz egy Képzési Bábút és 4 aranyat. Ha ez a legelső, aki meghal minden játékos harcban, kapsz 1 aranyat.'),
(228, 'Zsákmányoló', 'Arany', 'Az első 4 ellenséges bajnok, akik meghalnak minden harcban, ideiglenes befejezett tárgyat adnak egy bajnokodnak a csapatodban.'),
(229, 'Pontszám táblázat Zúzó', 'Arany', 'Minden körben, ha az alsó 4 között vagy, a csapatod tartósan 1,50%-kal több Támadási Sebességet és Képesség Erőt kap. Ha az első 4 között vagy, 10%-kal több Életet kapnak.'),
(230, 'Hulladék Jelvény', 'Arany', 'Szerezz egy Hulladék Jelvényt és egy Ziggs-et.'),
(231, 'Hulladék Korona', 'Prizmatikus', 'Szerezz egy Hulladék Jelvényt, egy Ziggs-et és 2 véletlenszerű komponenst.'),
(232, 'Sentinel Jelvény', 'Arany', 'Szerezz egy Sentinel Jelvényt és egy Rell-t.'),
(233, 'Sentinel Korona', 'Prizmatikus', 'Szerezz egy Sentinel Jelvényt, egy Crownguard-ot és egy Loris-t.'),
(234, 'Pajzs Ütés', 'Arany', 'A Sentinel-ek 8%-os bónusz Páncélt és Mágikus Ellenállást kapnak. Minden 4 másodpercben a következő támadásuk a teljes ellenállásuk 100%-át varázssebzésként okozza. Szerezz egy Lorist.'),
(235, 'Shimmerscale Esszencia', 'Prizmatikus', 'Szerezz egy Mogul\'s Mail-t. 5 kör után szerezz egy Gamblers Blade-t. Ezek a tárgyak aranyat adnak, valamint harci erőt.'),
(236, 'Bolt Glitch', 'Arany', 'Nem játékos harcok alatt a boltod minden 3 másodpercben ingyen frissül 30 másodpercig.'),
(237, 'Vásárlási Láz', 'Prizmatikus', 'Amikor szintet lépsz, ingyenes bolt frissítéseket kapsz a szinted számának megfelelően. Szerezz 4 aranyat.'),
(238, 'Ezüst Kanál', 'Ezüst', 'Szerezz 10 XP-t.'),
(239, 'Ütős', 'Arany', 'Szerezz 1 véletlenszerű komponenst. Minden játékos harc után, ha nincsenek tárgyak a pihenőhelyeden (kivéve a Fogyaszthatókat), szerezz 2 XP-t.'),
(240, 'Ütős+', 'Arany', 'Szerezz 1 véletlenszerű komponenst és 10 XP-t most. Minden játékos harc után, ha nincsenek tárgyak a pihenőhelyeden (kivéve a Fogyaszthatókat), szerezz 2 XP-t.'),
(241, 'Mesterlövész Jelvény', 'Arany', 'Szerezz egy Mesterlövész Jelvényt és egy Zerit.'),
(242, 'Mesterlövész Korona', 'Prizmatikus', 'Szerezz egy Mesterlövész Jelvényt, egy Infinity Edge-et és egy Zerit.'),
(243, 'Mesterlövész Fészek', 'Arany', 'A Mesterlövészek minden egyes kör után +8%-kal növelik a Sebzés Erősítést az ugyanarról a hexről kezdve (maximum +32%). Szerezz egy Zerit.'),
(244, 'Mágus Jelvény', 'Arany', 'Szerezz egy Mágus Jelvényt és egy Vladimir-t.'),
(245, 'Mágus Korona', 'Prizmatikus', 'Szerezz egy Mágus Jelvényt, egy Adaptive Helm-et és egy Vladimir-t.'),
(246, 'Lándzsás Akarat', 'Arany', 'A csapatod 10%-os Támadási Sebességet és 15 Manát kap. Szerezz egy B.F. Sword-ot.'),
(247, 'Szellemkapcsolat', 'Arany', 'A csapatod 4%-ot gyógyít a maximális Életéből minden 5 másodpercben. Növeld a gyógyítást 0,50%-kal minden 10% eltűnt játékos Élet után.'),
(248, 'Háború Zsákmányai I', 'Ezüst', 'Az ellenségek 25%-os eséllyel ejtenek zsákmányt, amikor meghalnak.'),
(249, 'Háború Zsákmányai II', 'Arany', 'Az ellenségek 30%-os eséllyel ejtenek zsákmányt, amikor meghalnak.'),
(250, 'Háború Zsákmányai III', 'Prizmatikus', 'Az ellenségek 40%-os eséllyel ejtenek zsákmányt, amikor meghalnak.'),
(251, 'Szivacsos', 'Prizmatikus', 'A harc kezdetén: Akár 5 bajnok is, akik 1 vagy kevesebb tárgyat tartanak, véletlenszerű befejezett tárgyat kapnak a legközelebbi tárgyat tartó szövetségestől.'),
(252, 'Csillagos Éjszaka', 'Arany', 'Az 1 költségű és 2 költségű bajnokok a boltodban eséllyel 2 csillagosak lesznek. Szerezz 3 aranyat. Az esélyek a játékos szintjével nőnek.'),
(253, 'Csillagos Éjszaka+', 'Arany', 'Az 1 költségű és 2 költségű bajnokok a boltodban eséllyel 2 csillagosak lesznek. Szerezz 8 aranyat. Az esélyek a játékos szintjével nőnek.'),
(254, 'Előfizetéses Szolgáltatás', 'Prizmatikus', 'Most és minden szakasz elején egy bolt nyílik 4 egyedi 4 költségű bajnokkért és 6 aranyért.'),
(255, 'Szuperhősök I', 'Ezüst', 'A csapatod 5%-kal több sebzést okoz, ami minden 3 csillagos bajnokról 2%-kal növekszik. Szerezz 2 újrapróbálást.'),
(256, 'Szuperhősök II', 'Arany', 'A csapatod 7%-kal több sebzést okoz, ami minden 3 csillagos bajnokról 5%-kal növekszik. Szerezz 4 újrapróbálást.'),
(257, 'Támogató Készlet', 'Arany', 'Válassz 1 a 4 Támogató tárgyból.'),
(258, 'Támogató Bányászat', 'Ezüst', 'Szerezz egy Képzési Bábút. Ha 6 alkalommal meghal, szerezz egy Támogató Anvilt és távolítsd el a Képzési Bábút.'),
(259, 'Támogató Bányászat+', 'Ezüst', 'Szerezz egy Képzési Bábút. Ha 4 alkalommal meghal, szerezz egy Támogató Anvilt és távolítsd el a Képzési Bábút.'),
(260, 'Túlélő', 'Ezüst', 'Miután 3 játékos kiesett, szerezz 60 aranyat.'),
(261, 'Kard Túltöltés', 'Prizmatikus', 'Szerezz 5 B.F. Sword-ot. A B.F. Sword-jaid +2,50%-os Támadási Sebességet adnak.'),
(262, 'Asztali Maradékok', 'Ezüst', 'Minden karuszel után szerezz egy nem elvitt egységet és annak tárgyát. Szerezz 1 aranyat.'),
(263, 'Taktikai Konyha', 'Prizmatikus', 'Szerezz egy Taktikai Köpenyt és egy véletlenszerű Emblemet.'),
(264, 'Csapatépítés', 'Ezüst', 'Szerezz egy Kisebb Bajnoki Másolót. Szerezz egy másikat 7 játékos harc után. Ez a tárgy lehetővé teszi, hogy lemásolj egy 3 költségű vagy kevesebb bajnokot.'),
(265, 'Csapatosítás I', 'Ezüst', 'Szerezz 1 véletlenszerű komponenst és 2 véletlenszerű 3 költségű bajnokot.'),
(266, 'Csapatosítás II', 'Arany', 'Szerezz 1 véletlenszerű Támogató tárgyat és 2 véletlenszerű 4 költségű bajnokot.'),
(267, 'Aranytojás', 'Prizmatikus', 'Szerezz egy aranytojást, amely 11 kör alatt kelt ki, és hatalmas zsákmányt ad. A nyerő játékos harca gyorsítja a kelési időt egy extra körrel.'),
(268, 'A Mutáció Éli Túl', 'Arany', 'A Kísérletek 12%-kal több Életet kapnak és egy speciális hexet adnak. A Kísérlet a hexben a harc kezdetekor meghal, és a Kísérlet bónusza más laboratóriumi hexekhez kerül. Szerezz 3 Kísérlet bajnokot.'),
(269, 'Tüskés Páncél', 'Arany', 'Szerezz egy Bramble Vest-et. A Bramble Vesteid 5-100%-kal több sebzést okoznak (szakasz alapján) és gyógyítják a hordozót a sebzés 50%-ával.'),
(270, 'Legkisebb Titán', 'Prizmatikus', 'Minden játékos harc után szerezz 2 játékos egészséget és 1 aranyat. A Taktikusan mozgás is gyorsabb.'),
(271, 'Legkisebb Titán+', 'Prizmatikus', 'Minden játékos harc után szerezz 2 játékos egészséget és 1 aranyat. A Taktikusan mozgás is gyorsabb. Szerezz 15 aranyat most.'),
(272, 'Titanikus Titán', 'Ezüst', 'Növeld a jelenlegi és maximális játékos egészséget 20%-kal. A karuszel körökben hamarabb szabadulsz, de sokkal lassabban.'),
(273, 'Sírrabló I', 'Arany', 'A következő 3 játékos kiesése után válassz egy tárgyat tőlük, amit megtartasz.'),
(274, 'Sírrabló II', 'Prizmatikus', 'Minden alkalommal, amikor egy játékos kiesik, válassz egy tárgyat tőlük, amit megtartasz.'),
(275, 'A Hulladékhegy Csúcsa', 'Arany', 'Minden 8 komponens, amit a Hulladék bajnokok átalakítanak, egy véletlenszerű komponenst ad (maximum 6). Szerezz egy Powder-t és egy Trundle-t.'),
(276, 'Toronyvédelem', 'Arany', 'Szerezz egy Képzési Bábút, amely egy véletlenszerű Emblemet tartalmaz, és távolsági támadásokat indít az ellenségekre. Fejlődik, ahogy a játék előrehalad.'),
(277, 'Kereskedelmi Szekció', 'Arany', 'Minden körben szerezz egy ingyenes Bolt újrapróbálást. Szerezz 1 aranyat.'),
(278, 'Képzési Ív', 'Arany', 'A Pit Fighter-ek véglegesen 1,50%-kal több Támadási Sebzést kapnak, ha az előző harcot elvesztették. Ha nyertek, 45 Életet nyernek helyette. Szerezz egy Urgot.'),
(279, 'Tulajdonság Követő', 'Arany', 'Az első alkalommal, amikor 7 nem egyedi tulajdonságot aktiválsz egy harcra, szerezz 5 véletlenszerű Emblemet.'),
(280, 'Tulajdonság: NévVár', 'Prizmatikus', 'Vander 35 permanens maximális Életet kap minden alkalommal, amikor Silco varázsol. Silco 8 permanens Képesség Erőt kap minden alkalommal, amikor Vander meghal. Szerezz egy 2 csillagos Vander-t, egy Silco-t és egy Spear of Shojin-t.'),
(281, 'Tulajdonság: Zsenik', 'Prizmatikus', 'Amikor Heimerdinger varázsol, Ekko 3 utánképet indít, mindegyik 30%-os sebzést okoz. Amikor Ekko varázsol, Heimerdinger 3 rakétát lő, mindegyik 100%-os sebzést okoz. Szerezz egy Heimerdingert és egy Ekko-t.'),
(282, 'Tulajdonság: Harci Törvény', 'Arany', 'Amikor Ambessa varázsol, Caitlyn egy megerősített támadást indít a célpontra, 250%-os sebzést okozva. Ambessa 35%-ot nyer Caitlyn Támadási Sebességéből. Szerezz egy Caitlyn-t és egy Ambessa-t.'),
(283, 'Tulajdonság: Fenyegetések', 'Arany', 'Amíg Silco mellett van, Powder Dominátor képességet kap, de már nem részesül a Család bónuszból. Amikor a majmocskájának robbanása történik, 3 monstrositás jelenik meg Silco-ból. Szerezz egy 2-csillagos Powder-t és egy Silco-t.'),
(284, 'Tulajdonság: Újjáalakulás', 'Arany', 'Amikor Vi varázsol, Ekko 3 utánképet indít, amelyek 50%-os sebzést okoznak. Amikor Ekko varázsol, Vi egy földrengést indít a célpont felé, 150%-os sebzést okozva. Szerezz egy Vi-t és egy Ekko-t.'),
(285, 'Tulajdonság: Nővérek', 'Arany', 'Amikor Vi takedown-t végez, Jinx 50%-os bónuszt kap a Támadási Sebességére 5 másodpercre. Amikor Jinx takedown-t végez, Vi 40%-os bónuszt kap a Támadási Sebességére 5 másodpercre.'),
(286, 'Tulajdonság: Valószínűtlen Páros', 'Arany', 'Jinx és Sevika 15%-os Támadási Sebesség bónuszt és 150 Életet kapnak. Minden alkalommal, amikor egyikük varázsol, a másik 20 manát kap. Sevika karja szerencsésebb. Szerezz egy Jinx-et és egy Sevika-t.'),
(287, 'Túl Sok Érték', 'Arany', 'Szerezz 1 újrapróbálást minden 3 egyedi két költségű bajnok után, akik az előző harcban részt vettek. Szerezz 3 két költségű egységet.'),
(288, 'Két Trükk', 'Arany', 'Szerezz egy véletlenszerű 2-csillagos két költségű és 2 véletlenszerű 2-csillagos egy költségű bajnokot.'),
(289, 'Alulértékeltek', 'Ezüst', 'Mikor a csapatod kevesebb egységet tart életben, mint az ellenfeled, az egységeid 8%-ot regenerálnak másodpercenként (maximális: 150).'),
(290, 'Szabadon Engedni a Bestiát', 'Arany', 'Szerezz egy Sterak\'s Gage-t. Amikor a hatása aktiválódik, a hordozó 35%-os Támadási Sebességet kap a harc hátralevő részére, és 10 másodpercre immunissá válik a tömegirányító hatásokra.'),
(291, 'Felfelé Ívelő Mobilitás', 'Prizmatikus', 'A vásárlás XP ára 1-tel kevesebb lesz. Szerezz 2 Életet és 2 ingyenes újrapróbálást minden alkalommal, amikor szintet lépsz.'),
(292, 'Vámpíros Vitalitás', 'Arany', 'A sebzésed 25%-át gyógyítod, amit az ellenséges Taktikusok ellen okozol. Az egységeid 12%-os Omnivamp-ot kapnak.'),
(293, 'Látomásos Jelvény', 'Arany', 'Szerezz egy Látomásos Jelvényt és egy Renata Glasc-t.'),
(294, 'Látomásos Korona', 'Prizmatikus', 'Szerezz egy Látomásos Jelvényt, egy Spear of Shojin-t és egy Renata Glasc-t.'),
(295, 'Üresség Rajzás', 'Prizmatikus', 'Szerezz egy Zz\'Rot Portált és egy másikat minden 9 játékos harc után. A Zz\'Rot Portál Voidling-jei 50%-kal több Támadási Sebességet és 40%-kal több Omnivamp-ot kapnak.'),
(296, 'Üresség Hívója', 'Arany', 'Minden 220 manát, amit a Látomásosok elhasználnak a harc közben, egy Voidling-et idéznek, legfeljebb 5 Voidling-et. Szerezz egy Rell-t és egy Morgana-t. A Voidling 550-700 Élettel rendelkezik a szakasz alapján.'),
(297, 'Pálca Túlfutás', 'Prizmatikus', 'Szerezz 5 Needlessly Large Rod-ot. A Needlessly Large Rod-jaid +2,50%-os Támadási Sebességet adnak.'),
(298, 'Vándorló Edző I', 'Arany', 'Szerezz 1 aranyat és egy Képzési Bábút 2 állandóan hozzákapcsolt Emblemmel.'),
(299, 'Vándorló Edző II', 'Prizmatikus', 'Szerezz 6 aranyat és egy Képzési Bábút 3 állandóan hozzákapcsolt Emblemmel.'),
(300, 'Háború az Alvilágért', 'Arany', 'Minden alkalommal, amikor úgy döntesz, hogy megmented a Shimmer-t a Fekete Piacon, gyógyítasz 4 játékos életet és kapsz 6 aranyat. Szerezz egy Rennit.'),
(301, 'Háború Útja', 'Arany', 'Miután 60 játékos sebzést okoztál, szerezz egy ládát magas költségű bajnokokkal és tárgyakkal.'),
(302, 'Őrző Jelvény', 'Arany', 'Szerezz egy Őrző Jelvényt és egy Vander-t.'),
(303, 'Őrző Korona', 'Prizmatikus', 'Szerezz egy Őrző Jelvényt, egy Steadfast Heart-ot és egy Scar-t.'),
(304, 'Üdv a Játszótéren', 'Arany', 'Ha legalább 2 Család tag él 12 másodperccel a harc után, vagy a harc végén, szerezz egy véletlenszerű másolatot Vander, Powder vagy Violet egyikéből. Szerezz egy Powder-t és Violet-t.'),
(305, 'Ami Nem Öl Meg', 'Arany', 'Szerezz 2 aranyat, miután elvesztettél egy játékos harcot. Szerezz egy véletlenszerű alkatrészt minden 4 veszteség után.'),
(306, 'Miért Ne Mindkettő?', 'Arany', 'Amíg 2 ugyanabból a Form Swapper-ből különböző formákban van a pályán, mindkettő 30 Képesség Erőt, Páncélt és Mágikus Ellenállást, valamint 30%-os Támadási Sebességet kap. Amikor 3-csillagosra fejlesztesz egy Form Swapper-t, szerezz egy 2-csillagos másolatot. Szerezz egy Swain-t és Gangplank-et.'),
(307, 'Megéri a Várakozást', 'Arany', 'Szerezz egy véletlenszerű két-csillagos 1 költségű bajnokot. 1 kör után szerezz egy újabb másolatot tőlük minden kör elején a játék hátralévő részében.'),
(308, 'Megéri a Várakozást II', 'Prizmatikus', 'Szerezz egy véletlenszerű 2 költségű bajnokot. Szerezz egy újabb másolatot tőlük minden kör elején a játék hátralévő részében.'),
(309, 'Fiatal és Vad, Szabad', 'Ezüst', 'Mindig szabadon mozoghatsz a Karusszel körökben. Szerezz 2 aranyat.');

-- --------------------------------------------------------

--
-- Table structure for table `board`
--

CREATE TABLE `board` (
  `Board_id` int(11) NOT NULL,
  `Id` int(11) NOT NULL,
  `Boardname` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `board_hexes`
--

CREATE TABLE `board_hexes` (
  `Id` int(11) NOT NULL,
  `Board_id` int(11) NOT NULL,
  `CharacterID` int(11) NOT NULL,
  `hex_x` int(11) NOT NULL,
  `hex_y` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `character`
--

CREATE TABLE `character` (
  `CharacterID` int(11) NOT NULL,
  `CharacterName` varchar(50) NOT NULL,
  `AbilityName` varchar(255) DEFAULT NULL,
  `Ability` text DEFAULT NULL,
  `Cost` int(11) DEFAULT NULL,
  `Health` int(11) DEFAULT NULL,
  `Health1` int(11) DEFAULT NULL,
  `Health2` int(11) DEFAULT NULL,
  `AttackSpeed` double DEFAULT NULL,
  `Damage` int(11) DEFAULT NULL,
  `Damage1` int(11) DEFAULT NULL,
  `Damage2` int(11) DEFAULT NULL,
  `AbilityPower` int(11) DEFAULT NULL,
  `ManaStart` int(11) DEFAULT NULL,
  `ManaMax` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `Range` int(11) DEFAULT NULL,
  `Characterimageblob` longblob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `character`
--

INSERT INTO `character` (`CharacterID`, `CharacterName`, `AbilityName`, `Ability`, `Cost`, `Health`, `Health1`, `Health2`, `AttackSpeed`, `Damage`, `Damage1`, `Damage2`, `AbilityPower`, `ManaStart`, `ManaMax`, `Armor`, `MagicResist`, `Range`, `Characterimageblob`) VALUES
(1, 'Amumu', 'Elavult technológia', 'Passzív: Csökkenti az összes bejövő sebzést 12-vel. Minden másodpercben szikrák keletkeznek, amelyek 10 AP varázssebzést okoznak a szomszédos ellenségeknek.', 1, 600, 1080, 1944, 0.6, 45, 81, 146, 100, 0, 0, 35, 35, 1, NULL),
(2, 'Darius', 'Tizedel', 'Forgás, fizikai sebzést okozva a szomszédos ellenségeknek és gyógyítva az életerőt. Fizikai sebzést okozó vérzést alkalmaz a célponton 4 másodpercen keresztül.', 1, 600, 1080, 1944, 0.7, 55, 99, 178, 100, 30, 70, 40, 40, 1, NULL),
(3, 'Vex', 'Közelgő Sötétség', 'Varázssebzést okoz a célnak, és létrehoz egy sötétség zónát körülötte egy mezőnyi sugárral. Rövid késleltetés után varázssebzést okoz az ellenségeknek, akik még mindig a zónában tartózkodnak.', 1, 450, 810, 1458, 0.7, 30, 54, 97, 100, 0, 60, 15, 15, 4, NULL),
(4, 'Violet', '1-2-3 Kombó', 'Két alkalommal megszúrja a célt fizikai sebzéssel. Ezután felütéssel támadja, fizikai sebzést okozva, és rövid időre felrepíti őt.', 1, 650, 1170, 2106, 0.8, 50, 90, 162, 100, 20, 65, 40, 40, 1, NULL),
(5, 'Zyra', 'Tüskés Gyökerek', 'Szőlőket küld a célpont felé, megütve őt és 1 másodpercre megkábítva, miközben varázssebzést okoz. Ezután kisebb szőlők keresnek két legközelebbi ellenséget, és varázssebzést okoznak nekik.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 120, 10, 60, 20, 20, 4, NULL),
(6, 'Draven', 'Forgó Harapások', 'Passzív: Ha Dravennek van egy megerősített balta a kezében, az felválthatja a következő támadását, fizikai sebzést okozva. A megerősített balták visszatérnek Dravenhez, miután eltaláltak egy ellenséget. Aktív: Forgat egy megerősített baltát.', 1, 500, 900, 1620, 0.7, 55, 99, 178, 100, 30, 60, 15, 15, 4, NULL),
(7, 'Irelia', 'Kihívó Tánc', 'Védelmi állásba lép, és pajzsot szerez, amely gyorsan elhalványul 3 másodperc alatt. Amikor a pajzs lejár, varázssebzést okoz, plusz 30%-át az elnyelt sebzésnek, az Irelia körüli és előtte lévő ellenségeknek.', 1, 700, 1260, 2268, 0.6, 45, 81, 146, 100, 30, 70, 40, 40, 1, NULL),
(8, 'Lux', 'Prizmatikus Pajzs', 'Pajzsot ad a legkevesebb aktuális életerővel rendelkező szövetségesnek. Lux következő támadása bónusz varázssebzést okoz.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 100, 0, 50, 20, 20, 4, NULL),
(9, 'Maddie', 'Kalapács Tűz', 'Lőj 6 lövést a legmesszebb lévő ellenség felé, amelyek fizikai sebzést okoznak az első ellenségnek, akit eltalálnak.', 1, 500, 900, 1620, 0.7, 50, 80, 162, 100, 20, 120, 15, 15, 4, NULL),
(10, 'Powder', 'Zűrös Játékfigura', 'Küldj egy majmot a legnagyobb ellenségcsoport felé, ami egy 2 mezőnyi sugárral robban fel a találatkor. Az eltalált ellenségek varázssebzést szenvednek, amely csökken a robbanás középpontjától való távolságuk függvényében. Sebezést és 1%-os égést alkalmaz minden eltalált ellenségre 5 másodpercig.', 1, 500, 900, 1620, 0.7, 35, 63, 113, 100, 40, 120, 15, 15, 4, NULL),
(11, 'Singed', 'Veszélyes Mutációk', 'Növeli a tartósságot, és a legtöbb sebzést okozó szövetségesnek támadási sebességet biztosít, ami 4 másodperc alatt elhalványul.', 1, 650, 1170, 2106, 0.6, 55, 99, 178, 100, 0, 50, 40, 40, 1, NULL),
(12, 'Steb', 'Terepi Orvostudomány', 'Passzív: Gyógyuláskor a két legközelebbi szövetségest gyógyítja a gyógyulás 25%-ával. Aktív: Gyógyít, és varázssebzést okoz a célnak.', 1, 650, 1170, 2106, 0.55, 55, 99, 178, 100, 30, 90, 45, 45, 1, NULL),
(13, 'Trundle', 'Kétségbeesett Rágás', 'Gyógyítja az egészséget és megrágja a célt fizikai sebzéssel. Mindkét hatás akár 75%-kal megnövelhető Trundle hiányzó életereje alapján.', 1, 650, 1170, 2106, 0.65, 50, 90, 162, 100, 30, 90, 40, 40, 1, NULL),
(14, 'Morgana', 'Kínzó Lélek', 'Átkoz egy legközelebbi, nem átkozott ellenséget, varázssebzést okozva neki 10 másodperc alatt, és csökkenti rajta használt pajzsok hatékonyságát 50%-kal.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 100, 0, 40, 20, 20, 4, NULL),
(15, 'Akali', 'Shuriken Flip', 'Aktív: Akali shurikent dob a célpontra, varázssebzést okozva, és megjelöli őket, hogy 4 másodpercig több sebzést szenvedjenek el. Ezután Akali elugrik a célponttól, majd egy rövid késleltetés után visszaugrik hozzájuk, és újabb varázssebzést okoz.', 2, 700, 1260, 2268, 0.75, 45, 81, 146, 100, 0, 60, 45, 45, 1, NULL),
(16, 'Camille', 'Adaptív csapás', 'Aktív: Megrúgja a célpontot, [150 / 224 / 374] adaptív sebzést okozva. Visszatölti az okozott sebzés 33%-át.', 2, 700, 1260, 2268, 0.75, 50, 90, 162, 100, 0, 25, 45, 45, 1, NULL),
(17, 'Nocturne', 'Túláradó pengék', '6 másodpercig a támadások a környező ellenségeket is vérzésre kényszerítik, amely fizikai sebzést okoz 1 másodpercig.', 2, 700, 1260, 2268, 0.75, 65, 117, 211, 100, 0, 40, 45, 45, 1, NULL),
(18, 'Rell', 'Törő Ütés', 'Pajzsot kap 4 másodpercre. Lándzsával eltalálja az ellenségeket egy vonalban varázssebzéssel, és elrabolja az általuk viselt Páncélt és Varázsvédelmet.', 2, 800, 1440, 2592, 0.6, 60, 108, 194, 100, 40, 90, 45, 45, 1, NULL),
(19, 'Renata', 'Hűségprogram', 'Lő egy pár rakétát a célpontra. Azokat az szövetségeseket, akiken áthaladnak, 3 másodpercre pajzshoz juttatja. Amikor ütköznek, varázssebzést okoznak a célpontnak és varázssebzést az érintett ellenségeknek.', 2, 600, 1080, 1944, 0.7, 35, 63, 113, 100, 20, 80, 20, 20, 4, NULL),
(20, 'Sett', 'Fejtörő', 'Aktiváláskor az ellenfeleket mindkét oldalról magához húzza és összeszedi őket, mágikus sebzést okozva és megállítva őket. Ha csak egy ellenséget húz be, akkor a sebzés és a Stun időtartama 50%-kal nő.', 2, 850, 1530, 2754, 0.6, 60, 108, 194, 100, 50, 100, 50, 50, 1, NULL),
(21, 'Tristana', 'Rajzolj egy Gyöngyöt', 'A karakter ágyúgolyót lő a célpontra, fizikai sebzést okozva. Ha a célpont meghal, az ágyúgolyó visszapattan a legközelebbi ellenségre, és okozza az extrasebzést. Amikor ez megtörténik, permanensen növeli a támadó sebzését egy bizonyos százalékával.', 2, 550, 990, 1782, 0.7, 40, 72, 130, 100, 20, 60, 20, 20, 4, NULL),
(22, 'Urgot', 'Korrosív Töltet', 'Lő egy robbanó töltetet, fizikai sebzést okozva a célpontnak és a szomszédos ellenségeknek. 20%-kal csökkenti az összes eltalált ellenség Páncélját 6 másodpercre. Kísérleti Bónusz: A harc kezdetekor és képesség használata után rohan a célponthoz, majd szerez maximális életerő pajzsot és támadási sebességet 5 másodpercre.', 2, 700, 1260, 2268, 0.7, 50, 90, 162, 100, 20, 70, 45, 45, 2, NULL),
(23, 'Vander', 'Alvilági kopó', 'Vander 2,5 másodpercre megáll a támadással, és megerősödik, miközben a következő támadása extra fizikai sebzést okoz. A megerősödés mértéke a csapatban lévő 1-es vagy 2-es költségű bajnokok számától függ.', 2, 800, 1440, 2592, 0.7, 50, 90, 162, 100, 0, 50, 45, 45, 1, NULL),
(24, 'Vladimir', 'Transzfúzió', 'A karakter meggyógyítja és varázssebzést okoz a célpontnak.', 2, 800, 1440, 2592, 0.65, 45, 81, 146, 100, 65, 65, 45, 45, 1, NULL),
(25, 'Zeri', 'Élő Akkumulátor', 'A karakter minden harmadik támadása egy szikrával helyettesítődik, amely fizikai sebzést okoz a célpontnak és 2 közeli ellenségnek.', 2, 600, 1080, 1944, 0.75, 45, 81, 146, 100, 3, 3, 20, 20, 4, NULL),
(26, 'Ziggs', 'Bombák Bombája', 'A karakter egy bombát dob a célpontra, varázssebzést okozva. 3 mini-bomba repül ki, és véletlenszerű ellenségeknek okoz varázssebzést.', 2, 600, 1080, 1944, 0.7, 35, 63, 113, 100, 15, 60, 20, 20, 4, NULL),
(27, 'Leona', 'Napfogyatkozás', 'Aktiváláskor Leona 3 másodpercre megerősödik, és 50% szívósságra tesz szert. Ezután 115 varázssebzést okoz a szomszédos ellenfeleknek.', 2, 800, 1440, 2592, 0.6, 55, 99, 178, 0, 40, 80, 50, 50, 1, NULL),
(28, 'Scar', 'Sumpsnipe Meglepetés', 'Bombákat dob a legközelebbi 3 ellenségre, Stun-olja őket 1,5 másodpercre, és varázssebzést okoz mindegyiknek. Gyógyítja a karakter életerejét.', 3, 800, 1440, 2592, 0.65, 50, 90, 162, 100, 80, 155, 50, 50, 1, NULL),
(29, 'Smeech', 'Hulladék Heker', 'A karakter a legkevesebb tárggyal rendelkező ellenség felé ugrik 4 hexen belül. Háromszor csap, összesen fizikai sebzést okozva. Ha az ellenség meghal, ismét ugrik, de 30%-kal kevesebb sebzést okoz.', 3, 800, 1440, 2592, 0.8, 65, 117, 211, 100, 20, 80, 50, 50, 1, NULL),
(30, 'Swain', 'Démoni Felemelkedés', 'Elülső: Gyógyít és felemelkedik 6 másodpercre. Miközben felemelkedett, gyógyít és varázssebzést okoz a közeli ellenségeknek minden másodpercben. Ha egy ellenséget legyőz, a felemelkedés időtartama 2 másodperccel meghosszabbodik. Hátsó: 8 varjút küld a célpontra, amelyek varázssebzést okoznak. Mindegyik varjú egy közeli ellenséghez repül, és varázssebzést okoz.', 3, 650, 1170, 2106, 0.7, 40, 72, 130, 100, 20, 70, 25, 25, 1, NULL),
(31, 'Twisted Fate', 'Vad Kártyák', 'Három kártyát dob különböző célpontokra. Kék Kártya: Visszaállítja az életerőt a legalacsonyabb életerővel rendelkező szövetségesnek. Piros Kártya: Varázssebzést okoz a legnagyobb ellenségkörben. Sárga Kártya: Varázssebzést okoz a célpontnak, és Stun-olja 1 másodpercre.', 3, 700, 1260, 2268, 0.7, 35, 63, 113, 100, 25, 75, 25, 25, 4, NULL),
(32, 'Blitzcrank', 'Statikus Mező', 'Passzív: Sérülés után a karakter a megnyelt sebzés 0,03%-át varázssebzés formájában visszaveri a célpontra. Aktív: 415/440/465 (AP) pajzsot nyer 4 másodpercre. Sokkolja a legközelebbi 3 ellenséget 40/60/100 (AP) varázssebzéssel és csökkenti a sebzésüket 0,1%-kal 4 másodpercre.', 3, 850, 1530, 2754, 0.65, 50, 90, 162, 100, 50, 100, 50, 50, 1, NULL),
(33, 'Ezreal', 'Esszencia Áramlás', 'A karakter egy lövéssel célozza meg a jelenlegi célpontját, amely fizikai sebzést okoz minden ellenségnek 1 hexen belül. Ezután fizikai sebzést okoz a robbanás középpontjában lévő egységnek.', 3, 700, 1260, 2268, 0.75, 60, 108, 194, 100, 60, 60, 25, 25, 4, NULL),
(34, 'Gangplank', 'Aratás a Lángokból', 'Elülső: Tisztítja az összes negatív hatást és gyógyítja a karakter életerejét. Vágás, amely fizikai sebzést okoz az ellenségeknek egy vonalban. Ha csak egy ellenség találkozik a támadással, a sebzés megduplázódik. Hátsó: Passzív: Miközben Mana-t nyer, 3 ragadós bombát dob el. Ha az ellenség, akire rátapadnak, meghal, átkerülnek egy másik közeli ellenségre. Aktív: Aktiváld a bombákat, hogy fizikai sebzést okozzanak az ellenségnek, akire rátapadtak, és fizikai sebzést az összes közeli ellenségnek.', 3, 700, 1260, 2268, 0.7, 50, 90, 162, 100, 75, 75, 20, 20, 1, NULL),
(35, 'Kogmaw', 'Fokozó Lőmód', 'Passzív: A támadások bónusz varázssebzést okoznak. Aktív: 25%-os, felhalmozódó támadási sebességet szerzel a harc hátralévő részére. Minden 3 használat után +1 hatótávot nyersz.', 3, 650, 1170, 2106, 0.7, 15, 27, 49, 100, 40, 40, 25, 25, 4, NULL),
(36, 'Loris', 'Piltover Pajzs', 'A karakter pajzsot kap 4 másodpercre. A pajzs 50%-át az őt körülvevő szövetségesek által elszenvedett sebzésnek átirányítja. Amikor a pajzs lejár, varázssebzést okoz egy kúpszerű területen.', 3, 850, 1530, 2754, 0.65, 50, 90, 162, 100, 50, 100, 50, 50, 1, NULL),
(37, 'Nami', 'Oceán Áramlás', 'Egy hullámot indít a célpont felé, amely háromszor visszapattan 3 hexen belüli ellenségekre, varázssebzést okozva mindegyiknek.', 3, 700, 1260, 2268, 0.7, 40, 72, 130, 100, 60, 60, 25, 25, 4, NULL),
(38, 'Nunu', 'ZOMBIE ERŐ!!', '3 másodpercre tartózkodj megnövelt ellenállással, és hozz létre egy 2 hex széles füstfelhőt, amely varázssebzést okoz az ellenségeknek. Ezután robbantsd fel a felhőt, és varázssebzést okozz az összes belső ellenségnek. Kísérleti Bónusz: Sebzés után 3%-os maximális életerő bónusz varázssebzést okozol (1 másodperces lehűlés).', 3, 800, 1440, 2592, 0.6, 50, 90, 162, 100, 60, 125, 50, 50, 1, NULL),
(39, 'Renni', 'Sludgerunner Ütés', 'A karakter 1,5 másodperc alatt gyógyítja meg magát. A képesség alatt felemeli a célpontot a levegőbe, Stun-olja és fizikai sebzést okoz. Ezután lecsapja a földre, fizikai sebzést okozva minden közeli ellenségnek.', 3, 850, 1530, 2754, 0.65, 55, 99, 178, 100, 40, 100, 50, 50, 1, NULL),
(40, 'Cassiopeia', 'Tövises Miasma', 'A karakter varázssebzést okoz a célpontnak. Minden harmadik használatkor a miasma két ellenségre szóródik a 3 hexen belül, varázssebzést okozva mindegyiknek.', 3, 700, 1260, 2268, 0.7, 40, 72, 130, 100, 10, 40, 25, 25, 4, NULL),
(41, 'Ekko', 'Másodpercek Felosztása', 'Elő hív egy utóképeket támadó hullámot, amely varázssebzést okoz a célpontnak és más közeli ellenségeknek. Az utóképek csökkentik a célpont varázsellenállását 5-tel a harc hátralévő részére.', 4, 1100, 1980, 3564, 0.85, 50, 90, 162, 100, 0, 60, 60, 60, 1, NULL),
(42, 'Elise', 'Kóma', 'Előre: Ugorj egy közeli hexára, és webeld be az összes ellenséget 2 hexen belül, Stun-olva őket és varázssebzést okozva. Gyógyítsd meg az életerőt. Hátra: Küldj pókcsemetéket a 4 legközelebbi ellenség felé, amelyek érintkezéskor felrobbannak, varázssebzést okozva a célpontnak és varázssebzést azok körül.', 4, 750, 1350, 2430, 0.75, 45, 81, 146, 100, 0, 10, 30, 30, 1, NULL),
(43, 'Garen', 'Demaciai Igazság', 'Passzív: Sebzés okozása után gyógyulj meg. Aktív: Nyerd el a Páncélt 4 másodpercre. Csapj le egy hatalmas karddal a célpontra, fizikai sebzést okozva nekik, és fizikai sebzést okozva az 2 hexen belüli ellenségeknek.', 4, 1000, 1800, 3240, 0.6, 65, 117, 211, 100, 60, 125, 60, 60, 1, NULL),
(44, 'Heimerdinger', 'PROGRESSSSS!', 'Lőj rakétákat véletlenszerű ellenségekre, amelyek varázssebzést okoznak. Minden egyes használatnál 1 rakéta több indul, mint az előző alkalommal.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 0, 40, 30, 30, 4, NULL),
(45, 'Illaoi', 'A Lélek Próbája', 'Nyerd el a Tartósságot 3 másodpercre. Az időtartam alatt elszívod az életerőt a legközelebbi ellenségektől. Ezt követően csapj le, varázssebzést okozva minden ellenségnek 2 hexen belül.', 4, 1100, 1980, 3564, 0.65, 70, 126, 227, 100, 65, 125, 60, 60, 1, NULL),
(46, 'Dr.Mundo', 'Maximális Dózis', 'Aktiváld az energiát, és gyógyulj 2 másodperc alatt. Amíg energizált állapotban vagy, minden másodpercben varázssebzést okozol egy közeli ellenségnek. Ezt követően varázssebzést okozol minden ellenségnek 2 hexen belül. Kísérleti Bónusz: 120 maximális életerőt kapsz. Ha egy ellenséget legyőzöl, 60 maximális életerőt nyersz a harc hátralévő részére.', 4, 1100, 1980, 3564, 0.65, 60, 108, 194, 100, 30, 100, 60, 60, 1, NULL),
(47, 'Silco', 'Konzerv Szörnyeteg', 'Hajíts egy kannát a célpontra, amely varázssebzést okoz és szörnyetegeket szabadít el. A szörnyetegek 5 alkalommal támadnak, minden támadás varázssebzést okoz.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 30, 80, 30, 30, 4, NULL),
(48, 'Twitch', 'Fújj és Imádkozz', 'Az elkövetkező 8 támadásnál szerez +85% támadási sebességet, végtelen hatótávolságot, és le cserélo a támadásokat egy áthatoló nyílra, amely véletlenszerű ellenségeket céloz. A nyilak fizikai sebzést okoznak, csökkentve azt minden ellenségen, amin áthaladnak. Kísérleti Bónusz: Minden 5. támadás után fizikai sebzést okozol a legközelebbi ellenségnek, ami a maximális egészségük % -ának megfelelően.', 4, 800, 1440, 2592, 0.75, 50, 90, 162, 100, 60, 60, 30, 30, 4, NULL),
(49, 'Vi', 'Zúzó Csapat', 'Nyerd el a Pajzsot 3 másodpercre, majd Stunold meg a célt 1,5 másodpercre. Csapd le őket, fizikai sebzést okozva, és egy sokkhullámot keltve a sorukban. Az ellenségek fizikai sebzést kapnak és rövid időre felrepülnek.', 4, 1100, 1980, 3564, 0.85, 75, 135, 243, 100, 40, 100, 50, 50, 1, NULL),
(50, 'Zoe', 'Csillag Pörgetés!', 'Lőj egy csillagot a célpontra, amely varázssebzést okoz. Az visszapattan a legmesszebb lévő ellenséghez 4 hexen belül, majd visszapattan a célponthoz. Ez a hatás ismétlődik, minden alkalommal egy másik ellenséget eltalálva.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 20, 80, 30, 30, 4, NULL),
(51, 'Ambessa', 'Kíméletlen Vadásznő', 'Ambessa két állás között vált aktiváláskor: Láncok: +1 hatótávot nyersz. A támadások fizikai sebzést okoznak. Aktiváláskor dash-elsz a célponthoz, és félkörben csapsz, fizikai sebzést okozva az eltalált ellenségeknek. Ököl: Omnivampot kapsz, és kétszer olyan gyorsan támadsz. Aktiváláskor röviden Stun-olod a célpontot, majd a földhöz csapod, fizikai sebzést okozva, végül elugrasz.', 4, 1100, 1980, 3564, 0.8, 65, 117, 211, 100, 40, 100, 50, 50, 1, NULL),
(52, 'Corki', 'Széles Oldali Lövöldözés', 'Célozz meg egy célpontot, majd egy közeli pozícióba mozogj, miközben rakétákat lősz, amelyek a célpont és minden ellenség között oszlanak el 2 hexen belül. Minden rakéta fizikai sebzést okoz, és csökkenti az ellenség páncélját 1-tel. Minden 7. rakéta fizikai sebzést okoz és 7-tel csökkenti a páncélt.', 4, 850, 1530, 2754, 0.75, 60, 108, 194, 100, 0, 60, 30, 30, 4, NULL),
(53, 'LeBlanc', 'The Chains of Fate', 'Aktív: Az 5 legközelebbi ellenséget összeköti láncokkal 5 másodpercre, megosztott varázssebzést okozva közöttük. Amikor egyet sebzés ér, a sebzés egy része bónusz igaz sebzésként oszlik meg a többi között. LeBlanc következő 3 támadása bónusz varázssebzést okoz, amely 0,5%-kal növekszik minden ellenség után, akit az eredeti sebzés megöl.', 5, 900, 1620, 2916, 0.8, 50, 90, 162, 100, 45, 90, 40, 40, 4, NULL),
(54, 'Malzahar', 'Call of the Machine', 'Aktív: Egy kaput idéz meg, amely egy 5 mezős vonalon halad át a célponton. Az eltalált ellenségek varázssebzést szenvednek el, és 20%-os Shred hatást kapnak 4 másodpercig. Malzahar 5 fertőzéshalmot terjeszt az eltalált ellenségek között. Fertőzés: Minden másodpercben varázssebzést okoz a harc hátralevő részében. Ez a hatás végtelenül halmozható. Amikor egy fertőzött célpont meghal, a halmokat a közeli ellenségekre terjeszti. Shred: Csökkenti a varázsellenállást.', 5, 950, 1710, 3078, 0.8, 45, 81, 146, 100, 45, 105, 40, 40, 4, NULL),
(55, 'Mordekaiser', 'Vasszellem markolása', 'Aktív: Rövid időre 40%-kal növeli a tartósságot, és egy hatalmas karmot idéz meg, amely varázssebzést okoz a legtöbb ellenségnek egy vonalban. A négy legközelebbi ellenség 25%-kal több sebzést kap, és Mordekaiser felé húzódik. A következő tíz másodpercben 30% életlopást kap, megnövelt támadási hatótávot szerez, és minden támadása helyett egy csapást hajt végre, amely varázssebzést okoz a célpontnak, valamint további varázssebzést minden más ellenségnek két hex távolságon belül.', 5, 1200, 2160, 3888, 0.55, 75, 135, 243, 100, 40, 100, 70, 70, 1, NULL),
(56, 'Rumble', 'Az Egyenlítő', 'Hívj le 5 rakétát a cél sorára, amelyek mindegyike varázssebzést okoz, Sebzést és 1%-os Égést alkalmaz az eltalált egységeken 5 másodpercig. Minden olyan rakéta esetén, amely nem talál el ellenséget, 20 Manát visszanyersz. Ha már csak 1 ellenség marad, akkor mind az összes rakétát rájuk lődd. Égetés: Az ellenfél maximális életerejének egy százalékát igaz sebzésként okozza másodpercenként. Sebzés: Csökkenti a kapott gyógyítást 33%-kal.', 5, 1200, 2160, 3888, 0.8, 60, 108, 194, 100, 40, 120, 70, 70, 1, NULL),
(57, 'Sevika', 'A Szerencse Próbája', 'Véletlenszerűen elhúzódik 1 a 3 varázslat közül, esély van Jackpot-ra! Lángszóró: Igaz sebzést okoz a célpontnak minden másodpercben a haláláig. Az őt körülvevő ellenségek 50%-kal kevesebb fizikai sebzést kapnak. Hosszú Ütés: Fizikai sebzést okoz a célpontnak, és eltaszítja őket. Ezután dash-el a célponthoz, és 1 hex körüli körben fizikai sebzést okoz. Rágás: Fizikai sebzést okoz a célpontnak. Ha az életereje 15%-nál kevesebb, végrehajtja őt, és újra elvégzi a legkevesebb életerővel rendelkező célpont számára 2 hex távolságra, 80%-os sebzéssel.', 5, 1200, 2160, 3888, 0.9, 80, 144, 259, 100, 0, 60, 60, 60, 1, NULL),
(58, 'Caitlyn', 'Légi Támadás', 'Vedd fel a mesterlövész pozíciót, és hívd be a léghajót, amely 5 másodpercig köröz a csatatéren, és 4 bombát dob egy véletlenszerű ellenséges csoport közé. A bombák fizikai sebzést okoznak egy egy-hexes körben. Mikor egy ellenség a Légi Támadás robbanásának epicentrumába kerül, csökkenti az Ő védelmét és varázsellenállását 20-mal, miközben egy lövéssel célba veszi őt, és fizikai sebzést okoz.', 5, 900, 1620, 2916, 0.55, 80, 144, 259, 100, 0, 50, 40, 40, 4, NULL),
(59, 'Jayce', 'Különleges Szállítmány', 'Passzív: Helyezzen el egy Hextech Forge-t. Aktiváláskor a legközelebbi 3 szövetséges pajzsot kap 4 másodpercre. Ha elpusztul, 100%-os életerővel újraéleszti. Aktív: Hívjon elő 2 Hexgate-et, és dobja be a célt az egyikbe, fizikai sebzést okozva, miközben visszaküldi őket az eredeti helyükre. A repülés közben a célpont minden ellenséget eltalál a pályán, fizikai sebzést okozva.', 5, 900, 1620, 2916, 0.8, 60, 108, 194, 100, 30, 80, 35, 35, 1, NULL),
(60, 'Jinx', 'Minden Elpusztítása', 'Aktív: Jinx váltogat a következő képességek között: Zap: Fizikai sebzést okoz az ellenségeknek egy vonalban, és 1,25 másodpercre megmerevíti őket. Flame Chompers: Fizikai sebzést okoz 3, 1 hex-es körben lévő ellenségnek. Death Rocket: Lőjön egy rakétát a tábla közepére, ami fizikai sebzést okoz MINDEN ellenségnek, a sebzés 10%-kal csökken minden egyes hex-távolság után, amely távolabb van az epicentrumtól.', 5, 900, 1620, 2916, 0.8, 60, 108, 194, 100, 0, 60, 40, 40, 4, NULL),
(61, 'Mel', 'Mágia Csatorna', 'Mel teleportál egy közeli szövetségeshez vagy egy kiválasztott pontra a pályán, pajzsot biztosítva magának és a közeli szövetségeseinek, amely elnyeli a sebzést. A pajzsok által blokkolt sebzés energiává alakul, és ha Mel többször is használja a képességét, az energiát mágikus sebzéssé alakítja.', 6, 800, 800, 1000, 0.7, 60, 60, 80, 0, 50, 100, 35, 35, 3, NULL),
(62, 'Viktor', 'Kaosz Vihar', 'Viktor egy hatalmas vihart szabadít el, amely egy vonalban sebzi az ellenségeket, miközben csökkenti azok páncélját és varázsellenállását. A képesség többször is aktiválható, minden alkalommal nagyobb sebzést okozva.', 6, 900, 900, 1100, 0.65, 75, 75, 95, 0, 60, 120, 40, 40, 3, NULL),
(63, 'Warwick', 'Vérvadászat', 'Warwick az alacsony egészségű ellenséget vadászza le, és jelentős bónusz sebzést okoz. Miután Warwick öt ellenséget legyőzött, bónusz támadási sebességet, életvisszanyerést és sebzéscsökkentést kap egy rövid időre.', 6, 850, 850, 1020, 0.75, 70, 70, 90, 0, 50, 100, 30, 30, 1, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `characterclass`
--

CREATE TABLE `characterclass` (
  `CharacterID` int(11) NOT NULL,
  `ClassID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `characterclass`
--

INSERT INTO `characterclass` (`CharacterID`, `ClassID`) VALUES
(1, 4),
(1, 28),
(2, 11),
(2, 28),
(3, 14),
(3, 15),
(4, 6),
(4, 9),
(5, 12),
(5, 24),
(6, 9),
(6, 11),
(7, 15),
(7, 18),
(8, 1),
(8, 24),
(9, 16),
(9, 26),
(10, 5),
(10, 6),
(10, 19),
(11, 18),
(11, 25),
(12, 26),
(12, 29),
(13, 5),
(13, 29),
(14, 8),
(14, 14),
(15, 10),
(15, 15),
(16, 19),
(16, 26),
(17, 4),
(17, 10),
(18, 11),
(18, 14),
(18, 18),
(19, 14),
(19, 25),
(20, 15),
(20, 29),
(21, 13),
(21, 23),
(22, 9),
(22, 12),
(22, 23),
(23, 6),
(23, 28),
(24, 8),
(24, 24),
(24, 28),
(25, 16),
(25, 21),
(26, 5),
(26, 7),
(27, 1),
(27, 18),
(28, 21),
(28, 28),
(28, 29),
(29, 19),
(29, 25),
(30, 3),
(30, 11),
(30, 24),
(31, 10),
(31, 26),
(32, 4),
(32, 7),
(33, 1),
(33, 15),
(33, 23),
(34, 3),
(34, 5),
(34, 9),
(35, 4),
(35, 16),
(36, 18),
(36, 26),
(37, 13),
(37, 24),
(38, 12),
(38, 14),
(39, 25),
(39, 29),
(40, 7),
(40, 8),
(41, 5),
(41, 19),
(41, 21),
(42, 3),
(42, 8),
(42, 29),
(43, 13),
(43, 28),
(44, 1),
(44, 14),
(45, 15),
(45, 18),
(46, 7),
(46, 12),
(47, 7),
(47, 25),
(48, 12),
(48, 16),
(49, 9),
(49, 26),
(50, 15),
(50, 24),
(51, 10),
(51, 11),
(51, 13),
(52, 5),
(52, 23),
(53, 8),
(53, 24),
(54, 4),
(54, 14),
(55, 7),
(55, 11),
(56, 5),
(56, 18),
(56, 20),
(57, 9),
(57, 17),
(57, 25),
(58, 16),
(58, 26),
(59, 1),
(59, 3),
(60, 15),
(60, 19),
(61, 22),
(62, 2),
(63, 12),
(63, 27);

-- --------------------------------------------------------

--
-- Table structure for table `class`
--

CREATE TABLE `class` (
  `ClassID` int(11) NOT NULL,
  `ClassName` varchar(50) NOT NULL,
  `BasicEffect` text DEFAULT NULL,
  `Classimageblob` longblob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `class`
--

INSERT INTO `class` (`ClassID`, `ClassName`, `BasicEffect`, `Classimageblob`) VALUES
(1, 'Akadémia', 'Az Akadémia három tárgyat szponzorál minden játékban. A szponzorált tárgyak másolatai bónusz maximális életerőt és sebzésfokozást biztosítanak. Az Akadémia egységei, akik szponzorált tárgyakat tartanak, kétszeres bónuszt kapnak, plusz további 5% életerőt és sebzésfokozást.', NULL),
(2, 'A gépek hírnöke', 'A gépek megnövelt erővel rendelkeznek, és bónusz életerőt és sebzést kapnak. A gépek emellett extra tartósságot nyernek páncél és varázsellenállás formájában, így ellenállóbbak az ellenséges támadásokkal szemben.', NULL),
(3, 'Alakváltó', 'Az Alakváltók képesek átalakulni a csata során, lehetővé téve számukra, hogy formát változtassanak és fokozzák harci képességeiket. Alkalmazkodnak a helyzethez, és jelentős erőt nyernek, ahogy a harc folytatódik.', NULL),
(4, 'Automata', 'Az \"Automata\" effektusa szerint, amikor sebzést okoznak, kristályokat szereznek. Ha elérik a 20 kristályt, egy mágikus sebzést okozó robbanást idéznek elő a célpontjukon, amely tartalmazza a korábbi robbanás óta kapott sebzés 20%-át, miközben visszaállítják a kristályokat. Ezen kívül növelik a Páncélt és a Mágikus Ellenállást is.', NULL),
(5, 'Barkácsoló', 'A Barkácsolók képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.', NULL),
(6, 'Család', 'A Család egységei bónusz életerőt és támadási sebzést kapnak a családtagok számának megfelelően a táblán. Minél több családtag van jelen, annál erősebbek az effektek.', NULL),
(7, 'Egyeduralkodó', 'Az Egyeduralkodó egységei bónusz sebzést és életerőt kapnak, valamint képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat.', NULL),
(8, 'Fekete rózsa', 'A Fekete rózsa egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.', NULL),
(9, 'Gladiátor', 'A Gladiátor egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(10, 'Gyorstámadó', 'A Gyorstámadó egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(11, 'Hódító', 'A Hódító egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(12, 'Kísérlet', 'A Kísérlet egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(13, 'Követ', 'A Követ egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(14, 'Látnok', 'A Látnok egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(15, 'Lázadó', 'A Lázadó egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.', NULL),
(16, 'Mesterlövész', 'A Mesterlövész egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(17, 'Nagy menő', 'A Nagy menő egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(18, 'Örző', 'Az Örző egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(19, 'Rajtaütő', 'A Rajtaütő egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.', NULL),
(20, 'Roncskirály', 'A Roncskirály egységei képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.', NULL),
(21, 'Szikra', 'A Szikra egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(22, 'Száműzött varázsló', 'A Száműzött varázslók képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.', NULL),
(23, 'Tüzér', 'A Tüzér egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(24, 'Varázsló', 'A Varázsló egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(25, 'Vegybáró', 'A Vegybárók képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.', NULL),
(26, 'Végrehajtó', 'A Végrehajtó egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(27, 'Vérvadász', 'A Vérvadász egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL),
(28, 'Virrasztó', 'A \"Virrasztó\" egységek megnövekedett Ellenállással rendelkeznek, amely tovább nő, ha több mint 50%-os életük van.', NULL),
(29, 'Zúzó', 'A Zúzó egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `classlevelbonus`
--

CREATE TABLE `classlevelbonus` (
  `ClassID` int(11) NOT NULL,
  `Level` int(11) NOT NULL,
  `CharacterCount` int(11) DEFAULT NULL,
  `BonusEffect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `classlevelbonus`
--

INSERT INTO `classlevelbonus` (`ClassID`, `Level`, `CharacterCount`, `BonusEffect`) VALUES
(1, 1, 3, '2% Életerő DA; szerezzen 1 szponzorált tárgyat.'),
(1, 2, 4, '3% Életerő DA; szerezzen 1 szponzorált tárgyat.'),
(1, 3, 5, '4% Életerő DA; szerezzen 1 szponzorált tárgyat.'),
(1, 4, 6, '8% Életerő DA'),
(2, 1, 1, 'Viktornak fix támadási sebessége van 0.55 támadás másodpercenként, és minden bónusz támadó sebességet, támadó sebzést és manát Képesség Erővé alakít át.\nA Mana helyett Viktor minden támadással 1 Kaotikus Energiát nyer, és akkor indítja el a képességét, amikor 8 Kaotikus Energia összegyűlik.'),
(3, 1, 2, '15% Védekezési Ráta (DR) vagy 20% Támadó Sebzés (DA)'),
(3, 2, 4, '30% Védekezési Ráta (DR) vagy 40% Támadó Sebzés (DA)'),
(4, 1, 2, '125 sebzés, 20 Páncél és MR'),
(4, 2, 4, '300 sebzés, 40 Páncél és MR'),
(4, 3, 6, '625 sebzés, 70 Páncél és MR'),
(5, 1, 2, '1 alkatrész, 25 Pajzs'),
(5, 2, 4, '3 alkatrész, 40 Pajzs'),
(5, 3, 6, 'Minden alkatrész, és a teljes tárgyak szerencséssé válnak! 65 Pajzs'),
(5, 4, 9, 'Radiáns tárgyak generálása! 70 Pajzs'),
(6, 1, 3, '25% csökkentés, 12% Védekezési Ráta (DR)'),
(6, 2, 4, '30% csökkentés, 20% Támadási Sebesség (AS)'),
(6, 3, 5, '40% csökkentés, rablás a felső oldalon! Harc után halad a rablás, minden túlélő családtag után növekvő előrehaladással!'),
(7, 1, 2, '250 Pajzs, 25% Képesség Erő (AP)'),
(7, 2, 4, '500 Pajzs, 50% Képesség Erő (AP)'),
(7, 3, 6, '800 Pajzs, 75% Képesség Erő (AP)'),
(8, 1, 3, 'Egy láncolt Sion megidézése. Ő felszabadul, miután 5 alkalommal cselekszenek a Fekete Rózsa egységek, vagy amikor 65% alá csökken az életereje.'),
(8, 2, 4, 'Sion erősebbé válik, és az ellenségei több sebzést szenvednek el a Fekete Rózsa egységeitől.'),
(8, 3, 5, 'Sion sötét mágiát szabadít el, és teljes életre gyógyul, amikor felszabadul.'),
(8, 4, 7, 'Amikor Sion meghal, életre kel és túlvilági erővel tér vissza!'),
(9, 1, 2, '6% igaz sebzés, 10% Életerő'),
(9, 2, 4, '12% igaz sebzés, 25% Életerő'),
(9, 3, 6, '20% igaz sebzés, 40% Életerő'),
(9, 4, 8, '50% igaz sebzés, 99% Életerő'),
(10, 1, 2, '20-60% Támadási Sebesség (AS)'),
(10, 2, 3, '30-80% Támadási Sebesség (AS)'),
(10, 3, 4, '40-100% Támadási Sebesség (AS). Cél halála esetén a Gyors Támadók egy új célpont felé rohanak, és 200 pajzsot kapnak 3 másodpercre.'),
(11, 1, 2, '18% Támadási Sebzés (AD) és Képesség Erő (AP); 1x Hódítás'),
(11, 2, 4, '27% Támadási Sebzés (AD) és Képesség Erő (AP); 3x Hódítás'),
(11, 3, 6, '42% Támadási Sebzés (AD) és Képesség Erő (AP); 6x Hódítás'),
(11, 4, 9, '100% Támadási Sebzés (AD) és Képesség Erő (AP); 20x Hódítás'),
(13, 1, 1, 'Szerezd meg az Emisszáris bónuszt'),
(13, 2, 4, 'Szerezd meg az összes bónuszt. Az Emisszárok 300 Életerőt és 30% Támadási Sebzést (DA) kapnak'),
(14, 1, 2, '25% Mana'),
(14, 2, 4, '50% Mana'),
(14, 3, 6, '80% Mana'),
(14, 4, 8, '100% Mana, a Képességek 20%-kal gyógyítják a szövetségest a sebzés mértékével megegyezően'),
(15, 1, 3, '15% Támadási Sebzés (AD) és Képesség Erő (AP)'),
(15, 2, 5, '25% Támadási Sebzés (AD) és Képesség Erő (AP), 12% Életerő'),
(15, 3, 7, '45% Támadási Sebzés (AD) és Képesség Erő (AP), 20% Életerő, és minden ellenség Stunolása 2 másodpercre'),
(15, 4, 10, 'A füst jelzés harci kezdetekor és minden 6 másodpercben aktiválódik'),
(16, 1, 2, '7% sebzés minden egyes hexagonon'),
(16, 2, 4, '16% sebzés minden egyes hexagonon'),
(16, 3, 6, '35% sebzés minden egyes hexagonon és +5 Támadási Távolság'),
(17, 1, 1, 'Modok: \n- Rakéta: Lőj 8 rakétát, amelyek mindegyike 100 fizikai sebzést okoz \n- Pajzs: Szerezz 500 pajzsot 4 másodpercre \n- Érme: Szerezz 3 aranyat \n- Tripla: Fejleszd a dobott képességét!'),
(18, 1, 2, '10 Páncél és MR'),
(18, 2, 4, '25 Páncél és MR'),
(18, 3, 6, '50 Páncél és MR'),
(19, 1, 2, '20% Kritikus találat, 10% Kritikus szorzó'),
(19, 2, 3, '30% Kritikus találat, 20% Kritikus szorzó'),
(19, 3, 4, '40% Kritikus találat, 30% Kritikus szorzó'),
(19, 4, 5, '55% Kritikus találat, 35% Kritikus szorzó; ezen kívül 15% Tartósságot is nyersz'),
(20, 1, 1, 'Minden 3. körben nyiss egy fegyvertárat, hogy végleges fejlesztéseket vásárolj a legerősebb Rumble mechanikus egységedhez.'),
(21, 1, 2, 'A kapott sebzés 25%-a'),
(21, 2, 3, 'A kapott sebzés 40%-a'),
(21, 3, 4, 'A kapott sebzés 45%-a. Futás közben hatalmas sebességbeli növekedést kapsz.'),
(22, 1, 1, 'Amikor először kiesnél, ha Mel 12 alkalommal varázsolt játékos harcok során ebben a játékban, megment és életben maradsz. Ezt követően Mel tartósan 10%-os Sebzés Növelést kap.'),
(23, 1, 2, '10% AD'),
(23, 2, 4, '40% AD'),
(23, 3, 6, '50% AD, Minden 5. támadás után indít egy rakétát, amely duplázott sebzést okoz.'),
(24, 1, 2, '20 AP'),
(24, 2, 4, '50 AP'),
(24, 3, 6, '85 AP'),
(24, 4, 8, '100 AP, A képességek 25%-kal csökkentik a célpontjuk sebzését 3 másodpercre.'),
(25, 1, 3, '15 vagy 30; 20 Életerő'),
(25, 2, 4, ''),
(25, 3, 5, '20 vagy 60; 90 Életerő'),
(25, 4, 6, '30 vagy 80; 125 Életerő'),
(25, 5, 7, '30 vagy 120; 180 Életerő'),
(26, 1, 2, '1 egység; 15% Életerő, 12% DA'),
(26, 2, 4, '2 egység; 25% Életerő, 25% DA'),
(26, 3, 6, '4 egység; 40% Életerő, 40% DA'),
(26, 4, 8, '6 egység; 55% Életerő, 60% DA'),
(26, 5, 10, 'MINDEN ellenség; 100% Életerő, 150% DA; Harc kezdete: Konfiskálj minden ellenséges tárgyat!'),
(27, 1, 1, 'Warwick felfalja az ellenségeket, akik 12% alá csökkennek; 400 Életerőt gyógyít, és 50 Manát ad.'),
(28, 1, 2, '10% vagy 25% Védekezési Ráta (DR)'),
(28, 2, 4, '20% vagy 40% Védekezési Ráta (DR)'),
(28, 3, 6, '30% vagy 60% Védekezési Ráta (DR)'),
(29, 1, 2, '20% Életerő'),
(29, 2, 4, '45% Életerő'),
(29, 3, 6, '70% Életerő');

-- --------------------------------------------------------

--
-- Table structure for table `fullitems`
--

CREATE TABLE `fullitems` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Halfitemeffect1` text DEFAULT NULL,
  `Halfitemeffect2` text DEFAULT NULL,
  `bonuseffect` text DEFAULT NULL,
  `bonuseffect1` text DEFAULT NULL,
  `bonuseffect2` text DEFAULT NULL,
  `ActiveEffect` text DEFAULT NULL,
  `Fullitemimageblob` longblob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `fullitems`
--

INSERT INTO `fullitems` (`Id`, `Name`, `Halfitemeffect1`, `Halfitemeffect2`, `bonuseffect`, `bonuseffect1`, `bonuseffect2`, `ActiveEffect`, `Fullitemimageblob`) VALUES
(1, 'Halál penge', '55% sebzés', '', '10% sebzésnövelés', '', NULL, '7% bónusz sebzést okoz.', NULL),
(2, 'Hextech lőpenge', '20% sebzés', '20 varázserő', '15% életvarázs', '', NULL, 'A legalacsonyabb százalékos életerővel rendelkező szövetségest gyógyítja a kiosztott sebzés 20%-ával.', NULL),
(3, 'Az éj kardja', '10% sebzés', '20 páncél', '20% varázsellenállás', '', NULL, 'Egyszer minden harc során: Ha az életerőd 60%-ra csökken, rövid időre célozhatatlanná válsz, és megszabadulsz a negatív hatásoktól. Ezt követően 15%-os bónusz támadási sebességet kapsz.', NULL),
(4, 'Vérszomja', '15% sebzés', '20 varázsellenállás', '15 varázserő', '', NULL, '20% minden sebzésből gyógyítás. Egyszer minden harc során, ha az életerő 40%-ra csökken, egy 25%-os maximális életerőnyi pajzsot kap, amely legfeljebb 5 másodpercig tart. Minden sebzésből gyógyítás: A kiosztott sebzés egy részével gyógyítja magát.', NULL),
(5, 'Sterak kihívása', '150 életerő', '10% sebzés', '', '', NULL, 'Egyszer minden harc során: Ha az életerőd 60%-ra csökken, 25%-kal megnő a maximális életerőd, és 35%-kal a sebzésed.', NULL),
(6, 'Óriásölő', '25% sebzés', '25 varázserő', '10 támadási sebesség', '5% sebzésnövelés', NULL, '25%-kal több sebzést okoz az 1750-nél nagyobb maximális életerővel rendelkező ellenségeknek.', NULL),
(7, 'Shojin Lándzsája', '15 mana', '15% sebzés', '15 varázserő', '', NULL, 'A támadások 5 bónusz Manát adnak.', NULL),
(8, 'Határtalan penge', '35% sebzés', '35% kritikus csapási esély', '', '', NULL, 'A képességek képesek kritikus csapást mérni. Ha a birtokos képességei már képesek kritikus csapásra, akkor 10% kritikus sebzés bónuszt kap helyette.', NULL),
(9, 'Koronaőr', '20 varázserő', '20 páncél', '100 életerő', '', NULL, 'Harc kezdetén: 30%-os maximális életerőnek megfelelő pajzsot kapsz 8 másodpercre. Amikor a pajzs lejár, 35 képességerőt kapsz.', NULL),
(10, 'Ionos szikra', '15 varázserő', '15 varázsellenállás', '150 életerő', '', NULL, '30%-kal csökkenti a varázsellenállást a 2 mezőn belüli ellenségeknél. Amikor az ellenségek képességet használnak, varázssebzést szenvednek el, amely a maximális manájuk 160%-ának felel meg. Gyengítés: Csökkenti a varázsellenállást.', NULL),
(11, 'Morellonomikon', '150 életerő', '25 varázserő', '10% támadási sebesség', '', NULL, 'A támadások és képességek 1%-kal égetik és 33%-kal sebezhetővé teszik az ellenségeket 10 másodpercre. [Egyedi – bajnokonként csak 1 lehet] Égetés: A célpont maximális életerejének egy százalékát valódi sebzésként okozza másodpercenként. Sebezhetőség: Csökkenti a kapott gyógyítást.', NULL),
(12, 'Guinsoo dühpengéje', '10 varázserő', '10% támadási sebesség', '', '', NULL, 'A támadások 5%-os halmozódó támadási sebességet biztosítanak.', NULL),
(13, 'Arkangyal pálcája', '15 mana', '20 varázserő', '', '', NULL, 'Harc kezdetén: Minden 5. másodpercben 30 képességerőt kapsz.', NULL),
(14, 'Drágaköves kesztyű', '35 varázserő', '35% kritikus csapási esély', '', '', NULL, 'Ha a viselő képességei már képesek kritikus csapást mérni, 10% kritikus sebzésbónuszt kap helyette.', NULL),
(15, 'Rabadon halálsüvege', '50 varázserő', '15% támadási sebesség', '', '', NULL, '20% bónusz sebzést okoz.', NULL),
(16, 'A vízköpő sziklavértje', '30 varázsellenállás', '30 páncél', '150 életerő', '', NULL, 'Minden olyan ellenség után, aki a viselőt célozza, 10 páncélt és 10 varázsellenállást kapsz.', NULL),
(17, 'Naptűz köpeny', '20 páncél', '150 életerő', '', '', NULL, 'Minden 2 másodpercben 1%-kal égeti és 33%-kal sebezhetővé teszi az ellenséget 2 mezőn belül 10 másodpercre. [Egyedi – bajnokonként csak 1 lehet] Égetés: A célpont maximális életerejének egy százalékát valódi sebzésként okozza másodpercenként. Sebezhetőség: Csökkenti a kapott gyógyítást.', NULL),
(18, 'A titán elszántsága', '20 páncél', '10% támadási sebesség', '', '', NULL, 'Minden támadás vagy sebzés után 2%-kal növekszik a támadási sebzésed és 1 képességerő, amely 25-ször halmozódhat. Teljes halmozódásnál 20 páncélt és 20 varázsellenállást kapsz.', NULL),
(19, 'Az oltalmazó esküje', '30 mana', '20 páncél', '', '', NULL, 'Minden harcban egyszer, 40% életerőnél, kapsz egy 25%-os maximális életerőnek megfelelő pajzsot, amely 5 másodpercig tart, és 20 páncélt, valamint 20 varázsellenállást kapsz.', NULL),
(20, 'Állhatatos szív', '20 páncél', '20% kritikus csapási esély', '200 életerő', '', NULL, '8%-kal kevesebb sebzést kapsz. Ha az életerőd 50% felett van, akkor 15%-kal kevesebb sebzést kapsz.', NULL),
(21, 'Bokormellény', '65 páncél', '', '', '', NULL, 'Növekszik a maximális életerőd 5%-kal. 8%-kal kevesebb sebzést kapsz a támadásoktól. Amikor bármilyen támadás ér, 100 varázssebzést okozol az összes szomszédos ellenségnek. Késleltetés: 2 másodperc.', NULL),
(22, 'Egyenlepel', '150 életerő', '20 varázsellenállás', '', '', NULL, '30%-kal gyengíti a 2 mezőn belüli ellenségeket. Az első 10 másodpercben 25 páncélt és 25 varázsellenállást kapsz a harc során. Gyengítés: Csökkenti a páncélt.', NULL),
(23, 'Runaan hurrikánja', '20 varázsellenállás', '10% támadási sebesség', '25% sebzés', '', NULL, 'A támadások egy nyíllal lőnek a közeli ellenségre, amely a támadási sebzés 55%-át fizikai sebzésként okozza.', NULL),
(24, 'Adaptív sisak', '20 varázsellenállás', '15 mana', '10 varázserő', '', NULL, 'Harc kezdetén: Különböző bónuszokat kapsz a kezdőpozíciótól függően. Elülső két sor: 40 páncélt és 40 varázsellenállást kapsz. 1 manát nyersz, amikor támadás ér. Hátsó két sor: 20 képességerőt kapsz. 10 manát nyersz minden 3 másodpercben.', NULL),
(25, 'Higany', '20 varázsellenállás', '20% kritikus csapási esély', '30% támadási sebesség', '', NULL, 'Harc kezdetén: 14 másodpercre immunitást kapsz a tömeges irányítású hatásokkal szemben. Ez idő alatt minden 2 másodpercben 4%-kal növekszik a támadási sebességed. [Egyedi – bajnokonként csak 1 lehet]', NULL),
(26, 'Sárkánykarom', '75 varázsellenállás', '', '', '', NULL, 'Növekszik a maximális életerőd 9%-kal. Minden 2 másodpercben 5%-kal gyógyítod a maximális életerődet.', NULL),
(27, 'Statikk töltőpengéje', '15% támadási sebesség', '15 mana', '15 varázserő', '', NULL, 'Minden 3. támadás 35 varázssebzést okoz, és 30%-kal gyengíti 4 ellenség varázsellenállását 5 másodpercre. Gyengítés: Csökkenti a varázsellenállást.', NULL),
(28, 'Utolsó lehelet', '20% támadási sebesség', '20% kritikus csapási esély', '15% sebzés', '', NULL, 'Fizikai sebzés: 30% meggyengíti a célpont páncélját 3 másodpercre. Ez a hatás nem halmozódik. [Egyedi – bajnokonként csak 1 lehet] Gyengítés: Csökkenti a páncélt.', NULL),
(29, 'Vörös erősítés', '35% támadási sebesség', '', '3% sebzésnövelés', '', NULL, '6% bónusz sebzést okoz. A támadások és képességek 1%-kal égetik és 33%-kal sebezhetővé teszik az ellenségeket 5 másodpercre. Égetés: A célpont maximális életerejének egy százalékát valódi sebzésként okozza másodpercenként. Sebezhetőség: Csökkenti a kapott gyógyítást.', NULL),
(30, 'Nashor foga', '150 életerő', '10% támadási sebesség', '10 varázserő', '', NULL, 'Képesség használata után 40%-kal növekszik a támadási sebességed 5 másodpercre.', NULL),
(31, 'Megváltás', '150 életerő', '10 mana', '', '', NULL, 'Minden 5 másodpercben 15%-kal gyógyítja a 1 mezőn belüli szövetségeseket a hiányzó életerejükből. Ezen kívül 10%-kal kevesebb sebzést kapnak 5 másodpercre (a sebzéscsökkentés nem halmozódik). [Aura tárgy]', NULL),
(32, 'Blokktörő', '150 életerő', '20% kritikus csapási esély', '10 varázserő', '20% támadási sebesség', ' 10% sebzésnövelés', 'Pajzs sebzése után 25%-kal több sebzést okozol 3 másodpercre.', NULL),
(33, 'Warmog vértje', '600 életerő', '', '', '', NULL, 'Növekszik a maximális életerőd 8%-kal.', NULL),
(34, 'Kék erősítés', '30 mana', '', '15% sebzés', '15 varázserő', NULL, 'Amikor a viselő elér egy leütést, 8%-kal több sebzést okoz 8 másodpercre. [Egyedi – bajnokonként csak 1 lehet]', NULL),
(35, 'Az igazság ökle', '15 mana', '20% kritikus csapási esély', '', '', NULL, 'Kapsz 2 hatást: • 15% támadási sebzést és 15 képességerőt. • 15% omnivámpír. Minden körben véletlenszerűen megkétszereződik az egyik hatás. Omnivámpír: A sebzés egy részét visszagyógyítja.', NULL),
(36, 'Tolvajkesztyű', '20% kritikus csapási esély', '', '150 életerő', '', NULL, 'Minden körben: 2 véletlenszerű tárgyat kapsz. [3 tárgyhelyet fogyaszt.]', NULL),
(37, 'Taktikus köpenye', '', '', '', '', NULL, 'A csapatod +1 maximális csapatméretet kap. 10% eséllyel 1 aranyat kapsz, miután 10 másodpercig tartott a harc.', NULL),
(38, 'A taktikus koronája', '', '', '', '', NULL, 'A csapatod +1 maximális csapatméretet kap. 10% eséllyel 1 aranyat kapsz, amikor megnyered a harcot.', NULL),
(39, 'Taktikus pajzsa', '', '', '', '', NULL, 'A csapatod +1 maximális csapatméretet kap. 10% eséllyel 1 aranyat kapsz, amikor a viselő meghal.', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `fullitems_partialitems`
--

CREATE TABLE `fullitems_partialitems` (
  `Id` int(11) NOT NULL,
  `FullItemId` int(11) NOT NULL,
  `PartialItemId1` int(11) NOT NULL,
  `PartialItemId2` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `fullitems_partialitems`
--

INSERT INTO `fullitems_partialitems` (`Id`, `FullItemId`, `PartialItemId1`, `PartialItemId2`) VALUES
(1, 1, 1, 1),
(2, 2, 1, 2),
(3, 3, 1, 4),
(4, 4, 1, 5),
(5, 5, 1, 3),
(6, 6, 1, 6),
(7, 7, 1, 8),
(8, 8, 1, 7),
(9, 9, 2, 4),
(10, 10, 2, 5),
(11, 11, 2, 3),
(12, 12, 2, 6),
(13, 13, 2, 8),
(14, 14, 2, 7),
(15, 15, 2, 2),
(16, 16, 4, 5),
(17, 17, 4, 3),
(18, 18, 4, 6),
(19, 19, 4, 8),
(20, 20, 4, 7),
(21, 21, 4, 4),
(22, 22, 5, 3),
(23, 23, 5, 6),
(24, 24, 5, 8),
(25, 25, 5, 7),
(26, 26, 5, 5),
(27, 27, 6, 8),
(28, 28, 6, 7),
(29, 29, 6, 6),
(30, 30, 3, 6),
(31, 31, 3, 8),
(32, 32, 3, 7),
(33, 33, 3, 3),
(34, 34, 8, 8),
(35, 35, 8, 7),
(36, 36, 7, 7),
(37, 37, 9, 10),
(38, 38, 9, 9),
(39, 39, 10, 10);

-- --------------------------------------------------------

--
-- Table structure for table `partialitems`
--

CREATE TABLE `partialitems` (
  `partial_item_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL,
  `HalfItemimageblob` longblob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `partialitems`
--

INSERT INTO `partialitems` (`partial_item_id`, `name`, `effect`, `HalfItemimageblob`) VALUES
(1, 'K. N. Kard', '10 sebzés', NULL),
(2, 'Feleslegesen nagy pálca\r\n', '10 varázserő', NULL),
(3, 'Az óriás öve', '150 életerő', NULL),
(4, 'Sodronyozott mellény', '20 páncél', NULL),
(5, 'Negatron palást', '20 varázsellenállás', NULL),
(6, 'Reflexíj', '10% támadási sebesség', NULL),
(7, 'Bokszkesztyűk', '5% kritikus csapási esély', NULL),
(8, 'Istennő könnycseppje', '15 mana', NULL),
(9, 'Serpenyő', 'mi másért lenne itt', NULL),
(10, 'Spatula', 'biztos csinál valamit', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `permission`
--

CREATE TABLE `permission` (
  `Id` int(11) NOT NULL,
  `Level` int(1) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `Description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `permission`
--

INSERT INTO `permission` (`Id`, `Level`, `Name`, `Description`) VALUES
(1, 0, 'Luzer', 'Webes regisztráció felhasználó'),
(2, 9, 'Administrator', 'Rendszergazda');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `LoginName` varchar(16) NOT NULL,
  `HASH` varchar(64) NOT NULL,
  `SALT` varchar(64) NOT NULL,
  `Name` varchar(64) NOT NULL,
  `PermissionId` int(11) NOT NULL,
  `Active` tinyint(1) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ProfilePicturePath` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`Id`, `LoginName`, `HASH`, `SALT`, `Name`, `PermissionId`, `Active`, `Email`, `ProfilePicturePath`) VALUES
(1, 'a', 'dcedbd2d352d19c6eae0dfb12271b74d985c825b8d774afd2abd0d101b6e57ef', 'jQGX8grO1yjNqhiZbtROcseiqj1NVZJd2iqlfxPx1GKLJ9H8smnLJ9dloScCK6Zp', 'Kerényi Róbert', 2, 1, 'kerenyir@kkszki.hu', 'img\\kerenyir.jpg'),
(11, 'asdasd', '28edd477771171cfa64693047c73d840aa910e4825382a24fb7727414be53f4d', 'OATggfjEEEfKf154gZsXCJXM3WgXYXu8kSA7DXSTr8G2ps8pOeSlbYTzbYuv5yYB', 'asd', 1, 1, 'asd@gmail.com', 'default.jpg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `anomalies`
--
ALTER TABLE `anomalies`
  ADD PRIMARY KEY (`AnomalyId`);

--
-- Indexes for table `augments`
--
ALTER TABLE `augments`
  ADD PRIMARY KEY (`AugmentId`);

--
-- Indexes for table `board`
--
ALTER TABLE `board`
  ADD PRIMARY KEY (`Board_id`),
  ADD KEY `Id` (`Id`);

--
-- Indexes for table `board_hexes`
--
ALTER TABLE `board_hexes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Board_id` (`Board_id`),
  ADD KEY `CharacterID` (`CharacterID`);

--
-- Indexes for table `character`
--
ALTER TABLE `character`
  ADD PRIMARY KEY (`CharacterID`);

--
-- Indexes for table `characterclass`
--
ALTER TABLE `characterclass`
  ADD PRIMARY KEY (`CharacterID`,`ClassID`),
  ADD KEY `ClassID` (`ClassID`);

--
-- Indexes for table `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`ClassID`);

--
-- Indexes for table `classlevelbonus`
--
ALTER TABLE `classlevelbonus`
  ADD PRIMARY KEY (`ClassID`,`Level`);

--
-- Indexes for table `fullitems`
--
ALTER TABLE `fullitems`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `fullitems_partialitems`
--
ALTER TABLE `fullitems_partialitems`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FullItemId` (`FullItemId`),
  ADD KEY `PartialItemId1` (`PartialItemId1`),
  ADD KEY `PartialItemId2` (`PartialItemId2`);

--
-- Indexes for table `partialitems`
--
ALTER TABLE `partialitems`
  ADD PRIMARY KEY (`partial_item_id`);

--
-- Indexes for table `permission`
--
ALTER TABLE `permission`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Szint` (`Level`),
  ADD UNIQUE KEY `Nev` (`Name`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `LoginNev` (`LoginName`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `Jog` (`PermissionId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `anomalies`
--
ALTER TABLE `anomalies`
  MODIFY `AnomalyId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `augments`
--
ALTER TABLE `augments`
  MODIFY `AugmentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=310;

--
-- AUTO_INCREMENT for table `board`
--
ALTER TABLE `board`
  MODIFY `Board_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `board_hexes`
--
ALTER TABLE `board_hexes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `character`
--
ALTER TABLE `character`
  MODIFY `CharacterID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- AUTO_INCREMENT for table `class`
--
ALTER TABLE `class`
  MODIFY `ClassID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `fullitems`
--
ALTER TABLE `fullitems`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `fullitems_partialitems`
--
ALTER TABLE `fullitems_partialitems`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `partialitems`
--
ALTER TABLE `partialitems`
  MODIFY `partial_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `permission`
--
ALTER TABLE `permission`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `board`
--
ALTER TABLE `board`
  ADD CONSTRAINT `board_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `board_hexes`
--
ALTER TABLE `board_hexes`
  ADD CONSTRAINT `board_hexes_ibfk_1` FOREIGN KEY (`Board_id`) REFERENCES `board` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `board_hexes_ibfk_2` FOREIGN KEY (`CharacterID`) REFERENCES `character` (`CharacterID`) ON DELETE CASCADE;

--
-- Constraints for table `characterclass`
--
ALTER TABLE `characterclass`
  ADD CONSTRAINT `characterclass_ibfk_1` FOREIGN KEY (`CharacterID`) REFERENCES `character` (`CharacterID`),
  ADD CONSTRAINT `characterclass_ibfk_2` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `classlevelbonus`
--
ALTER TABLE `classlevelbonus`
  ADD CONSTRAINT `classlevelbonus_ibfk_1` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`);

--
-- Constraints for table `fullitems_partialitems`
--
ALTER TABLE `fullitems_partialitems`
  ADD CONSTRAINT `fullitems_partialitems_ibfk_1` FOREIGN KEY (`FullItemId`) REFERENCES `fullitems` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fullitems_partialitems_ibfk_2` FOREIGN KEY (`PartialItemId1`) REFERENCES `partialitems` (`partial_item_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fullitems_partialitems_ibfk_3` FOREIGN KEY (`PartialItemId2`) REFERENCES `partialitems` (`partial_item_id`) ON DELETE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`PermissionId`) REFERENCES `permission` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
