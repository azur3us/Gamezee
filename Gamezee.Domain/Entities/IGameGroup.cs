﻿using Gamezee.Domain.Entities.Base;

namespace Gamezee.Domain.Entities
{
    public interface IGameGroup : IBaseEntity<string>
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
    }
}
