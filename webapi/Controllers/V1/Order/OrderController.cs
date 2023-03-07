using Applications.Features.Order.Commands;
using Applications.Features.Order.Queries.GetUserOrders;
using webapi.ApiModels.Order;
using webapi.Base2Controller;
using webapi.WebExtensions;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.V1.Order;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/User")]
[Authorize]
public class OrderController : BaseController
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("CreateNewOrder")]
    public async Task<IActionResult> CreateNewOrder(CreateOrderModel model)
    {
        var command = await _sender.Send(new AddOrderCommand(UserId, model.OrderName));

        return base.OperationResult(command);
    }

    [HttpGet("GetUserOrders")]
    public async Task<IActionResult> GetUserOrders()
    {
        var query = await _sender.Send(new GetUserOrdersQueryModel(UserId));

        return base.OperationResult(query);
    }
}