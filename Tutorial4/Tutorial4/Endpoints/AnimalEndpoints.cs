namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        // GET
        app.MapGet("animals-minimalapi", () =>
        {
            return Results.Ok();
        });

        // GET - id
        app.MapGet("animals-minimalapi/{id}", (int id) =>
        {
            return Results.Ok();
        });

        // POST
        app.MapPost("animals-minimalapi", () =>
        {
            return Results.Created();
        });
    }
}