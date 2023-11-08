using LilithModConfigureTool.Types.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LilithModConfigureTool.Types.Components
{
    internal class UseDescComponent : IComponent
    {
        public UseDescComponent(string tag)
        {
            Value = null;
            Type = ComponentType.Text;
            SubComponents = new List<IComponent>();
            Attributes = null;
            Optional = true;
            Tag = tag;
        }
        public ComponentType Type { get; }

        public List<IComponent>? SubComponents { get; }

        public List<IAttribute>? Attributes { get; }

        public bool Optional { get; }

        public string Tag { get; }

        public object? Value { get; set; }

        public void Parse(XmlNode node)
        {
            Value = node.InnerText;
        }
    }
}
