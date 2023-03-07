using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Role.Queries.GetAllRolesQuery;

public record GetAllRolesQueryModel() : IRequest<OperationResult<List<GetAllRolesQueryResult>>>;