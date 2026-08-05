using CodingTracker;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var appConfig = new AppConfig(configuration);

var databaseInitializer = new DatabaseInitializer(appConfig.DbConnectionString);
databaseInitializer.Initialize();

var userInterface = new UserInterface(appConfig);
userInterface.MainMenu();