using LibraryManagementSystem;
using Spectre.Console;

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("Select your next operation")
            .AddChoices(Enum.GetValues<MenuOption>()));

    switch (choice)
    {
        case MenuOption.ViewBooks:
            BooksController.ViewBooks();
            break;
        case MenuOption.AddBook:
            BooksController.AddBook();
            break;
        case MenuOption.DeleteBook:
            BooksController.DeleteBook();
            break;
    }
}

enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook
}