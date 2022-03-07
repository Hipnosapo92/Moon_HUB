using MoonHotels_HUB_Service;
using System.Reflection;

namespace MoonHotels_HUB
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            MoonHotels_HUB_SRV_Configuration serviceConfiguration = new MoonHotels_HUB_SRV_Configuration();
            List<PluginConfiguration> pluginConfigurations = Configuration.GetSection("Plugins:PluginsConfiguration").Get<List<PluginConfiguration>>();
            foreach (PluginConfiguration pluginConfiguration in pluginConfigurations)
            {
                if (!String.IsNullOrEmpty(pluginConfiguration.PluginEndpoint) && !String.IsNullOrEmpty(pluginConfiguration.PluginName))
                {
                    MoonHotels_HUB_SRV_Plugin_Configuration moonHotels_HUB_SRV_Plugin_Configuration = new MoonHotels_HUB_SRV_Plugin_Configuration();
                    moonHotels_HUB_SRV_Plugin_Configuration.PluginName = pluginConfiguration.PluginName;
                    moonHotels_HUB_SRV_Plugin_Configuration.PluginEndPoint = pluginConfiguration.PluginEndpoint;
                    serviceConfiguration.PluginsConfiguration.Add(moonHotels_HUB_SRV_Plugin_Configuration);
                }
            }

            serviceConfiguration.PluginsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), Configuration.GetValue<string>("Plugins:PluginsFolder"));

            MoonHotels_HUB_SRV service = MoonHotels_HUB_SRV.GetService();
            service.InitializeService(serviceConfiguration);
        }
    }

    public class PluginConfiguration
    {
        public string PluginName { get; set; }
        public string PluginEndpoint { get; set; }
    }
}
