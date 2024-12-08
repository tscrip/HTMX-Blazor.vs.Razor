## Purpose of this Repo
I have been very interested in the idea of using Blazor Components with a lightweight frontend like HTMX. After going to the process of creating a Minimal API backend to host the routes, I though about comparing that against a traditional Razor Pages site.

## Discoveries
1. Blazor is component based where Razor Pages is Page based. As a result, Blazor tends to feel much more modern when working with it. Additionally, it is extremely easy to "ad-hoc" render components on other pages rather than having to duplicate code with the traditional Razor Pages approach.
2. Blazor with Minimal APIs feels like a great stack that can "get out of your way" compared to Razor Pages. Razor Pages feels like you are having to go against how it traditionally works to get HTMX working. (Look at how we have to do that Layout piece if they send the HX-Request header)
3. While the HTMX.TagHelpers seem like a very great addition, my concern is that it is not valid HTML. If you had to copy that out of the component and into your browser to test, you would have to update several things.

**This is not the final project nor am I done with testing. This is a living document to catelog my journey to replacing Blazor "interactive" with HTMX. Stay tuned and feel free to submit PRs if you have feedback.**
