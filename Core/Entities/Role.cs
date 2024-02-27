namespace Core.Entities;

public class Role :Entity<int>
{
    public string RoleName { get; set; }

    public int UserRoleId { get; set; }
}