using FluentValidation;
using Microsoft.Extensions.Options;
using OglasiSource.Core.Config;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;

namespace OglasiSource.Api.Helpers
{
   
    public class DateTimeValidator : AbstractValidator<DateTime>
    {
        public DateTimeValidator()
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop).NotEmpty()
                .Must(date => date != default(DateTime))
                .WithMessage("{PropertyName} is required");
        }
    }

    public class AddressEntityValidator : AbstractValidator<AddressEntity>
    {
        public AddressEntityValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address must not be empty.").Length(0, 100).WithMessage("Address should have 100 chars at most.");
            RuleFor(x => x.City).Length(0, 50).WithMessage("City should have 50 chars at most.");
            RuleFor(x => x.County).Length(0, 50).WithMessage("County should have 50 chars at most.");
            RuleFor(x => x.Country).Length(0, 45).WithMessage("Country should have 45 chars at most.");
            RuleFor(x => x.ZipCode).Length(0, 20).WithMessage("Zip code  should have 20 chars at most.");

        }
    }

    public class EmailAddressValidator : AbstractValidator<string>
    {
        public EmailAddressValidator()
        {
            RuleFor(x => x).NotEmpty().Length(0, 100).WithMessage("Email should have 100 chars at most.").EmailAddress().WithMessage("Email Not valid format.");
        }
    }
    public class NameValidator : AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(x => x).NotEmpty().Length(0, 100).WithMessage("Name should have 100 chars at most.");
        }

    }
    public class FirstNameValidator : AbstractValidator<string>
    {
        public FirstNameValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("First name must not be empty.").Length(0, 100).WithMessage("First name should have 100 chars at most.");
        }

    }
    public class LastNameValidator : AbstractValidator<string>
    {
        public LastNameValidator()
        {
            RuleFor(x => x).NotEmpty().Length(0, 100).WithMessage("Last name should have 100 chars at most.");
        }

    }

    
    public class PhoneValidator : AbstractValidator<string>
    {
        public PhoneValidator()
        {
            RuleFor(x => x).Length(0, 100).WithMessage("Phone should have 100 chars at most.");
        }
    }
  

    public class ColorValidator : AbstractValidator<string>
    {
        public ColorValidator()
        {
            RuleFor(x => x).Length(0, 50).WithMessage("Color should have 50 chars at most.");
        }
    }

   
    public class AccountValidator : AbstractValidator<string?>
    {
        public AccountValidator()
        {
            RuleFor(x => x).Length(0, 30).WithMessage("Account should have 30 chars at most.");
        }
    }

    public class EnumValidator<T> : AbstractValidator<T>
    {
        public EnumValidator()
        {
            RuleFor(x => x)
                .Must(x => EnumExtensions.GetValues<T>().Any(t => t.Name == x!.ToString()))
                .WithMessage("Value for " + typeof(T).Name + " is invalid.");
        }
    }

    public class RegexValidator : AbstractValidator<string?>
    {
        public RegexValidator()
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop)
                .Matches(@"^\s*\d+(?:-\d+)?\s*(?:,\s*\d+(?:-\d+)?\s*)*$")
                .WithMessage("Wrong insert!");
        }
    }

    public class DictionaryValidator<T> : AbstractValidator<int>
    {
        public DictionaryValidator(string propertyName, Dictionary<int, string> dictionary)
        {
            RuleFor(x => x)
                .Must(x => DictionaryExtensions.GetValues(dictionary).Any(d => d.Id == x))
                .WithMessage("Value for " + propertyName + " is invalid.");
        }
    }
    public class DictionaryNullValidator<T> : AbstractValidator<int?>
    {
        public DictionaryNullValidator(string propertyName, Dictionary<int,string> dictionary)
        {
            When(x => x != null, () =>
            {
                RuleFor(x => x!.Value)
                    .Must(x => DictionaryExtensions.GetValues(dictionary).Any(d => d.Id == x))
                    .WithMessage("Value for " + propertyName + " is invalid.");
            });
        }
    }

    public class UploadImageValidator : AbstractValidator<List<IFormFile>>
    {
        public UploadImageValidator()
        {
            RuleFor(x => x)
           .Must(files => files.All(file =>
               file.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
               file.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)))
           .WithMessage("Bad file extension");
        }
    }

}
