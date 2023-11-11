using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zespol
{
    [Serializable()]
    public abstract class Osoba:IEquatable<Osoba>
    {
        private string imie;
        public string Nazwisko { set; get; }
        private DateTime dataUrodzenia;
        private string PESEL;
        private Plcie Plec;
        private string num_tel;
        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }
        public DateTime DataUrodzenia
        {
            get => dataUrodzenia;
            set => dataUrodzenia = value;
        }
        [XmlAttribute()]
        public string pesel
        {
            get
            {
                return PESEL;
            }
            set
            {
                PESEL = value;
            }
        }
        [XmlElement(ElementName = "Plec")]
        public Plcie plec
        {
            get
            {
                return Plec;
            }
            set
            {
                Plec = value;
            }
        }
        public string Num_tel
        {
            get
            {
                return num_tel;
            }
            set
            {
                num_tel = value;
            }
        }
        public Osoba()
        {
            Imie = "default";
            Nazwisko = "default";
            PESEL = "00000000000";
        }
        public Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string data_urodzenia, string Pesel, Plcie plec)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy","dd-MM-yyyy" }, null, DateTimeStyles.None, out dataUrodzenia);
            PESEL = Pesel;
            Plec = plec;
        }
        public Osoba(string imie, string nazwisko, string data_urodzenia, string Pesel, string num_tel, Plcie plec)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy", "dd-MM-yyyy" }, null, DateTimeStyles.None, out dataUrodzenia);
            PESEL = Pesel;
            Num_tel = num_tel;
            Plec = plec;
        }
        public int Wiek()
        {
            int wiek;
            if(DateTime.Today.Month > dataUrodzenia.Month)
            {
                wiek = (DateTime.Today.Year - dataUrodzenia.Year);
            }
            else if(DateTime.Today.Month == dataUrodzenia.Month)
            {
                if(DateTime.Today.Day>=dataUrodzenia.Day)
                {
                    if(DateTime.Today.Year - dataUrodzenia.Year ==0)
                    {
                        wiek = 1;
                    }
                    else 
                    {
                        wiek = (DateTime.Today.Year - dataUrodzenia.Year);
                    }
                    
                }
                else
                {
                    wiek = (DateTime.Today.Year - dataUrodzenia.Year);
                }
            }
            else
            {
                wiek = (DateTime.Today.Year - dataUrodzenia.Year)-1;
            }

            return wiek;
        }
        public override string ToString()
        {
            string a = imie + " " + Nazwisko + " (" + Wiek() + " lat) " + dataUrodzenia.ToString("dd.MM.yyyy")+ " " + PESEL + " "+Num_tel+ " "+ Plec;
            return a;
        }
        
        public void Form_I_N()
        {
            string a = "";
            a +=char.ToUpper(imie[0]);
            for(int i = 1; i < imie.Length; i++)
            {
                a += char.ToLower(imie[i]);
            }
            Imie = a;

            a = "";
            a += char.ToUpper(Nazwisko[0]);
            for (int i = 1; i < Nazwisko.Length; i++)
            {
                a += char.ToLower(Nazwisko[i]);
            }
            Nazwisko = a;

        }
        public double Zyje_H(string Czas)
        {
            DateTime czas;
            DateTime.TryParseExact(Czas, new[] { "HH:mm", "HH.mm","H:mm","H.mm"}, null, DateTimeStyles.None, out czas);
            DateTime uro = dataUrodzenia.AddHours(czas.Hour);
            double ile = (DateTime.Now - uro).TotalHours;
            return Math.Round(ile);
        }
        public string PSL_popr()
        {
            if(PESEL.Length < 11)
            {
                return "niepoprawny (za mało cyfr)";
            }
            if (PESEL.Length > 11)
            {
                return "niepoprawny (za dużo cyfr)";
            }
            string rok = Convert.ToString(dataUrodzenia.Year);
            string rock = String.Concat(rok[0], rok[1]);
            rok = String.Concat(rok[2], rok[3]);
            string miesiac = Convert.ToString(dataUrodzenia.Month);
            if(miesiac.Length == 1)
            {
                miesiac = string.Concat('0', miesiac[0]);
            }
            else
            {
                miesiac = string.Concat(miesiac[0], miesiac[1]);
            }

            if (rock == "20")
            {
                miesiac = miesiac.Replace(miesiac[0], Convert.ToChar(Convert.ToInt32(miesiac[0])+2));
            }
            else if(rock=="21")
            {
                miesiac = miesiac.Replace(miesiac[0], Convert.ToChar(Convert.ToInt32(miesiac[0]) + 4));
            }
            else if (rock == "22")
            {
                miesiac = miesiac.Replace(miesiac[0], Convert.ToChar(Convert.ToInt32(miesiac[0]) + 6));
            }
            string dzien = Convert.ToString(dataUrodzenia.Day);
            if (dzien.Length == 1)
            {
                dzien = string.Concat('0', dzien[0]);
            }
            else
            {
                dzien = string.Concat(dzien[0], dzien[1]);
            }
            string rok2 = string.Concat(PESEL[0], PESEL[1]);
            string miesiac2 = string.Concat(PESEL[2], PESEL[3]);
            string dzien2 = string.Concat(PESEL[4], PESEL[5]);

            if (rok!=rok2||miesiac!=miesiac2||dzien!=dzien2)
            {
                return "niepoprawny (złe cyfry przy dacie urodzenia, czyli 1-6 pozycja)";
            }

            if ((Convert.ToInt32(PESEL[9]) % 2 == 0 && Plec == Plcie.M) || (Convert.ToInt32(PESEL[9]) % 2 == 1 && Plec == Plcie.K))
            {
                return "niepoprawny (zła cyfra przy płci, czyli na 10 pozycji)";
            }

            int contr = 0;
            for (int i = 0, a = 1; i < 11; i++)
            {
                contr += Convert.ToInt32(Convert.ToString(Convert.ToInt32(PESEL[i] - '0') * a)[0] - '0');
                if (a == 1)
                {
                    a = 3;
                }
                else if (a == 3)
                {
                    a = 7;
                }
                else if (a == 7)
                {
                    a = 9;
                }
                else if (a == 9)
                {
                    a = 1;
                }
            }
            contr = 10 - Convert.ToInt32(Convert.ToString(contr)[0] - '0');
            int contr2 = Convert.ToInt32(PESEL[10]-'0');
            Console.WriteLine(contr + " " + contr2);
            if (contr != contr2)
            {
                return "niepoprawny (zła cyfra kontrolna, czyli 11 pozycja)";
            }

            return "poprawny";
        }
        public bool Equals(Osoba a)
        {
            if(this.PESEL == a.PESEL)
            {
                return true;
            }
            return false;
        }
    }
}
