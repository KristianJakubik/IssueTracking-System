using AutoMapper;
using BL.Queries;
using BL.Repositories;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;
using System;
using Riganti.Utils.Infrastructure.Core;

namespace BL.Facades
{
    public class ProjectFacade : AppFacadeBase
    {
        public ProjectRepository Repository { get; set; }
        public PersonRepository PersonRepository { get; set; }
        public CompanyRepository CompanyRepository { get; set; }
        public ProjectListQueries ProjectListQuery { get; set; }
        public IssueRepository IssueRepository { get; set; }

        protected IQuery<ProjectDTO> CreateQuery(ProjectFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter is null");
            }

            var query = ProjectListQuery;
            query.Filter = filter;

            return query;
        }

        protected IQuery<ProjectDTO> CreateQuery()
        {
            var query = ProjectListQuery;
            return query;
        }

        public List<ProjectDTO> GetAllProjects()
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<ProjectDTO> GetProjectsByIds(int[] ids)
        {
            using (UnitOfWorkProvider.Create())
            {
                var appProjects = Repository.GetByIds(ids);
                return Mapper.Map<List<ProjectDTO>>(appProjects);
            }
        }

        public void CreateProject(ProjectDTO project, int selectedCustomerId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalProject = Mapper.Map<Project>(project);
                if (selectedCustomerId > 0)
                {
                    if (PersonRepository.GetById(selectedCustomerId) != null)
                    {
                        dalProject.Customer = PersonRepository.GetById(selectedCustomerId);
                    }
                    else
                    {
                        dalProject.Customer = CompanyRepository.GetById(selectedCustomerId);
                    }
                    Repository.Insert(dalProject);
                    uow.Commit();
                }
            }
        }

        public List<ProjectDTO> GetProjectsByCustomer(int customerId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery(new ProjectFilter { CustomerId = customerId }).Execute().ToList();
            }
        }

        public int GetCustomerId(int projectId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return GetProjectsByIds(new[] { projectId }).First().Customer.Id;
            }
        }
    }
}

