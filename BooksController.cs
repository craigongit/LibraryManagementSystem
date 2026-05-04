// This class contains the logic necessary to handle
// all the operations related to the Books management

using Spectre.Console;
using static LibraryManagementSystem.MockDatabase;
namespace LibraryManagementSystem;

internal class BooksController
{
    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        AnsiConsole.MarkupLine("[yellow]Enter the name of the book![/]");

        string? bookToAdd = Console.ReadLine();

        // Check if the book alredy exist
        // Add or reject tthe book depending on the result

        if (Books.Contains(bookToAdd))
        {
            AnsiConsole.MarkupLine("[red]Operation failed, the book is already registered![/]");
        }
        else
        {
            Books.Add(bookToAdd);
            AnsiConsole.MarkupLine("[green]The book was successfully added[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        // Prompt the user to choice the book to delete
        // among those stored in the Books list

        var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("select the book to delete: ")
                .AddChoices(Books));

        Books.Remove(bookToDelete);
        AnsiConsole.MarkupLine("[green]The book was successfully removed![/]");
    }
}
