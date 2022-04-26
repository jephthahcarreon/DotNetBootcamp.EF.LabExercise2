using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public interface IAnnualSalaryRepository : IRepository<AnnualSalary>
    {
        public IEnumerable<AnnualSalary> FindAllYearByCode(Employee employee);
    }
    public class AnnualSalaryRepository : GenericRepository<AnnualSalary>, IAnnualSalaryRepository
    {
        public AnnualSalaryRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<AnnualSalary> FindAllYearByCode(Employee employee)
        {
            IEnumerable<AnnualSalary> query = FindAll().Where(a => a.CEmployeeCode == employee.CEmployeeCode).ToList();
            return query;
        }
    }
}
