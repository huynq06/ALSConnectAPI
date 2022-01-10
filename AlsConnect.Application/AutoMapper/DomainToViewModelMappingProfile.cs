using AlsConnect.Application.ViewModels.Notification;
using AlsConnect.Application.ViewModels.Products;
using AlsConnect.Application.ViewModels.System;
using AlsConnect.Data.EF.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
        }
    }
}
