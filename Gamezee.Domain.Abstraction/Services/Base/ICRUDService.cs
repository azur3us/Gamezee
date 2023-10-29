using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Domain.Abstraction.Services.Base
{
    public interface ICRUDService<TKey, TCreateDto, TUpdateDTO, TReadDTO>
        where TCreateDto : ICreateDTO
        where TUpdateDTO : IUpdateDTO
        where TReadDTO : IReadDTO
    {
        Task<TKey> CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDTO dto);
        Task DeleteAsync(TKey id);

        Task<List<IReadDTO>> Read();
        Task<IReadDTO> Read(TKey id);

    }
}
