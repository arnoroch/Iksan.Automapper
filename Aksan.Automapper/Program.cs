using Iksan.Shared;
using Aksan.Automapper.Helpers;
using Aksan.Automapper.Model;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
    })
    .Build();


// Récupérer le service IMapper
IServiceProvider ServiceProvider = host.Services;
var mapper = ServiceProvider!.GetService<IMapper>();

// Générons qques données pour notre exemple.
DataGenerator dg = new DataGenerator();
var listePersonnes = dg.GenPersonns(15);

// résultat de la transformation
var personnesDto = mapper.Map<List<PersonDto>>(listePersonnes);

// ** Transformation inverse
var onePersonDto = personnesDto.FirstOrDefault();
onePersonDto.Age = 21;
var onePerson = mapper.Map<Personn>(onePersonDto);



Console.ReadLine();