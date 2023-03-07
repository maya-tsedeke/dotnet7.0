using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Order.Queries.GetAllOrders;

public record GetAllOrdersQuery() : IRequest<OperationResult<List<GetAllOrdersQueryResult>>>;