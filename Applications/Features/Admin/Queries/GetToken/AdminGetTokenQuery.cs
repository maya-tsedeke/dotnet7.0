using Applications.Models.Common;
using Applications.Models.Jwt;
using Mediator;

namespace Applications.Features.Admin.Queries.GetToken;

public record AdminGetTokenQuery(string UserName, string Password) : IRequest<OperationResult<AccessToken>>;