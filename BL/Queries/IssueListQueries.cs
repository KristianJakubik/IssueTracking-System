using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Queries
{
    public class IssueListQueries : AppQuery<IssueDTO>
    {
        public IssueFilter Filter { get; set; }
        public IssueListQueries(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        protected override IQueryable<IssueDTO> GetQueryable()
        {
            IQueryable<Issue> query = Context.Issues;
            if (Filter != null)
            {
                if (Filter.State != null)
                {
                    query = Context.Issues.Where(x => x.State == Filter.State);
                }

                if (Filter.ProjectId != null && Filter.ProjectId > 0)
                {
                    query = Context.Issues.Where(x => x.Project.Id == Filter.ProjectId);
                }

                if (Filter.EmployeeId != null && Filter.EmployeeId > 0)
                {
                    query = Context.Issues.Where(x => x.Employee.Id == Filter.EmployeeId);
                }

                if (Filter.Type != null)
                {
                    query = Context.Issues.Where(x => x.Type == Filter.Type);
                }
            }

            return query.Project().To<IssueDTO>();
        }
    }
}

