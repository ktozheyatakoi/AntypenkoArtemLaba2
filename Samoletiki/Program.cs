using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoletiki
{

        class Airplane
        {
            public string Name { get; set; }

            public int FuelConsuption { get; set; }

            public int MaxKilomiters { get; set; }

            public int MaxWeight;

            public Airplane(string name, int maxWeight)
            {
                Name = name;
                MaxWeight = maxWeight;

            }
        }

        class HumanPlane : Airplane
        {
            public List<string> HumanNames = new List<string>();

            public HumanPlane(string name, int maxWeight)
                : base(name, maxWeight)
            {

            }

            public void AddHuman(string name)
            {
                HumanNames.Add(name);
            }
        }

        class CargoPlane : Airplane
        {
            public List<int> Cargos = new List<int>();

            public CargoPlane(string name, int maxWeight)
               : base(name, maxWeight)
            {
            }

            public void AddCargo(int cargo)
            {
                Cargos.Add(cargo);
            }
        }

        class Airport
        {
            public List<HumanPlane> humanPlanes = new List<HumanPlane>();

            public List<CargoPlane> cargoPlanes = new List<CargoPlane>();

            public List<Airplane> GetAllPlanes()
            {
                var airplanes = new List<Airplane>();

                airplanes.AddRange(humanPlanes);
                airplanes.AddRange(cargoPlanes);

                return airplanes;
            }

            public List<Airplane> GetSortedByFuelConsumtion()
            {
                return GetAllPlanes().OrderBy(x => x.FuelConsuption).ToList();
            }

            public List<Airplane> GetAirplanesInRangeByMaxKilometers(int a, int b)
            {
                return GetAllPlanes()
                    .Where(x => x.MaxKilomiters >= a)
                    .Where(x => x.MaxKilomiters <= b)
                    .ToList();
            }

            public static void WritePlanes(List<Airplane> airplanes)
            {
                foreach (var plane in airplanes)
                    Console.WriteLine(plane.Name + "  " + plane.MaxKilomiters + "km  " + plane.FuelConsuption + "fuel");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var airport = new Airport();
                airport.humanPlanes.Add(new HumanPlane("pochti bolshoi ", 400) { FuelConsuption = 4, MaxKilomiters = 4 });
                airport.humanPlanes.Add(new HumanPlane("bolshoi", 500) { FuelConsuption = 5, MaxKilomiters = 5 });

                airport.cargoPlanes.Add(new CargoPlane("maloi", 100) { FuelConsuption = 1, MaxKilomiters = 1 });
                airport.cargoPlanes.Add(new CargoPlane("pochti maloi", 200) { FuelConsuption = 2, MaxKilomiters = 2 });
                airport.cargoPlanes.Add(new CargoPlane("seredinochka", 300) { FuelConsuption = 3, MaxKilomiters = 3 });



                Airport.WritePlanes(airport.GetAllPlanes());
                Console.WriteLine();

                Airport.WritePlanes(airport.GetSortedByFuelConsumtion());
                Console.WriteLine();


                Airport.WritePlanes(airport.GetAirplanesInRangeByMaxKilometers(2, 4));
                Console.WriteLine();

                Console.ReadKey();
            }
        }
    }

