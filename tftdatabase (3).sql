-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 05, 2025 at 04:09 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
-- Table structure for table `augments`
--

CREATE TABLE `augments` (
  `AugmentID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Effect` text DEFAULT NULL,
  `Rarity` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `augments`
--

INSERT INTO `augments` (`AugmentID`, `Name`, `Effect`, `Rarity`) VALUES
(1, 'A Golden Find', 'Champions evolved by the Anomaly drop 2 gold every 2 kills. Gain 10 free rerolls.', 'Gold'),
(2, 'At What Cost', 'Immediately go to level 6 and gain 8 XP. You don\'t get to choose your future augments.', 'Prismatic'),
(3, 'Band of Thieves I', 'Gain 1 Thief\'s Gloves.', 'Silver');

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
  `Range` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `character`
--

INSERT INTO `character` (`CharacterID`, `CharacterName`, `AbilityName`, `Ability`, `Cost`, `Health`, `Health1`, `Health2`, `AttackSpeed`, `Damage`, `Damage1`, `Damage2`, `AbilityPower`, `ManaStart`, `ManaMax`, `Armor`, `MagicResist`, `Range`) VALUES
(1, 'Amumu', 'Obsolete Technology', 'Passive: Reduce all incoming damage by 12. Every second, sparks that deal 10ap magic damage to adjacent enemies.', 1, 600, 1080, 1944, 0.6, 45, 81, 146, 100, 0, 0, 35, 35, 1),
(2, 'Darius', 'Deciumate', 'Spin, dealing physical damage to adjacent enemies and healing HP. Apply a physical damage bleed to target over 4 seconds.', 1, 600, 1080, 1944, 0.7, 55, 99, 178, 100, 30, 70, 40, 40, 1),
(3, 'Vex', 'Közelgő Sötétség', 'Varázssebzést okoz a célnak, és létrehoz egy sötétség zónát körülötte egy mezőnyi sugárral. Rövid késleltetés után varázssebzést okoz az ellenségeknek, akik még mindig a zónában tartózkodnak.', 1, 450, 810, 1458, 0.7, 30, 54, 97, 100, 0, 60, 15, 15, 4),
(4, 'Violet', '1-2-3 Kombó', 'Két alkalommal megszúrja a célt fizikai sebzéssel. Ezután felütéssel támadja, fizikai sebzést okozva, és rövid időre felrepíti őt.', 1, 650, 1170, 2106, 0.8, 50, 90, 162, 100, 20, 65, 40, 40, 1),
(5, 'Zyra', 'Tüskés Gyökerek', 'Szőlőket küld a célpont felé, megütve őt és 1 másodpercre megkábítva, miközben varázssebzést okoz. Ezután kisebb szőlők keresnek két legközelebbi ellenséget, és varázssebzést okoznak nekik.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 120, 10, 60, 20, 20, 4),
(6, 'Draven', 'Forgó Harapások', 'Passzív: Ha Dravennek van egy megerősített balta a kezében, az felválthatja a következő támadását, fizikai sebzést okozva. A megerősített balták visszatérnek Dravenhez, miután eltaláltak egy ellenséget. Aktív: Forgat egy megerősített baltát.', 1, 500, 900, 1620, 0.7, 55, 99, 178, 100, 30, 60, 15, 15, 4),
(7, 'Irelia', 'Kihívó Tánc', 'Védelmi állásba lép, és pajzsot szerez, amely gyorsan elhalványul 3 másodperc alatt. Amikor a pajzs lejár, varázssebzést okoz, plusz 30%-át az elnyelt sebzésnek, az Irelia körüli és előtte lévő ellenségeknek.', 1, 700, 1260, 2268, 0.6, 45, 81, 146, 100, 30, 70, 40, 40, 1),
(8, 'Lux', 'Prizmatikus Pajzs', 'Pajzsot ad a legkevesebb aktuális életerővel rendelkező szövetségesnek. Lux következő támadása bónusz varázssebzést okoz.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 100, 0, 50, 20, 20, 4),
(9, 'Maddie', 'Kalapács Tűz', 'Lőj 6 lövést a legmesszebb lévő ellenség felé, amelyek fizikai sebzést okoznak az első ellenségnek, akit eltalálnak.', 1, 500, 900, 1620, 0.7, 50, 80, 162, 100, 20, 120, 15, 15, 4),
(10, 'Powder', 'Zűrös Játékfigura', 'Küldj egy majmot a legnagyobb ellenségcsoport felé, ami egy 2 mezőnyi sugárral robban fel a találatkor. Az eltalált ellenségek varázssebzést szenvednek, amely csökken a robbanás középpontjától való távolságuk függvényében. Sebezést és 1%-os égést alkalmaz minden eltalált ellenségre 5 másodpercig.', 1, 500, 900, 1620, 0.7, 35, 63, 113, 100, 40, 120, 15, 15, 4),
(11, 'Singed', 'Veszélyes Mutációk', 'Növeli a tartósságot, és a legtöbb sebzést okozó szövetségesnek támadási sebességet biztosít, ami 4 másodperc alatt elhalványul.', 1, 650, 1170, 2106, 0.6, 55, 99, 178, 100, 0, 50, 40, 40, 1),
(12, 'Steb', 'Terepi Orvostudomány', 'Passzív: Gyógyuláskor a két legközelebbi szövetségest gyógyítja a gyógyulás 25%-ával. Aktív: Gyógyít, és varázssebzést okoz a célnak.', 1, 650, 1170, 2106, 0.55, 55, 99, 178, 100, 30, 90, 45, 45, 1),
(13, 'Trundle', 'Kétségbeesett Rágás', 'Gyógyítja az egészséget és megrágja a célt fizikai sebzéssel. Mindkét hatás akár 75%-kal megnövelhető Trundle hiányzó életereje alapján.', 1, 650, 1170, 2106, 0.65, 50, 90, 162, 100, 30, 90, 40, 40, 1),
(14, 'Morgana', 'Kínzó Lélek', 'Átkoz egy legközelebbi, nem átkozott ellenséget, varázssebzést okozva neki 10 másodperc alatt, és csökkenti rajta használt pajzsok hatékonyságát 50%-kal.', 1, 500, 900, 1620, 0.7, 30, 54, 97, 100, 0, 40, 20, 20, 4),
(15, 'Akali', 'Shuriken Flip', 'Aktív: Akali shurikent dob a célpontra, varázssebzést okozva, és megjelöli őket, hogy 4 másodpercig több sebzést szenvedjenek el. Ezután Akali elugrik a célponttól, majd egy rövid késleltetés után visszaugrik hozzájuk, és újabb varázssebzést okoz.', 2, 700, 1260, 2268, 0.75, 45, 81, 146, 100, 0, 60, 45, 45, 1),
(16, 'Camille', 'Adaptív csapás', 'Aktív: Megrúgja a célpontot, [150 / 224 / 374] adaptív sebzést okozva. Visszatölti az okozott sebzés 33%-át.', 2, 700, 1260, 2268, 0.75, 50, 90, 162, 100, 0, 25, 45, 45, 1),
(17, 'Nocturne', 'Túláradó pengék', '6 másodpercig a támadások a környező ellenségeket is vérzésre kényszerítik, amely fizikai sebzést okoz 1 másodpercig.', 2, 700, 1260, 2268, 0.75, 65, 117, 211, 100, 0, 40, 45, 45, 1),
(18, 'Rell', 'Törő Ütés', 'Pajzsot kap 4 másodpercre. Lándzsával eltalálja az ellenségeket egy vonalban varázssebzéssel, és elrabolja az általuk viselt Páncélt és Varázsvédelmet.', 2, 800, 1440, 2592, 0.6, 60, 108, 194, 100, 40, 90, 45, 45, 1),
(19, 'Renata', 'Hűségprogram', 'Lő egy pár rakétát a célpontra. Azokat az szövetségeseket, akiken áthaladnak, 3 másodpercre pajzshoz juttatja. Amikor ütköznek, varázssebzést okoznak a célpontnak és varázssebzést az érintett ellenségeknek.', 2, 600, 1080, 1944, 0.7, 35, 63, 113, 100, 20, 80, 20, 20, 4),
(20, 'Sett', 'Fejtörő', 'Aktiváláskor az ellenfeleket mindkét oldalról magához húzza és összeszedi őket, mágikus sebzést okozva és megállítva őket. Ha csak egy ellenséget húz be, akkor a sebzés és a Stun időtartama 50%-kal nő.', 2, 850, 1530, 2754, 0.6, 60, 108, 194, 100, 50, 100, 50, 50, 1),
(21, 'Tristana', 'Rajzolj egy Gyöngyöt', 'A karakter ágyúgolyót lő a célpontra, fizikai sebzést okozva. Ha a célpont meghal, az ágyúgolyó visszapattan a legközelebbi ellenségre, és okozza az extrasebzést. Amikor ez megtörténik, permanensen növeli a támadó sebzését egy bizonyos százalékával.', 2, 550, 990, 1782, 0.7, 40, 72, 130, 100, 20, 60, 20, 20, 4),
(22, 'Urgot', 'Korrosív Töltet', 'Lő egy robbanó töltetet, fizikai sebzést okozva a célpontnak és a szomszédos ellenségeknek. 20%-kal csökkenti az összes eltalált ellenség Páncélját 6 másodpercre. Kísérleti Bónusz: A harc kezdetekor és képesség használata után rohan a célponthoz, majd szerez maximális életerő pajzsot és támadási sebességet 5 másodpercre.', 2, 700, 1260, 2268, 0.7, 50, 90, 162, 100, 20, 70, 45, 45, 2),
(23, 'Vander', 'Alvilági kopó', 'Vander 2,5 másodpercre megáll a támadással, és megerősödik, miközben a következő támadása extra fizikai sebzést okoz. A megerősödés mértéke a csapatban lévő 1-es vagy 2-es költségű bajnokok számától függ.', 2, 800, 1440, 2592, 0.7, 50, 90, 162, 100, 0, 50, 45, 45, 1),
(24, 'Vladimir', 'Transzfúzió', 'A karakter meggyógyítja és varázssebzést okoz a célpontnak.', 2, 800, 1440, 2592, 0.65, 45, 81, 146, 100, 65, 65, 45, 45, 1),
(25, 'Zeri', 'Élő Akkumulátor', 'A karakter minden harmadik támadása egy szikrával helyettesítődik, amely fizikai sebzést okoz a célpontnak és 2 közeli ellenségnek.', 2, 600, 1080, 1944, 0.75, 45, 81, 146, 100, 3, 3, 20, 20, 4),
(26, 'Ziggs', 'Bombák Bombája', 'A karakter egy bombát dob a célpontra, varázssebzést okozva. 3 mini-bomba repül ki, és véletlenszerű ellenségeknek okoz varázssebzést.', 2, 600, 1080, 1944, 0.7, 35, 63, 113, 100, 15, 60, 20, 20, 4),
(27, 'Leona', 'Napfogyatkozás', 'Aktiváláskor Leona 3 másodpercre megerősödik, és 50% szívósságra tesz szert. Ezután 115 varázssebzést okoz a szomszédos ellenfeleknek.', 2, 800, 1440, 2592, 0.6, 55, 99, 178, 0, 40, 80, 50, 50, 1),
(28, 'Scar', 'Sumpsnipe Meglepetés', 'Bombákat dob a legközelebbi 3 ellenségre, Stun-olja őket 1,5 másodpercre, és varázssebzést okoz mindegyiknek. Gyógyítja a karakter életerejét.', 3, 800, 1440, 2592, 0.65, 50, 90, 162, 100, 80, 155, 50, 50, 1),
(29, 'Smeech', 'Hulladék Heker', 'A karakter a legkevesebb tárggyal rendelkező ellenség felé ugrik 4 hexen belül. Háromszor csap, összesen fizikai sebzést okozva. Ha az ellenség meghal, ismét ugrik, de 30%-kal kevesebb sebzést okoz.', 3, 800, 1440, 2592, 0.8, 65, 117, 211, 100, 20, 80, 50, 50, 1),
(30, 'Swain', 'Démoni Felemelkedés', 'Elülső: Gyógyít és felemelkedik 6 másodpercre. Miközben felemelkedett, gyógyít és varázssebzést okoz a közeli ellenségeknek minden másodpercben. Ha egy ellenséget legyőz, a felemelkedés időtartama 2 másodperccel meghosszabbodik. Hátsó: 8 varjút küld a célpontra, amelyek varázssebzést okoznak. Mindegyik varjú egy közeli ellenséghez repül, és varázssebzést okoz.', 3, 650, 1170, 2106, 0.7, 40, 72, 130, 100, 20, 70, 25, 25, 1),
(31, 'Twisted Fate', 'Vad Kártyák', 'Három kártyát dob különböző célpontokra. Kék Kártya: Visszaállítja az életerőt a legalacsonyabb életerővel rendelkező szövetségesnek. Piros Kártya: Varázssebzést okoz a legnagyobb ellenségkörben. Sárga Kártya: Varázssebzést okoz a célpontnak, és Stun-olja 1 másodpercre.', 3, 700, 1260, 2268, 0.7, 35, 63, 113, 100, 25, 75, 25, 25, 4),
(32, 'Blitzcrank', 'Statikus Mező', 'Passzív: Sérülés után a karakter a megnyelt sebzés 0,03%-át varázssebzés formájában visszaveri a célpontra. Aktív: 415/440/465 (AP) pajzsot nyer 4 másodpercre. Sokkolja a legközelebbi 3 ellenséget 40/60/100 (AP) varázssebzéssel és csökkenti a sebzésüket 0,1%-kal 4 másodpercre.', 3, 850, 1530, 2754, 0.65, 50, 90, 162, 100, 50, 100, 50, 50, 1),
(33, 'Ezreal', 'Esszencia Áramlás', 'A karakter egy lövéssel célozza meg a jelenlegi célpontját, amely fizikai sebzést okoz minden ellenségnek 1 hexen belül. Ezután fizikai sebzést okoz a robbanás középpontjában lévő egységnek.', 3, 700, 1260, 2268, 0.75, 60, 108, 194, 100, 60, 60, 25, 25, 4),
(34, 'Gangplank', 'Aratás a Lángokból', 'Elülső: Tisztítja az összes negatív hatást és gyógyítja a karakter életerejét. Vágás, amely fizikai sebzést okoz az ellenségeknek egy vonalban. Ha csak egy ellenség találkozik a támadással, a sebzés megduplázódik. Hátsó: Passzív: Miközben Mana-t nyer, 3 ragadós bombát dob el. Ha az ellenség, akire rátapadnak, meghal, átkerülnek egy másik közeli ellenségre. Aktív: Aktiváld a bombákat, hogy fizikai sebzést okozzanak az ellenségnek, akire rátapadtak, és fizikai sebzést az összes közeli ellenségnek.', 3, 700, 1260, 2268, 0.7, 50, 90, 162, 100, 75, 75, 20, 20, 1),
(35, 'Kogmaw', 'Fokozó Lőmód', 'Passzív: A támadások bónusz varázssebzést okoznak. Aktív: 25%-os, felhalmozódó támadási sebességet szerzel a harc hátralévő részére. Minden 3 használat után +1 hatótávot nyersz.', 3, 650, 1170, 2106, 0.7, 15, 27, 49, 100, 40, 40, 25, 25, 4),
(36, 'Loris', 'Piltover Pajzs', 'A karakter pajzsot kap 4 másodpercre. A pajzs 50%-át az őt körülvevő szövetségesek által elszenvedett sebzésnek átirányítja. Amikor a pajzs lejár, varázssebzést okoz egy kúpszerű területen.', 3, 850, 1530, 2754, 0.65, 50, 90, 162, 100, 50, 100, 50, 50, 1),
(37, 'Nami', 'Oceán Áramlás', 'Egy hullámot indít a célpont felé, amely háromszor visszapattan 3 hexen belüli ellenségekre, varázssebzést okozva mindegyiknek.', 3, 700, 1260, 2268, 0.7, 40, 72, 130, 100, 60, 60, 25, 25, 4),
(38, 'Nunu', 'ZOMBIE ERŐ!!', '3 másodpercre tartózkodj megnövelt ellenállással, és hozz létre egy 2 hex széles füstfelhőt, amely varázssebzést okoz az ellenségeknek. Ezután robbantsd fel a felhőt, és varázssebzést okozz az összes belső ellenségnek. Kísérleti Bónusz: Sebzés után 3%-os maximális életerő bónusz varázssebzést okozol (1 másodperces lehűlés).', 3, 800, 1440, 2592, 0.6, 50, 90, 162, 100, 60, 125, 50, 50, 1),
(39, 'Renni', 'Sludgerunner Ütés', 'A karakter 1,5 másodperc alatt gyógyítja meg magát. A képesség alatt felemeli a célpontot a levegőbe, Stun-olja és fizikai sebzést okoz. Ezután lecsapja a földre, fizikai sebzést okozva minden közeli ellenségnek.', 3, 850, 1530, 2754, 0.65, 55, 99, 178, 100, 40, 100, 50, 50, 1),
(40, 'Cassiopeia', 'Tövises Miasma', 'A karakter varázssebzést okoz a célpontnak. Minden harmadik használatkor a miasma két ellenségre szóródik a 3 hexen belül, varázssebzést okozva mindegyiknek.', 3, 700, 1260, 2268, 0.7, 40, 72, 130, 100, 10, 40, 25, 25, 4),
(41, 'Ekko', 'Másodpercek Felosztása', 'Elő hív egy utóképeket támadó hullámot, amely varázssebzést okoz a célpontnak és más közeli ellenségeknek. Az utóképek csökkentik a célpont varázsellenállását 5-tel a harc hátralévő részére.', 4, 1100, 1980, 3564, 0.85, 50, 90, 162, 100, 0, 60, 60, 60, 1),
(42, 'Elise', 'Kóma', 'Előre: Ugorj egy közeli hexára, és webeld be az összes ellenséget 2 hexen belül, Stun-olva őket és varázssebzést okozva. Gyógyítsd meg az életerőt. Hátra: Küldj pókcsemetéket a 4 legközelebbi ellenség felé, amelyek érintkezéskor felrobbannak, varázssebzést okozva a célpontnak és varázssebzést azok körül.', 4, 750, 1350, 2430, 0.75, 45, 81, 146, 100, 0, 10, 30, 30, 1),
(43, 'Garen', 'Demaciai Igazság', 'Passzív: Sebzés okozása után gyógyulj meg. Aktív: Nyerd el a Páncélt 4 másodpercre. Csapj le egy hatalmas karddal a célpontra, fizikai sebzést okozva nekik, és fizikai sebzést okozva az 2 hexen belüli ellenségeknek.', 4, 1000, 1800, 3240, 0.6, 65, 117, 211, 100, 60, 125, 60, 60, 1),
(44, 'Heimerdinger', 'PROGRESSSSS!', 'Lőj rakétákat véletlenszerű ellenségekre, amelyek varázssebzést okoznak. Minden egyes használatnál 1 rakéta több indul, mint az előző alkalommal.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 0, 40, 30, 30, 4),
(45, 'Illaoi', 'A Lélek Próbája', 'Nyerd el a Tartósságot 3 másodpercre. Az időtartam alatt elszívod az életerőt a legközelebbi ellenségektől. Ezt követően csapj le, varázssebzést okozva minden ellenségnek 2 hexen belül.', 4, 1100, 1980, 3564, 0.65, 70, 126, 227, 100, 65, 125, 60, 60, 1),
(46, 'Dr.Mundo', 'Maximális Dózis', 'Aktiváld az energiát, és gyógyulj 2 másodperc alatt. Amíg energizált állapotban vagy, minden másodpercben varázssebzést okozol egy közeli ellenségnek. Ezt követően varázssebzést okozol minden ellenségnek 2 hexen belül. Kísérleti Bónusz: 120 maximális életerőt kapsz. Ha egy ellenséget legyőzöl, 60 maximális életerőt nyersz a harc hátralévő részére.', 4, 1100, 1980, 3564, 0.65, 60, 108, 194, 100, 30, 100, 60, 60, 1),
(47, 'Silco', 'Konzerv Szörnyeteg', 'Hajíts egy kannát a célpontra, amely varázssebzést okoz és szörnyetegeket szabadít el. A szörnyetegek 5 alkalommal támadnak, minden támadás varázssebzést okoz.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 30, 80, 30, 30, 4),
(48, 'Twitch', 'Fújj és Imádkozz', 'Az elkövetkező 8 támadásnál szerez +85% támadási sebességet, végtelen hatótávolságot, és le cserélo a támadásokat egy áthatoló nyílra, amely véletlenszerű ellenségeket céloz. A nyilak fizikai sebzést okoznak, csökkentve azt minden ellenségen, amin áthaladnak. Kísérleti Bónusz: Minden 5. támadás után fizikai sebzést okozol a legközelebbi ellenségnek, ami a maximális egészségük % -ának megfelelően.', 4, 800, 1440, 2592, 0.75, 50, 90, 162, 100, 60, 60, 30, 30, 4),
(49, 'Vi', 'Zúzó Csapat', 'Nyerd el a Pajzsot 3 másodpercre, majd Stunold meg a célt 1,5 másodpercre. Csapd le őket, fizikai sebzést okozva, és egy sokkhullámot keltve a sorukban. Az ellenségek fizikai sebzést kapnak és rövid időre felrepülnek.', 4, 1100, 1980, 3564, 0.85, 75, 135, 243, 100, 40, 100, 50, 50, 1),
(50, 'Zoe', 'Csillag Pörgetés!', 'Lőj egy csillagot a célpontra, amely varázssebzést okoz. Az visszapattan a legmesszebb lévő ellenséghez 4 hexen belül, majd visszapattan a célponthoz. Ez a hatás ismétlődik, minden alkalommal egy másik ellenséget eltalálva.', 4, 800, 1440, 2592, 0.75, 40, 72, 130, 100, 20, 80, 30, 30, 4),
(51, 'Ambessa', 'Kíméletlen Vadásznő', 'Ambessa két állás között vált aktiváláskor: Láncok: +1 hatótávot nyersz. A támadások fizikai sebzést okoznak. Aktiváláskor dash-elsz a célponthoz, és félkörben csapsz, fizikai sebzést okozva az eltalált ellenségeknek. Ököl: Omnivampot kapsz, és kétszer olyan gyorsan támadsz. Aktiváláskor röviden Stun-olod a célpontot, majd a földhöz csapod, fizikai sebzést okozva, végül elugrasz.', 4, 1100, 1980, 3564, 0.8, 65, 117, 211, 100, 40, 100, 50, 50, 1),
(52, 'Corki', 'Széles Oldali Lövöldözés', 'Célozz meg egy célpontot, majd egy közeli pozícióba mozogj, miközben rakétákat lősz, amelyek a célpont és minden ellenség között oszlanak el 2 hexen belül. Minden rakéta fizikai sebzést okoz, és csökkenti az ellenség páncélját 1-tel. Minden 7. rakéta fizikai sebzést okoz és 7-tel csökkenti a páncélt.', 4, 850, 1530, 2754, 0.75, 60, 108, 194, 100, 0, 60, 30, 30, 4),
(53, 'LeBlanc', 'The Chains of Fate', 'Aktív: Az 5 legközelebbi ellenséget összeköti láncokkal 5 másodpercre, megosztott varázssebzést okozva közöttük. Amikor egyet sebzés ér, a sebzés egy része bónusz igaz sebzésként oszlik meg a többi között. LeBlanc következő 3 támadása bónusz varázssebzést okoz, amely 0,5%-kal növekszik minden ellenség után, akit az eredeti sebzés megöl.', 5, 900, 1620, 2916, 0.8, 50, 90, 162, 100, 45, 90, 40, 40, 4),
(54, 'Malzahar', 'Call of the Machine', 'Aktív: Egy kaput idéz meg, amely egy 5 mezős vonalon halad át a célponton. Az eltalált ellenségek varázssebzést szenvednek el, és 20%-os Shred hatást kapnak 4 másodpercig. Malzahar 5 fertőzéshalmot terjeszt az eltalált ellenségek között. Fertőzés: Minden másodpercben varázssebzést okoz a harc hátralevő részében. Ez a hatás végtelenül halmozható. Amikor egy fertőzött célpont meghal, a halmokat a közeli ellenségekre terjeszti. Shred: Csökkenti a varázsellenállást.', 5, 950, 1710, 3078, 0.8, 45, 81, 146, 100, 45, 105, 40, 40, 4),
(55, 'Mordekaiser', 'Vasszellem markolása', 'Aktív: Rövid időre 40%-kal növeli a tartósságot, és egy hatalmas karmot idéz meg, amely varázssebzést okoz a legtöbb ellenségnek egy vonalban. A négy legközelebbi ellenség 25%-kal több sebzést kap, és Mordekaiser felé húzódik. A következő tíz másodpercben 30% életlopást kap, megnövelt támadási hatótávot szerez, és minden támadása helyett egy csapást hajt végre, amely varázssebzést okoz a célpontnak, valamint további varázssebzést minden más ellenségnek két hex távolságon belül.', 5, 1200, 2160, 3888, 0.55, 75, 135, 243, 100, 40, 100, 70, 70, 1),
(56, 'Rumble', 'Az Egyenlítő', 'Hívj le 5 rakétát a cél sorára, amelyek mindegyike varázssebzést okoz, Sebzést és 1%-os Égést alkalmaz az eltalált egységeken 5 másodpercig. Minden olyan rakéta esetén, amely nem talál el ellenséget, 20 Manát visszanyersz. Ha már csak 1 ellenség marad, akkor mind az összes rakétát rájuk lődd. Égetés: Az ellenfél maximális életerejének egy százalékát igaz sebzésként okozza másodpercenként. Sebzés: Csökkenti a kapott gyógyítást 33%-kal.', 5, 1200, 2160, 3888, 0.8, 60, 108, 194, 100, 40, 120, 70, 70, 1),
(57, 'Sevika', 'A Szerencse Próbája', 'Véletlenszerűen elhúzódik 1 a 3 varázslat közül, esély van Jackpot-ra! Lángszóró: Igaz sebzést okoz a célpontnak minden másodpercben a haláláig. Az őt körülvevő ellenségek 50%-kal kevesebb fizikai sebzést kapnak. Hosszú Ütés: Fizikai sebzést okoz a célpontnak, és eltaszítja őket. Ezután dash-el a célponthoz, és 1 hex körüli körben fizikai sebzést okoz. Rágás: Fizikai sebzést okoz a célpontnak. Ha az életereje 15%-nál kevesebb, végrehajtja őt, és újra elvégzi a legkevesebb életerővel rendelkező célpont számára 2 hex távolságra, 80%-os sebzéssel.', 5, 1200, 2160, 3888, 0.9, 80, 144, 259, 100, 0, 60, 60, 60, 1),
(58, 'Caitlyn', 'Légi Támadás', 'Vedd fel a mesterlövész pozíciót, és hívd be a léghajót, amely 5 másodpercig köröz a csatatéren, és 4 bombát dob egy véletlenszerű ellenséges csoport közé. A bombák fizikai sebzést okoznak egy egy-hexes körben. Mikor egy ellenség a Légi Támadás robbanásának epicentrumába kerül, csökkenti az Ő védelmét és varázsellenállását 20-mal, miközben egy lövéssel célba veszi őt, és fizikai sebzést okoz.', 5, 900, 1620, 2916, 0.55, 80, 144, 259, 100, 0, 50, 40, 40, 4),
(59, 'Jayce', 'Különleges Szállítmány', 'Passzív: Helyezzen el egy Hextech Forge-t. Aktiváláskor a legközelebbi 3 szövetséges pajzsot kap 4 másodpercre. Ha elpusztul, 100%-os életerővel újraéleszti. Aktív: Hívjon elő 2 Hexgate-et, és dobja be a célt az egyikbe, fizikai sebzést okozva, miközben visszaküldi őket az eredeti helyükre. A repülés közben a célpont minden ellenséget eltalál a pályán, fizikai sebzést okozva.', 5, 900, 1620, 2916, 0.8, 60, 108, 194, 100, 30, 80, 35, 35, 1),
(60, 'Jinx', 'Minden Elpusztítása', 'Aktív: Jinx váltogat a következő képességek között: Zap: Fizikai sebzést okoz az ellenségeknek egy vonalban, és 1,25 másodpercre megmerevíti őket. Flame Chompers: Fizikai sebzést okoz 3, 1 hex-es körben lévő ellenségnek. Death Rocket: Lőjön egy rakétát a tábla közepére, ami fizikai sebzést okoz MINDEN ellenségnek, a sebzés 10%-kal csökken minden egyes hex-távolság után, amely távolabb van az epicentrumtól.', 5, 900, 1620, 2916, 0.8, 60, 108, 194, 100, 0, 60, 40, 40, 4),
(61, 'Mel', 'Mágia Csatorna', 'Mel teleportál egy közeli szövetségeshez vagy egy kiválasztott pontra a pályán, pajzsot biztosítva magának és a közeli szövetségeseinek, amely elnyeli a sebzést. A pajzsok által blokkolt sebzés energiává alakul, és ha Mel többször is használja a képességét, az energiát mágikus sebzéssé alakítja.', 6, 800, 800, 1000, 0.7, 60, 60, 80, 0, 50, 100, 35, 35, 3),
(62, 'Viktor', 'Kaosz Vihar', 'Viktor egy hatalmas vihart szabadít el, amely egy vonalban sebzi az ellenségeket, miközben csökkenti azok páncélját és varázsellenállását. A képesség többször is aktiválható, minden alkalommal nagyobb sebzést okozva.', 6, 900, 900, 1100, 0.65, 75, 75, 95, 0, 60, 120, 40, 40, 3),
(63, 'Warwick', 'Vérvadászat', 'Warwick az alacsony egészségű ellenséget vadászza le, és jelentős bónusz sebzést okoz. Miután Warwick öt ellenséget legyőzött, bónusz támadási sebességet, életvisszanyerést és sebzéscsökkentést kap egy rövid időre.', 6, 850, 850, 1020, 0.75, 70, 70, 90, 0, 50, 100, 30, 30, 1);

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
  `BasicEffect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `class`
--

INSERT INTO `class` (`ClassID`, `ClassName`, `BasicEffect`) VALUES
(1, 'Akadémia', 'Az Akadémia három tárgyat szponzorál minden játékban. A szponzorált tárgyak másolatai bónusz maximális életerőt és sebzésfokozást biztosítanak. Az Akadémia egységei, akik szponzorált tárgyakat tartanak, kétszeres bónuszt kapnak, plusz további 5% életerőt és sebzésfokozást.'),
(2, 'A gépek hírnöke', 'A gépek megnövelt erővel rendelkeznek, és bónusz életerőt és sebzést kapnak. A gépek emellett extra tartósságot nyernek páncél és varázsellenállás formájában, így ellenállóbbak az ellenséges támadásokkal szemben.'),
(3, 'Alakváltó', 'Az Alakváltók képesek átalakulni a csata során, lehetővé téve számukra, hogy formát változtassanak és fokozzák harci képességeiket. Alkalmazkodnak a helyzethez, és jelentős erőt nyernek, ahogy a harc folytatódik.'),
(4, 'Automata', 'Az \"Automata\" effektusa szerint, amikor sebzést okoznak, kristályokat szereznek. Ha elérik a 20 kristályt, egy mágikus sebzést okozó robbanást idéznek elő a célpontjukon, amely tartalmazza a korábbi robbanás óta kapott sebzés 20%-át, miközben visszaállítják a kristályokat. Ezen kívül növelik a Páncélt és a Mágikus Ellenállást is.'),
(5, 'Barkácsoló', 'A Barkácsolók képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.'),
(6, 'Család', 'A Család egységei bónusz életerőt és támadási sebzést kapnak a családtagok számának megfelelően a táblán. Minél több családtag van jelen, annál erősebbek az effektek.'),
(7, 'Egyeduralkodó', 'Az Egyeduralkodó egységei bónusz sebzést és életerőt kapnak, valamint képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat.'),
(8, 'Fekete rózsa', 'A Fekete rózsa egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.'),
(9, 'Gladiátor', 'A Gladiátor egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(10, 'Gyorstámadó', 'A Gyorstámadó egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(11, 'Hódító', 'A Hódító egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(12, 'Kísérlet', 'A Kísérlet egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(13, 'Követ', 'A Követ egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(14, 'Látnok', 'A Látnok egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(15, 'Lázadó', 'A Lázadó egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.'),
(16, 'Mesterlövész', 'A Mesterlövész egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(17, 'Nagy menő', 'A Nagy menő egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(18, 'Örző', 'Az Örző egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(19, 'Rajtaütő', 'A Rajtaütő egységei képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.'),
(20, 'Roncskirály', 'A Roncskirály egységei képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.'),
(21, 'Szikra', 'A Szikra egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(22, 'Száműzött varázsló', 'A Száműzött varázslók képesek elcsábítani az ellenséges egységeket, ideiglenesen átállítva őket a saját csapatukhoz, és így megerősítve a csapat erejét.'),
(23, 'Tüzér', 'A Tüzér egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(24, 'Varázsló', 'A Varázsló egységei képesek átvenni az ellenséges egységek képességeit, ideiglenesen megerősítve sajátjukat, és bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(25, 'Vegybáró', 'A Vegybárók képesek összegyűjteni a csata során eldobott alkatrészeket. Ezek az alkatrészek fokozzák képességeiket, lehetővé téve számukra, hogy erőteljes tárgyakat építsenek és erősödjenek a játék előrehaladtával.'),
(26, 'Végrehajtó', 'A Végrehajtó egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(27, 'Vérvadász', 'A Vérvadász egységei képesek gyorsan támadni, és minden támadásuk után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.'),
(28, 'Virrasztó', 'A \"Virrasztó\" egységek megnövekedett Ellenállással rendelkeznek, amely tovább nő, ha több mint 50%-os életük van.'),
(29, 'Zúzó', 'A Zúzó egységei képesek megsemmisíteni az ellenséges egységeket, és a legyőzött ellenséges egységek után bónusz sebzést és életerőt kapnak, fokozva a csapat erejét.');

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
  `full_item_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL,
  `Effect1` text NOT NULL,
  `ActiveEffect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `fullitems`
--

INSERT INTO `fullitems` (`full_item_id`, `name`, `effect`, `Effect1`, `ActiveEffect`) VALUES
(1, 'Lándzsa Shojin', '20 támadási sebesség', '15% támadás sebzés', 'Minden támadás után 10 mana-t ad a viselőjének.'),
(2, 'Végtelen Élelem', '40% kritikus sebzés', '20% sebzés', 'A kritikus találatok 50%-kal növelik az általuk okozott sebzést.'),
(3, 'Naplemente Páncél', '300 életerő', '60 páncél', '5 másodpercenként 15%-os terület sebzés az ellenfelek számára.'),
(4, 'Vérivó', '100 életerő gyógyulás minden támadással', '40 támadó sebzés', 'Kétszeres gyógyulás minden kritikus támadással.'),
(5, 'Ékszeres Kesztyű', '20 varázserő', '15% kritikus sebzés', 'Képesség aktiválásakor kritikus sebzést ad 30%-kal.'),
(6, 'Tolvaj Kesztyű', '2 véletlenszerű itemet kap a viselője', '50 életerő gyógyulás', 'Random aktiválódik, és egy másik választott eszközt másol.'),
(7, 'Taktikai Korona', '200 életerő', '10% támadás sebzés', 'Egy extra képesség a csapathoz, amikor a csapat több mint 50%-os HP-val van.'),
(8, 'Kőpáncél', '50 páncél', '30% sebzés csökkentés', 'Minden támadás után 10%-kal növeli a páncélt.'),
(9, 'Warmog Páncél', '800 életerő', '', '10 másodpercenként 4%-kal gyógyul.'),
(10, 'Utolsó Lehelet', '40%-os vágás', '35 sebzés csökkentés', 'Mindig rontja a célpontok páncélját.'),
(11, 'Megváltás', '50%-os gyógyulás egy aktiválás után', '30% csapattárs támogatás', 'Gyógyítja az összes szövetségest 20%-ra.'),
(12, 'Nashor Foga', '60 sebzés', '20 támadás sebzés', '5 másodpercenként 1 másodpercnyi gyorsaság.'),
(13, 'Igazság Keze', '25%-os kritikus sebzés', '30 sebzés növelés', 'Kritikus találatok aktiválják a védekezést.'),
(14, 'Guinsoo harcoló Penge', '20 sebzés', '10 sebzés növelés', 'Minden támadás után növekvő támadó sebzés.'),
(15, 'Sárkánykarom', '50 páncél', '50 varázs páncél', 'Képesség aktiválásakor mindent védenek a varázslatok.'),
(16, 'Titan Határozott', '40 támadó sebzés', '60 páncél', 'Minden támadás után extra sebzést biztosít.'),
(17, 'Ióniás Szikra', '25%-os sebzés növekedés', '5%-os varázssebzés', 'Minden támadás után egy varázslatnál extra sebzés.'),
(18, 'Óriásölő', '25%-os sebzés', '25 varázserő', '25%-os extra sebzés azoknak, akik több mint 1750 maximális életerővel rendelkeznek.'),
(19, 'Óvó Köpeny', '5%-os páncél', '15%-os varázsdefenzív védelem', 'Képesség növeli a célpont páncélját.'),
(20, 'Vörös Buff', '10%-os sebzés csökkentés', '20%-os sebzés növelés', 'A sebzés a csökkentett védelem alapján növekszik.'),
(21, 'Éjszaka Életem', '30%-os kritikus sebzés', '25%-os csökkentett sebzés', 'Kritikus találatokkal megnöveli az aktiválódott sebzést.'),
(22, 'Arkangyal Staff', '80 varázserő', '5%-os támadási sebesség', 'Képesség aktiválásakor extra varázssebzés.'),
(23, 'Tövispáncél', '20% páncél', '', 'Amikor a viselőjét eltalálják, a körülötte lévő ellenségek a kapott sebzés 30%-át mágikus sebzésként kapják.'),
(24, 'Steraks Gage', '400 életerő', '30 támadósebesség', 'Sebzést követően egy pajzsot kap, amely a sebzés 50%-át képes elnyelni 3 másodpercig.'),
(25, 'Hextech Gunblade', '50 támadási sebesség', '20% kritikus találat sebzés', 'A viselő gyógyító hatása 35%-kal nő a sebzés alapján, amit az ellenségnek okozott.'),
(26, 'Koronavédő', '30 páncél', '20 mágikus ellenállás', 'Pajzsot ad minden szomszédos szövetségesnek, amely 40%-kal csökkenti a kapott sebzést 4 másodpercre.'),
(27, 'Statikk Shiv', '15 támadási sebesség', '25% kritikus sebzés', 'Minden 5. támadás láncszerű villámlást indít, amely 4 közeli ellenséget talál meg mágikus sebzéssel.'),
(28, 'Evenshroud', '200 életerő', '30% páncél', 'Csökkenti a közvetlen közelében lévő ellenségek sebzését 25%-kal 2 mező távolságra.'),
(29, 'Guardbreaker', '20% támadási sebesség', '40 támadósebesség', 'Mágikus sebzést okoz minden ütésnél, és 3 másodpercre csökkenti az ellenfél sebzését 20%-kal.'),
(30, 'Quicksilver', '20% támadási sebesség', '', '3 másodpercre immunitást ad a tömeges irányítást jelentő hatásokkal szemben, miután aktiválják.'),
(31, 'Adaptive Helm', '40 mágikus ellenállás', '20% páncél', 'Miután mágikus sebzést kap, a viselő 25%-kal növeli mágikus ellenállását 3 másodpercre.'),
(32, 'Morellonomicon', '10 varázserő', '20% páncél', 'Csökkenti az ellenfelek gyógyulását 50%-kal, ha eltalálják őket.'),
(33, 'Steadfast Heart', '100 életerő', '30 páncél', 'Pajzsot kap, amely a viselő maximális életereje 25%-ának megfelelő sebzést nyel el, ha az életereje 50% alá csökken.'),
(34, 'Kék Buff', '10% varázserő', '', '20 manát biztosít másodpercenként a viselőnek.'),
(35, 'Protector\'s Vow', '25 páncél', '20% varázserő', 'Sebzést követően pajzsot ad egy szövetségesnek 2 mező távolságra, amely elnyel 25%-ot a kapott sebzésből 4 másodpercre.'),
(36, 'Rabadon\'s Deathcap', '100 varázserő', '', 'A viselő képességeinek erejét 50%-kal növeli.'),
(37, 'Deathblade', '15% kritikus találat sebzés', '', 'A kritikus találatok után 5 másodpercre 40%-kal megnöveli a kritikus sebzést.'),
(38, 'Runaan\'s Hurricane', '30 támadósebesség', '10% kritikus sebzés', 'Minden támadás 2 további nyilat lő ki véletlenszerű célpontokra.'),
(39, 'Tactician\'s Cape', '300 életerő', '25 páncél', '20 bónusz életerőt biztosít minden szomszédos szövetségesnek.'),
(40, 'Tactician\'s Shield', '50 páncél', '', '40%-os bónusz védelmet biztosít minden szövetségesnek a közelben.');

-- --------------------------------------------------------

--
-- Table structure for table `partialitems`
--

CREATE TABLE `partialitems` (
  `partial_item_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `partialitems`
--

INSERT INTO `partialitems` (`partial_item_id`, `name`, `effect`) VALUES
(1, 'B.F. Sword', '10 Attack damage.'),
(2, 'Needlessly Large Rod', '10 Ability power.'),
(3, 'Giant\'s Belt', 'Gain 150 Health.'),
(4, 'Láncing', '20 páncél'),
(5, 'Negatron Köpeny', '20 mágikus ellenállás'),
(6, 'Visszahajló Íj', '10% támadási sebesség'),
(7, 'Edzőkesztyűk', '5% kritikus találat'),
(8, 'Istennő Könnye', '15 mana'),
(9, 'Serpenyő', 'mi másért lenne itt'),
(10, 'Laposkanál', 'biztos csinál valamit');

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
(1, 'kerenyir', 'd5fe0e517520122f1ab363b6b7ee9ae616e7ad393693ef00d81a7f287a79931a', 'Gm63C4jiWnYvfZfiKUu2cu8AHPNDj8NoHhtQn88yiJhyOunBNSd7tRoWo5wwqg9X', 'Kerényi Róbert', 2, 1, 'kerenyir@kkszki.hu', 'img\\kerenyir.jpg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `augments`
--
ALTER TABLE `augments`
  ADD PRIMARY KEY (`AugmentID`);

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
  ADD PRIMARY KEY (`full_item_id`);

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
-- AUTO_INCREMENT for table `augments`
--
ALTER TABLE `augments`
  MODIFY `AugmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
  MODIFY `full_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

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
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`PermissionId`) REFERENCES `permission` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
