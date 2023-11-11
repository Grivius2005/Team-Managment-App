using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Zespol
{
    [Serializable()]
    public class Zespol:ICloneable,IZapisywalna, IEquatable<Zespol>
    {
        [XmlElement(ElementName = "LiczbaCzlonkow")]
        public int liczbaCzlonkow { set; get; }
        [XmlElement(ElementName = "Nazwa")]
        public string nazwa { set; get; }
        [XmlElement(ElementName = "Kierownik")]
        public KierownikZespolu kierownik { set; get; }
        [XmlElement(ElementName = "Czlonek")]
        public List<CzlonekZespolu> czlonkowie { set; get; }


        public Zespol()
        {
            liczbaCzlonkow = 0;
            nazwa = null;
            kierownik = null;
            czlonkowie = new List<CzlonekZespolu>();
        }
        public Zespol(string Nazwa, KierownikZespolu Kierownik)
        {
            liczbaCzlonkow = 0;
            nazwa = Nazwa;
            kierownik = Kierownik;
            czlonkowie = new List<CzlonekZespolu>();
        }

        public void DodajCzlonka(CzlonekZespolu c)
        {
            liczbaCzlonkow++;
            czlonkowie.Add(c);
        }

        public override string ToString()
        {
            string a = "Zespół: " + nazwa + "\n" + "Kierownik: " + kierownik.ToString();
            for(int i=0;i<czlonkowie.Count;i++)
            {
                a += "\n" + czlonkowie[i].ToString();
            }
            return a;
        }
        public bool JestCzlonkiem(string P)
        {
            for(int i=0;i<czlonkowie.Count;i++)
            {
                if(czlonkowie[i].pesel==P)
                {
                    return true;
                }
            }
            return false;
        }
        public bool JestCzlonkiem(string im,string naz)
        {
            for (int i = 0; i < czlonkowie.Count; i++)
            {
                if (czlonkowie[i].Imie == im&&czlonkowie[i].Nazwisko == naz)
                {
                    return true;
                }
            }
            return false;
        }
        public void UsunCzlonka(string P)
        {
            for (int i = 0; i < czlonkowie.Count; i++)
            {
                if (czlonkowie[i].pesel == P)
                {
                    czlonkowie.RemoveAt(i);
                    liczbaCzlonkow--;
                    return;
                }
            }
        }
        public void UsunCzlonka(string im, string naz)
        {
            for (int i = 0; i < czlonkowie.Count; i++)
            {
                if (czlonkowie[i].Imie == im && czlonkowie[i].Nazwisko == naz)
                {
                    czlonkowie.RemoveAt(i);
                    liczbaCzlonkow--;
                    return;
                }
            }
        }

        public void UsunWszystkich()
        {
            czlonkowie.Clear();
            liczbaCzlonkow = 0;

        }

        public List<CzlonekZespolu> WyszukajCzlonkow(string f)
        {
            List<CzlonekZespolu> a = new List<CzlonekZespolu>();
            List<CzlonekZespolu> b = new List<CzlonekZespolu>();
            a = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                return c.Imie == f;
            }
            );
            b = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                return c.Nazwisko == f;
            }
            );
            a.AddRange(b);
            b = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                DateTime data;
                DateTime.TryParseExact(f, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out data);
                return c.DataUrodzenia == data;
            }
            );
            a.AddRange(b);
            b = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                if(f=="M")
                {
                    return c.plec == Plcie.M;
                }
                if(f=="K")
                {
                    return c.plec == Plcie.K;
                }
                else
                {
                    return false;
                }
                
            }
            );
            a.AddRange(b);
            b = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                return c.Funkcja == f;

            }
            );
            a.AddRange(b);
            b = czlonkowie.FindAll(
            delegate (CzlonekZespolu c)
            {
                DateTime data;
                DateTime.TryParseExact(f, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out data);
                return c.DataZapisu == data;
            }
            );
            return a;
        }

        public List<CzlonekZespolu> WyszukajCzlonkow(int miesiac)
        {
            List<CzlonekZespolu> a = new List<CzlonekZespolu>();
            for(int i=0;i<czlonkowie.Count;i++)
            {
                if(czlonkowie[i].DataZapisu.Month == miesiac)
                {
                    a.Add(czlonkowie[i]);
                }
            }
            return a;
        }
        public Object Clone()
        {
            Zespol Kopia = (Zespol)MemberwiseClone();
            Kopia.kierownik = this.kierownik.Clone() as KierownikZespolu;
            Kopia.czlonkowie = new List<CzlonekZespolu>();

            for (int i = 0; i < czlonkowie.Count; i++)
            {
                Kopia.czlonkowie.Add(czlonkowie[i].Clone() as CzlonekZespolu);
            }

            return Kopia;
        }

        public void Sortuj()
        {
            for(int i=0;i<czlonkowie.Count;i++)
            {
                for(int j=0;j<czlonkowie.Count-1;j++)
                {
                    if(czlonkowie[j].CompareTo(czlonkowie[j+1])>0)
                    {
                        CzlonekZespolu a = czlonkowie[j];
                        czlonkowie[j] = czlonkowie[j + 1];
                        czlonkowie[j + 1] = a;
                    }
                }
            }
        }

        public void SortujPoPESEL()
        {
            czlonkowie.Sort(new PESELComparator());
        }

        public bool JestCzlonkiem(CzlonekZespolu a)
        {
            foreach(CzlonekZespolu i in czlonkowie)
            {
                if(i.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }

        public void ZapiszBin(string nazwa)
        {
            FileStream f = new FileStream(nazwa, FileMode.Create);
            BinaryFormatter form = new BinaryFormatter();
            try
            {
                form.Serialize(f, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Nie udało się zserializować. Powód: " + e.Message);
            }
            finally
            {
                f.Close();
            }
        }
        public Object OdczytajBin(string nazwa)
        {
            Object a;
            FileStream f = new FileStream(nazwa, FileMode.Open);
            BinaryFormatter form = new BinaryFormatter();
            a = form.Deserialize(f);
            f.Close();
            return a;
        }

       public static void ZapiszXML(string nazwa, Zespol a)
        {
            TextWriter f = new StreamWriter(nazwa);
            XmlSerializer s = new XmlSerializer(typeof(Zespol));
            try
            {
                s.Serialize(f, a);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Nie udało się zserializować. Powód: " + e.Message);
            }
            finally
            {
                f.Close();
            }
            
        }

        public static Zespol OdczytajXML(string nazwa)
        {
            Zespol a;
            FileStream f = new FileStream(nazwa, FileMode.Open);
            XmlSerializer s = new XmlSerializer(typeof(Zespol));

            a = (Zespol)s.Deserialize(f);
            f.Close();
            return a;
        }
        public bool Equals(Zespol a)
        {
            if(this.nazwa != a.nazwa || !this.kierownik.Equals(a.kierownik) || this.czlonkowie.Count != a.czlonkowie.Count )
            {
                return false;
            }
            for(int i=0; i<this.czlonkowie.Count;i++)
            {
                if(!this.czlonkowie[i].Equals(a.czlonkowie[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
