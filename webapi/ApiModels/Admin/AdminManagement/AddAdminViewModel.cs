﻿using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.Admin.AdminManagement;

public record AddAdminViewModel(string AdminUserName, [EmailAddress(ErrorMessage = "Please Enter a valid email")] string AdminEmail, string AdminPassword, int RoleId);