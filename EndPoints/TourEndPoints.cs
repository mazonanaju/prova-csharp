// using System.Security.Claims;
// using Turistando.UseCases.CreateTour;
// using Turistando.UseCases.EditTour;
// using Turistando.UseCases.GetTourDetails;
// using Microsoft.AspNetCore.Mvc;

// namespace Turistando.Endpoints;

// public static class TourEndpoints
// {
//     public static void ConfigureTourEndpoints(this WebApplication app)
//     {
//         app.MapGet("tour/{id}", async (string id, [FromServices] GetTourDetailsUseCase useCase) =>
//         {
//             var payload = new GetTourDetailsPayload(Guid.Parse(id));
//             var result = await useCase.Do(payload);
            
//             return (result.IsSuccess, result.Reason) switch
//             {
//                 (false, "Passeio não encontrado") => Results.NotFound(),
//                 (false, _) => Results.BadRequest(),
//                 (true, _) => Results.Ok(result.Data)
//             };
//         });

//         app.MapPost("tour", async (
//             [FromBody] CreateTourPayload payload,
//             HttpContext http,
//             [FromServices] CreateTourUseCase useCase
//         ) =>
//         {
//             var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
//             var userId = Guid.Parse(claim.Value);
//             var newPayload = payload with { CreatorID = userId };
            
//             var result = await useCase.Do(newPayload);
            
//             return (result.IsSuccess, result.Reason) switch
//             {
//                 (false, _) => Results.BadRequest(result.Reason),
//                 (true, _) => Results.Created()
//             };
//         }).RequireAuthorization();

//         app.MapPost("tour/{tourId}/addpoint/{pointId}", async (
//             string tourId,
//             string pointId,
//             HttpContext http,
//             [FromServices] EditTourUseCase useCase
//         ) =>
//         {
//             var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
//             var userId = Guid.Parse(claim.Value);
//             var payload = new EditTourPayload(Guid.Parse(tourId), Guid.Parse(pointId), userId);
            
//             var result = await useCase.Do(payload);

//             return (result.IsSuccess, result.Reason) switch
//             {
//                 (false, "Passeio não encontrado") => Results.NotFound(),
//                 (false, "O usuário não é o criador desse passeio") => Results.Forbid(),
//                 (false, "Ponto turístico não encontrado.") => Results.NotFound(),
//                 (false, _) => Results.BadRequest(result.Reason),
//                 (true, _) => Results.Ok()
//             };
//         }).RequireAuthorization();
//     }
// }