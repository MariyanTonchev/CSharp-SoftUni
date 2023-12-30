using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.App.Dto.Export;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string inputUsersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, inputUsersXml));

            //string inputProductsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, inputProductsXml));

            //string inputCategoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, inputCategoriesXml));

            //string inputCategoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProductsXml));

            //Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(GetSoldProducts(context));

            Console.WriteLine(GetCategoriesByProductsCount(context));

            //Console.WriteLine(GetUsersWithProducts(context));
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));

            using var reader = new StringReader(inputXml);
            ImportUserDTO[] importUserDTOs = (ImportUserDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            User[] users = mapper.Map<User[]>(importUserDTOs);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            using var reader = new StringReader(inputXml);
            ImportProductDTO[] importProductDTOs = (ImportProductDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            Product[] products = mapper.Map<Product[]>(importProductDTOs);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            using var reader = new StringReader(inputXml);
            ImportCategoryDTO[] importCategoryDTOs = (ImportCategoryDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            Category[] categories = mapper.Map<Category[]>(importCategoryDTOs)
                .Where(c => c.Name is not null)
                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}"; ;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesProductsDTO[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);
            ImportCategoriesProductsDTO[] importCategoriesProductsDTOs = (ImportCategoriesProductsDTO[])xmlSerializer.Deserialize(reader);

            var categoriesIds = context.Categories.Select(c => new { c.Id }).ToArray();
            var productsIds = context.Products.Select(p => new { p.Id }).ToArray();

            var mapper = GetMapper();
            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(importCategoriesProductsDTOs)
                        .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId)
                                && context.Products.Any(p => p.Id == cp.ProductId))
                        .ToArray();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ProductExportDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductExportDto()
                {
                    name = p.Name,
                    price = p.Price,
                    buyer = p.Buyer != null ? $"{p.Buyer.FirstName} {p.Buyer.LastName}" : null
                })
                .OrderBy(p => p.price)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            SellerUserDto[] users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new SellerUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold
                        .Select(ps => new SoldProductDto()
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SellerUserDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new UserCountSoldProductsDto()
            {
                count = context.Users.Where(u => u.ProductsSold.Any()).Count(),
                users = new UsersRoot()
                {
                    Users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age.ToString(),
                    SoldProducts = new ProductSoldRootDto()
                    {
                        Count = u.ProductsSold.Count,
                        Test = new ProductsRoot()
                        {
                            SoldProducts = u.ProductsSold
                            .Select(p => new SoldProductDto()
                            {
                                name = p.Name,
                                price = p.Price,
                            })
                            .OrderByDescending(p => p.price)
                            .ToArray()
                        }
                    }
                })
                .Take(10)
                .ToArray()
                }
            };

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(UserCountSoldProductsDto), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CategoryExportDto[] categories = context.Categories
                .Select(c => new CategoryExportDto()
                {
                    name = c.Name,
                    count = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.count)
                .ThenBy(c => c.totalRevenue)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryExportDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}