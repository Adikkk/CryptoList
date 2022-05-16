using System;

namespace List.Infrastructure.Models
{
    public record BaseEntity
    {
        public Guid Id { get; init; }
    }
}
