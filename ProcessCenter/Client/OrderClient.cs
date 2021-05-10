using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static ProcessCenter.Infrastructure.Dtos;

namespace ProcessCenter.Clients
{
    public class OrderClient
    {
        private readonly HttpClient httpClient;
        public OrderClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<OrderDto>> GetOrderAsync()
        {
            var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<OrderDto>>("/order");
            return items;
        }
    }
}
