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
    /// Logica di interazione per Versamento.xaml
    /// </summary>
    
    public partial class Versamento : Window
    {
        private AccountBancario accountPassato;
        public Versamento(AccountBancario account)
        {
            InitializeComponent();
            this.accountPassato = account;
            this.Width = 600;
            this.Height = 300;
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Versamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Recupero l'importo nella TextBox
                float importo = float.Parse(ImportoTextBox.Text);
                if (importo > 0)
                {
                    accountPassato.versamento(importo);

                    MessageBox.Show($"Versamento di {importo} completato con successo! Nuovo saldo: {accountPassato.getSaldo()} Euro", "Successo");

                    // Chiudi la finestra o torna alla schermata principale
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Importo, try again.");
            }
        }
    }
}
