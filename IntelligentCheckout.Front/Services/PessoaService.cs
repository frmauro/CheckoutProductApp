using IntelligentCheckout.Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Services
{
    public class PessoaService
    {
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        private Person _person;

        public Person ObterPessoaAtual()
        {
            return this._person;
        }

        public void AtualizarPessoa(PessoaLogin login)
        {
            if (login.FotosDoRosto == null)
                login.FotosDoRosto = new FotoDoRosto[0];

            this._person = new Person()
            {
                Id = login.Id,
                Nome = login.Nome,
                FotosDoRosto = login.FotosDoRosto.Select(f => f.FotoEmBase64).ToArray()
            };
            this.NotifyStateChanged();
        }


        public void Logout()
        {
            this._person = null;
            this.NotifyStateChanged();
        }

    }
}
