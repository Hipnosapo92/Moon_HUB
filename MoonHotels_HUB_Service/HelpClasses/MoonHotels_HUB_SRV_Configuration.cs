using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels_HUB_Service
{
    public class MoonHotels_HUB_SRV_Configuration
    {
        public MoonHotels_HUB_SRV_Configuration()
        {
            Initialize();
        }

        public void Initialize()
        {
            PluginsPath = String.Empty;
            PluginsConfiguration = new List<MoonHotels_HUB_SRV_Plugin_Configuration>();
        }

        public string PluginsPath { get; set; }
        public List<MoonHotels_HUB_SRV_Plugin_Configuration> PluginsConfiguration { get; set; }
    }

    public class MoonHotels_HUB_SRV_Plugin_Configuration
    {
        public MoonHotels_HUB_SRV_Plugin_Configuration()
        {
            Initialize();
        }

        public void Initialize()
        {
            PluginName = String.Empty;
            PluginVersion = String.Empty;
            PluginEndPoint = String.Empty;
        }

        public string PluginName { get; set; }
        public string PluginVersion { get; set; }
        public string PluginEndPoint { get; set; }
    }
}
