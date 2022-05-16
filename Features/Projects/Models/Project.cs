using List.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace List.Features.Projects.Models
{
    public record Project(
            string UserId,
            string Name,
            string Link,
            string Description,
            string Category,
            string ISOCode,
            string PictureUri,
            bool IsPremium
    ) : BaseEntity;
}
