using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JsonExemplo
{
    class JsonRequesterController
    {
        public String efetuarGet (String url)
        {
            //Ele vai acessar a URL, ler o conteúdo armazenar na memória e colocar o conteúdo na classe request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //Pegar o conteúdo lido, e converter para uma classe que permite converter pra stream (fila de bytes)
            HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            //Pega o conteúdo do response e converte para um stream
            StreamReader streamreader = new StreamReader(httpWebResponse.GetResponseStream());
            return streamreader.ReadToEnd(); //Pega o conteúdo do streamreader ^lÊ tudo e retorna uma string
        }
    }
}
