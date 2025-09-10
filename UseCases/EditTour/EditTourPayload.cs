namespace Turistando.UseCases.EditTour;

public record EditTourPayload(
    Guid TourID,
    Guid PointID,
    Guid UserID
);