using ContoBancarioWPF.Model;
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


namespace ContoBancarioWPF
{
    /// <summary>
    /// Logica di interazione per Registrati.xaml
    /// </summary>
    public partial class Registrati : Window
    {
        private List<AccountBancario> account_bancari;
        public AccountBancario nuovoAccount { get; set; }
        public Registrati(List<AccountBancario> accountBancari)
        {
            InitializeComponent();
            this.account_bancari = accountBancari;
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickRegistrati(object sender, RoutedEventArgs e)
        {
            // Verifica che il nome del primo titolare sia inserito
            if (string.IsNullOrWhiteSpace(FirstTitolareTextBox.Text))
            {
                MessageBox.Show("Il nome del primo titolare è obbligatorio!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Controlla se il saldo è un numero valido e positivo
            if (!float.TryParse(Saldo.Text, out float saldo) || saldo <= 0)
            {
                MessageBox.Show("Il saldo deve essere un numero positivo!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Se la CheckBox è selezionata, controlla se il nome del secondo titolare è stato inserito
            if (SecondTitolareCheckBox.IsChecked == true && string.IsNullOrWhiteSpace(SecondTitolareTextBox.Text))
            {
                MessageBox.Show("Il nome del secondo titolare è obbligatorio se la checkbox è selezionata!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creazione del conto
            nuovoAccount = new AccountBancario(GenerazioneConto.generazioneNumeroConto(), FirstTitolareTextBox.Text.ToLower(), saldo);
            

            // Se la CheckBox è selezionata, aggiungi il secondo titolare
            if (SecondTitolareCheckBox.IsChecked == true)
            {
                nuovoAccount.AggiungiTitolare(SecondTitolareTextBox.Text.ToLower());
            }

            // Conferma della registrazione
            MessageBox.Show("Conto registrato con successo!", "Successo", MessageBoxButton.OK, MessageBoxImage.Information);
            account_bancari.Add(nuovoAccount);
            this.DialogResult = true;
            this.Close();
            // Altri eventuali passaggi, come salvare l'account in una lista o un database

        }

        private void Button_ClickAnnulla(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
