using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.User;

public record RefreshTokenViewModel([Required(ErrorMessage = "Please Enter Refresh Token")] Guid RefreshToken);