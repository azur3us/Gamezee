using Gamezee.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Gamezee.Infrastructure.Database.Models.Base
{
    internal abstract record BaseIntEntity : BaseEntity<int>
    {
        
    }
    internal abstract record BaseStringEntity : BaseEntity<string> 
    {
        public BaseStringEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    [PrimaryKey(nameof(Id))]
    internal abstract record BaseEntity<TKey>
    {
        public required TKey Id { get; set; }
    }
}
