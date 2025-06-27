using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteka38cet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
      List<Knjiga> knjigaList;
      public MainWindow()
      {
          InitializeComponent();
          knjigaList = new List<Knjiga>();
          UcitajPodatke();
      }

      private void Dodaj_Click(object sender, RoutedEventArgs e)
      {
          knjigaList.Add(new Knjiga(txtNazivKnjige.Text, txtNazivAutora.Text, DateTime.Now));
          UcitajPodatke();
      }

      private void UcitajPodatke()
      {
          DGCentralni.ItemsSource = null;

          DGCentralni.ItemsSource = knjigaList;

      }*/

        private const string Podaci = @".\knjige.txt";
        private List<Knjiga> knjige = new List<Knjiga>();

        public MainWindow()
        {
            InitializeComponent();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            // Proverava da li fajl postoji

            if (File.Exists(Podaci))
            {
                // Čita sve linije iz fajla
                var lines = File.ReadAllLines(Podaci);

                // Parsira svaku liniju u objekat tipa Knjiga i dodaje ga u listu knjiga
                knjige = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new Knjiga(parts[0], parts[1], DateTime.Parse(parts[2]));
                }).ToList();

                // Postavlja listu knjiga kao izvor podataka za DataGrid
                DGCentralni.ItemsSource = knjige;
            }
            else
            {
                MessageBox.Show("Fajl nije pronađen");
            }
        }

        // Metoda koja se poziva kada se klikne na dugme "Dodaj"
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Kreira novi objekat Knjiga sa podacima iz unetih polja i trenutnim datumom i vremenom
            var knjiga = new Knjiga(txtNazivKnjige.Text, txtNazivAutora.Text, DateTime.Now);

            // Proverava da li su oba polja (naziv knjige i autor) popunjena
            if (!string.IsNullOrEmpty(knjiga.NazivKnjige) && !string.IsNullOrEmpty(knjiga.NazivAutora))
            {
                // Dodaje novu knjigu u listu knjiga
                knjige.Add(knjiga);

                // Dodaje podatke o novoj knjizi u fajl
                File.AppendAllText(Podaci, $"{knjiga.NazivKnjige},{knjiga.NazivAutora},{knjiga.DatumUpisa:yyyy-MM-dd HH:mm:ss}\n");

                // Prikazuje poruku o uspešnom upisu
                MessageBox.Show("Uspešan upis!");
            }
            else
            {
                // Prikazuje poruku o neuspešnom upisu ako su polja prazna
                MessageBox.Show("Neuspešan upis!");
            }

            // Ponovo učitava podatke kako bi se nova knjiga prikazala u DataGrid-u
            UcitajPodatke();
        }
    }



}