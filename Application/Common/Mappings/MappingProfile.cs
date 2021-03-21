using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Domain.Models;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var classes = assembly.GetTypes();
            
            var types = classes
                .Where(t => t.GetInterfaces().Contains(typeof(IMapFrom<Job>))).ToList();
            
            var res = classes
                    .Where(m => m.IsClass && m.GetInterface("IMapFrom") != null).ToList();
            
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}