using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLegsPlugin_DTO;
using MoonHotels_HUB_Interfaces;
namespace HotelLegsPlugin
{
    internal class HotelLegsProvider : IConnectionProvider
    {
        public HotelLegsProvider()
        {

        }

        public string GetName()
        {
            return "HotelLegs";
        }

        public void Search(string endPoint, IMoonHotels_HUB_Communication_Request request, IMoonHotels_HUB_Communication_Response response)
        {
            HotelLegsAPI hotelLegsAPI = new HotelLegsAPI();

            HotelLegsRequest hotelLegsRequest = new HotelLegsRequest();
            TranslateRequest(request, hotelLegsRequest);

            HotelLegsResponse hotelLegsResponse = new HotelLegsResponse();

            hotelLegsAPI.Search(endPoint, hotelLegsRequest, hotelLegsResponse);

            TranslateResponses(hotelLegsResponse, response);
        }

        private void TranslateRequest(IMoonHotels_HUB_Communication_Request request, HotelLegsRequest hotelLegsRequest)
        {
            hotelLegsRequest.Hotel = request.HotelId;
            hotelLegsRequest.CheckInDate = request.CheckIn;
            hotelLegsRequest.NumberOfNights = (request.CheckOut - request.CheckIn).Days;
            hotelLegsRequest.Guests = request.NumberOfGuests;
            hotelLegsRequest.Rooms = request.NumberOfRooms;
            hotelLegsRequest.Currency = request.Currency;
        }

        private void TranslateResponses(HotelLegsResponse hotelLegsResponse, IMoonHotels_HUB_Communication_Response response)
        {
            foreach (HotelLegsResponseResult hotelLegResult in hotelLegsResponse.Results)
            {
                IMoonHotels_HUB_Communication_Response_Room room = response.Rooms.FirstOrDefault(x => x.RoomId == hotelLegResult.Room);
                if (room == null)
                {
                    room = new MoonHotels_HUB_Communication_Response_Room();
                    room.RoomId = hotelLegResult.Room;
                    response.Rooms.Add(room);
                }

                IMoonHotels_HUB_Communication_Response_Rate rate = new MoonHotels_HUB_Communication_Response_Rate();
                rate.Price = hotelLegResult.Price;
                rate.MealPlanId = hotelLegResult.Meal;
                rate.IsCancellable = hotelLegResult.CanCancel;

                room.Rates.Add(rate);
            }
        }
    }
}
