namespace Library.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    
    // navigation
    public ICollection<Loan> Loans { get; set; }= new List<Loan>();
}