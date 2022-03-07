using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels_HUB_Interfaces
{
    #region Request
    public interface IMoonHotels_HUB_Communication_Request
    {
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfRooms { get; set; }
        public string Currency { get; set; }
    }

    #endregion
    #region Response
    public interface IMoonHotels_HUB_Communication_Response
    {
        public List<IMoonHotels_HUB_Communication_Response_Room> Rooms { get; set; }        
    }

    public interface IMoonHotels_HUB_Communication_Response_Room
    {
        public int RoomId { get; set; }

        public List<IMoonHotels_HUB_Communication_Response_Rate> Rates { get;set; }
    }

    public interface IMoonHotels_HUB_Communication_Response_Rate
    {
        public int MealPlanId { get; set; }

        public bool IsCancellable { get; set; }

        public double Price { get; set; }
    }
    #endregion
}
