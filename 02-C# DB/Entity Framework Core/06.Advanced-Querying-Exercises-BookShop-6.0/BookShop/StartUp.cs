namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //--Exercise 2--
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, input));

            //--Exercise 3--
            //Console.WriteLine(GetGoldenBooks(db));

            //--Exercise 4--
            //Console.WriteLine(GetBooksByPrice(db));

            //--Exercise 5--
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //--Exercise 6--
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            //--Exercise 7--
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //--Exercise 8--
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //--Exercise 9--
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //--Exercise 10--
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            //--Exercise 11--
            //int lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck));

            //--Exercise 12--
            //Console.WriteLine(CountCopiesByAuthor(db));

            //--Exercise 13--
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //--Exercise 14--
            //Console.WriteLine(GetMostRecentBooks(db));

            //--Exercise 15--
            IncreasePrices(db);

            //--Exercise 16--
            Console.WriteLine(RemoveBooks(db));
        }

        //--Exercise 2--
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                return $"{command} is not a valid type";
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString();
        }

        //--Exercise 3--
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        //--Exercise 4--
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:F2}"));
        }

        //--Exercise 5--
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        //--Exercise 6--
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input));

            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context.Books
                        .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                        .OrderBy(b => b.Title)
                        .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        //--Exercise 7--
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
        }

        //--Exercise 8--
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }

        //--Exercise 9--
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        //--Exercise 10--
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorFullName})"));
        }

        //--Exercise 11--
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        //--Exercise 12--
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    TotalBooks = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBooks).ToList();

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.AuthorName} - {a.TotalBooks}"));
        }

        //--Exercise 13--
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryTotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.CategoryTotalProfit)
                .ToList();

            return string.Join(Environment.NewLine, categories.Select(c => $"{c.CategoryName} ${c.CategoryTotalProfit:F2}"));
        }

        //--Exercise 14--
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach(var categoryBook in category.CategoryBooks)
                {
                    sb.AppendLine($"{categoryBook.Title} ({categoryBook.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString();
        }

        //--Exercise 15--
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach(var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //--Exercise 15--
        public static int RemoveBooks(BookShopContext context)
        {
            context.ChangeTracker.Clear();

            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);

            return context.SaveChanges();
        }
    }
}


