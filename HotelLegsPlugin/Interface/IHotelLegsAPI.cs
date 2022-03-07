using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLegsPlugin_DTO;

namespace HotelLegsPlugin
{
    internal interface IHotelLegsAPI
    {
        void Search(string endpoint, HotelLegsRequest request, HotelLegsResponse response);
    }
}
