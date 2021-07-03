using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonExemplo
{
    public class cepWebService
    {
        public String cep { get; set; }
        public String logradouro { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String localidade { get; set; }
        public String uf { get; set; }
        public int ibge { get; set; }
        public int gia { get; set; }
        public int ddd { get; set; }
        public int siafi { get; set; }

    }
    public static class JsonController
    {
        public static Boolean obterDadosClasse(String query, ref cepWebService cepWebService)
        {
            //Nancy
            //Cria uma instância da nossa classe
            JsonRequesterController jsonRequesterController = new JsonRequesterController();
            //Chama nosso método para ler o json
            String retorno = jsonRequesterController.efetuarGet("https://viacep.com.br/ws/" + query + "/json/");
            //Cria uma instância do nancy para tratar nosso json
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //Trata nossa string com o nosso json e separa para os atributos da nossa classe
            cepWebService = javaScriptSerializer.Deserialize<cepWebService>(retorno);
            return true;
        }
        public static Boolean obterDados(ref RichTextBox rch)
        {
            //Nancy
            //Cria uma instância da nossa classe
            JsonRequesterController jsonRequesterController = new JsonRequesterController();
            //Chama nosso método para ler o json
            String retorno = jsonRequesterController.efetuarGet("https://viacep.com.br/ws/01001000/json/");
            //Cria uma instância do nancy para tratar nosso json
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //Trata nossa string com o nosso json e separa para os atributos da nossa classe
            cepWebService cepWebService = javaScriptSerializer.Deserialize<cepWebService>(retorno);

            //C#
            //Cria um string builder
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Cep: " + cepWebService.cep); //Separa o CEP
            stringBuilder.AppendLine("Logradouro: " + cepWebService.logradouro); //Separa o CEP
            stringBuilder.AppendLine("Complemento: " + cepWebService.complemento); //Separa o CEP
            stringBuilder.AppendLine("Bairro: " + cepWebService.bairro); //Separa o CEP
            stringBuilder.AppendLine("Localidade: " + cepWebService.localidade); //Separa o CEP
            stringBuilder.AppendLine("UF: " + cepWebService.uf); //Separa o CEP
            stringBuilder.AppendLine("IBGE: " + cepWebService.ibge.ToString()); //Separa o CEP
            stringBuilder.AppendLine("GIA: " + cepWebService.gia.ToString()); //Separa o CEP
            stringBuilder.AppendLine("DDD: " + cepWebService.ddd.ToString()); //Separa o CEP
            stringBuilder.AppendLine("SIAFI: " + cepWebService.siafi.ToString()); //Separa o CEP
            rch.Text = stringBuilder.ToString(); //Converte nosso string builder para uma string e popula nosso 

            return true;
        }
    }
}
