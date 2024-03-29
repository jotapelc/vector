﻿using AutoMapper;
using Nancy.Json;
using Nancy.Json.Simple;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Aplicacao.Contrato;
using Vector.Aplicacao.DTO;
using Vector.Dominio.Contratos.IServico;
using Vector.Dominio.Entidades;
using Vector.Servicos.EmailApi.Contrato;

namespace Vector.Aplicacao.Aplicacao
{
    public class AvatarMockAplicacao : IAvatarMockAplicacao
    {
        private readonly IAvatarMockServico servico;
        private readonly IRequestApi request;
        private readonly IMapper mapper;

        public AvatarMockAplicacao(IAvatarMockServico servico, IRequestApi request, IMapper mapper)
        {
            this.servico = servico;
            this.request = request;
            this.mapper = mapper;
        }

        public string ListarAvatar()
        {
            var listaBD = servico.ListarAvatar();
            try
            {
                if (listaBD.Count <= 0)
                {
                    listaBD = ListarApi();
                    servico.BulkInsert(listaBD);
                }
                else if (listaBD[0].SavedIn < DateTime.Today)
                {
                    listaBD = ListarApi();
                    servico.BulkUpdate(listaBD);
                }

                var resultado = ListarEmailLimpo();
              

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<AvatarMock> ListarApi()
        {
            var novaLista = new List<AvatarMock>();
            try
            {
                var lista = request.ListarApi();

                if (lista == null)
                    return null;

                novaLista = lista;
            }
            catch (Exception)
            {
                return null;
            }
            return novaLista;
        }

        public List<AvatarMockDTOGroupBy> ListarEmailAgrupadoPorData()
        {
            var lista = servico.ListarEmailAgrupadoPorData();
            if (lista == null)
                return null;


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.Serialize(lista);


            var resultado = mapper.Map<List<AvatarMockDTOGroupBy>>(lista);
            return resultado;

        }

        public List<AvatarMockDTO> ListarApenasEmail()
        {
            var listarMail = servico.ListarApenasEmail();
            if (listarMail == null)
                ListarAvatar();

            var resultado = mapper.Map<List<AvatarMockDTO>>(listarMail);
    
            return resultado;
        }

        public string ListarEmailLimpo()
        {
            
            var emails = servico.ListarEmailLimpo();

            JsonObject character = new JsonObject();
            character.Add("emails", emails );

            var json = new JavaScriptSerializer().Serialize(character);
            return json;
        }

        public string LIstarData()
        {
            var datas = servico.LIstarData();
            var resultado = mapper.Map<List<AvatarMockDTOGroupBy>>(datas);
            List<AvatarMockDTOGroupBy> estancia = new(resultado);

            //var query = from avatares in estancia
            //          group avatares by avatares.CreatedAt.Hour;

            var query = from avatars in estancia
                        group new { avatars.CreatedAt, avatars.Mail }
                        by avatars.CreatedAt.Hour into newGroup
                        select newGroup;

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);

                foreach (var c in item)
                {
                    Console.WriteLine(c.Mail);

                }
            }

            dynamic dynJson = JsonConvert.SerializeObject(query);
            Console.WriteLine("------------------------------------------------------");
            return dynJson; 

 
        }
    }
}
