namespace Library.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Isbn { get; set; } = null!;
    public DateTime PublishDate { get; set; }
    
    // Navigation
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}