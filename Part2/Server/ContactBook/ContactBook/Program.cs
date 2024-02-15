var builder = WebApplication.CreateBuilder(args);

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

var contacts = new List<Contact>
{
    new Contact { Id = 1, Name = "John Smith", Address = "Main Street 1" }
};

app.MapGet("/", () =>
{
    return contacts;
});

app.Run();

class Contact
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
}