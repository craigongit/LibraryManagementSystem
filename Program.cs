using Spectre.Console;

var menuChoices = new List<string>()
{
    "View Books", 
    "Add Book", 
    "Delete Book"
};

var books = new List<string>()
{
    "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
};

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select your next Operation")
            .AddChoices(menuChoices));  

    switch (choice)
    {
        case "View Books":

            AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

            foreach (var book in books)
            {
                AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
            }

            AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
            Console.ReadKey();

            break;
        case "Add Book":

            AnsiConsole.MarkupLine("[yellow]Enter the name of the book![/]");

            string? bookToAdd = Console.ReadLine();

            // Check if the book alredy exist
            // Add or reject tthe book depending on the result

            if (books.Contains(bookToAdd))
                AnsiConsole.MarkupLine("[red]Operation failed, the book is already registered![/]");
            else
            {
                books.Add(bookToAdd);
                AnsiConsole.MarkupLine("[green]The book was successfully added[/]");
            }

            AnsiConsole.MarkupLine("[yellow]Press Any key to Continue[/]");
            Console.ReadKey();

            break;
        case "Delete Book":
            break;
    } 
}