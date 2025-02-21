using System.Text;

namespace MotoApp.Data.Entities;

//ta encja jest wykorzystywane do SQLServera
public class Car : EntityBase
{
    public int Year { get; set; }
    public string Manufacturer { get; set; }
    public string Name { get; set; }
    public double Displacement { get; set; }
    public int Cylinders { get; set; }
    public int City { get; set; }
    public int Highway { get; set; }
    public int Combined { get; set; }

}

/* ta encja była wykorzystywana z Entiny In Memory
public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }

    // Calculated Properties
    public int? NameLength { get; set; }
    public decimal? TotalSales { get; set; }

    #region ToString Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);

        sb.AppendLine($"{Name} ID: {Id}");
        sb.AppendLine($"    Color: {Color}  Type: {Type ?? "n/a"}");
        sb.AppendLine($"    Cost:  {StandardCost:c}   Price: {ListPrice:c}");
        if (NameLength.HasValue)
        {
            sb.AppendLine($"    Name Length: {NameLength}");
        }
        if (TotalSales.HasValue)
        {
            sb.AppendLine($"    Total Sales: {TotalSales:c}");
        }
        return sb.ToString();
    }
    #endregion
}
*/


//public class Car
//{
//    public string Name { get; set; }
//    public string Color { get; set; }
//    public decimal StandardCost { get; set; }
//    public decimal ListPrice { get; set; }
//    public string Type { get; set; }

//    // Calculated Properties
//    public int? NameLength { get; set }
//    public decimal? TotalSales { get; set }
//}
