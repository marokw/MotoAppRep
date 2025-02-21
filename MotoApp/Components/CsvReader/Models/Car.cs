using System.Drawing;
using System.Text;

namespace MotoApp.Components.CsvReader.Models;

public class Car
{
    public int Year { get; set; }
    public string Manufacturer { get; set; }
    public string Name { get; set; }
    public double Displacement { get; set; }
    public int Cylinders { get; set; }
    public int City { get; set; }
    public int Highway { get; set; }
    public int Combined { get; set; }

    #region
    public override string ToString()
    {
        StringBuilder sb = new(1024);

        sb.AppendLine($"{Name} ");
        sb.AppendLine($"    Manufacturer: {Manufacturer}  Year: {Year}");
        sb.AppendLine($"    Displacement:  {Displacement} ");
        sb.AppendLine($"    Cylinders:  {Cylinders} ");
        sb.AppendLine($"    City:  {City} ");
        sb.AppendLine($"    Highway:  {Highway} ");
        sb.AppendLine($"    Combined:  {Combined} ");

        return sb.ToString();
    }
    #endregion

}
