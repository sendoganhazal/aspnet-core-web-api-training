var builder = WebApplication.CreateBuilder(args);

// Services (Containers)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//app.MapGet ( "/", ( ) => "Hello World!" ); // anasayfada "hello world!" yazacak
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
