namespace Turistando.UseCases.GetTourDetails;

public record GetTourDetailsResponse(
    string Title,
    string Description,
    ICollection<string> Points,
    string CreatorName
);