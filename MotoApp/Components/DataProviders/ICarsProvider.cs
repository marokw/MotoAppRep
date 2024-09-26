using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        //select
        List<string> GetUniqueCarColors();
        decimal GetMinimumPriceOfAllCars();
        List<Car> GetSpecificColumns();
        string AnonymousClass();

        //order by
        List<Car> OrderByName();
        List<Car> OrderByNameDescending();
        List<Car> OrderByColorAndName();
        List<Car> OrderByColorAndNameDesc();

        //where
        List<Car> WhereStartsWith(string prefix);
        List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
        List<Car> WhereColorIs(string color);
        List<Car> WhereCostIsGreaterThan(decimal minPrice);

        //first, last, single
        Car FirstByColor(string color);
        Car? FirstOrDefaultByColor(string color);
        Car FirstOrDefaultByColorWitchDefault(string color);
        Car LastByColor(string color);
        Car SingleById(int id);
        Car? SingleOrDefaultById(int id);

        //Take
        List<Car> TakeCars(int howMany);
        List<Car> TakeCars(Range range);
        List<Car> TakeCarsWhileNameStartsWith(string prefix);

        //Skip
        List<Car> SkipCars(int howMany);
        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        //Distinct
        List<string> DistinctAllColors();
        List<Car> DistinctByColors();

        //Chunk
        List<Car[]> ChunkCars(int size);

    }
}
