using MoonHotels_HUB_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoonHotels_HUB_DTO
{
    public class MoonHotels_Communication_Request : IMoonHotels_HUB_Communication_Request
    {
        public MoonHotels_Communication_Request()
        {
            Initialize();
        }

        public void Initialize()
        {
            HotelId = -1;
            CheckIn = DateTime.MinValue;
            CheckOut = DateTime.MinValue;
            NumberOfGuests = -1;
            NumberOfRooms = -1;
            Currency = String.Empty;
        }

        [JsonPropertyName("hotelId")]
        public int HotelId { get; set; }

        [JsonPropertyName("checkIn")]
        public DateTime CheckIn { get; set; }

        [JsonPropertyName("checkOut")]
        public DateTime CheckOut { get; set; }

        [JsonPropertyName("numberOfGuests")]
        public int NumberOfGuests { get; set; }

        [JsonPropertyName("numberOfRooms")]
        public int NumberOfRooms { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
