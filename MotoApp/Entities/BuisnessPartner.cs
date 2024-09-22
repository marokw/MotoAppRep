namespace MotoApp.Entities
{
    public class BuisnessPartner : EntityBase
    {
        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
