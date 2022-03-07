using HotelLegsPlugin_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLegsPlugin
{
    internal class HotelLegsAPI : IHotelLegsAPI
    {
        public void Search(string endpoint, HotelLegsRequest request, HotelLegsResponse response)
        {
            //TODO: Conects to the API Endpoint.
            //TODO: Send request.
            //TODO: Receive request.

            #region mock response.

            HotelLegsResponseResult responseResult = new HotelLegsResponseResult();
            responseResult.Room = 1;
            responseResult.Meal = 1;
            responseResult.CanCancel = false;
            responseResult.Price = 123.46;
            response.Results.Add(responseResult);

            responseResult = new HotelLegsResponseResult();
            responseResult.Room = 1;
            responseResult.Meal = 1;
            responseResult.CanCancel = true;
            responseResult.Price = 150.00;
            response.Results.Add(responseResult);

            responseResult = new HotelLegsResponseResult();
            responseResult.Room = 2;
            responseResult.Meal = 1;
            responseResult.CanCancel = false;
            responseResult.Price = 148.25;
            response.Results.Add(responseResult);

            responseResult = new HotelLegsResponseResult();
            responseResult.Room = 2;
            responseResult.Meal = 2;
            responseResult.CanCancel = false;
            responseResult.Price = 165.38;
            response.Results.Add(responseResult);

            #endregion;
        }
    }
}
