using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelLegsPlugin_DTO
{
    public class HotelLegsRequest
    {
        [JsonPropertyName("hotel")]
        public int Hotel;

        [JsonPropertyName("checkInDate")]
        public DateTime CheckInDate;

        [JsonPropertyName("numberOfNights")]
        public int NumberOfNights;

        [JsonPropertyName("guests")]
        public int Guests;

        [JsonPropertyName("rooms")]
        public int Rooms;

        [JsonPropertyName("currency")]
        public string Currency;
    }
}
