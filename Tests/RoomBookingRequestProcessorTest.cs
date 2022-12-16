using Core.Models;
using Core.Processors;
using Core.Services;
using FluentAssertions;
using Moq;

namespace Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private readonly RoomBookingRequestProcessor _roomBookingRequestProcessor;
        private readonly RoomBookingRequest _roomBookingRequest;
        private readonly Mock<IRoomBookingService> _roomBookingServiceMock;

        public RoomBookingRequestProcessorTest()
        {
            //Arrange
            _roomBookingRequest = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2023, 12, 14)
            };

            _roomBookingServiceMock = new Mock<IRoomBookingService>();
            _roomBookingRequestProcessor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Request()
        {
            var roomBookingResult = _roomBookingRequestProcessor.BookRoom(_roomBookingRequest);

            //Assert
            roomBookingResult.Should().NotBeNull();
            roomBookingResult.FullName.Should().Be(_roomBookingRequest.FullName);
            roomBookingResult.Email.Should().Be(_roomBookingRequest.Email);
            roomBookingResult.Date.Should().Be(_roomBookingRequest.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {

            var exception = _roomBookingRequestProcessor.Invoking(b => b.BookRoom(null))
                                                         .Should()
                                                         .Throw<ArgumentException>();
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            RoomBookingResult savedBooking = null;
            _roomBookingServiceMock.Setup(r => r.Save(It.IsAny<RoomBookingResult>()))
                .Callback<RoomBookingResult>(booking => savedBooking = booking);

            _roomBookingRequestProcessor.BookRoom(_roomBookingRequest);

            _roomBookingServiceMock.Verify(r => r.Save(It.IsAny<RoomBookingResult>()), Times.Once);

            savedBooking.Should().NotBeNull();
            savedBooking.FullName.Should().Be(_roomBookingRequest.FullName);
            savedBooking.Email.Should().Be(_roomBookingRequest.Email);
            savedBooking.Date.Should().Be(_roomBookingRequest.Date);
        }
    }
}