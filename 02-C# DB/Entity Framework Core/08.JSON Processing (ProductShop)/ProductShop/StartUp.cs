using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Globalization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new();

            //Exercise 1
            //string inputJson = File.ReadAllText("..\\..\\..\\Datasets\\users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //Exercise 2
            //string inputJson = File.ReadAllText("..\\..\\..\\Datasets\\products.json");
           // Console.WriteLine(ImportProducts(context, inputJson));

            //Exercise 3
            //string inputJson = File.ReadAllText("..\\..\\..\\Datasets\\categories.json");
            //Console.WriteLine(ImportCategories(context, inputJson));

            //Exercise 4
            //string inputJson = File.ReadAllText("..\\..\\..\\Datasets\\categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));

            //Exercise 5
            //Console.WriteLine(GetProductsInRange(context));

            //Exercise 6
            //Console.WriteLine(GetSoldProducts(context));

            //Exercise 7
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //Exercise 8
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Exercise 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Exercise 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Exercise 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            categories = categories.Where(c => c.Name != null).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Exercise 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            
            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //Exercise 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Exercise 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
                })

                .ToArray();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //Exercise 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = (c.CategoriesProducts
                        .Average(cp => cp.Product.Price)).ToString("F2", CultureInfo.InvariantCulture),
                    totalRevenue = (c.CategoriesProducts
                        .Sum(cp => cp.Product.Price)).ToString("F2", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //Exercise 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .ToArray();

            var output = new
            {
                usersCount = users.Count(),
                users = users.Select(u => new
                {
                    u.firstName,
                    u.lastName,
                    u.age,
                    soldProducts = new
                    {
                        count = u.soldProducts.Count(),
                        products = u.soldProducts
                    }
                })
            };

            string jsonOutput = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return jsonOutput;
        }
    }
}