using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string[] FotosDoRosto { get; set; }
    }
}
