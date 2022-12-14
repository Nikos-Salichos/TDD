namespace Tests.Models
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingRequest BookRoom(RoomBookingRequest roomBookingRequest)
        {
            return new RoomBookingRequest
            {
                FullName = roomBookingRequest.FullName,
                Email = roomBookingRequest.Email,
                Date = roomBookingRequest.Date,
            };
        }
    }
}