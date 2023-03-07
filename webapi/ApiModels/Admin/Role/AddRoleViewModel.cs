using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.Admin.Role
{
    public record AddRoleViewModel([Required(ErrorMessage = "Please enter role name")]
        string RoleName);
}
