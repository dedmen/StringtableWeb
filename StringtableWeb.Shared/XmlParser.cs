using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using StringtableWeb.Shared.Container;

namespace StringtableWeb.Shared {
    public class XmlParser {

        public static Project ParseDocument(string text) {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(text);


            var result = ContainerHelper.ParseFromXml(xd.LastChild); //#TODO throw exception if more elements

            if (result is Project proj)
                return proj;

            return null;
        }

        public static Project ParseDocument(Stream doc) {
            XmlDocument xd = new XmlDocument();
            xd.Load(doc);

            var result = ContainerHelper.ParseFromXml(xd.LastChild); //#TODO throw exception if more elements

            if (result is Project proj)
                return proj;

            return null;
        }


        public static string PrintDocument(Project proj) {

            XmlDocument sitemapDoc = new XmlDocument();
            //#TODO detect utf header case-sensitive stuff from input and store in project
            XmlDeclaration xmlDeclaration = sitemapDoc.CreateXmlDeclaration("1.0", "UTF-8", null); 
            sitemapDoc.AppendChild(xmlDeclaration);

            proj.ToXml(sitemapDoc, sitemapDoc);

            using (var stream = new MemoryStream()) {
                XmlWriterSettings settings = new XmlWriterSettings {Encoding = Encoding.GetEncoding("UTF-8")};

                using (var writer = new XmlTextWriter(stream, new UTF8Encoding(false)))
                {
                    sitemapDoc.Save(writer);
                }

                var stringFromStream = Encoding.ASCII.GetString(stream.ToArray());
                return stringFromStream;
            }
        }
    }
}
