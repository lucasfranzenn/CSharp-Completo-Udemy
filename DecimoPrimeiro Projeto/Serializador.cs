using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace DecimoPrimeiro_Projeto
{
    internal class Serializador
    {
        static private DataContractSerializer serializador = new DataContractSerializer(typeof(BaseDeDados));

        public static void Serializa(string caminho, BaseDeDados dados)
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings() { Indent = true };
            StringBuilder stringBuilder = new();

            using (XmlWriter writer = XmlWriter.Create(stringBuilder, writerSettings))
            {
                serializador.WriteObject(writer, dados);
            }

            string objetoSerializado = stringBuilder.ToString();

            using (FileStream meuArquivoXML = File.Create(caminho));

            File.WriteAllText(caminho, objetoSerializado);
        }

        public static BaseDeDados Deserializa(string caminho)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    string conteudoObjeto = File.ReadAllText(caminho);

                    StringReader stringReader  = new StringReader(conteudoObjeto);

                    using (XmlReader xmlReader = XmlReader.Create(stringReader))
                    {
                        BaseDeDados temp = (BaseDeDados)serializador.ReadObject(xmlReader);
                        return temp;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
                return null;
            }
        }
    }
}
