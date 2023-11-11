using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using Zespol;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        public KierownikZespolu osoba1 = null;
        public CzlonekZespolu osoba2 = null;

        public OsobaWindow()
        {
            
            InitializeComponent();
            MinWidth = 539.911;
            MaxWidth = 539.911;
            MinHeight = 540.693;
            MaxHeight = 540.693;
        }
        public OsobaWindow(KierownikZespolu osoba) : this()
        {
            osoba1 = osoba;
            labelDosaStan.Content = "Doświadczenie";
            labelZatru.Content = "";
            inputZatru.Visibility = Visibility.Hidden;
            inputPesel.Text = osoba.pesel;
            inputImie.Text = osoba.Imie;
            inputNazwisko.Text = osoba.Nazwisko;
            inputUro.Text = osoba.DataUrodzenia.ToString("dd-MMM-yyyy");
            inputPlec.Text = ((osoba.plec) == Plcie.K) ? "Kobieta" : "Mężczyzna";
            inputDosaStan.Text = osoba.Doswiadczenie.ToString();
        }

        public OsobaWindow(CzlonekZespolu osoba): this()
        {
            osoba2 = osoba;
            if (osoba2.pesel != "0000000000" && osoba2.Imie != "default" && osoba2.Nazwisko != "default")
            {
                labelDosaStan.Content = "Stanowisko";
                inputPesel.Text = osoba.pesel;
                inputImie.Text = osoba.Imie;
                inputNazwisko.Text = osoba.Nazwisko;
                inputUro.Text = osoba.DataUrodzenia.ToString("dd-MMM-yyyy");
                inputPlec.Text = ((osoba.plec) == Plcie.K) ? "Kobieta" : "Mężczyzna";
                inputDosaStan.Text = osoba.Funkcja;
                inputZatru.Text = osoba.DataZapisu.ToString("dd-MMM-yyyy");
            }

        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            int help = 0;
            string[] fdata = { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MMM-yyyy", "dd.MM.yyyy", "dd-MM-yyyy" };
            CzlonekZespolu h = new CzlonekZespolu("", "", inputUro.Text, inputPesel.Text, (inputPlec.Text == "Kobieta") ? Plcie.K : Plcie.M);
            if (checkWalipesel.IsChecked == true && DateTime.TryParseExact(inputUro.Text, fdata, null, DateTimeStyles.None, out DateTime test1))
            {
                if (h.PSL_popr() != "poprawny")
                {
                    MessageBox.Show("Pesel " + h.PSL_popr(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    help++;
                }
            }
            if (inputUro.Text != "" && !DateTime.TryParseExact(inputUro.Text, fdata, null, DateTimeStyles.None, out DateTime test2))
            {
                MessageBox.Show("Błedny fromat w dacie urodzenia!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                help++;
            }
            if(inputZatru.Text != "" && !DateTime.TryParseExact(inputZatru.Text, fdata, null, DateTimeStyles.None, out DateTime test3))
            {
                MessageBox.Show("Błedny fromat w dacie zatrudnienia!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                help++;
            }
            if (osoba2 == null && !int.TryParse(inputDosaStan.Text, out int test4))
            {
                MessageBox.Show("Błedny fromat w doświadczeniu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                help++;
            }
            if (help == 0)
            {
                if (inputPesel.Text != "" && inputImie.Text != "" && inputImie.Text != "" && osoba2 == null)
                {
                    osoba1.pesel = inputPesel.Text;
                    osoba1.Imie = inputImie.Text;
                    osoba1.Nazwisko = inputNazwisko.Text;
                    osoba1.Form_I_N();
                    DateTime.TryParseExact(inputUro.Text, fdata, null, DateTimeStyles.None, out DateTime date);
                    osoba1.DataUrodzenia = date;
                    osoba1.plec = (inputPlec.Text == "Kobieta") ? Plcie.K : Plcie.M;
                    osoba1.Doswiadczenie = Convert.ToInt32(inputDosaStan.Text);
                    DialogResult = true;
                }
                if (inputPesel.Text != "" && inputImie.Text != "" && inputImie.Text != "" && osoba1 == null)
                {
                    osoba2.pesel = inputPesel.Text;
                    osoba2.Imie = inputImie.Text;
                    osoba2.Nazwisko = inputNazwisko.Text;
                    osoba2.Form_I_N();
                    DateTime.TryParseExact(inputUro.Text, fdata, null, DateTimeStyles.None, out DateTime date1);
                    osoba2.DataUrodzenia = date1;
                    osoba2.plec = (inputPlec.Text == "Kobieta") ? Plcie.K : Plcie.M;
                    osoba2.Funkcja = inputDosaStan.Text;
                    DateTime.TryParseExact(inputZatru.Text, fdata, null, DateTimeStyles.None, out DateTime date2);
                    osoba2.DataZapisu = date2;
                    DialogResult = true;
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void labelWalipesel_Clicked(object sender, RoutedEventArgs e)
        {
            if(checkWalipesel.IsChecked == false)
            {
                checkWalipesel.IsChecked = true;
            }
            else
            {
                checkWalipesel.IsChecked = false;
            }
        }
        
    }
}
