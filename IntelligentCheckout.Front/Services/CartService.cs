using IntelligentCheckout.Front.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private Guid _session;

        public event Action OnChange;

        public CartService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("BaseUrl");
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public Guid GetCurrentSessionIdOrNew()
        {
            if (_session == Guid.Empty)
                _session = Guid.NewGuid();
            return _session;
        }

        public async Task<Carrinho> GetCarrinhos()
        {
            var sessionId = GetCurrentSessionIdOrNew();
            var url = $"{_baseUrl}/carrinho/{sessionId}";
            var resposta = await _httpClient.GetFromJsonAsync<CarrinhoResposta>(url);
            return resposta.Data ?? new Carrinho() { IdSessao = sessionId };
        }


        public async Task<Carrinho> AdicionarItem(ItemDeCompra item)
        {
            var sessionId = GetCurrentSessionIdOrNew();
            var url = $"{_baseUrl}/carrinho/{sessionId}";

            var data = new
            {
                IdProduto = item.Produto.Id.ToString(),
                Quantidade = item.Quantidade
            };

            await _httpClient.PostAsJsonAsync(url, data);
            NotifyStateChanged();
            
            return await GetCarrinhos();
        }


        public async Task<Carrinho> AtualizarItem(ItemDeCompra item)
        {
            var sessionId = GetCurrentSessionIdOrNew();
            var url = $"{_baseUrl}/carrinho/{sessionId}";

            var data = new
            {
                IdProduto = item.Produto.Id.ToString(),
                Quantidade = item.Quantidade
            };

            await _httpClient.PatchAsync(url, new StringContent(JsonSerializer.Serialize(data)));
            NotifyStateChanged();

            return await GetCarrinhos();
        }


        public async Task<Carrinho> RemoverItem(ItemDeCompra item)
        {
            var idProduto = item.Produto.Id.ToString();
            var sessionId = GetCurrentSessionIdOrNew();
            var url = $"{_baseUrl}/carrinho/{sessionId}/{idProduto}";

            await _httpClient.DeleteAsync(url);
            NotifyStateChanged();

            return await GetCarrinhos();
        }


        public async Task<Carrinho> LimparCarrinho()
        {
            var sessionId = GetCurrentSessionIdOrNew();
            var url = $"{_baseUrl}/carrinho/{sessionId}";

            await _httpClient.DeleteAsync(url);
            NotifyStateChanged();

            return await GetCarrinhos();
        }





    }
}
