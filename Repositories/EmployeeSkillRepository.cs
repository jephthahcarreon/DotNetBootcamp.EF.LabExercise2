using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public interface IEmployeeSkillRepository : IRepository<EmployeeSkill>
    {
        public IEnumerable<EmployeeSkill> GetEmployeeSkillCode(Employee employee);
    }
    public class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<EmployeeSkill> GetEmployeeSkillCode(Employee employee)
        {
            IEnumerable<EmployeeSkill> entity = this.Context.EmployeeSkills.Where(e => e.CEmployeeCode == employee.CEmployeeCode).ToList();
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Entity with {employee.CEmployeeCode} doesn't exist.");
        }
    }
}
