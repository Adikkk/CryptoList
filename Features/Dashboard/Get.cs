using GenerateMediator;
using List.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List.Features.Dashboard
{
    [GenerateMediator]
    public static partial class Get
    {
        public sealed partial record Query(string UserId);

        public record Project(
            Guid Id,
            string UserId,
            string Name,
            string Link,
            string Description,
            string Category,
            string ISOCode,
            string PictureUri,
            bool IsPremium
         );

        public static async Task<IReadOnlyList<Project>> QueryHandler(
            Query query,
            ApplicationDbContext context
        )
        {
            var totalSitesCount = await context.Projects
                .Where(q => q.UserId == query.UserId)
                .CountAsync();

            var projects = await context.Projects
                .Select(q => new Project(
                    q.Id,
                    q.UserId,
                    q.Name,
                    q.Link,
                    q.Description,
                    q.Category,
                    q.ISOCode,
                    q.PictureUri,
                    q.IsPremium
                    ))
                .ToListAsync();

            return projects;
        }
    }
}
