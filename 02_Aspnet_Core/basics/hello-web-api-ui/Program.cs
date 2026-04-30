var builder = WebApplication.CreateBuilder(args); // Bize web application üzerinden bir Builder verir. 

// Add services to the container.

builder.Services.AddControllers(); // 1. servis kaydý
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // 2. servis kaydý
builder.Services.AddSwaggerGen( ); // 3. servis kaydý

var app = builder.Build();
/* 
 * builder'a Build fonk. üzerinden çalýþtýrdýðýmýzda bize bir web application döner.
 * Bu webapp (app deðiþkeni) kullanabiliriz
 */

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); // uygulamanýn koþmasýný saðlar
