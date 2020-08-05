using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Models
{
    public class Resposta
    {
        public List<Aviso> Avisos { get; set; }
        public Erro Erro { get; set; }
    }
}
