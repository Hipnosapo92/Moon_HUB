using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels_HUB_Interfaces
{
    public interface IConnectionProvider
    {
        public void Search(string endPoint, IMoonHotels_HUB_Communication_Request request, IMoonHotels_HUB_Communication_Response response);
        public string GetName();
    }
}
