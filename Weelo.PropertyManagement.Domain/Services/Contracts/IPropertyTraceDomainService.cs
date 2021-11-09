﻿using Weelo.PropertyManagement.Domain.Base.Contract;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyTraceDomainService : IDomainService
    {
        #region Contract
        RequestResultType RegisterTrace(PropertyTrace trace);
        #endregion
    }
}