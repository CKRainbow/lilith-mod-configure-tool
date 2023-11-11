using LilithModConfigureTool.Types.Components.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;

namespace LilithModConfigureTool.Types.Components
{
    internal class UseDescComponent : BaseComponent
    {
        public UseDescComponent(string tag) : base(tag, subComponents: new List<IComponent>())
        {
        }

        public override FrameworkElement GetControl()
        {
            StackPanel stackPanel = new();
            Label label = new();
            label.Content = Tag;
            TextBox textBox = new();
            textBox.SetBinding(
                TextBox.TextProperty,
                new Binding
                {
                    Source = Value,
                    Path = new PropertyPath("."),
                    Mode = BindingMode.TwoWay
                }
                );
            stackPanel.Children.Add(label);
            stackPanel.Children.Add(textBox);
            return stackPanel;
        }

        public override void Parse(XmlNode node)
        {
            Value = node.InnerText;
        }
    }
}
