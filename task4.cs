using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Book
    {
        public string Title;
        public string Author;
        public int PublicationYear;
        public double Price;
        public int QuantityInStock;

        public Book(string title, string author, int publicationYear, double price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public string GetTitle()
        {
            return $"Title: {Title}";
        }

        public string GetAuthor()
        {
            return $"Author: {Author}";
        }

        public string GetPublicationYear()
        {
            return $"Publication Year: {PublicationYear}";
        }

        public string GetPrice()
        {
            return $"Price: ${Price:F2}";
        }

        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies <= QuantityInStock)
            {
                QuantityInStock -= numberOfCopies;
                Console.WriteLine($"{numberOfCopies} copies of '{Title}' sold successfully.");
            }
            else
            {
                Console.WriteLine($"Error: Not enough copies of '{Title}' in stock.");
            }
        }

        public void Restock(int additionalCopies)
        {
            QuantityInStock += additionalCopies;
            Console.WriteLine($"{additionalCopies} copies of '{Title}' added to the stock.");
        }

        public string BookDetails()
        {
            return $"Book Details:\n{GetTitle()}\n{GetAuthor()}\n{GetPublicationYear()}\n{GetPrice()}\nQuantity in Stock: {QuantityInStock}";
        }
    }

    class Program
    {
        static void Main()
        {
            List<Book> bookList = new List<Book>();
            int option = 0;
            while (option!=7)
            {
                Console.Clear();
                option = Display_menu();
                if(option==1)
                {
                    Console.Clear();
                    Console.Write("Enter the title of the book: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter the author of the book: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter the publication year of the book: ");
                    int publicationYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the price of the book: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter the quantity in stock: ");
                    int quantityInStock = int.Parse(Console.ReadLine());

                    Book newBook = new Book(title, author, publicationYear, price, quantityInStock);
                    bookList.Add(newBook);
                    Console.WriteLine($"Book '{title}' added successfully.");
                }
            if(option==2)
                {
                    Console.Clear();
                    foreach (Book book in bookList)
                    {
                        Console.WriteLine(book.BookDetails());
                    }
                }
            if(option==3)
                {
                    Console.Clear();
                    Console.Write("Enter the title of the book: ");
                    string searchTitle = Console.ReadLine();
                    bool found = false;
                    foreach (Book book in bookList)
                    {
                        if (book.Title == searchTitle)
                        {
                            Console.WriteLine(book.GetAuthor());
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"Book with title '{searchTitle}' not found.");
                    }
                }
            if(option==4)
                {
                    Console.Clear();
                    Console.Write("Enter the title of the book: ");
                    string sellTitle = Console.ReadLine();
                    bool found = false;
                    foreach (Book book in bookList)
                    {
                        if (book.Title == sellTitle)
                        {
                            Console.Write("Enter the number of copies to sell: ");
                            int sellCopies = int.Parse(Console.ReadLine());
                            book.SellCopies(sellCopies);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"Book with title '{sellTitle}' not found.");
                    }
                }
            if(option==5)
                {
                    Console.Clear();
                    Console.Write("Enter the title of the book: ");
                    string restockTitle = Console.ReadLine();
                    bool found = false;
                    foreach (Book book in bookList)
                    {
                        if (book.Title == restockTitle)
                        {
                            Console.Write("Enter the number of copies to restock: ");
                            int restockCopies = int.Parse(Console.ReadLine());
                            book.Restock(restockCopies);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"Book with title '{restockTitle}' not found.");
                    }
                }
            if(option==6)

                {
                    Console.Clear();
                    Console.WriteLine($"Number of books in the list: {bookList.Count}");
                }
            if(option==7)
                {
                    Console.Clear();
                    Console.WriteLine("Exiting the program. Goodbye!");
                }
                Console.WriteLine("Press any key to Continue!");
                Console.ReadKey();
            }
        }
        static int Display_menu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All the Books information");
            Console.WriteLine("3. Get the Author details of a specific book");
            Console.WriteLine("4. Sell Copies of a Specific Book");
            Console.WriteLine("5. Restock a Specific Book");
            Console.WriteLine("6. See the count of the Books present in your bookList");
            Console.WriteLine("7. Exit");
        again:
            Console.Write("Enter your choice (1-7): ");
            int choice = int.Parse(Console.ReadLine());
            if(choice<1||choice>7)
            {
                Console.WriteLine("You have Entered an invalid option:(");
                Console.ReadKey();
                goto again;
            }
            return choice;
        }
    }


}
