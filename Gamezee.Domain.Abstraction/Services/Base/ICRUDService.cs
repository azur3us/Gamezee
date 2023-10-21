using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Domain.Abstraction.Services.Base
{
    public interface ICRUDService<TKey, TCreateDto, TUpdateDTO>
        where TCreateDto : ICreateDTO
        where TUpdateDTO : IUpdateDTO
    {
        Task<TKey> CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDTO dto);
        Task DeleteAsync(TKey id);

        Task<List<T>> Read<T>();
    }
}
