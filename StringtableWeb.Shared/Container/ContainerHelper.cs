using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    class ContainerHelper {

        public static IContainer ParseFromXml(XmlNode node) {
            switch (node.LocalName.ToLower()) {
                case "project": {
                    var element = new Project();
                    element.FromXml(node);
                    return element;
                }
                case "package": {
                    var element = new Package();
                    element.FromXml(node);
                    return element;
                }
                case "container": {
                    var element = new Container();
                    element.FromXml(node);
                    return element;
                }
                case "key": {
                    var element = new Key();
                    element.FromXml(node);
                    return element;
                }
            }

            return null;
        }


    }
}
