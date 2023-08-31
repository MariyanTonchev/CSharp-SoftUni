using System;

namespace _06.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cargos = int.Parse(Console.ReadLine());

            int cargoTransportedWithBus = 0;
            int cargoTransportedWithTruck = 0;
            int cargoTransportedWithTrain = 0;



            for(int i = 0; i < cargos; i++)
            {
                int cargoWeight = int.Parse(Console.ReadLine());

                if(cargoWeight <= 3)
                {
                    cargoTransportedWithBus += cargoWeight;
                }
                else if(cargoWeight >= 4 && cargoWeight <= 11) 
                {
                    cargoTransportedWithTruck += cargoWeight;
                }
                else if(cargoWeight >= 12)
                {
                    cargoTransportedWithTrain += cargoWeight;
                }
            }

            int sumCargoWeight = cargoTransportedWithBus + cargoTransportedWithTrain + cargoTransportedWithTruck;
            double averageTransportPrice = (double)(cargoTransportedWithBus * 200 + cargoTransportedWithTruck * 175 + cargoTransportedWithTrain * 120) / sumCargoWeight;

            double pCargoBus = (cargoTransportedWithBus * 1.0 / sumCargoWeight) * 100;
            double pCargoTruck = (cargoTransportedWithTruck * 1.0 / sumCargoWeight) * 100;
            double pCargoTrain = (cargoTransportedWithTrain * 1.0 / sumCargoWeight) * 100;

            Console.WriteLine($"{averageTransportPrice:F2}");
            Console.WriteLine($"{pCargoBus:F2}%");
            Console.WriteLine($"{pCargoTruck:F2}%");
            Console.WriteLine($"{pCargoTrain:F2}%");
        }
    }
}