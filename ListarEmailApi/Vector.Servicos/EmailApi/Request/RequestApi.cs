using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Entidades;
using Vector.Servicos.EmailApi.Contrato;

namespace Vector.Servicos.EmailApi.Request
{
    public class RequestApi : IRequestApi
    {

        public List<AvatarMock> ListarAvatar()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://6064ac2bf09197001778660d.mockapi.io");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var result = httpClient.GetAsync("api/test-api")
                .Result.Content.ReadAsStringAsync().Result;

     
            return JsonConvert.DeserializeObject<List<AvatarMock>>(result);
        }

        public List<AvatarMock> ListarEmailAgrupadoPorData()
        {
            throw new NotImplementedException();
        }

    }
}
