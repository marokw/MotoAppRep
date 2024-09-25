using System;
using System.Drawing;
using System.Text;

namespace MotoApp.DataProviders;

public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carRepository;

    public CarsProvider(IRepository<Car> carsRepository)
    {
        _carRepository = carsRepository;
    }

    public List<string> GetUniqueCarColors()
    {
        var cars = _carRepository.GetAll();
        var colors = cars.Select(x => x.Color).Distinct().ToList();
        return colors;
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        var cars = _carRepository.GetAll();
        return cars.Select(x => x.ListPrice).Min();
    }

    public List<Car> GetSpecificColumns()
    {
        var cars = _carRepository.GetAll();
        var list = cars.Select(car => new Car
        {
            Id = car.Id,
            Name = car.Name,
            Type = car.Type
        }
        ).ToList();

        return list;
    }


    public string AnonymousClass()
    {
        var cars = _carRepository.GetAll();

        var list = cars.Select(car => new
        {
            Identifier = car.Id,
            ProductName = car.Name,
            ProductType = car.Type
        }
        );

        StringBuilder sb = new(2048);
        foreach (var car in list)
        {
            sb.AppendLine($"Product ID: {car.Identifier}");
            sb.AppendLine($"Product Name: {car.Identifier}");
            sb.AppendLine($"Product Type: {car.Identifier}");
        }
        return sb.ToString();
    }

    public List<Car> OrderByName()
    {
        var cars = _carRepository.GetAll();
        return cars.OrderBy(x => x.Name).ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        var cars = _carRepository.GetAll();
        return cars.OrderByDescending(x => x.Name).ToList();
    }

    public List<Car> OrderByColorAndName()
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Color).
            ThenBy(x => x.Name)
            .ToList();
    }

    public List<Car> OrderByColorAndNameDesc()
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderByDescending(x => x.Color).
            ThenByDescending(x => x.Name)
            .ToList();
    }

    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }

    public List<Car> WhereColorIs(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.ByColor(color).ToList();
    }

    public List<Car> WhereCostIsGreaterThan(decimal minPrice)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(x => x.ListPrice > minPrice).ToList();
    }

    public Car FirstByColor(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.First(x => x.Color == color);
    }

    public Car? FirstOrDefaultByColor(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.FirstOrDefault(x => x.Color == color);
    }

    public Car FirstOrDefaultByColorWitchDefault(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.FirstOrDefault(x => x.Color == color, new Car { Id = -1, Name = "NOT FOUND"});
    }

    public Car LastByColor(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.Last(x => x.Color == color);
    }

    public Car SingleById(int id)
    {
        var cars = _carRepository.GetAll();
        return cars.Single(x => x.Id == id);
    }
    public Car? SingleOrDefaultById(int id)
    {
        var cars = _carRepository.GetAll();
        return cars.SingleOrDefault(x => x.Id == id);
    }

    public List<Car> TakeCars(int howMany)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Name)
            .Take(howMany)
            .ToList();
    }

    public List<Car> TakeCars(Range range)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Name)
            .Take(range)
            .ToList();
    }

    public List<Car> TakeCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Name)
            .TakeWhile(x=>x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<Car> SkipCars(int howMany)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Name)
            .Skip(howMany)
            .ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(x => x.Name)
            .SkipWhile(x => x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<string> DistinctAllColors()
    {
        var cars = _carRepository.GetAll();
        return cars
            .Select(x=>x.Color)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<Car> DistinctByColors()
    {
        var cars = _carRepository.GetAll();
        return cars
            .DistinctBy(x => x.Color)
            .OrderBy(c => c.Color)
            .ToList();
    }

    public List<Car[]> ChunkCars(int size)
    {
        var cars = _carRepository.GetAll();
        return cars.Chunk(size).ToList();
    }
}

/*
    public class CarsProviderBasic : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProviderBasic(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<Car> WhereCostIsGreaterThan(decimal minPrice)
        {
            var cars = _carsRepository.GetAll();
            var list = new List<Car>();

            foreach(var car in cars)
            {
                if(car.ListPrice > minPrice)
                    list.Add(car);
            }

            return list;
        }


        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var list = new List<string>();

            foreach (var car in cars)
            {
                if (!list.Contains(car.Color))
                    list.Add(car.Color);
            }

            return list;
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            decimal ret = decimal.MaxValue;

            foreach (var car in cars)
            {
                if (car.ListPrice < ret)
                    ret = car.ListPrice;
            }

            return ret;
        }
    }*/

