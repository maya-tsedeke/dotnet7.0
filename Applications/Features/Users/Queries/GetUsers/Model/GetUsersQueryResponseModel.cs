﻿using Applications.Profiles;
using Domain.Entities.User;

namespace Applications.Features.Users.Queries.GetUsers.Model;

public record GetUsersQueryResponseModel : ICreateMapper<User>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
}