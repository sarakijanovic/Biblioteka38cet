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

        }



    }
}