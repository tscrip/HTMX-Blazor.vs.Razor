using Htmx;
using HTMX_Blazor.vs.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HTMX_Blazor.vs.Razor.Pages.Razor.Dogs;

public class DogGridModel : PageModel
{
    HttpClient httpClient;
    public List<string> dogPhotos = new List<string>();

    public DogGridModel(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task OnGet()
    {
        if(Request.IsHtmx())
        {
            ViewData["Layout"] = null;
        }
        else
        {
            ViewData["Layout"] = "~/Shared/Layout.cshtml";
        }

        await FetchDogPhoto();

        //DogPhotos.Add("https://images.dog.ceo/breeds/terrier-dandie/n02096437_179.jpg");
        //DogPhotos.Add("https://images.dog.ceo/breeds/terrier-dandie/n02096437_179.jpg");
        //DogPhotos.Add("https://images.dog.ceo/breeds/terrier-dandie/n02096437_179.jpg");

    }

    private async Task<string?> FetchDogPhoto()
    {
        var response = await httpClient.GetAsync("https://dog.ceo/api/breeds/image/random/49");
        if(response.IsSuccessStatusCode)
        {
            var result = JsonSerializer.Deserialize<DogsResult>(response.Content.ReadAsStream());
            if(result == null || result.Status != "success") return null;

            dogPhotos.AddRange(result.Message);
        }

        return null;
    }
}