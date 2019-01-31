using AutoMapper;
using MotoSell.Controllers.Resources;
using MotoSell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSell.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>() 
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            //API Resrouce to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(x => x.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(x => x.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(x => x.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    //remove features
                   
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                    //add new feature
                  
                   var addedFeatures= vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id});
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);

                });
                

        }
    }
}    
