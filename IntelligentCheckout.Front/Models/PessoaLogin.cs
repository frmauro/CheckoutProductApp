using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Models
{
    public class PessoaLogin
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public FotoDoRosto[] FotosDoRosto { get; set; }

    }
}
