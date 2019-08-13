using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public class Package : GenericContainerBase {
        protected override string GetKeyName() {
            return "Package";
        }
    }
}
