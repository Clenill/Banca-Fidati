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
    /// Logica di interazione per Lista.xaml
    /// </summary>
    public partial class Lista : Window
    {
        private AccountBancario account_da_listare;
        public Lista(AccountBancario account)
        {
            InitializeComponent();
            this.account_da_listare = account;

            foreach (var transazione in account.ottieniStoricoTransazioni())
            {
                TransactionListBox.Items.Add(transazione);
            }

        }
    }
}
