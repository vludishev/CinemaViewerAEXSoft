using AutoMapper;
using CV.App.Shared.Models;
using CV.Infrastructure.Entities;
using Screenshot = CV.Infrastructure.Entities.Screenshot;

namespace CV.App.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Screenshots.FirstOrDefault(s => s.IsPoster)!.ImageUrl))
            .ForMember(dest => dest.Screenshots, opt => opt.MapFrom(src => src.Screenshots))
            .ForMember(dest => dest.FilmGenres, opt => opt.MapFrom(src => src.FilmGenres))
            .ForMember(dest => dest.FilmActors, opt => opt.MapFrom(src => src.FilmActors));

            CreateMap<Screenshot, ScreenshotDto>();

            CreateMap<FilmGenre, FilmGenreDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<Genre, GenreDto>();

            CreateMap<FilmActor, FilmActorDto>()
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor));

            CreateMap<Actor, ActorDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault()!.ImageUrl))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));

            CreateMap<Photo, PhotoDto>();
        }
    }
}
