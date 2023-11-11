using LilithModConfigureTool.Types.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace LilithModConfigureTool.Types.Components
{
    internal abstract class BaseComponent : IComponent
    {
        public BaseComponent(string tag, ComponentType type=ComponentType.Text, List<IComponent>? subComponents=null, List<IAttribute>? attributes=null, bool optional=true)
        {
            Value = null;
            Type = type;
            SubComponents = subComponents;
            Attributes = attributes;
            Optional = optional;
            Tag = tag;
        }
        public ComponentType Type { get; }

        public List<IComponent>? SubComponents { get; }

        public List<IAttribute>? Attributes { get; }

        public bool Optional { get; }

        public string Tag { get; }

        public object? Value { get; set; }

        public abstract void Parse(XmlNode node);

        public abstract FrameworkElement GetControl();
    }
}
