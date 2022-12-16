using Core.Models;
using Core.Processors;
using Core.Services;
using FluentAssertions;
using Moq;

namespace Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _roomBookingRequestProcessor;
        private RoomBookingRequest _roomBookingRequest;
        private Mock<IRoomBookingService> _roomBookingService;

        public RoomBookingRequestProcessorTest()
        {
            //Arrange
            _roomBookingRequest = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2023, 12, 14)
            };

            _roomBookingService = new Mock<IRoomBookingService>();
            _roomBookingRequestProcessor = new RoomBookingRequestProcessor(_roomBookingService.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Request()
        {
            //Act
            var roomBookingRequestProcessor = new RoomBookingRequestProcessor();

            var roomBookingResult = roomBookingRequestProcessor.BookRoom(_roomBookingRequest);

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
            //  processor
        }
    }
}