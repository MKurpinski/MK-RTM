using ControllerTests.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ControllerTests.Tests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderServiceMock;

        public OrderControllerTests()
        {
            _orderServiceMock = new Mock<IOrderService>();
        }

        [Fact]
        public void SubmitOrder_InvokesOrderService()
        {
            var submitOrderDto = new SubmitOrderDto();
            _orderServiceMock.Setup(x => x.SubmitOrder(submitOrderDto))
                .Returns(Result<OrderSubmittedResultDto>.Failure);
            var orderController = new OrderController(_orderServiceMock.Object);

            orderController.SubmitOrder(submitOrderDto);

            _orderServiceMock.Verify(mock => mock.SubmitOrder(submitOrderDto), Times.Once());
        }

        [Fact]
        public void SubmitOrder_FailedOrderSubmitting_ReturnsBadRequest()
        {
            var submitOrderDto = new SubmitOrderDto();
            _orderServiceMock.Setup(x => x.SubmitOrder(submitOrderDto))
                .Returns(Result<OrderSubmittedResultDto>.Failure);
            var orderController = new OrderController(_orderServiceMock.Object);

            var result = orderController.SubmitOrder(submitOrderDto);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void SubmitOrder_SuccededOrderSubmitting_ReturnsOk()
        {
            var submitOrderDto = new SubmitOrderDto();
            _orderServiceMock.Setup(x => x.SubmitOrder(submitOrderDto))
                .Returns(Result<OrderSubmittedResultDto>.Success(new OrderSubmittedResultDto()));

            var orderController = new OrderController(_orderServiceMock.Object);

            var result = orderController.SubmitOrder(submitOrderDto) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType<OrderSubmittedResultDto>();
        }
    }
}
