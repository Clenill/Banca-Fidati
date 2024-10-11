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
using ContoBancarioWPF.Model;

namespace ContoBancarioWPF
{
    /// <summary>
    /// Logica di interazione per Accedi.xaml
    /// </summary>
    public partial class Accedi : Window
    {
        private List<AccountBancario> account_bancari;
        public Accedi(List<long> numeriConto, List<AccountBancario> lista_account_bancari)
        {
            InitializeComponent();
            NumeroContoComboBox.ItemsSource = numeriConto;
            account_bancari = lista_account_bancari;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            long numeroContoSelezionato = (long)NumeroContoComboBox.SelectedItem;
        }

        private void Button_ClickAccedi(object sender, RoutedEventArgs e)
        {
            if (NumeroContoComboBox.SelectedItem == null || string.IsNullOrWhiteSpace(NameAccountHolding.Text))
            {
                MessageBox.Show("Per favore, seleziona un numero di conto e inserisci il nome del titolare.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Recupero il numero conto e il nome titolare inseriti
            long numeroContoSelezionato = (long)NumeroContoComboBox.SelectedItem;
            string nomeTitolareInserito = NameAccountHolding.Text;
            
            foreach(AccountBancario account in account_bancari )
            {
                if(account.getNumero_conto() == numeroContoSelezionato && account.getNome_titolare_conto().Equals(nomeTitolareInserito, StringComparison.OrdinalIgnoreCase))
                {
                    // IN caso di esito positivo vado alla pagina successiva ed avviso con un messaggio a schermo
                    MessageBox.Show("Valid Username and Account!");
                    //Passo l'account alla pagina successiva
                    PaginaConto paginaConto = new PaginaConto(account);
                    paginaConto.ShowDialog();
                    
                    return; 
                }
            }
            //Nel caso non ci sia corrispondenza, mostro un messaggio
            MessageBox.Show("Invalid Account Holder and/or Account Number, please try again.");
        }

        private void Button_ClickChiudi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
