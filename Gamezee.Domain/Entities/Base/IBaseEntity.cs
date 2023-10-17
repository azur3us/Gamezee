namespace Gamezee.Domain.Entities.Base
{
    public interface IBaseEntity
    {

    }

    public interface IBaseEntity<TKey> 
    {
        public TKey Id { get; set; }
    }
}
