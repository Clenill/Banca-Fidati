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
    /// Logica di interazione per PaginaConto.xaml
    /// </summary>
    public partial class PaginaConto : Window
    {
        private AccountBancario accountCorrente;
        public PaginaConto(AccountBancario account_connesso)
        {
            InitializeComponent();
            this.accountCorrente = account_connesso;
            DataContext = accountCorrente;  // Imposta l'account come DataContext per il binding
            
        }
        //Metodo per aggiornare il saldo visualizzto
        

        private void Button_Versamento_Click(object sender, RoutedEventArgs e)
        {
            Versamento paginaVersa= new Versamento(accountCorrente);
            paginaVersa.ShowDialog();
            
        }

        private void Button_Prelievo_Click(object sender, RoutedEventArgs e)
        {
            Prelievo paginaPrelievo = new Prelievo(accountCorrente);
            paginaPrelievo.ShowDialog();
        }

        private void Button_Cronologia_Click(object sender, RoutedEventArgs e)
        {
            Cronologia cronologia = new Cronologia(accountCorrente);
            cronologia.ShowDialog();
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
