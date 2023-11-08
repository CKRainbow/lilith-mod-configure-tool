using LilithModConfigureTool.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilithModConfigureTool
{
    internal class ModType
    {
        public ModType(string name, string usualPath)
        {
            _name = name;
            UsualPath = usualPath;
        }

        private string _name;

        public string Name {
            get
            {
                return LocalizationProvider.GetLocalizaedValue<string>("Mod" + _name);
            }
        }
        public string UsualPath { get; }

        public List<String> ModFiles { get; } = new();

        public void AddFile(string path)
        {
            ModFiles.Add(path);
        }

        public void ClearFile()
        {
            ModFiles.Clear();
        }
    }
}
