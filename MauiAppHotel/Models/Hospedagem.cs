using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoEscolhido { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; } 

        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }

        public int QntDiarias => (DataCheckout - DataCheckin).Days;

        public double ValorTotal
        {
            get
            {
                return (QuartoEscolhido.ValorAdultos * QntAdultos + QuartoEscolhido.ValorCriancas * QntCriancas) * QntDiarias;
            }
        }
    }
}
