using GenerateMediator;
using List.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List.Features.Projects
{
    [GenerateMediator]
    public static partial class Details
    {
        public sealed partial record Query(string Id);

        public record ProjectModel(
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

        public static async Task<ProjectModel> QueryHandler(
            Query query,
            ApplicationDbContext context
        )
        {
            var project = await context.Projects
                .Where(q => q.Id.ToString() == query.Id)
                .Select(q => new ProjectModel(
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
                .SingleOrDefaultAsync();

            return project;
        }
    }
}
