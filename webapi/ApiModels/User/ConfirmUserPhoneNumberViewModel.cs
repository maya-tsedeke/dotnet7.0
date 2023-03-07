using Microsoft.Build.Framework;

namespace webapi.ApiModels.User;

public class ConfirmUserPhoneNumberViewModel
{
    [Required]
    public string UserKey { get; set; }

    [Required]
    public string Code { get; set; }
}