﻿namespace Applications.Features.Role.Queries.GetAuthorizableRoutesQuery;

public record GetAuthorizableRouteQueryResult(string RouteKey, string AreaName, string ControllerName, string ActionName, string ControllerDescription);