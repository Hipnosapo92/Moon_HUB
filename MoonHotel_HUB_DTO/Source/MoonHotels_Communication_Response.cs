using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MoonHotels_HUB_Interfaces;


namespace MoonHotels_HUB_DTO
{
    public class MoonHotels_Communication_Response : IMoonHotels_HUB_Communication_Response
    {
        public MoonHotels_Communication_Response()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (Rooms != null)
            {
                Rooms.Clear();
            }
            else
            {
                Rooms = new List<IMoonHotels_HUB_Communication_Response_Room>();
            }
        }

        [JsonPropertyName("rooms")]
        public List<IMoonHotels_HUB_Communication_Response_Room> Rooms { get; set; }
    }

    public class MoonHotels_HUB_Communication_Response_Room : IMoonHotels_HUB_Communication_Response_Room
    {
        public MoonHotels_HUB_Communication_Response_Room()
        {
            Initialize();
        }

        public void Initialize()
        {
            RoomId = -1;

            if (Rates != null)
            {
                Rates.Clear();
            }
            else
            {
                Rates = new List<IMoonHotels_HUB_Communication_Response_Rate>();                
            }
        }

        [JsonPropertyName("roomId")]
        public int RoomId { get; set; }

        [JsonPropertyName("rates")]
        public List<IMoonHotels_HUB_Communication_Response_Rate> Rates { get; set; }
    }

    public class MoonHotels_HUB_Communication_Response_Rate : IMoonHotels_HUB_Communication_Response_Rate
    {
        public MoonHotels_HUB_Communication_Response_Rate()
        {
            Initialize();
        }

        public void Initialize()
        {
            MealPlanId = -1;
            IsCancellable = false;
            Price = -1;
        }

        public int MealPlanId { get; set; }

        public bool IsCancellable { get; set; }

        public double Price { get; set; }
    }
}
