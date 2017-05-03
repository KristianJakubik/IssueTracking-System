using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Queries
{
    public class ProjectListQueries : AppQuery<ProjectDTO>
    {
        public ProjectFilter Filter { get; set; }
        public ProjectListQueries(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        protected override IQueryable<ProjectDTO> GetQueryable()
        {
            IQueryable<Project> query = Context.Projects;
            if (Filter != null)
            {
                if (Filter.CustomerId > 0)
                {
                    query = Context.Projects.Where(x => x.Customer.Id == Filter.CustomerId);
                }
            }
            return query.Project().To<ProjectDTO>();
        }
    }
}

