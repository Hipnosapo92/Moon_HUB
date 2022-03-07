using MoonHotels_HUB_DTO;
using MoonHotels_HUB_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels_HUB_Service
{
    public class MoonHotels_HUB_SRV
    {
        private static MoonHotels_HUB_SRV _Service;
        private static object _locker = new object();

        private static string PluginsPath = String.Empty;
        private static List<MoonHotels_HUB_SRV_Providers> _ConnectorProviders = new List<MoonHotels_HUB_SRV_Providers>();

        public void InitializeService(MoonHotels_HUB_SRV_Configuration configuration)
        {
            if (configuration != null)
            {
                string[] pluginFilesPaths = Directory.GetFiles(configuration.PluginsPath, "*.dll");
                Type interfaceType = typeof(IConnectionProvider);

                foreach (string pluginFile in pluginFilesPaths)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(pluginFile);
                        foreach (var type in assembly.GetTypes())
                        {
                            if (interfaceType.IsAssignableFrom(type) && type.IsClass)
                            {
                                MoonHotels_HUB_SRV_Providers provider = new MoonHotels_HUB_SRV_Providers();
                                IConnectionProvider connectionProvider = (IConnectionProvider)Activator.CreateInstance(type);
                                string name = connectionProvider.GetName();
                                if (!String.IsNullOrEmpty(name))
                                {
                                    MoonHotels_HUB_SRV_Plugin_Configuration pluginConfig = configuration.PluginsConfiguration.FirstOrDefault(x => x.PluginName.Equals(name, StringComparison.OrdinalIgnoreCase));
                                    if (pluginConfig != null)
                                    {
                                        provider.Name = pluginConfig.PluginName;
                                        provider.EndPoint = pluginConfig.PluginEndPoint;
                                        provider.ConnectionProvider = connectionProvider;
                                        _ConnectorProviders.Add(provider);
                                    }
                                }
                            }
                        }
                    }
                    catch (BadImageFormatException)
                    {
                        // Not a .net assembly  - ignore
                    }
                }
            }
        }

        public static MoonHotels_HUB_SRV GetService()
        {
            if (_Service == null)
            {
                lock (_locker)
                {
                    if (_Service == null)
                    {
                        _Service = new MoonHotels_HUB_SRV();
                    }
                }
            }

            return _Service;
        }

        public MoonHotels_HUB_SRV()
        {
            Initialize();
        }

        private void Initialize()
        {

        }

        public void Search(IMoonHotels_HUB_Communication_Request request, IList<MoonHotels_Communication_Response> responses)
        {
            foreach (MoonHotels_HUB_SRV_Providers connectionProvider in _ConnectorProviders)
            {
                MoonHotels_Communication_Response response = new MoonHotels_Communication_Response();
                try
                {
                    connectionProvider.ConnectionProvider.Search(connectionProvider.EndPoint, request, response);
                    responses.Add(response);
                }
                catch(Exception ex)
                {
                    //To allow request in others providers if one of them fails.
                }
            }
        }

    }
}
