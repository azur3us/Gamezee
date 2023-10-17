using Gamezee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gamezee.Infrastructure.Models
{
    [Owned]
    internal record GameAddress : IGameAddress
    {
        [MaxLength(128)]
        public string? FieldName { get; set; }
        [MaxLength(150)]
        public required string Street { get; set; }
        [MaxLength(10)]
        public required string StreetNumber { get; set; }
        [MaxLength(150)]
        public required string City { get; set; }
        [MaxLength(6)]
        public  required string PostalCode { get; set; }
    }
}
