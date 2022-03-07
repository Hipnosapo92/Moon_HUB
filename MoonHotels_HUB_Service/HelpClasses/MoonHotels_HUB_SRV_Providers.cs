using MoonHotels_HUB_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels_HUB_Service
{
    internal class MoonHotels_HUB_SRV_Providers
    {
        public MoonHotels_HUB_SRV_Providers()
        {
            Initialize();
        }

        public void Initialize()
        {
            ConnectionProvider = null;
            Name = String.Empty;
            EndPoint = String.Empty;
        }

        internal IConnectionProvider ConnectionProvider { get; set; }   
        internal string Name { get; set; }
        internal string EndPoint { get; set; }
    }
}
