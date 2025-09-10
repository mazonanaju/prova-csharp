namespace Turistando.Models;
public class TourPoint
{
    public Guid TourID { get; set; }
    public Tour Tour { get; set; }

    public Guid PointID { get; set; }
    public Point Point { get; set; }
}