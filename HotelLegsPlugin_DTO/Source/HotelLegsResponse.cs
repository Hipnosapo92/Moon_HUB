using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelLegsPlugin_DTO
{
    public class HotelLegsResponse
    {
        public HotelLegsResponse()
        {
            Initialize();
        }

        public void Initialize()
        {
            Results = new List<HotelLegsResponseResult>();
        }

        [JsonPropertyName("results")]
        public List<HotelLegsResponseResult> Results;
    }
    public class HotelLegsResponseResult
    {
        public HotelLegsResponseResult()
        {
            Initialize();
        }

        public void Initialize()
        {
            Room = -1;
            Meal = -1;
            CanCancel = false;
            Price = 0;
        }

        [JsonPropertyName("room")]
        public int Room;

        [JsonPropertyName("meal")]
        public int Meal;

        [JsonPropertyName("canCancel")]
        public bool CanCancel;

        [JsonPropertyName("price")]
        public double Price;
    }


}
