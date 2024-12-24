namespace Library.Domain.Entities;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    // navigation
    public Book Book { get; set; } = null!;
    public User User { get; set; } = null!;
}