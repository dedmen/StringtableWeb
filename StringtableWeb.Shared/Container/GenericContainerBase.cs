using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public abstract class GenericContainerBase : IContainer
    {
        public string Name {
            get => Attributes["name"];
            set => Attributes["name"] = value;
        }

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        public List<IContainer> Children = new List<IContainer>();

        protected abstract string GetKeyName();

        public void ToXml(XmlDocument doc, XmlNode currentElement) {
            XmlElement keyElement = doc.CreateElement(null, GetKeyName(), null);
            foreach (var att in Attributes)
                keyElement.SetAttribute(att.Key, att.Value);

            foreach (var element in Children) {
                element.ToXml(doc, keyElement);
            }

            currentElement.AppendChild(keyElement);
        }

        public void FromXml(XmlNode currentElement) {
            if (currentElement.Attributes != null)
                foreach (XmlAttribute att in currentElement.Attributes)
                    Attributes[att.LocalName] = att.Value;

            foreach (XmlNode child in currentElement.ChildNodes) {
                Children.Add(ContainerHelper.ParseFromXml(child));
            }
        }

    }
}
