using Aksan.Automapper;
using Aksan.Automapper.Model;
using Bogus;
using Iksan.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nelibur.ObjectMapper;


Console.WriteLine("Hello, World!");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        
    })
    .Build();

// http://tinymapper.net/


// ATTENTION 
// Entité Person fait parti de Bogus !!!!!!!!!!!!!!!!

// Générons qques données pour notre exemple.
DataGenerator dg = new DataGenerator();
var listePersonnes = dg.GenPersonns(15);

// résultat de la transformation
TinyMapper.Bind<Personn, PersonDto>();
Personn personA = listePersonnes.First<Personn>();
PersonDto personDtoA = TinyMapper.Map<PersonDto>(personA);


// Liste de personnes
TinyMapper.Bind<List<Personn>, List<PersonDto>>();
List<PersonDto> personnesDto = TinyMapper.Map<List<PersonDto>>(listePersonnes);

// Ignore members 
TinyMapper.Bind<Personn, PersonDto>(config =>
{
    config.Ignore(x => x.Fullname);
    config.Ignore(x => x.Age);
    config.Bind(source => source.FirstName, target => target.FirstName);
    config.Bind(source => source.Lastname, target => target.Lastname);
});
List<PersonDto> personnesDtoIgnores = TinyMapper.Map<List<PersonDto>>(listePersonnes);


// ** Transformation inverse
TinyMapper.Bind<PersonDto, Personn>();
var onePersonDto = personnesDto.FirstOrDefault();
onePersonDto.Age = 21;
var onePerson = TinyMapper.Map<Personn>(onePersonDto);



Console.ReadLine();