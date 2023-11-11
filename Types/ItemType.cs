using LilithModConfigureTool.Types.Components;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LilithModConfigureTool.Types
{
    internal class ItemType : BaseType
    {
        public ItemType(string path) : base(path)
        { 

        }

        override public void AddControl(EditWindow window)
        {
            foreach (var component in Components)
            {
                window.AddToGrid(component.GetControl());
            }
            
        }

        override public void Parse()
        {
            XmlNode? node = Document.SelectSingleNode("//useDescriptions");
            if (node != null)
            {
                UseDescriptionsComponent? useDescriptions = new UseDescriptionsComponent();
                useDescriptions.Parse(node);
                Components?.Add(useDescriptions);
            }
        }
    }
}
