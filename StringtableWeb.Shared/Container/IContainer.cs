using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public interface IContainer {
        string Name { get; set; }
        Dictionary<string, string> Attributes { get; set; }

        void ToXml(XmlDocument doc, XmlNode currentElement);
        void FromXml(XmlNode currentElement);
    }
}
