using App.API;
using App.Application.Featured.News.GetAll.Data;
using App.Application.Featured.News.GetAll.Query;
using MediatR;
using System.Net;

public static class NewsEndpoint
{
    public static void ConfigureNewsEndpoints(this WebApplication app)
    {
        app.MapGet("/news", GetAllNews)
            .WithName("GetNews")
            .Produces<List<NewsDTO>>(200)
            .Produces(400);
    }

    public static async Task<IResult> GetAllNews(IMediator mediator, [AsParameters] GetNewsQuery newsQuery)
    {

        var getNewsResult = await mediator.Send(newsQuery);

        if (getNewsResult.IsSuccess)
        {

            return Results.Ok(getNewsResult.Value);
        }
        return Results.BadRequest(getNewsResult.Error);


    }
}
