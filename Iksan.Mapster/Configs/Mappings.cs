using Aksan.Automapper.Model;
using Bogus;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iksan.Mapster.Configs
{
    public static class MapsterExtensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Personn, PersonDto>
                .NewConfig()
                .Map(dest => dest.Fullname, src => $"{src.FirstName} {src.Lastname}");
        }

        public static PersonDto MapToDto(this Personn personn)
        {
            var personShortInfoDto = personn.Adapt<PersonDto>();
            return personShortInfoDto;
        }


    }

}
