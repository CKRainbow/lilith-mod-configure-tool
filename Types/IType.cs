using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LilithModConfigureTool.Types.Components;

namespace LilithModConfigureTool.Types
{
    internal interface IType
    {

        string Path { get; }

        List<IComponent>? Componenets { get; }

        XmlDocument Document { get; }

        void Parse();
    }
}
