using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ContoBancarioWPF.Model
{
    //Aggiunta dell'interfaccia in modo da notificare le modifiche
    public class AccountBancario : INotifyPropertyChanged
    {
        private long numero_conto;
        private List<String> nome_titolare_conto;
        private float saldo;

        private int contatoreIdTransazione = 0;
        private List<Transaction> storicoTransaction;

        public event PropertyChangedEventHandler PropertyChanged;

        public AccountBancario(long num_conto, string nome_titolare_conto, float saldo)
        {
            this.numero_conto = num_conto;
            this.nome_titolare_conto = new List<string> { nome_titolare_conto };
            if (saldo > 0)
            {
                this.saldo = saldo;
            }
            else
            {
                throw new Exception("Money must be positive!");
            }
            storicoTransaction = new List<Transaction>();
        }

        public long NumeroConto
        {
            get
            {
                return numero_conto;
            }
        }

        public string NomeTitolareConto
        {
            get
            {
                return getNome_titolare_conto();
            }
        }
        public float Saldo
        {
            get
            {
                return saldo;
            }
        }

        public long getNumero_conto()
        {
            return this.numero_conto;
        }
        public string getNome_titolare_conto()
        {
            //Ritorno la lista di titolari in una unica stringa. I nomi saranno separati da una virgola
            string titolari_conto = "";
             foreach(string titolari in this.nome_titolare_conto )
            {
                titolari_conto += titolari;
            }
             return titolari_conto;
        }
        

        public void AggiungiTitolare(string titolare_secondario)
        {
            this.nome_titolare_conto.Add(titolare_secondario);
        }
        public float getSaldo()
        {
            return this.saldo;
        }

        public void versamento(float versamento)
        {
            this.saldo += versamento;
            registraTransazione(versamento);
            OnPropertyChanged(nameof(this.saldo));// Aggiorno il saldo nel binding
        }
        public Boolean prelievo(float prelievo)
        {
            //Controlla che la somma richiesta sia positiva e l'account abbia fondi sufficienti
            //In caso positivo si procede al prelievo e alla registrazione di esso 
            //In caso negativo si restituisce un semplice messaggio.
            if (prelievo > 0 && (this.saldo - prelievo) >= 0)
            {
                this.saldo -= prelievo;
                registraTransazione(-prelievo);
                OnPropertyChanged(nameof(this.saldo));//Aggiorno il saldo nel binding
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Withdrawal!");
                return false;
            }
        }

        private void registraTransazione(float importo)
        {
            //Metodo utilizzato per incrementare il contatore della transazione
            //Crea una nuova istanza di Transaction e la aggiunge nel campo della classe come ultima transazione
            this.contatoreIdTransazione++;
            Transaction transazione = new Transaction(this.contatoreIdTransazione, importo);
            this.storicoTransaction.Add(transazione);
        }

        public List<Transaction> ottieniStoricoTransazioni()
        {
            //Restituisce la lista dello storico delle transazioni effettuate dall'istanza di classe
            return this.storicoTransaction;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString()
        {
            return $"Account number: {this.numero_conto}  " + $" Account holder: {getNome_titolare_conto()} " + $" Total Balance {this.saldo}  Euro" + $"Il contatore Transazioni è pari a {this.storicoTransaction}";
        }


    }
}
