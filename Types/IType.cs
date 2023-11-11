using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LilithModConfigureTool.Types.Components;

namespace LilithModConfigureTool.Types
{
    public interface IType
    {

        string Path { get; }

        List<IComponent> Components { get; }

        XmlDocument Document { get; }

        void Parse();

        void AddControl(EditWindow window);
    }
}
