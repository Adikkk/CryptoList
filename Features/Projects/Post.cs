using FluentValidation;
using GenerateMediator;
using List.Features.Projects.Models;
using List.Infrastructure.Data;
using System.Threading.Tasks;

namespace List.Features.Projects
{
    [GenerateMediator]
    public static partial class Post
    {
        public sealed partial record Command(
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
            }
        }

        public static async Task CommandHandler(
            Command command,
            ApplicationDbContext context
        )
        {
            var project = new Project(
                command.UserId,
                command.Name,
                command.Link,
                command.Description,
                command.Category,
                command.ISOCode,
                command.PictureUri,
                command.IsPremium
            );

            context.Add(project);

            await context.SaveChangesAsync();
        }
    }
}
