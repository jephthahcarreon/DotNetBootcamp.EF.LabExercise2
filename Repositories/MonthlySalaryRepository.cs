using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public interface IMonthlySalaryRepository : IRepository<MonthlySalary>
    {
        public IEnumerable<MonthlySalary> FindAllMonthByCode(Employee employee);
    }
    public class MonthlySalaryRepository : GenericRepository<MonthlySalary>, IMonthlySalaryRepository
    {
        public MonthlySalaryRepository(RecruitmentContext context) : base(context)
        {
        }

        public IEnumerable<MonthlySalary> FindAllMonthByCode(Employee employee)
        {
            IEnumerable<MonthlySalary> query = FindAll().Where(a => a.CEmployeeCode == employee.CEmployeeCode).ToList();
            return query;
        }
    }
}
