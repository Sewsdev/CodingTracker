using Spectre.Console;

namespace CodingTracker;

internal class UserInterface
{
    private readonly CodingSessionController _codingSessionController;

    public UserInterface(AppConfig appConfig)
    {
        _codingSessionController = new CodingSessionController(appConfig);
    }
    
    public void MainMenu()
    {
        
        while (true)
        {
            Console.Clear();
        
            AnsiConsole.MarkupLine("[yellow bold]Coding Tracker[/]\n");

            var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>()
                    .Title("What do you want to do?")
                    .AddChoices(Enum.GetValues<MenuAction>()));

            switch (menuChoice)
            {
                case MenuAction.AddSession:
                    _codingSessionController.Add();
                    break;
                case MenuAction.ViewSessions:
                    _codingSessionController.ViewAll();
                    break;
            }
        }
    }
}

enum MenuAction
{
    ViewSessions,
    AddSession
}