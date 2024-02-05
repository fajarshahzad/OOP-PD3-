using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class MUser
{
    public string Username;
    public string Password;
    public string Role;

    public MUser(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public static List<MUser> LoadUsersFromFile(string filePath)
    {
        List<MUser> users = new List<MUser>();
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string username = parts[0];
                    string password = parts[1];
                    string role = parts[2];

                    MUser user = new MUser(username, password, role);
                    users.Add(user);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading users file: {ex.Message}");
        }

        return users;
    }

    public static void SignUp(List<MUser> users)
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        if (users.Any(user => user.Username == username))
        {
            Console.WriteLine("Username already exists. Please choose a different one.");
            return;
        }

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        Console.Write("Enter Role: ");
        string role = Console.ReadLine();

        MUser newUser = new MUser(username, password, role);
        users.Add(newUser);

        Console.WriteLine("Sign up successful!");
    }

    public static MUser SignIn(List<MUser> users)
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
    public static void SaveUsersToFile(List<MUser> users, string filePath)
    {
        try
        {
            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (MUser user in users)
                {
                    file.WriteLine($"{user.Username},{user.Password},{user.Role}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing products file: {ex.Message}");
        }
    }
}

class Product
{
    public string ProductName;
    public string ProductColor;
    public int ProductStock;
    public int ProductPrice;
    public string Warranty;

    public Product(string name, string color, int stock, int price, string warranty)
    {
        ProductName = name;
        ProductColor = color;
        ProductStock = stock;
        ProductPrice = price;
        Warranty = warranty;
    }

