using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zespol;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespol.Zespol zespol;
        bool zmiany = false;
        int help = 0;
        public MainWindow()
        {
            InitializeComponent();
            MinWidth = 655.726;
            MaxWidth = 655.726;
            MinHeight = 485;
            MaxHeight = 485;
            zespol = new Zespol.Zespol();
            zespol = (Zespol.Zespol)Zespol.Zespol.OdczytajXML("Zespol.XML");
            inputNazwa.Text = zespol.nazwa;
            inputKierownik.Text = zespol.kierownik.ToString();
            listCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);

        }
        private void inputNazwa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(help == 0)
            {
                help++;
                return;
            }
            zespol.nazwa = inputNazwa.Text;
            zmiany = true;
        }

        private void changeKierownik_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.kierownik);
            okno.ShowDialog();
            if(okno.DialogResult == true)
            {
                zmiany = true;
            }
            inputKierownik.Text = zespol.kierownik.ToString();

        }

        private void addCzlonkowie_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            okno.ShowDialog();
            if(okno.DialogResult == true)
            {
                zmiany = true;
                zespol.DodajCzlonka(cz);
                listCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            }

        }
        private void changeCzlonkowie_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = -1;
            zaznaczony = listCzlonkowie.SelectedIndex;
            if (zaznaczony == -1)
            {
                MessageBox.Show("Nie wybrano żadnego członka zespołu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                OsobaWindow okno = new OsobaWindow(zespol.czlonkowie[zaznaczony]);
                okno.ShowDialog();
                if (okno.DialogResult == true)
                {
                    zmiany = true;
                }
                listCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            }

        }

        private void delCzlonkowie_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = -1;
            zaznaczony = listCzlonkowie.SelectedIndex;
            if (zaznaczony == -1)
            {
                MessageBox.Show("Nie wybrano żadnego członka zespołu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                zmiany = true;
                zespol.czlonkowie.RemoveAt(zaznaczony);
                listCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            }

        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "Plik XML | *.xml";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.nazwa = inputNazwa.Text;
                Zespol.Zespol.ZapiszXML(filename, zespol);
                zmiany = false;
                help = 0;
            }
        }
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Zespol.Zespol zespolread = Zespol.Zespol.OdczytajXML(filename);
                zespol = zespolread;
                zmiany = false;
                help = 0;
            }
            inputNazwa.Text = zespol.nazwa;
            inputKierownik.Text = zespol.kierownik.ToString();
            listCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
        }
        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            if (!zmiany)
            {
                Close();
            }
            else
            {
                MessageBoxResult mresult = MessageBox.Show("Zmodyfikowano zespół. Czy chcesz zapisać zmiany?", "Zespół", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (mresult == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.Filter = "Plik XML | *.xml";
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        Zespol.Zespol.ZapiszXML(filename, zespol);
                        Close();
                    }
                }
                if (mresult == MessageBoxResult.No)
                {
                   Close();
                }    
            }
        }


    }
}
