using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoBancarioWPF.Model
{
    public class Transaction
    {
        private int idtransazione { get; set; }
        private float importo_transazione { get; set; }

        public Transaction(int idtransazione, float importo_transazione)
        {
            this.idtransazione = idtransazione;
            this.importo_transazione = importo_transazione;
        }
        public int getIDTransaction()
        {
        return idtransazione; 
        }
        public float getImporto_transazione()
        {
            return importo_transazione;
        }

        public override string ToString()
        {
            return $"Id Transaction: {idtransazione}° " + $" Amount Transaction  {importo_transazione}";
        }
    }
}
