using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public class Key : IContainer {

        public string Name {
            get => Attributes["ID"];
            set => Attributes["ID"] = value;
        }

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public Dictionary<LanguageType, string> Translations = new Dictionary<LanguageType, string>();

        public void ToXml(XmlDocument doc, XmlNode currentElement) {

            XmlElement keyElement = doc.CreateElement(null, "Key", null);
            foreach (var att in Attributes)
                keyElement.SetAttribute(att.Key, att.Value);


            foreach (var val in Translations) {
                var language = val.Key;
                var text = val.Value;
                XmlElement languageElement = doc.CreateElement(null, language.ToString(), null);
                languageElement.InnerText = text;
                keyElement.AppendChild(languageElement);
            }

            currentElement.AppendChild(keyElement);
        }

        public void FromXml(XmlNode currentElement) {

            if (currentElement.Attributes != null)
                foreach (XmlAttribute att in currentElement.Attributes)
                    Attributes[att.LocalName] = att.Value;

            foreach (XmlNode child in currentElement.ChildNodes)
                if (Enum.TryParse(child.LocalName, true, out LanguageType language))
                    Translations[language] = child.InnerText;
        }
    }
}
