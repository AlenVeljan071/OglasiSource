using AutoMapper;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Core.Responses.Image;
using OglasiSource.Core.Responses.RatingReview;


namespace OglasiSource.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<SignAccountCommand, ApplicationUser>()
                .ForMember(x => x.Avatar, o => o.MapFrom(x => (x.Avatar != null) ? Convert.FromBase64String(x.Avatar!) : null));
            CreateMap<EditAccountCommand, ApplicationUser>()
                .ForMember(x => x.Avatar, o => o.MapFrom(x => (x.Avatar != null) ? Convert.FromBase64String(x.Avatar!) : null));
            CreateMap<ApplicationUser, ApplicationUserResponse>()
                 .ForMember(x => x.Avatar, o => o.MapFrom(x => (x.Avatar != null) ? Convert.ToBase64String(x.Avatar!) : null));

            #endregion

            #region Advertisement

            CreateMap<CreateAdvertisementCommand, Advertisement>();
            CreateMap<UpdateAdvertisementCommand, Advertisement>();
            CreateMap<UpdateAdvertisementPriceCommand, Advertisement>();

            CreateMap<Advertisement, AdvertisementResponse>()
            .ForMember(x => x.Shifter, o => o.MapFrom(x => x.Shifter != null ? DictionaryExtensions.GetValues(Core.Constants.Constants.Shifters).First(d => d.Id == x.Shifter.Value) : null))
            .ForMember(x => x.Gear, o => o.MapFrom(x => x.Gear != null ? DictionaryExtensions.GetValues(Core.Constants.Constants.Gears).First(d => d.Id == x.Gear.Value) : null))
            .ForMember(x => x.Emission, o => o.MapFrom(x => x.Emission != null ? DictionaryExtensions.GetValues(Core.Constants.Constants.Emissions).First(d => d.Id == x.Emission.Value) : null))
            .ForMember(x => x.Seat, o => o.MapFrom(x => x.Seat != null ? DictionaryExtensions.GetValues(Core.Constants.Constants.Seats).First(d => d.Id == x.Seat.Value) : null))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color != null ? DictionaryExtensions.GetValues(Core.Constants.Constants.Colors).First(d => d.Id == x.Color.Value) : null))
            .ForMember(x => x.Fuel, o => o.MapFrom(x => x.Fuel != null ? EnumExtensions.GetValues<Fuel>().First(s => s.Id == (int)x.Fuel) : null))
            .ForMember(x => x.Drive, o => o.MapFrom(x => x.Drive != null ? EnumExtensions.GetValues<Drive>().First(s => s.Id == (int)x.Drive) : null))
            .ForMember(x => x.ParkingSensors, o => o.MapFrom(x => x.ParkingSensors != null ? EnumExtensions.GetValues<ParkingSensors>().First(s => s.Id == (int)x.ParkingSensors) : null))
            .ForMember(x => x.Images, o => o.MapFrom(x => x.SavedImages.Count != 0 ? x.SavedImages : null)); 

            CreateMap<Advertisement, AdvertisementMinResponse>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.VehicleBrand!.Name != null ? x.VehicleBrand.Name  + " " + x.VehicleModel!.Name: null))
                .ForMember(x => x.Image, o => o.MapFrom(x => x.SavedImages.Count != 0 ? x.SavedImages.First(): null));

            CreateMap<SavedImage, ImageResponse>();
            #endregion

            #region Rating and Review

            CreateMap<CreateReviewCommand, Review>();
            CreateMap<UpdateReviewCommand, Review>();
            CreateMap<Review, ReviewResponse>()
                .ForPath(x => x.User.Id, o => o.MapFrom(x => x.ApplicationUser.Id))
                .ForPath(x => x.User.Avatar, o => o.MapFrom(src => (src.ApplicationUser.Avatar != null) ? Convert.ToBase64String(src.ApplicationUser.Avatar!) : null));

            CreateMap<CreateRatingCommand, Rating>();
            CreateMap<Rating, RatingResponse>()
               .ForPath(x => x.ApplicationUser.Id, o => o.MapFrom(x => x.ApplicationUser.Id))
               .ForPath(x => x.ApplicationUser.Avatar, o => o.MapFrom(src => (src.ApplicationUser.Avatar != null) ? Convert.ToBase64String(src.ApplicationUser.Avatar!) : null));


            #endregion


        }

    }
}
