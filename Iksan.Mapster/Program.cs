using Aksan.Automapper.Model;
using Bogus;
using Iksan.Mapster.Configs;
using Iksan.Shared;
using Mapster;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

Console.WriteLine("Hello, World!");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMapster();
        services.RegisterMapsterConfiguration();
        
    })
    .Build();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());



/* SANS Di (début)*/
// Générons qques données pour notre exemple.
DataGenerator dg = new DataGenerator();
var listePersonnes = dg.GenPersonns(15);

// résultat de la transformation
Personn personA = listePersonnes.First<Personn>();
PersonDto personDtoA = personA.Adapt<PersonDto>();
/* SANS Di (fin)*/


/* AVEC Di (début)*/
PersonDto personnDtoB = host.Services.GetService<IMapper>()?.Map<PersonDto>(personA);
PersonDto personnDtoC = personA.MapToDto();
/* AVEC Di (fin)*/


Console.ReadLine();