﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Models
{
    public class ProdutoIEnumerableResposta : Resposta
    {
        public List<Produto> Data { get; set; }
    }
}
