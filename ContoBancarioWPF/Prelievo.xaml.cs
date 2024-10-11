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
    /// Logica di interazione per Prelievo.xaml
    /// </summary>
    public partial class Prelievo : Window
    {
        private AccountBancario accountPassato;
        Boolean transazione;
        public Prelievo(AccountBancario account)
        {
            InitializeComponent();
            this.accountPassato = account;
            this.Width = 600;
            this.Height = 300;
            transazione = false;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Preleva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Recupero l'importo nella TextBox
                float importo = float.Parse(ImportoPrelievoTextBox.Text);
                if (importo > 0)
                {

                    if (accountPassato.prelievo(importo))
                    {
                        MessageBox.Show($"Prelievo di {importo} completato con successo! Nuovo saldo: {accountPassato.getSaldo()} Euro", "Successo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Prelievo di {importo} non completato, controlla se il saldo disponibile è sufficiente");
                    }

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Number, try again.");
            }
        }
    }
}
