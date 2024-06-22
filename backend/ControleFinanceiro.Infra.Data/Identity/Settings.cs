using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Authentications
{
    public static class Settings
    {
        public static string SecretKey { get; set; } = Guid.NewGuid().ToString();
    }
}
