using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespol
{
    public enum Plcie
    {
        M,
        K
    }
    class Program
    {
        static void WyswietlListeCZ(List<CzlonekZespolu> a)
        {
            a.ForEach(Console.WriteLine);
        }
        static void Main(string[] args)
        {
            //Sprawdź Osoba
            /*Osoba a = new Osoba("BeAtA","NoWaK", "1992-10-22", "92102201347","213742069",Plcie.K);
            Osoba b = new Osoba("JaN", "JaNoWsKi", "1993-03-15", "92031507772","123456789", Plcie.M);
            a.Form_I_N();
            b.Form_I_N();
            Console.WriteLine("Normalnie\n");
            Console.WriteLine(a.Imie + " " + a.Nazwisko + " " + a.DataUrodzenia.ToString("yyyy-MM-dd") + " " + a.pesel + " " + a.plec);
            Console.WriteLine("Ma " + a.Wiek() + " lat");
            Console.WriteLine(b.Imie + " " + b.Nazwisko + " " + b.DataUrodzenia.ToString("yyyy-MM-dd") + " " + b.pesel + " " + b.plec);
            Console.WriteLine("Ma " + b.Wiek() + " lat");
            Console.WriteLine("\nMetodą ToString\n");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Osoba ta przeżyła " + a.Zyje_H("12.00") + " godzin");
            Console.WriteLine("Poprawność peselu: " + a.PSL_popr());
            Console.WriteLine(b.ToString());
            Console.WriteLine("Osoba ta przeżyła " + b.Zyje_H("12:00") + " godzin");
            Console.WriteLine("Poprawność peselu: " + b.PSL_popr());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź CzlonekZespolu
            /*CzlonekZespolu a = new CzlonekZespolu("BeAtA", "NoWaK", "1992-10-22", "92102201347", "213742069", Plcie.K, "01-sty-2020","projektant");
            CzlonekZespolu b = new CzlonekZespolu("JaN", "JaNoWsKi", "1993-03-15", "92031507772", "123456789", Plcie.M, "01-cze-2019", "Jankowski programista");
            a.Form_I_N();
            b.Form_I_N();
            Console.WriteLine("Metodą ToString\n");
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź KierownikZespolu
            /*KierownikZespolu a = new KierownikZespolu("AdAm", "KoWaLsKi", "1990-07-01", "90070100211", "213742069", Plcie.M,5);
            a.Form_I_N();
            Console.WriteLine("Metodą ToString\n");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Poprawność peselu: " + a.PSL_popr());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź Zespol
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold","Adamski","22.10.1992", "92102266738",Plcie.M,"01-sty-2020","sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "But", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            Console.WriteLine(IT.ToString());
            Console.WriteLine("\nCzy członek istnieje: " + IT.JestCzlonkiem("Witold", "Adamski") + "; " + IT.JestCzlonkiem("91072235964") + "; " + IT.JestCzlonkiem("Paweł", "Adamski") + "; " + IT.JestCzlonkiem("91072245964"));
            Console.WriteLine("\nWyszykiwanie 1: ");
            WyswietlListeCZ(IT.WyszukajCzlonkow("programista"));
            Console.WriteLine("\nWyszykiwanie 2: ");
            WyswietlListeCZ(IT.WyszukajCzlonkow(1));
            IT.UsunCzlonka("92051613915");
            IT.UsunCzlonka("Anna", "Mysza");
            Console.WriteLine("\nUsunięcie członków:\n" + IT.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź kopiowanie
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "But", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            KierownikZespolu g = (KierownikZespolu)a.Clone();
            CzlonekZespolu h = (CzlonekZespolu)b.Clone();
            Zespol NowaGrupa = (Zespol)IT.Clone();
            NowaGrupa.nazwa = "NowaGrupa";
            NowaGrupa.kierownik = new KierownikZespolu("Rafał", "Marzec", "01.01.1900", "88032112357", Plcie.M, 5);
            Console.WriteLine(g.ToString() + "\n" + h.ToString() + "\n\n" + IT.ToString()+ "\n\n" + NowaGrupa.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź sortowanie
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "Adamski", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            IT.Sortuj();
            Console.WriteLine(IT.ToString() + "\n\n");
            IT.SortujPoPESEL();
            Console.WriteLine(IT.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź equale
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "Adamski", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            CzlonekZespolu g = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            if(IT.JestCzlonkiem(g))
            {
                Console.WriteLine("Jest członkiem");
            }
            else
            {
                Console.WriteLine("Nie jest członkiem");
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź zapis i odczyt z pliku bin
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "Adamski", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            IT.ZapiszBin("zespol.bin");
            Console.WriteLine("Zapisano do pliku\n\n");
            Zespol Odcz = (Zespol)IT.OdczytajBin("zespol.bin");
            Console.WriteLine(Odcz.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/

            //Sprawdź zapis i odczyt do pliku XML
            /*KierownikZespolu a = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", Plcie.M, 5);
            CzlonekZespolu b = new CzlonekZespolu("Witold", "Adamski", "22.10.1992", "92102266738", Plcie.M, "01-sty-2020", "sekretarz");
            CzlonekZespolu c = new CzlonekZespolu("Jan", "Janowski", "15.03.1992", "92031532652", Plcie.M, "01-sty-2020", "programista");
            CzlonekZespolu d = new CzlonekZespolu("Jan", "Adamski", "16.05.1992", "92051613915", Plcie.M, "01-cze-2019", "programista");
            CzlonekZespolu e = new CzlonekZespolu("Beata", "Nowak", "22.11.1993", "93112225023", Plcie.K, "01-sty-2020", "projektant");
            CzlonekZespolu f = new CzlonekZespolu("Anna", "Mysza", "22.07.1991", "91072235964", Plcie.K, "31-lip-2019", "projektant");
            Zespol IT = new Zespol("Grupa IT", a);
            IT.DodajCzlonka(b);
            IT.DodajCzlonka(c);
            IT.DodajCzlonka(d);
            IT.DodajCzlonka(e);
            IT.DodajCzlonka(f);
            Zespol.ZapiszXML("zespol.xml",IT);
            Console.WriteLine("Zapisano do pliku\n\n");
            Zespol Odcz = Zespol.OdczytajXML("zespol.xml");
            Console.WriteLine(Odcz.ToString());
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();*/
        }
    }
}
