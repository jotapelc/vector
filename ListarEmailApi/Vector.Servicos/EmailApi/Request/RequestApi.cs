using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vector.Aplicacao.DTO;
using Vector.Servicos.EmailApi.Contrato;

namespace Vector.Servicos.EmailApi.Request
{
    public class RequestApi : IRequestApi
    {
        private HttpClient httpClient = new HttpClient();

        public RequestApi()
        {
            httpClient.BaseAddress = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/");
        }

        public async Task<List<AvatarMockDTO>> ListarAvatar()
        {
            HttpResponseMessage resposta = await httpClient.GetAsync("test-api");
            if (resposta.IsSuccessStatusCode)
            {
                var dados = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AvatarMockDTO>>(dados);
            }

            return new List<AvatarMockDTO>();
        }

        public List<AvatarMockDTO> ListarEmailAgrupadoPorData()
        {
            throw new NotImplementedException();
        }
    }
}
