using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Queries
{
    public class EmployeeListQueries : AppQuery<EmployeeDTO>
    {
        public EmployeeListQueries(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        protected override IQueryable<EmployeeDTO> GetQueryable()
        {
            IQueryable<Employee> query = Context.Employees;
            return query.Project().To<EmployeeDTO>();
        }
    }
}

