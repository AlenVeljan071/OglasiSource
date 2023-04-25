using FluentValidation;
using MediatR;


namespace OglasiSource.Api.Cqrs.Commands.Image
{
    public class UploadImageCommand : IRequest<Core.Classes.Image>
    {
        public int AdvertisementId { get; set; }
        public string Image { get; set; }
      

        public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
        {
            public UploadImageCommandValidator()
            {
            }
        }
  
    }
}
