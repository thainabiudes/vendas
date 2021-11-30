using System;

namespace API.Models
{
    public class Pagamento
    {
        public Pagamento() => CriadoEm = DateTime.Now;
        public int PagamentoId { get; set; }
        public string FormaDePagamento { get; set; }
        public int NumeroDeVezes { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}