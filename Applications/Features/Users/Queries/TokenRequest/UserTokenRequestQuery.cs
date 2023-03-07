using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Users.Queries.TokenRequest;

public record UserTokenRequestQuery(string UserPhoneNumber) : IRequest<OperationResult<UserTokenRequestQueryResult>>;