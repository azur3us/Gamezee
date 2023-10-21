using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Entities
{
    public interface IAppUser : IEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool HasBenefitCard { get; set; }
    }
}
