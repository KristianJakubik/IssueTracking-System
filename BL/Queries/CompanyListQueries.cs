using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Queries
{
    public class CompanyListQueries : AppQuery<CompanyDTO>
    {
        public CompanyListQueries(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        protected override IQueryable<CompanyDTO> GetQueryable()
        {
            IQueryable<Company> query = Context.Companies;
            return query.Project().To<CompanyDTO>();
        }
    }
}
