namespace concerts.Models;

public class Concert
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public DateTime Date { get; set; }
    public string Venue { get; set; }
    public decimal Price { get; set; }
}
