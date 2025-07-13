using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aksan.Automapper.Model;

namespace Iksan.Shared
{
    public class DataGenerator
    {
        Faker<Personn> personFake;

        public DataGenerator()
        {
            Randomizer.Seed = new Random(1105);


        }


        public Personn GenPerson()
        {
            personFake = new Faker<Personn>()
                .RuleFor(property: p => p.FirstName, setter: f => f.Name.FirstName())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.Lastname, f => f.Name.LastName())
                .RuleFor(p => p.Email, (f, u) => f.Internet.Email(u.FirstName, u.Lastname))
    ;
            return personFake.Generate(1).FirstOrDefault();
        }

        public List<Personn> GenPersonns(int nb)
        {
            personFake = new Faker<Personn>()
                .RuleFor(property: p => p.FirstName, setter: f => f.Name.FirstName())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.Lastname, f => f.Name.LastName())
                .RuleFor(p => p.Email, (f, u) => f.Internet.Email(u.FirstName, u.Lastname))
    ;
            return personFake.Generate(nb);
        }

    }
}
