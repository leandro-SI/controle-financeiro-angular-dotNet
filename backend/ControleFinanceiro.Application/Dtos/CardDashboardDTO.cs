using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Dtos
{
    public class CardDashboardDTO
    {
        public int QtdCartoes { get; set; }
        public decimal GanhoTotal { get; set; }
        public decimal DespesaTotal { get; set; }
        public decimal Saldo { get; set; }
    }
}
