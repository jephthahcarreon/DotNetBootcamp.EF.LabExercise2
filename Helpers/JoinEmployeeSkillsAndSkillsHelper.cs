using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Helpers
{
    public class JoinEmployeeSkillsAndSkillsHelper
    {
        public static void JoinEmployeeSkillsAndSkills(IEnumerable<EmployeeSkill> employeeSkill, IEnumerable<Skill> skillList)
        {
            var query = employeeSkill.Join(skillList,
                                                   employee => employee.CSkillCode,
                                                   skill => skill.CSkillCode,
                                                   (employee, skill) =>
                                                    new
                                                    {
                                                        EmployeeCode = employee.CEmployeeCode,
                                                        EmployeeSkill = skill.VSkill
                                                    });
            Console.WriteLine($"Employee Skill: ");
            for (int i = 0; i < query.Count(); i++)
            {
                Console.WriteLine($"\t\t{i + 1}. {query.ElementAt(i).EmployeeSkill}");
            }
        }
    }
}
