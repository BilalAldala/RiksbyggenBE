using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

string connStr = config.GetConnectionString("DatabaseConnection") ?? throw new InvalidOperationException("Connection string not found.");

using var connection = new SqlConnection(connStr);
connection.Open();

Console.WriteLine("Connected to Database");