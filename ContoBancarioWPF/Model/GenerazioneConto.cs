using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoBancarioWPF.Model
{
    internal class GenerazioneConto
    {
        //utilizzo questa classe per generare numeri conto diversi in maniera sequenziale
        private static long inizia_numero_conto = 1_000_223_000;
        public static long generazioneNumeroConto()
        {
            return inizia_numero_conto++;
        }
    }
}
