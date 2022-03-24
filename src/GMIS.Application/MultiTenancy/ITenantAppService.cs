﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GMIS.MultiTenancy.Dto;

namespace GMIS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

