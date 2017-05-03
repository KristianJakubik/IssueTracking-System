using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Queries
{
    public class PersonListQueries : AppQuery<PersonDTO>
    {
        public PersonListQueries(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        protected override IQueryable<PersonDTO> GetQueryable()
        {
            IQueryable<Person> query = Context.Persons;
            return query.Project().To<PersonDTO>();
        }
    }
}
