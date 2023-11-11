using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace LilithModConfigureTool.Types.Components.Attributes
{
    public enum AttributeType
    {
        Bool,
        Text,
        Int,
    }
    public interface IAttribute
    {
        AttributeType Type { get; }
        object? Value { get; set; }

        void Parse(XmlAttribute attrib);

        FrameworkElement GetControl();
    }
}
