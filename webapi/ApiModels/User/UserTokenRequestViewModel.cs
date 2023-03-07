using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.User;

public class UserTokenRequestViewModel
{
    [Phone]
    [Required]
    public string UserPhoneNumber { get; set; }
}