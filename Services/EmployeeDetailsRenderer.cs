using RecruitmentSolution.Helpers;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Services
{
    public static class EmployeeDetailsRenderer
    {
        public static void RenderEmployeeDetails(Employee searchedEmployee, Position employeePosition, IEnumerable<AnnualSalary> annualSalaryList, IEnumerable<MonthlySalary> monthlySalaryList, IEnumerable<EmployeeSkill> employeeSkill, IEnumerable<Skill> skillList)
        {
            Console.WriteLine($"Employee Code:\t{searchedEmployee.CEmployeeCode}");
            Console.WriteLine($"First Name:\t{searchedEmployee.VFirstName}");
            Console.WriteLine($"Last Name:\t{searchedEmployee.VLastName}");
            Console.WriteLine($"Position:\t{employeePosition.VDescription}");
            Console.WriteLine($"Annual Salary: ");
            foreach (var annualSalary in annualSalaryList)
            {
                Console.WriteLine($"\t\tYear: {annualSalary.SiYear}, Salary: {annualSalary.MAnnualSalary}");
            }
            Console.WriteLine($"Monthly Salary: ");
            foreach (var monthlySalary in monthlySalaryList)
            {
                Console.WriteLine($"\t\tSalary: {monthlySalary.MMonthlySalary}, Pay Date: {monthlySalary.DPayDate}, Referral Bonus: {monthlySalary.MReferralBonus}");
            }

            JoinEmployeeSkillsAndSkillsHelper.JoinEmployeeSkillsAndSkills(employeeSkill, skillList);
        }
    }
}
