using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace iLibrarySystem.XMLSerializer
{
    public abstract class XMLSet<T> where T : class
    {
        protected XMLSet()
        {

        }

        public virtual T ReadXmlSerialize(string P_sPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(P_sPath, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public virtual List<T> ReadXmlSerializeList(string P_sPath)
        {
            List<T> list = new List<T>();
            using (FileStream stream = new FileStream(P_sPath, FileMode.Open))
            {
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    ConformanceLevel = ConformanceLevel.Fragment
                };
                XmlReader reader = XmlReader.Create(stream, settings);
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (List<T>)serializer.ReadObject(stream);
            }
        }

        public virtual void UpdateXmlSerialize(T P_oXML, string P_sPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(P_sPath))
            {
                serializer.Serialize(writer, P_oXML);
            }
        }

        public virtual void UpdateXmlSerialize(List<T> P_oXML, string P_sPath)
        {
            using (FileStream stream = new FileStream(P_sPath, FileMode.Create))
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  ",
                    OmitXmlDeclaration = true,
                    Encoding = new UTF8Encoding(false),
                    CloseOutput = false
                };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    new DataContractSerializer(typeof(T)).WriteObject(writer, P_oXML);
                }
            }
        }
    }
}
