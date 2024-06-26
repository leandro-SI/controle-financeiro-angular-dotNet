using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class MesRepository : GenericRepository<Mes>, IMesRepository
    {
        public MesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
