using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Role.Queries.GetAuthorizableRoutesQuery;

public record GetAuthorizableRoutesQueryModel() : IRequest<OperationResult<List<GetAuthorizableRouteQueryResult>>>;