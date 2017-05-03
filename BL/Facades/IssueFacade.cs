using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;
using System;

namespace BL.Facades
{
    public class IssueFacade : AppFacadeBase
    {
        public IssueRepository Repository { get; set; }
        public ProjectRepository ProjectRepository { get; set; }
        public EmployeeRepository EmployeeRepository { get; set; }
        public IssueListQueries IssueListQuery { get; set; }

        protected IQuery<IssueDTO> CreateQuery(IssueFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter is null");
            }

            var query = IssueListQuery;
            query.Filter = filter;
            return query;
        }

        protected IQuery<IssueDTO> CreateQuery()
        {
            var query = IssueListQuery;
            return query;
        }

        public List<IssueDTO> GetAllIssues()
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssuesByIds(int[] ids)
        {
            using (UnitOfWorkProvider.Create())
            {
                var appIssues = Repository.GetByIds(ids);
                return Mapper.Map<List<IssueDTO>>(appIssues);
}
        }

        public void CreateIssue(IssueDTO issue, int selectedProjectId, int selectedEmployeeId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalIssue = Mapper.Map<Issue>(issue);
                if (selectedProjectId > 0 && selectedEmployeeId > 0)
                {
                    dalIssue.Project = ProjectRepository.GetById(selectedProjectId);
                    dalIssue.Employee = EmployeeRepository.GetById(selectedEmployeeId);
                    Repository.Insert(dalIssue);
                    uow.Commit();
                }
            }
        }

        public List<IssueDTO> GetIssuesByType(IssueType type)
        {
            return CreateQuery(new IssueFilter { Type = type }).Execute().ToList();
        }

        public List<IssueDTO> GetIssuesByState(State state)
        {
            return CreateQuery(new IssueFilter { State = state }).Execute().ToList();
        }

        public List<IssueDTO> GetIssuesByProject(int projectId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter {ProjectId = projectId}).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssuesByEmployee(int employeeId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter {EmployeeId = employeeId}).Execute().ToList();
            }
        }

        public int GetCountOfIssuesByState(State state)
        {
            return GetIssuesByState(state).Count;
        }

        public int GetCountOfIssuesByType(IssueType type)
        {
            return GetIssuesByType(type).Count;
        }

        public int GetCountOfIssuesByProject(int projectId)
        {
            return GetIssuesByProject(projectId).Count;
        }

        public void DeleteIssue(int id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                Repository.Delete(id);
                uow.Commit();
            }
        }
        public void UpdateIssue(IssueDTO issue, int employeeId = 0)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appIssue = Repository.GetById(issue.Id);
                Mapper.Map(issue, appIssue);
                appIssue.Project = ProjectRepository.GetById(appIssue.ProjectId);

                if (employeeId > 0)
                {
                    appIssue.EmployeeId = employeeId;
                    appIssue.Employee = EmployeeRepository.GetById(employeeId);
                }
                Repository.Update(appIssue);
                uow.Commit();
            }
        }
    }
}