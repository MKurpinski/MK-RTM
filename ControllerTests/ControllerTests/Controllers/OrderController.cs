using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerTests.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController: Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult SubmitOrder(SubmitOrderDto orderDto)
        {
            var result = _orderService.SubmitOrder(orderDto);
            if (!result.Succeded)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}
