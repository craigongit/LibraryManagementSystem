using Spectre.Console;

var books = new List<string>()
    {
        "The Great Gatsby",
        "To Kill a Mockingbird",
        "1984",
        "Pride and Prejudice",
        "The Catcher in the Rye",
        "The Hobbit",
        "Moby-Dick",
        "War and Peace",
        "The Odyssey",
        "The Lord of the Rings",
        "Jane Eyre",
        "Animal Farm",
        "Brave New World",
        "The Chronicles of Narnia",
        "The Diary of a Young Girl",
        "The Alchemist",
        "Wuthering Heights",
        "Fahrenheit 451",
        "Catch-22",
        "The Hitchhiker's Guide to the Galaxy"
    };

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
            ViewBooks();
            break;
        case MenuOption.AddBook:
            AddBook();
            break;
        case MenuOption.DeleteBook:
            DeleteBook();
            break;
    }
}

void ViewBooks()
{
    AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

    foreach (var book in books)
    {
        AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
    }

    AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
    Console.ReadKey();
}

void AddBook()
{
    AnsiConsole.MarkupLine("[yellow]Enter the name of the book![/]");

    string? bookToAdd = Console.ReadLine();

    // Check if the book alredy exist
    // Add or reject tthe book depending on the result

    if (books.Contains(bookToAdd))
    {
        AnsiConsole.MarkupLine("[red]Operation failed, the book is already registered![/]");
    }
    else
    {
        books.Add(bookToAdd);
        AnsiConsole.MarkupLine("[green]The book was successfully added[/]");
    }

    AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
    Console.ReadKey();
}

void DeleteBook()
{
    // Prompt the user to choice the book to delete
    // among those stored in the books list

    var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("select the book to delete: ")
            .AddChoices(books));

    books.Remove(bookToDelete);
    AnsiConsole.MarkupLine("[green]The book was successfully removed![/]");
}

enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook
}