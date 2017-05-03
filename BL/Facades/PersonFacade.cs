using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;

namespace BL.Facades
{
   public class PersonFacade : AppFacadeBase
    {
        public PersonRepository Repository { get; set; }

        public PersonListQueries PersonListQuery { get; set; }


        protected IQuery<PersonDTO> CreateQuery()
        {
            var query = PersonListQuery;
            return query;
        }

        public List<PersonDTO> GetAllPerson()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<PersonDTO> GetPersonsByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appPersons = Repository.GetByIds(ids);
                return Mapper.Map<List<PersonDTO>>(appPersons);
            }
        }

        public void CreatePerson(PersonDTO person)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalPerson = Mapper.Map<Person>(person);
                Repository.Insert(dalPerson);
                uow.Commit();
            }
        }
    }
}
