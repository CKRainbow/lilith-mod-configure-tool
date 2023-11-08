using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilithModConfigureTool
{
    static internal class AppResources
    {
        static AppResources()
        {
            AvailableType = new()
            {
                new ModType("Item", @"items\items"),
                new ModType("Clothing", @"items\clothing"),
                new ModType("Weapon", @"items\weapons")
            };

        }

        static public List<ModType> AvailableType {get;}
    }
}
