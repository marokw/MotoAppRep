using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders.Extensions;

static public class CarsExtensions
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
    {
        return query.Where(x => x.Color == color);
    }
}

