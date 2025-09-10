namespace Turistando.Models;

public class User
{
    public Guid ID { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public ICollection<Tour> Tours { get; set; }
}