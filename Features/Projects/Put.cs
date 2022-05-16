using FluentValidation;
using GenerateMediator;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using List.Features.Account.Models;
using List.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using List.Features.Projects.Models;
using System;

namespace List.Features.Projects
{
    [GenerateMediator]
    public static partial class Put
    {
        public sealed partial record Command(
            Guid Id,
            string UserId,
            string Name,
            string Link,
            string Description,
            string Category,
            string ISOCode,
            string PictureUri,
            bool IsPremium
        )
        {
            public static void AddValidation(AbstractValidator<Command> v)
            {
                v.RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("Please enter id");

                v.RuleFor(x => x.UserId)
                   .NotEmpty().WithMessage("Please enter user id");

                v.RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Please enter name");

                v.RuleFor(x => x.Link)
                    .NotEmpty().WithMessage("Please enter Link");

                v.RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Please enter Description");

                v.RuleFor(x => x.Category)
                    .NotEmpty().WithMessage("Please enter Category");

                v.RuleFor(x => x.ISOCode)
                    .NotEmpty().WithMessage("Please enter ISOCode");

                v.RuleFor(x => x.PictureUri)
                    .NotEmpty().WithMessage("Please enter PictureUri");

                v.RuleFor(x => x.IsPremium)
                    .NotEmpty().WithMessage("Please enter IsPremium");
            }
        }

        public record CommandResult (
          bool alreadyExist = false  
        );

        public static async Task<CommandResult> CommandHandler(
            Command command,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context
        )
        {
            /*var user = await userManager.FindByIdAsync(command.Id);
            if(user is not null)
            {
                if (user.Id != command.UserId)
                {
                    return new(true);
                }
            }

            if(command.UserId is not null)
            {
                if(user.Id != command.UserId)
                {
                    return new(true);
                }
            }*/

            var project = await context.Projects
                .Where(q => q.Id == command.Id)
                .FirstOrDefaultAsync();

            var projectEdited = new Command(
                project.Id,
                project.UserId,
                command.Name,
                command.Link,
                command.Description,
                command.Category,
                command.ISOCode,
                command.PictureUri,
                command.IsPremium
            );

            /*project.Name = command.*/

            context.Update(projectEdited);

            await context.SaveChangesAsync();
            
            return new();
        }
    }
}
