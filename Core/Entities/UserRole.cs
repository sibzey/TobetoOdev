namespace Core.Entities;

public class UserRole : Entity<int>
{
    public User? User {  get; set; }
    public  int?  UserId { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; } 
}