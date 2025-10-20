using Adoroid.Core.Repository.Repositories;

namespace PasswordManager.Domain.Entities;

public class User : Entity<Guid>
{
    public User()
    {
        Users = new HashSet<User>();
        UserAccounts = new HashSet<UserAccount>();
        Categories = new HashSet<Category>();
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? RefreshToken { get; set; }
    public string? OtpCode { get; set; }
    public DateTime? RefreshTokenExpr { get; set; }
    public bool EmailConfirmed { get; set; }

    public ICollection<User> Users { get; set; }    
    public ICollection<UserAccount> UserAccounts { get; set; }
    public ICollection<UserNote> UserNotes { get; set; } 
    public ICollection<Category> Categories { get; set; }
