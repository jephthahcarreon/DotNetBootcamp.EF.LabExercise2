using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IRepository<Employee>
    { 
        public EmployeeRepository(RecruitmentContext context) : base(context)
        {
        }
    }
}
