using Spectre.Console;
using static LibraryManagementSystem.Enums;

namespace LibraryManagementSystem;

internal class UserInterface
{
    // Create an instance of BooksController
    private BooksController booksController = new();

    internal void MainMenu()
    {
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
                    booksController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    booksController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    booksController.DeleteBook();
                    break;
            }
        }
    }
}
