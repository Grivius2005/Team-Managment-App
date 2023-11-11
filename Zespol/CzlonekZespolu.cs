using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Zespol
{
    [Serializable()]
    public class CzlonekZespolu : Osoba, ICloneable, IComparable<CzlonekZespolu>
    {
        private DateTime dataZapisu;
        private string funkcja;
        public DateTime DataZapisu
        {
            set
            {
                dataZapisu = value;
            }
            get
            {
                return dataZapisu;
            }
        }
        public string Funkcja
        {
            set
            {
                funkcja = value;
            }
            get
            {
                return funkcja;
            }
        }
        public CzlonekZespolu():base() { }
        public CzlonekZespolu(string imie, string nazwisko):base(imie,nazwisko) { }
        public CzlonekZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, Plcie plec) : base(imie, nazwisko, data_urodzenia, Pesel, plec) { }
        public CzlonekZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, string num_tel, Plcie plec):base(imie, nazwisko, data_urodzenia, Pesel,num_tel,plec) { }
        public CzlonekZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, Plcie plec, string dataz, string f) :base(imie,nazwisko,data_urodzenia,Pesel, plec)
        {
            DateTime.TryParseExact(dataz, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out dataZapisu);
            funkcja = f;
        }
        public CzlonekZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, string num_tel, Plcie plec, string dataz, string f) :base(imie,nazwisko,data_urodzenia,Pesel, num_tel, plec)
        {
            DateTime.TryParseExact(dataz, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out dataZapisu);
            funkcja = f;
        }

        public override string ToString()
        {
            string a = Imie + " " + Nazwisko + ", "+ DataUrodzenia.ToString("dd.MM.yyyy") + " " + pesel + " " + plec + " " + funkcja + " (" + dataZapisu.ToString("dd-MMM-yyyy") + ")";
            return a;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public int CompareTo(CzlonekZespolu a)
        {
            if (a == null) return 1;
            else
            {
                if(this.Nazwisko.CompareTo(a.Nazwisko)==0)
                {
                    return this.Imie.CompareTo(a.Imie);
                    
                }
                else
                {
                    return this.Nazwisko.CompareTo(a.Nazwisko);
                }
            }
        }
    }
}
