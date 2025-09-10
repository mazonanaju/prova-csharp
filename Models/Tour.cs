namespace Turistando.Models;

public class Tour
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatorID { get; set; }

    public User Creator { get; set; }
    public ICollection<TourPoint> TourPoints { get; set; } = new List<TourPoint>();
}