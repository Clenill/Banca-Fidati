using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContoBancarioWPF.Model;

namespace ContoBancarioWPF.ViewModel
{
    internal class AccountViewModel : INotifyPropertyChanged
    {
        private AccountBancario _accountBancario;
        public event PropertyChangedEventHandler PropertyChanged;

        public AccountViewModel()
        {
            _accountBancario = new AccountBancario(GenerazioneConto.generazioneNumeroConto(), "Mario Rossi", 1000);
        }

        public long NumeroConto => _accountBancario.getNumero_conto();
        public string Intestatario => _accountBancario.getNome_titolare_conto();

        public float Saldo
        {
            get => _accountBancario.getSaldo();
            //set//Bisogna introdurre la transazione in modo da avere la cronologia delle operazioni
            
        }
        public ICommand DepositaCommand { get; set; }
        public ICommand PrelevaCommand { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
