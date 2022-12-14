using FluentAssertions;
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
            roomBookingResult.Should().NotBeNull();
            roomBookingResult.FullName.Should().Be(bookingRequest.FullName);
            roomBookingResult.Email.Should().Be(bookingRequest.Email);
            roomBookingResult.Date.Should().Be(bookingRequest.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var roomBookingRequestProcessor = new RoomBookingRequestProcessor();

            var exception = roomBookingRequestProcessor.Invoking(b => b.BookRoom(null))
                                                         .Should()
                                                         .Throw<NullReferenceException>();
        }
    }
}