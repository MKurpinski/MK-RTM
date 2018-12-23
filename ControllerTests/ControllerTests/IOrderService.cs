using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerTests
{
    public interface IOrderService
    {
        Result<OrderSubmittedResultDto> SubmitOrder(SubmitOrderDto orderDto);
    }
}
