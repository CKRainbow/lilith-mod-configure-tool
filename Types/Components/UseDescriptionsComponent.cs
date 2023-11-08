using LilithModConfigureTool.Types.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace LilithModConfigureTool.Types.Components
{
    internal class UseDescriptionsComponent : IComponent
    {
        public UseDescriptionsComponent()
        {
            Value = null;
            Type = ComponentType.Container;
            SubComponents = new List<IComponent>();
            Attributes = null;
            Optional = true;
            Tag = "UseDescriptions";
        }
        public ComponentType Type { get; }

        public List<IComponent>? SubComponents { get; }

        public List<IAttribute>? Attributes { get; }

        public bool Optional { get; }

        public string Tag { get; }

        public object? Value { get; set; }

        public void Parse(XmlNode node)
        {
            XmlNode? selfUse = node.SelectSingleNode("//selfUse");
            XmlNode? otherUse = node.SelectSingleNode("//otherUse");
            if (selfUse != null)
            {
                UseDescComponent? selfUseComponent = new UseDescComponent("selfUse");
                selfUseComponent.Parse(selfUse);
                SubComponents?.Add(selfUseComponent);
            }
            if (otherUse != null)
            {
                UseDescComponent? otherUseComponent = new UseDescComponent("otherUse");
                otherUseComponent.Parse(otherUse);
                SubComponents?.Add(otherUseComponent);
            }
        }
    }
}
