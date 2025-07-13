using Aksan.Automapper.Model;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iksan.Mapster
{
    public class JobWithDi
    {
        public JobWithDi (IMapper mapper)
        {
            var sourceObject = mapper.Adapt<PersonDto>();
        }

    }
}
