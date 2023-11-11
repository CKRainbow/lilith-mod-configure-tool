using LilithModConfigureTool.Types.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace LilithModConfigureTool.Types.Components
{
    internal class UseDescriptionsComponent : BaseComponent
    {
        public UseDescriptionsComponent() : base("UseDescriptions", type:ComponentType.Container, subComponents: new List<IComponent>())
        {
        }

        override public void Parse(XmlNode node)
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

        public override FrameworkElement GetControl()
        {
            if (SubComponents == null) return null;
            WrapPanel wrapPanel = new WrapPanel();
            foreach (var subComponent in SubComponents)
            {
                wrapPanel.Children.Add(subComponent.GetControl());
            }
            return wrapPanel;
        }
    }
}
