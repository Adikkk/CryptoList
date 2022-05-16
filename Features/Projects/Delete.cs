using FluentValidation;
using GenerateMediator;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using List.Features.Account.Models;
using List.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace List.Features.Projects
{
    [GenerateMediator]
    public static partial class Delete
    {
        public sealed partial record Command
        (
            string ProjectId
        )
        {
            public static void AddValidation(AbstractValidator<Command> v)
            {
                v.RuleFor(x => x.ProjectId)
                    .NotEmpty().WithMessage("Please enter project id");
            }
        }

        public static async Task CommandHandler(
            Command command,
            ApplicationDbContext context
        )
        {
            var project = await context.Projects.FindAsync(Guid.Parse(command.ProjectId));

            context.Remove(project);

            await context.SaveChangesAsync();
        }
    }
}
