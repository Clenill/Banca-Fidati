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
using ContoBancarioWPF.Model;

namespace ContoBancarioWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<AccountBancario> account_bancari;
        public MainWindow()
        {
            InitializeComponent();

            account_bancari = new List<AccountBancario>();


            AccountBancario account1 = new AccountBancario(GenerazioneConto.generazioneNumeroConto(), "mario draghi", 1237774);
            AccountBancario account2 = new AccountBancario(GenerazioneConto.generazioneNumeroConto(), "barak obama", 23237522);
            AccountBancario account3 = new AccountBancario(GenerazioneConto.generazioneNumeroConto(), "michelangelo buonarroti", 5000);

            account_bancari.Add(account1);
            account_bancari.Add(account2);
            account_bancari.Add(account3);

            List<long> numeriConto = RecuperaNumeriConto(account_bancari);


        }

       
        private List<long> RecuperaNumeriConto(List<AccountBancario> account_bancari)
        {
            // Recupero i numeri conto dalla lista di Account Bancario
            List<long> numeriConto = new List<long>();

            foreach (AccountBancario account in account_bancari)
            {
                numeriConto.Add(account.getNumero_conto());
            }

            return numeriConto;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_ClickAccedi(object sender, RoutedEventArgs e)
        {
            List<long> numeriConto = RecuperaNumeriConto(account_bancari);
            Accedi accediConCredenziali = new Accedi(numeriConto, account_bancari);
            accediConCredenziali.Closed += accediConCredenziali_Closed;
            accediConCredenziali.ShowDialog();
        }
        //Riapro la finestra principale quando la pagina di accesso con credenziali viene chiusa
        private void accediConCredenziali_Closed(object sender, EventArgs e) 
        {
            //Mostro la finestra principale
            
            this.Show();
        }

        private void Button_ClickRegistrati(object sender, RoutedEventArgs e)
        {
            //In questo caso uso show dialog perché devo ritornare alla pagina per effettuare l'accesso con le credenziali
            Registrati registratiCredenziali = new Registrati(account_bancari);
            registratiCredenziali.ShowDialog();

            // Aggiornamento ComboBox dopo la registrazine
            
        }
    }
}