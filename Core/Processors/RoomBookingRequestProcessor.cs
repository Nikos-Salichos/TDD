using Core.Models;
using Core.Services;

namespace Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        public RoomBookingRequest BookRoom(RoomBookingRequest roomBookingRequest)
        {
            if (roomBookingRequest == null)
            {
                throw new ArgumentException(null, nameof(roomBookingRequest));
            }

            return new RoomBookingRequest
            {
                FullName = roomBookingRequest.FullName,
                Email = roomBookingRequest.Email,
                Date = roomBookingRequest.Date,
            };
        }
    }
}