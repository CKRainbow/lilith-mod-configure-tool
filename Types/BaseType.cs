using LilithModConfigureTool.Types.Components;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilithModConfigureTool.Types
{
    internal abstract class BaseType : IType
    {
        public BaseType(string path)
        {
            Path = path;
            Components = new List<IComponent>();
            Document = new XmlDocument();
            Document.Load(path);
        }
        public string Path { get; }

        public List<IComponent> Components { get; }

        public XmlDocument Document { get; }

        public abstract void AddControl(EditWindow window);

        public abstract void Parse();
    }
}
