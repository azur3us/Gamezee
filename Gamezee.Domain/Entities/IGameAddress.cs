namespace Gamezee.Domain.Entities
{
    public interface IGameAddress
    {
        public string? FieldName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
