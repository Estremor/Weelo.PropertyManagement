﻿using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class PropertyImageDomainService : DomainService, IPropertyImageDomainService
    {
        #region Fields
        private readonly IRepository<PropertyImage> _imageRepo;
        private readonly IRepository<Property> _propertyRepo;
        #endregion

        #region C´tor
        public PropertyImageDomainService(IRepository<PropertyImage> imageRepo, IRepository<Property> propertyRepo)
        {
            _imageRepo = imageRepo;
            _propertyRepo = propertyRepo;
        }
        #endregion
        #region Methods
        public RequestResultType SaveImage(PropertyImage image)
        {
            var propertyResult = _propertyRepo.Entity.Find(image.IdProperty);
            if (propertyResult == null) return RequestResultType.ErrorResul;
            _imageRepo.Insert(image);
            return RequestResultType.SuccessResult;
        } 
        #endregion
    }
}
