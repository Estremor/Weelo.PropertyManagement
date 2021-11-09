﻿using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class PropertyTraceDomainService : DomainService, IPropertyTraceDomainService
    {
        #region Fields
        private readonly IRepository<PropertyTrace> _repository;
        private readonly IRepository<Property> _propertyRepo;
        #endregion

        #region C'tor
        public PropertyTraceDomainService(IRepository<PropertyTrace> repository, IRepository<Property> propertyRepo)
        {
            _repository = repository;
            _propertyRepo = propertyRepo;
        }
        #endregion

        #region Method
        public RequestResultType RegisterTrace(PropertyTrace trace)
        {
            if (_propertyRepo.Entity.Find(trace.IdProperty) != null)
            {
                if (!string.IsNullOrWhiteSpace(trace.Name))
                {
                    _repository.Insert(trace);
                    return RequestResultType.SuccessResult;
                }
            }
            return RequestResultType.ErrorResul;
        }
        #endregion
    }
}
