using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.Admin.Role;

public record ChangeRoleClaimsViewModel([Range(1, int.MaxValue, ErrorMessage = "Please enter role Id")] int RoleId, [Required(ErrorMessage = "Please Enter New Role Claim Values")] List<string> RoleClaimValue);