using Applications.Models.Common;
using Applications.Models.Jwt;
using Mediator;

namespace Applications.Features.Users.Queries.GenerateUserToken.Model;

public record GenerateUserTokenQuery(string UserKey, string Code) : IRequest<OperationResult<AccessToken>>;