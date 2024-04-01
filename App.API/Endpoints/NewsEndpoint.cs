using App.API;
using App.Application.Featured.News.GetAll.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

public static class NewsEndpoint
{
    public static void ConfigureNewsEndpoints(this WebApplication app)
    {
        app.MapGet("/news", GetAllNews)
            .WithName("GetNews")
            .Produces<APIResponse>(200)
            .Produces(400);
    }

    public static async Task<IResult> GetAllNews(IMediator mediator, [AsParameters] GetNewsQuery newsQuery)
    {
        var response = new APIResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

        try
        {
            var news = await mediator.Send(newsQuery);

            if (news != null)
            {
                response.Result = news;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                return Results.Ok(response);
            }

            response.ErrorMessages.Add("No news found.");
            response.StatusCode = HttpStatusCode.NotFound;
            return Results.NotFound(response);
        }
        catch (Exception ex)
        {
            response.ErrorMessages.Add(ex.Message);
            return Results.BadRequest(response);
        }
    }
}
