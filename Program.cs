using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using RecruitmentSolution.Repositories;
using RecruitmentSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using RecruitmentSolution.Helpers;

namespace RecruitmentSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
                var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

                string userEmployeeCodeInput = UserInputValidator.ValidateEmployeeCodeInput();

                using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
                {
                    try
                    {
                        EmployeeRepository employeeRepository = new EmployeeRepository(context);
                        var searchedEmployee = employeeRepository.FindByCode(userEmployeeCodeInput);

                        PositionRepository positionRepository = new PositionRepository(context);
                        var employeePosition = positionRepository.FindByCode(searchedEmployee.CCurrentPosition);

                        AnnualSalaryRepository annualSalaryRepository = new AnnualSalaryRepository(context);
                        IEnumerable<AnnualSalary> annualSalaryList = annualSalaryRepository.FindAllYearByCode(searchedEmployee);

                        MonthlySalaryRepository monthlySalaryRepository = new MonthlySalaryRepository(context);
                        IEnumerable<MonthlySalary> monthlySalaryList = monthlySalaryRepository.FindAllMonthByCode(searchedEmployee);

                        EmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository(context);
                        List<EmployeeSkill> employeeSkill = employeeSkillRepository.GetEmployeeSkillCode(searchedEmployee).ToList();

                        SkillRepository skillRepository = new SkillRepository(context);
                        List<Skill> skillList = skillRepository.FindAll().ToList();

                        EmployeeDetailsRenderer.RenderEmployeeDetails(searchedEmployee, employeePosition, annualSalaryList, monthlySalaryList, employeeSkill, skillList);
                    }    
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    UserInputValidator.PromptContinueApplication();
                }
            }
        }
    }
}
