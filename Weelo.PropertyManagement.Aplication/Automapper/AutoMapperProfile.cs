using AutoMapper;
using System;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Entities;
using static Weelo.PropertyManagement.Aplication.Dtos.PropertyDataDto;

namespace Weelo.PropertyManagement.Aplication.Automapper
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Owner
            CreateMap<Owner, OwnerDto>()
                .ForMember(x => x.Photo, src => src.MapFrom(d => d.Photo == null ? string.Empty : Convert.ToBase64String(d.Photo)));

            CreateMap<OwnerDto, Owner>()
                .ForMember(x => x.Photo, src => src.MapFrom(d => string.IsNullOrWhiteSpace(d.Photo) ? null : Convert.FromBase64String(d.Photo)));
            #endregion

            #region Property
            CreateMap<Property, PropertyDataDto>()
                .ForMember(x => x.OwnerDocument, src => src.Ignore())
                .ForMember(x => x.PropertyImages, src => src.Ignore());

            CreateMap<PropertyDataDto, Property>()
                .ForMember(x => x.IdOwner, src => src.Ignore());

            CreateMap<PropertyReadDto, Property>();
            CreateMap<Property, PropertyReadDto>();

            CreateMap<PropertyTraceDto, Property>();
            CreateMap<PropertyTraceDto, PropertyTrace>().ForMember(x => x.Value, src => src.MapFrom(d => d.Value == null || d.Value <= 0 ? d.Price : d.Value));

            #endregion

            #region PropertyImage
            CreateMap<PropertyImage, Image>()
                .ForMember(x => x.File, src => src.MapFrom(d => d.File == null ? string.Empty : Convert.ToBase64String(d.File)));

            CreateMap<Image, PropertyImage>()
                .ForMember(x => x.File, src => src.MapFrom(d => string.IsNullOrWhiteSpace(d.File) ? null : Convert.FromBase64String(d.File)));
            #endregion

            #region Image
            CreateMap<ImageDto, PropertyImage>()
                .ForMember(x => x.File, src => src.MapFrom(d => string.IsNullOrWhiteSpace(d.File) ? null : Convert.FromBase64String(d.File)));

            CreateMap<PropertyImage, ImageDto>()
                .ForMember(x => x.File, src => src.MapFrom(d => d.File == null ? string.Empty : Convert.ToBase64String(d.File)));
            #endregion
        }
    }
}
