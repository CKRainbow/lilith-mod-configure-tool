using LilithModConfigureTool.Types.Components;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilithModConfigureTool.Types
{
    internal class ItemType : IType
    {
        public ItemType(string path)
        {
            Path = path;
            Componenets = new List<IComponent>();
            Document = new XmlDocument();
            Document.Load(path);
        }
        public string Path { get; }

        public List<IComponent>? Componenets { get; }

        public XmlDocument Document { get; }

        public void Parse()
        {
            
            XmlNode? node = Document.SelectSingleNode("//useDescriptions");
            if (node != null)
            {
                UseDescriptionsComponent? useDescriptions = new UseDescriptionsComponent();
                useDescriptions.Parse(node);
                Componenets?.Add(useDescriptions);
            }
        }
    }
}
