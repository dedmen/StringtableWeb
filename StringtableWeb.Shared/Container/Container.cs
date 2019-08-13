using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public class Container : GenericContainerBase {
        protected override string GetKeyName() {
            return "Container";
        }
    }
}