    public static List<Product> LoadProductsFromFile(string productFilePath)
    {
        List<Product> products = new List<Product>();
        try
        {
            string[] lines = File.ReadAllLines(productFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    string name = parts[0];
                    string color = parts[1];
                    int stock = int.Parse(parts[2]);
                    int price = int.Parse(parts[3]);
                    string warranty = parts[4];

                    Product product = new Product(name, color, stock, price, warranty);
                    products.Add(product);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading products file: {ex.Message}");
        }

        return products;
    }

    public static void SaveProductsToFile(List<Product> products, string productFilePath)
    {
        try
        {
            using (StreamWriter file = new StreamWriter(productFilePath))
            {
                foreach (Product product in products)
                {
                    file.WriteLine($"{product.ProductName},{product.ProductColor},{product.ProductStock},{product.ProductPrice},{product.Warranty}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing products file: {ex.Message}");
        }
    }
}

class Admin
{
    public List<Product> Products;

    public Admin(List<Product> products)// constructor that make list of products
    {
        Products = products;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void DisplayProducts()
    {
        Console.WriteLine($"Name\t\t\tColor\t\t\tPrice\t\t\tStock\t\t\tWarranty");
        foreach (Product product in Products)
        {
            Console.WriteLine($"{product.ProductName}\t\t\t{product.ProductColor}\t\t\t{product.ProductPrice}\t\t\t{product.ProductStock}\t\t\t{product.Warranty}");
        }
    }

    public void UpdateProduct(int productIndex, string name, string color, int stock, int price, string warranty)
    {
        if (productIndex >= 0 && productIndex < Products.Count)
        {
            Product product = Products[productIndex];
            product.ProductName = name;
            product.ProductColor = color;
            product.ProductStock = stock;
            product.ProductPrice = price;
            product.Warranty = warranty;
            Console.WriteLine("Product Updated Successfully :)");
        }
        else
        {
            Console.WriteLine("Index is not accessible :(");
        }
    }

    public void RemoveProduct(int indexToRemove)
    {
        if (indexToRemove >= 0 && indexToRemove < Products.Count)
        {
            Products.RemoveAt(indexToRemove);
            Console.WriteLine("Product Removed Successfully :)");
        }
        else
        {
            Console.WriteLine("Product not found :(");
        }
    }
}

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\Mr Saim\\source\\repos\\task5(app)\\task5(app)\\users.txt";
        string productFilePath = "C:\\Users\\Mr Saim\\source\\repos\\task5(app)\\task5(app)\\Products.txt";

        List<MUser> users = MUser.LoadUsersFromFile(filePath);
        List<Product> products = Product.LoadProductsFromFile(productFilePath);
        Admin admin = new Admin(products);

        int option = 0;
        while (option != 3)
        {
            Console.Clear();
            option = DisplayMenu();
            if (option == 1)
            {
                Console.Clear();
                StoreName();
                MUser.SignUp(users);
            }
            if (option == 2)
            {
                Console.Clear();
                StoreName();
                MUser signedInUser = MUser.SignIn(users);
                if (signedInUser != null && (signedInUser.Role.ToLower() == "admin"))
                {
                    AdminInterface(admin);
                }
            }
            if (option == 3)
            {
                Console.Clear();
                StoreName();
                Console.WriteLine("Exiting the program. Goodbye!");
                MUser.SaveUsersToFile(users, filePath);
                Product.SaveProductsToFile(products, productFilePath);
            }
            Console.ReadKey();
        }
    }

    static int DisplayMenu()
    {
        StoreName();
        Console.WriteLine("1. Sign Up>>>>>>>");
        Console.WriteLine("2. Sign In>>>>>>>");
        Console.WriteLine("3. Exit>>>>>>>>>>");
    again:
        Console.Write("Enter your choice (1-3): ");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid Option:(");
            goto again;
        }
        return choice;
    }
    static void AdminInterface(Admin admins)
            {
              int option = 0;
              while(option!=5)
                {
                    Console.Clear();
                    StoreName();
                    option = AdminOption();
                    if(option==1)
                {
                    Console.Clear();
                    StoreName();
                    Console.WriteLine("Enter the name of the Product: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the color of the Product: ");
                    string color = Console.ReadLine();
                again:
                    Console.WriteLine("Enter the stock of the Product: ");
                    int stock = int.Parse(Console.ReadLine());
                    if(stock<=0)
                    {
                        Console.WriteLine("Invalid Stock:(");
                        goto again;
                    }
                again1:
                    Console.WriteLine("Enter the price of the Product: ");
                    int price = int.Parse(Console.ReadLine());
                    if(price<=0)
                    {
                        Console.WriteLine("Invalid Price:(");
                        goto again1;
                    }
                    Console.WriteLine("Enter the warranty of the Product: ");
                    string warranty = Console.ReadLine();
                    Product newProduct = new Product(name, color, stock, price, warranty);
                    admins.AddProduct(newProduct);
              }
                if(option==2)
                {
                    Console.Clear();
                    StoreName();
                    admins.DisplayProducts();
                }
                if(option==3)
                {
                    Console.Clear();
                    StoreName();
                    admins.DisplayProducts();
                    Console.WriteLine("Enter the index of the Product to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateIndex))
                    {
                        Console.WriteLine("Enter the name of the Product: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the color of the Product: ");
                        string color = Console.ReadLine();
                    again:
                        Console.WriteLine("Enter the stock of the Product: ");
                        int stock = int.Parse(Console.ReadLine());
                        if (stock <= 0)
                        {
                            Console.WriteLine("Invalid Stock:(");
                            goto again;
                        }
                    again1:
                        Console.WriteLine("Enter the price of the Product: ");
                        int price = int.Parse(Console.ReadLine());
                        if (price <= 0)
                        {
                            Console.WriteLine("Invalid Price:(");
                            goto again1;
                        }
                        Console.WriteLine("Enter the warranty of the Product: ");
                        string warranty = Console.ReadLine();
                        admins.UpdateProduct(updateIndex - 1, name, color, stock, price, warranty);
                    }
                    else
                    {
                        Console.WriteLine("Index not accessible:(");
                    }
                }
                if(option==4)
                {
                    Console.Clear();
                    StoreName();
                    admins.DisplayProducts();
                    Console.WriteLine("Enter the index of the product to remove: ");
                    int Index_to_remove = int.Parse(Console.ReadLine());
                    admins.RemoveProduct(Index_to_remove-1);
                }
                if(option==5)
                {
                    Console.Clear();
                    StoreName();
                    Thanks();
                    break;
                }
                Console.ReadKey();
            }
        }
        static int AdminOption()
        {
            AdminMenu();
            Console.WriteLine("1.ADD PRODUCTS>>>>>>>");
            Console.WriteLine("2.VIEW PRODUCTS>>>>>>");
            Console.WriteLine("3.UPDATE PRODUCT>>>>>");
            Console.WriteLine("4.REMOVE PRODUCT>>>>>");
            Console.WriteLine("5.EXIT>>>>>>>>>>>>>>>");
        again:
            Console.WriteLine("Enter the option(1-5)");
            int option = int.Parse(Console.ReadLine());
            if(option<1||option>5)
            {
                Console.WriteLine("Invalid Option!! Try Again");
                goto again;
            }
            return option;
        }
        static void AdminMenu()
        {
            Console.WriteLine("  ___      _           _        ___  ___                  \r\n / _ \\    | |         (_)       |  \\/  |                  \r\n/ /_\\ \\ __| |_ __ ___  _ _ __   | .  . | ___ _ __  _   _  \r\n|  _  |/ _` | '_ ` _ \\| | '_ \\  | |\\/| |/ _ \\ '_ \\| | | | \r\n| | | | (_| | | | | | | | | | | | |  | |  __/ | | | |_| | \r\n\\_| |_/\\__,_|_| |_| |_|_|_| |_| \\_|  |_/\\___|_| |_|\\__,_| \r\n                                                          \r\n                                                          ");
        }
        static void StoreName()
        {
            Console.WriteLine(" _____                 _            _   _           _   \r\n/  ___|               (_)          | \\ | |         | |  \r\n\\ `--.  ___ _ ____   ___  ___ ___  |  \\| | ___  ___| |_ \r\n `--. \\/ _ \\ '__\\ \\ / / |/ __/ _ \\ | . ` |/ _ \\/ __| __|\r\n/\\__/ /  __/ |   \\ V /| | (_|  __/ | |\\  |  __/\\__ \\ |_ \r\n\\____/ \\___|_|    \\_/ |_|\\___\\___| \\_| \\_/\\___||___/\\__|\r\n                                                        \r\n                                                        ");
        }
    static void Thanks()
    {
        Console.WriteLine(" _____ _                 _         ______           _   _ _     _ _   _             \r\n|_   _| |               | |        |  ___|         | | | (_)   (_) | (_)            \r\n  | | | |__   __ _ _ __ | | _____  | |_ ___  _ __  | | | |_ ___ _| |_ _ _ __   __ _ \r\n  | | | '_ \\ / _` | '_ \\| |/ / __| |  _/ _ \\| '__| | | | | / __| | __| | '_ \\ / _` |\r\n  | | | | | | (_| | | | |   <\\__ \\ | || (_) | |    \\ \\_/ / \\__ \\ | |_| | | | | (_| |\r\n  \\_/ |_| |_|\\__,_|_| |_|_|\\_\\___/ \\_| \\___/|_|     \\___/|_|___/_|\\__|_|_| |_|\\__, |\r\n                                                                               __/ |\r\n                                                                              |___/ ");
    }
    }
