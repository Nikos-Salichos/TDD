using Tests.Models;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Return_Room_Booking_Request()
        {
            //Arrange
            var bookingRequest = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2023, 12, 14)
            };

            //Act
            var roomBookingRequestProcessor = new RoomBookingRequestProcessor();

            var roomBookingResult = roomBookingRequestProcessor.BookRoom(bookingRequest);

            //Assert
            Assert.NotNull(roomBookingResult);
            roomBookingResult.Should().NotBeNull();
            Assert.Equal(roomBookingResult.FullName, roomBookingResult.FullName);
        }
    }
}