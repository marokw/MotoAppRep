using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;

        public App(
            IRepository<Employee> employeesRepository, 
            IRepository<Car> carsRepository,
            ICarsProvider carsProvider
            )
        {
            _employeesRepository = employeesRepository;
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
        }

        public void Run()
        {
            Console.WriteLine("void Run()");


            var employees = new[]
            {
                new Employee { FirstName = "Adam" },
                new Employee { FirstName = "Piotr" },
                new Employee { FirstName = "Zuzia"}
            };

            foreach (var employee in employees)
            {
                _employeesRepository.Add(employee);
            }

            _employeesRepository.Save();

            var items = _employeesRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }


            //cars

            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                _carsRepository.Add(car);
            }

            foreach(var car in _carsProvider.FilterCars(150000))
            {
                Console.WriteLine(car);
            }

        }

        //dzięki uprzejmości Chat GPT :)
        public static List<Car> GenerateSampleCars()
        {
            return new List<Car>
            {
                new Car { Name = "Polonez", Color = "Black", StandardCost = 1059.31M, ListPrice = 1431.50M, Type = "58" },
                new Car { Name = "Fiat 126p", Color = "Red", StandardCost = 854.20M, ListPrice = 1200.75M, Type = "45" },
                new Car { Name = "Mercedes-Benz", Color = "Silver", StandardCost = 5000.50M, ListPrice = 6000.99M, Type = "Sedan" },
                new Car { Name = "Tesla Model S", Color = "White", StandardCost = 34500.00M, ListPrice = 49999.99M, Type = "Electric" },
                new Car { Name = "BMW X5", Color = "Blue", StandardCost = 27000.00M, ListPrice = 38000.50M, Type = "SUV" },
                new Car { Name = "Toyota Corolla", Color = "Grey", StandardCost = 9500.00M, ListPrice = 12500.50M, Type = null },
                new Car { Name = "Honda Civic", Color = "Black", StandardCost = 8000.75M, ListPrice = 10400.90M, Type = "Compact" },
                new Car { Name = "Ford Mustang", Color = "Yellow", StandardCost = 15000.99M, ListPrice = 22000.00M, Type = "Sport" },
                new Car { Name = "Volkswagen Golf", Color = "Green", StandardCost = 7800.65M, ListPrice = 9800.00M, Type = "Hatchback" },
                new Car { Name = "Audi A4", Color = "White", StandardCost = 22000.45M, ListPrice = 27000.55M, Type = "Sedan" },
                new Car { Name = "Porsche 911", Color = "Red", StandardCost = 60000.99M, ListPrice = 80000.75M, Type = "Sport" },
                new Car { Name = "Hyundai Elantra", Color = "Blue", StandardCost = 8000.10M, ListPrice = 10000.20M, Type = "Compact" },
                new Car { Name = "Chevrolet Camaro", Color = "Orange", StandardCost = 20000.50M, ListPrice = 25000.00M, Type = "Sport" },
                new Car { Name = "Lexus RX", Color = "White", StandardCost = 35000.75M, ListPrice = 43000.50M, Type = "SUV" },
                new Car { Name = "Mazda 3", Color = "Silver", StandardCost = 12000.00M, ListPrice = 14500.90M, Type = "Compact" },
                new Car { Name = "Jaguar XF", Color = "Black", StandardCost = 45000.99M, ListPrice = 60000.50M, Type = "Luxury" },
                new Car { Name = "Volvo XC90", Color = "Grey", StandardCost = 40000.00M, ListPrice = 52000.25M, Type = "SUV" },
                new Car { Name = "Ferrari F8", Color = "Red", StandardCost = 180000.00M, ListPrice = 250000.00M, Type = "Supercar" },
                new Car { Name = "Kia Soul", Color = "Green", StandardCost = 12000.50M, ListPrice = 15000.75M, Type = "Crossover" },
                new Car { Name = "Nissan Altima", Color = "Black", StandardCost = 13000.25M, ListPrice = 16500.99M, Type = null },
                new Car { Name = "Subaru Outback", Color = "Silver", StandardCost = 22000.00M, ListPrice = 27000.45M, Type = "SUV" },
                new Car { Name = "Dodge Charger", Color = "White", StandardCost = 27000.99M, ListPrice = 34000.50M, Type = "Sedan" },
                new Car { Name = "Lamborghini Huracan", Color = "Yellow", StandardCost = 210000.75M, ListPrice = 290000.99M, Type = "Supercar" },
                new Car { Name = "Jeep Wrangler", Color = "Green", StandardCost = 28000.99M, ListPrice = 35000.00M, Type = "Off-road" },
                new Car { Name = "Mitsubishi Lancer", Color = "Blue", StandardCost = 15000.50M, ListPrice = 19500.75M, Type = "Sedan" },
                new Car { Name = "Peugeot 3008", Color = "Black", StandardCost = 17000.99M, ListPrice = 21000.65M, Type = "SUV" },
                new Car { Name = "Alfa Romeo Giulia", Color = "Red", StandardCost = 40000.75M, ListPrice = 48000.50M, Type = "Luxury" },
                new Car { Name = "Skoda Superb", Color = "Grey", StandardCost = 25000.50M, ListPrice = 31000.00M, Type = "Sedan" },
                new Car { Name = "Renault Clio", Color = "White", StandardCost = 9000.75M, ListPrice = 11500.50M, Type = "Hatchback" },
                new Car { Name = "Citroen C3", Color = "Blue", StandardCost = 8500.50M, ListPrice = 10500.99M, Type = "Compact" }

            };
        }
    }
}
