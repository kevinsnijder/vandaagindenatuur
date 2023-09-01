using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using VandaagInDeNatuur;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Console.WriteLine("Creating memory hashset");

var path = "/app/naturecalendar.csv";
if (!File.Exists(path))
   throw new Exception("no nature calendar D:");

var reader = new StreamReader(path);
var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
   Delimiter = ";",
};
var csv = new CsvReader(reader, config);
var records = csv.GetRecords<NatureMessage>();
foreach (var record in records)
{
   NatureHashTable.messages.Add(record);
}

//NatureHashTable.messages.Add();

app.UseAuthorization();

app.MapControllers();

app.Run();
