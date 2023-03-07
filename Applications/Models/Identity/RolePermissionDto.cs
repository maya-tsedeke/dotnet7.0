using Domain.Entities.User;

namespace Applications.Models.Identity;

public class RolePermissionDto
{
    public List<string> Keys { get; set; } = new List<string>();

    public Role Role { get; set; }

    public int RoleId { get; set; }

    public List<ActionDescriptionDto> Actions { get; set; }
}