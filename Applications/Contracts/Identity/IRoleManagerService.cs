﻿using Applications.Models.Identity;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Applications.Contracts.Identity;

public interface IRoleManagerService
{
    Task<List<GetRolesDto>> GetRolesAsync();
    Task<IdentityResult> CreateRoleAsync(CreateRoleDto model);
    Task<bool> DeleteRoleAsync(int roleId);
    Task<List<ActionDescriptionDto>> GetPermissionActionsAsync();
    Task<RolePermissionDto> GetRolePermissionsAsync(int roleId);
    Task<bool> ChangeRolePermissionsAsync(EditRolePermissionsDto model);
    Task<Role> GetRoleByIdAsync(int roleId);
}