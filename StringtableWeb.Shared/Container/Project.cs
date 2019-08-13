using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StringtableWeb.Shared.Container {
    public class Project : GenericContainerBase {
        protected override string GetKeyName() {
            return "Project";
        }
    }
}
