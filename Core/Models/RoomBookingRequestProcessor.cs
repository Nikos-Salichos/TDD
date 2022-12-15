namespace Tests.Models
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequest BookRoom(RoomBookingRequest roomBookingRequest)
        {
            if (roomBookingRequest == null)
            {
                throw new ArgumentException(nameof(roomBookingRequest));
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