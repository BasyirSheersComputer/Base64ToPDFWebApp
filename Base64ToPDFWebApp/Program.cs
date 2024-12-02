var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapPost("/", async (HttpContext context) =>
{
    // Read the Base64 string from the form
    var base64String = await new StreamReader(context.Request.Body).ReadToEndAsync();

    try
    {
        byte[] bytes = Convert.FromBase64String(base64String);

        // Save the PDF file or do any further processing here

        // Send success message back to the client
        await context.Response.WriteAsync("PDF file has been successfully processed.");
    }
    catch (Exception ex)
    {
        // Send error message back to the client
        await context.Response.WriteAsync($"An error occurred: {ex.Message}");
    }
});

app.Run();
