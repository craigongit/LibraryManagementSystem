using Spectre.Console;

string[] menuChoices = 
[
    "View Books", 
    "Add Book", 
    "Delete Book"
];

var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .Title("Select your next Operation")
    .AddChoices(menuChoices));