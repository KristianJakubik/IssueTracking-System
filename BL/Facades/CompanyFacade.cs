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
    public class CompanyFacade : AppFacadeBase
    {
        public CompanyRepository Repository { get; set; }

        public CompanyListQueries CompanyListQuery { get; set; }


        protected IQuery<CompanyDTO> CreateQuery()
        {
            var query = CompanyListQuery;
            return query;
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<CompanyDTO> GetCompaniesByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appCompanies = Repository.GetByIds(ids);
                return Mapper.Map<List<CompanyDTO>>(appCompanies);
            }
        }

        public void CreateCompany(CompanyDTO company)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalComapny = Mapper.Map<Company>(company);
                Repository.Insert(dalComapny);
                uow.Commit();
            }
        }
    }
}
