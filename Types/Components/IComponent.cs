using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using LilithModConfigureTool.Types.Components.Attributes;

namespace LilithModConfigureTool.Types.Components
{
    public enum ComponentType
    {
        Container,
        Bool,
        Text,
        Int,
    }
    internal interface IComponent
    {
        ComponentType Type { get; }
        
        List<IComponent>? SubComponents { get; }
        List<IAttribute>? Attributes { get; }

        Boolean Optional { get; } 

        string Tag { get; }

        object? Value { get; set; }

        void Parse(XmlNode node);
    }
}
