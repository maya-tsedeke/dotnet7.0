using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Order.Commands;

public record AddOrderCommand(int UserId, string OrderName) : IRequest<OperationResult<bool>>;