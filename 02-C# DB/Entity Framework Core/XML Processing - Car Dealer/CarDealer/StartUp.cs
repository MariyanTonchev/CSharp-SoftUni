using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputUsersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, inputUsersXml));

            //string inputUsersXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, inputUsersXml));

            //string inputUsersXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, inputUsersXml));

            //string inputUsersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, inputUsersXml));

            //string inputUsersXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, inputUsersXml));

            //Console.WriteLine(GetCarsWithDistance(context));

            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //Console.WriteLine(GetLocalSuppliers(context));

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Console.WriteLine(GetTotalSalesByCustomer(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);
            ImportSupplierDTO[] dto = (ImportSupplierDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(dto);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDTO[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);
            ImportPartDTO[] dto = (ImportPartDTO[])xmlSerializer.Deserialize(reader);

            var suppliersIds = context.Suppliers.Select(x => x.Id).ToArray();

            var mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(dto)
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .ToArray();

            context.AddRange(parts); 
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDTO[]), new XmlRootAttribute("Cars"));

            using StringReader stringReader = new StringReader(inputXml);
            ImportCarDTO[] importCarDTOs = (ImportCarDTO[])xmlSerializer.Deserialize(stringReader);

            var mapper = GetMapper();
            List<Car> cars = new List<Car>();

            foreach(var carDTO in importCarDTOs)
            {
                Car car = mapper.Map<Car>(carDTO);
                int[] carPartsIds = carDTO.PartsIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach(var id in carPartsIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));

            using StringReader stringReader = new StringReader(inputXml);
            ImportCustomerDTO[] importCustomerDTOs = (ImportCustomerDTO[])xmlSerializer.Deserialize(stringReader);

            var mapper = GetMapper();
            Customer[] customers = mapper.Map<Customer[]>(importCustomerDTOs);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDTO[]), new XmlRootAttribute("Sales"));

            using StringReader stringReader = new StringReader(inputXml);
            ImportSaleDTO[] importSaleDTOs = (ImportSaleDTO[])xmlSerializer.Deserialize(stringReader);

            var carsIds = context.Cars.Select(x => x.Id).ToList();

            var mapper = GetMapper();
            Sale[] sales = mapper.Map<Sale[]>(importSaleDTOs)
                .Where(s => carsIds.Contains(s.CarId))
                .ToArray();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDTO[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new ExportCarDTO
                {
                    make = c.Make,
                    model = c.Model,
                    travelledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.make)
                .ThenBy(c => c.model)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarWithAttributesDTO[] cars = context.Cars
                .Where(c => c.Make.Equals("BMW"))
                .Select(c => new ExportCarWithAttributesDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance) 
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithAttributesDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), cars, xmlSerializerNamespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupplierDTO[] suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDTO
                {
                    Id= s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDTO[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), suppliers, xmlSerializerNamespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarWithPartsDTO[] cars = context.Cars
                .Select(c => new ExportCarWithPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                    .Select(pc => new ExportPartDTO
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), cars, xmlSerializerNamespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerTotalSalesDTO[] customers = context.Customers
                .Where(c => c.Sales.Any())
                .Include(c => c.Sales)
                    .ThenInclude(s => s.Car.PartsCars)
                        .ThenInclude(pc => pc.Part)
                .AsNoTracking()
                .AsEnumerable()
                .Select(c => new ExportCustomerTotalSalesDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s =>
                        s.Car.PartsCars.Sum(pc =>
                            Math.Round(c.IsYoungDriver ? pc.Part.Price * 0.95m : pc.Part.Price, 2)
                        )
                    )
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerTotalSalesDTO[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), customers, xmlSerializerNamespaces);

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDTO[] sales = context.Sales
                .Select(s => new ExportSaleDTO
                {
                    Car = new ExportCarForSaleWithAttributesDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars
                            .Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleDTO[]), new XmlRootAttribute("sales"));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), sales, xmlSerializerNamespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}