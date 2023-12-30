using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            ////Exercise 9
            //string inputJson1 = File.ReadAllText("..\\..\\..\\Datasets\\suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputJson1));

            ////Exercise 10
            //string inputJson2 = File.ReadAllText("..\\..\\..\\Datasets\\parts.json");
            //Console.WriteLine(ImportParts(context, inputJson2));

            ////Exercise 11
            //string inputJson3 = File.ReadAllText("..\\..\\..\\Datasets\\cars.json");
            //Console.WriteLine(ImportCars(context, inputJson3));

            ////Exercise 12
            //string inputJson4 = File.ReadAllText("..\\..\\..\\Datasets\\customers.json");
            //Console.WriteLine(ImportCustomers(context, inputJson4));

            ////Exercise 13
            //string inputJson5 = File.ReadAllText("..\\..\\..\\Datasets\\sales.json");
            //Console.WriteLine(ImportSales(context, inputJson5));

            ////Exercise 14
            //Console.WriteLine(GetOrderedCustomers(context));

            ////Exercise 15
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            ////Exercise 16
            //Console.WriteLine(GetLocalSuppliers(context));

            ////Exercise 17
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            ////Exercise 18
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            ////Exercise 19
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //Exercise 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Exercise 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => suppliers.Contains(p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Exercise 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var carsDto = JsonConvert.DeserializeObject<List<JsonCarDto>>(inputJson);

            int[] existingPartsId = context.Parts.Select(x => x.Id).ToArray();

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    if (existingPartsId.Contains(partId))
                    {
                        var part = new PartCar
                        {
                            CarId = car.Id,
                            PartId = partId
                        };
                        car.PartsCars.Add(part);
                    }
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Exercise 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Exercise 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Exercise 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Exercise 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make.Equals("Toyota"))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //Exercise 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //Exercise 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new 
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance,
                    },

                    parts = c.PartsCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToList();


            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //Exercise 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Join(context.Sales, c => c.Id, s => s.CustomerId, (c, s) => new { Customer = c, Sale = s })
                .Join(context.PartsCars, cs => cs.Sale.CarId, pc => pc.CarId, (cs, pc) => new { cs.Customer, cs.Sale, PartsCar = pc })
                .Join(context.Parts, csp => csp.PartsCar.PartId, p => p.Id, (csp, p) => new { csp.Customer, csp.Sale, csp.PartsCar, Part = p })
                .GroupBy(c => new { c.Customer.Id, c.Customer.Name })
                .Select(g => new
                {
                    fullName = g.Key.Name,
                    boughtCars = g.Select(c => c.Sale.CarId).Distinct().Count(),
                    spentMoney = g.Sum(c => c.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
            .Take(10)
            .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = s.Discount.ToString("F2", CultureInfo.InvariantCulture),
                price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("F2", CultureInfo.InvariantCulture),
                priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) - (s.Car.PartsCars.Sum(pc => pc.Part.Price) * s.Discount / 100))
                                .ToString("F2", CultureInfo.InvariantCulture)
            })
            .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}