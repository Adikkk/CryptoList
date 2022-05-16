using System;

namespace List.Features.Projects.Models
{
    public record Edit(
        Guid Id
    )
    {
        public Project project { get; set; }
    }
}
