using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Users.Queries.GetUsers.Model;

public record GetUsersQueryModel : IRequest<OperationResult<List<GetUsersQueryResponseModel>>>;