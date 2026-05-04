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
            AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/] - [yellow]{book.Pages} pages[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        string? bookTitle = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        int bookPages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");


        // Check if the book alredy exist
        // Add or reject tthe book depending on the result

        if (Books.Exists(b => b.Name.Equals(bookTitle, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]Operation failed, the book is already registered![/]");
        }
        else
        {
            var newBook = new Book(bookTitle, bookPages);
            Books.Add(newBook);
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
                new SelectionPrompt<Book>()
                .Title("select the book to delete: ")
                .UseConverter(b => $"{b.Name}")
                .AddChoices(Books));

        Books.Remove(bookToDelete);
        AnsiConsole.MarkupLine("[green]The book was successfully removed![/]");
    }
}
