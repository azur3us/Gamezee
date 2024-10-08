﻿using Gamezee.Domain.Abstraction.Dtos;

namespace Gamezee.Domain.Abstraction.Services.Base
{
    public interface ICRUDService<TKey, TCreateDto, TUpdateDTO, TReadDTO>
        where TCreateDto : ICreateDTO
        where TUpdateDTO : IUpdateDTO
        where TReadDTO : IReadDTO
    {
        Task<TKey> CreateAsync(TCreateDto dto);
        Task UpdateAsync(TKey id,TUpdateDTO dto);
        Task DeleteAsync(TKey id);

        Task<List<TReadDTO>> ReadAsync();
        Task<TReadDTO> ReadAsync(TKey id);

    }
}
