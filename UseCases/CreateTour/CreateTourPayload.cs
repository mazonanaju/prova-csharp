namespace Turistando.UseCases.CreateTour;

public record CreateTourPayload(
    string Title,
    string Description,
    Guid CreatorID
);