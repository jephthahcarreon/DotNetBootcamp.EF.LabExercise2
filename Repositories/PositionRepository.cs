using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IRepository<Position>
    {
        public PositionRepository(RecruitmentContext context) : base(context)
        {
        }
    }

    //public interface IPositionRepository : IRepository<Position>
    //{
    //    public Position GetEmployeePosition(Employee employee);
    //}
    //public class PositionRepository : GenericRepository<Position>, IPositionRepository
    //{
    //    public PositionRepository(RecruitmentContext context) : base(context)
    //    {
    //    }

    //    public Position GetEmployeePosition(Employee employee)
    //    {
    //        List<Employee> searchedEmployee = new List<Employee> { employee };
    //        var employeePosition = employee.Join();
    //    }
    //}
}
