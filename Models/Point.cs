namespace Turistando.Models;

public class Point
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    
    public ICollection<TourPoint> TourPoints { get; set; }
}