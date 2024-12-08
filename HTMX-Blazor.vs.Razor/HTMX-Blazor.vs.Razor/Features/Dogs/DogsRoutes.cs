using HTMX_Blazor.vs.Razor.Features.Dogs.DogGrid;
using HTMX_Blazor.vs.Razor.Features.Shared.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HTMX_Blazor.vs.Razor.Features.Dogs;

public static class DogsRoutes
{
    public static IEndpointRouteBuilder MapDogEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/blazor/dogs");

        group.MapGet("/", RazorComponentResult (HttpContext context) => {

            if(context.Request.Headers.ContainsKey("HX-Request"))
            {
                return new RazorComponentResult<DogsPage>();
            }
            else
            {
                return new RazorComponentResult<MainLayout>(new
                {
                    Body = new RenderFragment(builder =>
                    {
                        builder.OpenComponent<DogsPage>(0);
                        builder.CloseComponent();
                    })
                });
            }
        });

        group.MapGet("/doggrid", RazorComponentResult (HttpContext context) => {

            if(context.Request.Headers.ContainsKey("HX-Request"))
            {
                return new RazorComponentResult<DogGridComponent>();
            }
            else
            {
                return new RazorComponentResult<MainLayout>(new
                {
                    Body = new RenderFragment(builder =>
                    {
                        builder.OpenComponent<DogGridComponent>(0);
                        builder.CloseComponent();
                    })
                });
            }
        });

        return endpoints;
    }
}
