﻿using Gamezee.Domain.Entities;
using Gamezee.Domain.Repository.Base;

namespace Gamezee.Domain.Repository
{
    public interface IGameRepository : IBaseRepository<IGame, string>
    {
    }
}
