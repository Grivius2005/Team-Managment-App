using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Zespol
{
    [Serializable()]
    public class KierownikZespolu:Osoba,ICloneable
    {
        private int doswiadczenie;
        public int Doswiadczenie
        {
            set
            {
                doswiadczenie = value;
            }
            get
            {
                return doswiadczenie;
            }
        }
        public KierownikZespolu():base() { }
        public KierownikZespolu(string imie, string nazwisko) : base(imie, nazwisko) { }
        public KierownikZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, Plcie plec) : base(imie, nazwisko, data_urodzenia, Pesel, plec) { }
        public KierownikZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, string num_tel, Plcie plec) : base(imie, nazwisko, data_urodzenia, Pesel, num_tel, plec) { }
        public KierownikZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, Plcie plec, int d) : base(imie, nazwisko, data_urodzenia, Pesel, plec)
        {
            doswiadczenie = d;
        }
        public KierownikZespolu(string imie, string nazwisko, string data_urodzenia, string Pesel, string num_tel, Plcie plec, int d) : base(imie, nazwisko, data_urodzenia, Pesel,num_tel, plec)
        {
            doswiadczenie = d;
        }

        public override string ToString()
        {
            string a = Imie + " " + Nazwisko + ", " + DataUrodzenia.ToString("dd.MM.yyyy") + " " + pesel + " " + plec + " " + doswiadczenie;
            return a;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
