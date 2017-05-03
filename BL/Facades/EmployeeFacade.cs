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
    public class EmployeeFacade : AppFacadeBase
    {
        public EmployeeRepository Repository { get; set; }
        public IssueRepository IssueRepository { get; set; }

        public EmployeeListQueries EmployeeListQuery { get; set; }


        protected IQuery<EmployeeDTO> CreateQuery()
        {
            var query = EmployeeListQuery;
            return query;
        }

        public List<EmployeeDTO> GetAllEmployee()
        {
            using (UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<EmployeeDTO> GetEmployeesByIds(int[] ids)
        {
            using (UnitOfWorkProvider.Create())
            {
                var appEmployees = Repository.GetByIds(ids);
                return Mapper.Map<List<EmployeeDTO>>(appEmployees);
            }
        }

        public void CreateEmployee(EmployeeDTO employee)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalEmployee = Mapper.Map<Employee>(employee);
                Repository.Insert(dalEmployee);
                uow.Commit();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var facade = new IssueFacade()
                {
                  UnitOfWorkProvider  = UnitOfWorkProvider,
                  IssueListQuery = new IssueListQueries(UnitOfWorkProvider)
                };
                var issues = facade
                .GetIssuesByEmployee(id);
                issues.ForEach(issue =>
                {
                    issue.Employee = null;
                    IssueRepository.Update(Mapper.Map<Issue>(issue));
                });
                Repository.Delete(id);
                uow.Commit();
            }
        }
    }
}