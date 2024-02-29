using Lixil.Snow.BizLogic;
using Microsoft.AspNetCore.Razor.TagHelpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


//ログ出力
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddLogging(logBuild =>
{
    logBuild.AddEventLog();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
PostgerSetting.Configure(builder.Configuration);
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=P130101}/{action=GetXXX}/{saibanSyurui?}");

//app.Run();
var port = Environment.GetEnvironmentVariable("PORT");
if (port == null)
{
    // デバッグ実行用
    app.Run();
}
else
{
    // Cloud Run実行用
    app.Run($"http://0.0.0.0:{port}");
}

//// Cloud Run実行用
//app.MapGet("/", () => $"Hello {Environment.GetEnvironmentVariable("TARGET") ?? "World"}!"); //<-追加
//app.Run($"http://0.0.0.0:{port}");}

