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
    /// Logica di interazione per Cronologia.xaml
    /// </summary>
    public partial class Cronologia : Window
    {
        private AccountBancario accountCronologia;
        private Lista lista_transazioni;
        public Cronologia(AccountBancario account)
        {
            InitializeComponent();
            this.accountCronologia = account;

            foreach (var transazione in account.ottieniStoricoTransazioni())
            {
                TransazioniContoComboBox.Items.Add(transazione);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Quando viene selezionata una transazione, mostrare i dettagli
            var transazioneSelezionata = (Transaction)TransazioniContoComboBox.SelectedItem;
            if (transazioneSelezionata != null)
            {
                NumeroTrxTextBox.Text = transazioneSelezionata.getIDTransaction().ToString();
                ImportoTextBox.Text = transazioneSelezionata.getImporto_transazione().ToString();
                
            }
        }

        private void Button_Chiudi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ListaStorico_Click(object sender, RoutedEventArgs e)
        {
            if (lista_transazioni == null || !lista_transazioni.IsLoaded)
            {
                lista_transazioni = new Lista(accountCronologia);
                lista_transazioni.Show();
            }
            else
            {
                MessageBox.Show("L'istanza di Lista è già aperta.", "Avviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            // Controlla se l'istanza di Lista è aperta e chiudila forzatamente
            if (lista_transazioni != null && lista_transazioni.IsLoaded)
            {
                lista_transazioni.Close();
                lista_transazioni = null;
            }
        }
    }
}
