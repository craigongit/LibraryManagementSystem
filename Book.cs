namespace LibraryManagementSystem;

internal class Book
{
    internal string Name {get; set;} = "Unknown";
    internal int Pages {get; set;} = 0;

    internal Book(string name, int pages)
    {
        Name = name;
        Pages = pages;
        Console.WriteLine($"Name: {Name}, Pages: {Pages}");
    }
}