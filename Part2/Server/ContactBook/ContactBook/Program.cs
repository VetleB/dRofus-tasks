using ContactBook;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                          .WithOrigins("http://localhost:4200",
                                       "https://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

var contacts = new ContactDatabase();

app.MapGet("/contacts", () =>
{
    return Results.Ok(contacts.GetContacts());
});

app.MapGet("/contacts/{id}", (int id) =>
{
    var contact = contacts.GetContact(id);
    if (contact == null)
        return Results.NotFound("Contact not found");

    return Results.Ok(contact);
});

app.Run();